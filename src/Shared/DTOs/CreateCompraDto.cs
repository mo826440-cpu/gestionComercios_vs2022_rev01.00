namespace Shared.DTOs;

/// <summary>
/// DTO para crear una nueva compra
/// </summary>
public class CreateCompraDto
{
    public Guid ComercioId { get; set; }
    public Guid ProveedorId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal? Descuento { get; set; }
    public string? NumeroFactura { get; set; }
    public string? Observaciones { get; set; }
    public List<DetalleCompraItemDto> Detalles { get; set; } = new();
}

/// <summary>
/// DTO para un item/detalle de compra
/// </summary>
public class DetalleCompraItemDto
{
    public Guid ProductoId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal? Descuento { get; set; }
}

