using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla detalle_compras
/// Representa un item/producto en una compra
/// </summary>
[Table("detalle_compras")]
public class DetalleCompra : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid CompraId { get; set; } // FK a compras
    public Guid ProductoId { get; set; } // FK a productos
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    public decimal? Descuento { get; set; }
    public DateTime CreatedAt { get; set; }
}

