namespace Shared.Services;

/// <summary>
/// Servicio para generar IDs públicos con formato especial
/// Formato: XX + ID_COMERCIO (ej: "01-abc123-def456")
/// </summary>
public interface IIdGeneratorService
{
    /// <summary>
    /// Genera un ID público para un usuario
    /// Formato: XX (número secuencial) + "-" + ID_COMERCIO (primeros caracteres del Guid)
    /// </summary>
    /// <param name="comercioId">ID del comercio al que pertenece el usuario</param>
    /// <param name="tableName">Nombre de la tabla (usuarios, productos, etc.)</param>
    /// <returns>ID público con formato "XX-abc123def456"</returns>
    Task<string> GenerateIdPublicoAsync(Guid comercioId, string tableName);

    /// <summary>
    /// Genera un ID público para un comercio
    /// Formato: Número secuencial basado en el orden de creación
    /// </summary>
    /// <returns>ID público con formato "01", "02", "03", etc.</returns>
    Task<string> GenerateIdPublicoComercioAsync();
}

