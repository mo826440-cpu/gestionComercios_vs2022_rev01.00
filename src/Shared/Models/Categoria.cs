using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla categorias
/// Representa una categoría de productos
/// </summary>
[Table("categorias")]
public class Categoria : BaseModel
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

