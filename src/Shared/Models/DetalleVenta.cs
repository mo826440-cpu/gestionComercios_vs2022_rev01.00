using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla detalle_ventas
/// Representa un item/producto en una venta
/// </summary>
[Table("detalle_ventas")]
public class DetalleVenta : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid VentaId { get; set; } // FK a ventas
    public Guid ProductoId { get; set; } // FK a productos
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
    public decimal? Descuento { get; set; }
    public DateTime CreatedAt { get; set; }
}

