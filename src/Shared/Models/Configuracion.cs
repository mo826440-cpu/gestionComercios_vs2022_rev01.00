namespace Shared.Models;

/// <summary>
/// Modelo para la tabla configuraciones
/// Representa configuraciones del sistema por comercio
/// </summary>
public class Configuracion
{
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public string Categoria { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
    public string? Valor { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

