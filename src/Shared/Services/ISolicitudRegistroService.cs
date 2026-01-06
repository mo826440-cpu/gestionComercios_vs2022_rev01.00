using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de solicitudes de registro
/// </summary>
public interface ISolicitudRegistroService
{
    /// <summary>
    /// Crear una nueva solicitud de registro
    /// </summary>
    Task<SolicitudRegistro?> CreateAsync(string emailSolicitante);

    /// <summary>
    /// Obtener solicitud por email
    /// </summary>
    Task<SolicitudRegistro?> GetByEmailAsync(string email);

    /// <summary>
    /// Obtener solicitud por código de verificación
    /// </summary>
    Task<SolicitudRegistro?> GetByCodigoAsync(string codigo);

    /// <summary>
    /// Aprobar una solicitud y generar código de verificación
    /// </summary>
    Task<SolicitudRegistro?> AprobarAsync(Guid solicitudId, string aprobadoPor);

    /// <summary>
    /// Rechazar una solicitud
    /// </summary>
    Task<bool> RechazarAsync(Guid solicitudId, string rechazadoPor);

    /// <summary>
    /// Verificar código de verificación
    /// </summary>
    Task<bool> VerificarCodigoAsync(string email, string codigo);

    /// <summary>
    /// Marcar solicitud como verificada
    /// </summary>
    Task<bool> MarcarComoVerificadaAsync(string email);

    /// <summary>
    /// Obtener todas las solicitudes pendientes
    /// </summary>
    Task<List<SolicitudRegistro>> GetPendientesAsync();

    /// <summary>
    /// Generar código de verificación aleatorio (6 dígitos)
    /// </summary>
    string GenerarCodigoVerificacion();
}

