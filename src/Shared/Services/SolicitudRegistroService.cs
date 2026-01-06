using Shared.Models;
using Shared.Services;

namespace Shared.Services;

/// <summary>
/// Servicio para manejar solicitudes de registro
/// </summary>
public class SolicitudRegistroService : ISolicitudRegistroService
{
    private readonly ISupabaseService _supabaseService;

    public SolicitudRegistroService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<SolicitudRegistro?> CreateAsync(string emailSolicitante)
    {
        try
        {
            // Verificar si ya existe una solicitud para este email
            var existente = await GetByEmailAsync(emailSolicitante);
            if (existente != null)
            {
                // Si ya existe y está pendiente o aprobada, retornarla
                if (existente.Estado == "pendiente" || existente.Estado == "aprobada")
                {
                    return existente;
                }
                // Si está rechazada o expirada, crear una nueva
            }

            var solicitud = new SolicitudRegistro
            {
                Id = Guid.NewGuid(),
                EmailSolicitante = emailSolicitante.ToLowerInvariant(),
                Estado = "pendiente",
                FechaSolicitud = DateTime.UtcNow,
                MaxIntentos = 5,
                IntentosVerificacion = 0
            };

            var response = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Insert(solicitud);

            return response?.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al crear solicitud: {ex}");
            return null;
        }
    }

    public async Task<SolicitudRegistro?> GetByEmailAsync(string email)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Where(x => x.EmailSolicitante == email.ToLowerInvariant())
                .Order(x => x.FechaSolicitud, Postgrest.Models.Ordering.Descending)
                .Limit(1)
                .Get();

            return response?.FirstOrDefault();
        }
        catch
        {
            return null;
        }
    }

    public async Task<SolicitudRegistro?> GetByCodigoAsync(string codigo)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Where(x => x.CodigoVerificacion == codigo)
                .Where(x => x.Estado == "aprobada")
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<SolicitudRegistro?> AprobarAsync(Guid solicitudId, string aprobadoPor)
    {
        try
        {
            var solicitud = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Where(x => x.Id == solicitudId)
                .Single();

            if (solicitud == null)
            {
                return null;
            }

            // Generar código de verificación
            var codigo = GenerarCodigoVerificacion();

            // Actualizar solicitud
            solicitud.Estado = "aprobada";
            solicitud.CodigoVerificacion = codigo;
            solicitud.FechaAprobacion = DateTime.UtcNow;
            solicitud.FechaExpiracion = DateTime.UtcNow.AddHours(24); // Expira en 24 horas
            solicitud.AprobadoPor = aprobadoPor;
            solicitud.IntentosVerificacion = 0;

            var response = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Update(solicitud)
                .Match(x => x.Id);

            return response?.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al aprobar solicitud: {ex}");
            return null;
        }
    }

    public async Task<bool> RechazarAsync(Guid solicitudId, string rechazadoPor)
    {
        try
        {
            var solicitud = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Where(x => x.Id == solicitudId)
                .Single();

            if (solicitud == null)
            {
                return false;
            }

            solicitud.Estado = "rechazada";
            solicitud.AprobadoPor = rechazadoPor; // Reutilizamos el campo para guardar quién rechazó

            await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Update(solicitud)
                .Match(x => x.Id);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> VerificarCodigoAsync(string email, string codigo)
    {
        try
        {
            var solicitud = await GetByEmailAsync(email);
            if (solicitud == null)
            {
                return false;
            }

            // Verificar que la solicitud esté aprobada
            if (solicitud.Estado != "aprobada")
            {
                return false;
            }

            // Verificar que no haya expirado
            if (solicitud.FechaExpiracion.HasValue && solicitud.FechaExpiracion.Value < DateTime.UtcNow)
            {
                // Marcar como expirada
                solicitud.Estado = "expirada";
                await _supabaseService.Client
                    .From<SolicitudRegistro>()
                    .Update(solicitud)
                    .Match(x => x.Id);
                return false;
            }

            // Verificar intentos máximos
            if (solicitud.IntentosVerificacion >= solicitud.MaxIntentos)
            {
                return false;
            }

            // Incrementar intentos
            solicitud.IntentosVerificacion++;

            // Verificar código
            if (solicitud.CodigoVerificacion?.Equals(codigo, StringComparison.OrdinalIgnoreCase) == true)
            {
                // Código correcto
                solicitud.Estado = "verificada";
                solicitud.FechaVerificacion = DateTime.UtcNow;
                await _supabaseService.Client
                    .From<SolicitudRegistro>()
                    .Update(solicitud)
                    .Match(x => x.Id);
                return true;
            }
            else
            {
                // Código incorrecto, actualizar intentos
                await _supabaseService.Client
                    .From<SolicitudRegistro>()
                    .Update(solicitud)
                    .Match(x => x.Id);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar código: {ex}");
            return false;
        }
    }

    public async Task<bool> MarcarComoVerificadaAsync(string email)
    {
        try
        {
            var solicitud = await GetByEmailAsync(email);
            if (solicitud == null)
            {
                return false;
            }

            solicitud.Estado = "verificada";
            solicitud.FechaVerificacion = DateTime.UtcNow;

            await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Update(solicitud)
                .Match(x => x.Id);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<SolicitudRegistro>> GetPendientesAsync()
    {
        try
        {
            var response = await _supabaseService.Client
                .From<SolicitudRegistro>()
                .Where(x => x.Estado == "pendiente")
                .Order(x => x.FechaSolicitud, Postgrest.Models.Ordering.Descending)
                .Get();

            return response?.ToList() ?? new List<SolicitudRegistro>();
        }
        catch
        {
            return new List<SolicitudRegistro>();
        }
    }

    public string GenerarCodigoVerificacion()
    {
        // Generar código de 6 dígitos
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }
}

