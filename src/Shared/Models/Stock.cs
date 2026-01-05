using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla stock
/// Representa el stock de un producto en un comercio
/// </summary>
[Table("stock")]
public class Stock : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid ProductoId { get; set; } // FK a productos
    public decimal Cantidad { get; set; }
    public decimal? CantidadMinima { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

