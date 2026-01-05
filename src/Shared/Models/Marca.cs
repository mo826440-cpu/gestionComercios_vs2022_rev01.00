using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla marcas
/// Representa una marca de productos
/// </summary>
[Table("marcas")]
public class Marca : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public bool Activo { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

