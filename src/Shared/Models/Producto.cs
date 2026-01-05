using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla productos
/// Representa un producto en el inventario
/// </summary>
[Table("productos")]
public class Producto : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid? CategoriaId { get; set; } // FK a categorias
    public Guid? MarcaId { get; set; } // FK a marcas
    public string Nombre { get; set; } = string.Empty;
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal? PrecioCompra { get; set; }
    public bool Activo { get; set; } = true;
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

