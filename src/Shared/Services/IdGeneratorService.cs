using Shared.Models;
using Supabase.Postgrest.Attributes;

namespace Shared.Services;

/// <summary>
/// Servicio para generar IDs públicos con formato especial
/// Implementación del generador de IDs
/// </summary>
public class IdGeneratorService : IIdGeneratorService
{
    private readonly ISupabaseService _supabaseService;

    public IdGeneratorService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<string> GenerateIdPublicoAsync(Guid comercioId, string tableName)
    {
        try
        {
            // Obtener el ID público del comercio (sin guiones, solo los primeros caracteres)
            var comercio = await _supabaseService.Client
                .From<Comercio>()
                .Where(x => x.Id == comercioId)
                .Single();

            string comercioIdStr = comercioId.ToString("N").Substring(0, 12); // Primeros 12 caracteres sin guiones

            // Contar registros existentes en la tabla para este comercio
            int nextNumber = await GetNextSequentialNumberAsync(comercioId, tableName);

            // Formato: "01-abc123def456" (número de 2 dígitos + guión + primeros 12 caracteres del comercio ID)
            return $"{nextNumber:D2}-{comercioIdStr}";
        }
        catch
        {
            // Si hay error, generar un número aleatorio como fallback
            string comercioIdStr = comercioId.ToString("N").Substring(0, 12);
            return $"99-{comercioIdStr}";
        }
    }

    public async Task<string> GenerateIdPublicoComercioAsync()
    {
        try
        {
            // Contar comercios existentes
            var comercios = await _supabaseService.Client
                .From<Comercio>()
                .Get();

            int nextNumber = comercios.Models.Count + 1;

            // Formato: "01", "02", "03", etc.
            return $"{nextNumber:D2}";
        }
        catch
        {
            // Si hay error, retornar "99" como fallback
            return "99";
        }
    }

    private async Task<int> GetNextSequentialNumberAsync(Guid comercioId, string tableName)
    {
        try
        {
            // Contar registros existentes según la tabla
            switch (tableName.ToLower())
            {
                case "usuarios":
                    var usuarios = await _supabaseService.Client
                        .From<Usuario>()
                        .Where(x => x.ComercioId == comercioId)
                        .Get();
                    return usuarios.Models.Count + 1;

                // Agregar más casos según sea necesario (productos, clientes, etc.)
                default:
                    return 1; // Por defecto, empezar en 1
            }
        }
        catch
        {
            return 1; // Si hay error, empezar en 1
        }
    }
}

