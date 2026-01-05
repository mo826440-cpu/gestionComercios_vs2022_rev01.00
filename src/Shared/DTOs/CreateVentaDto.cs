using Shared.Models;

namespace Shared.DTOs;

/// <summary>
/// DTO para crear una nueva venta
/// </summary>
public class CreateVentaDto
{
    public Guid ComercioId { get; set; }
    public Guid? ClienteId { get; set; }
    public Guid UsuarioId { get; set; }
    public Guid? CajaId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.UtcNow;
    public decimal? Descuento { get; set; }
    public string? Observaciones { get; set; }
    public List<DetalleVentaItemDto> Detalles { get; set; } = new();
}

/// <summary>
/// DTO para un item/detalle de venta
/// </summary>
public class DetalleVentaItemDto
{
    public Guid ProductoId { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal? Descuento { get; set; }
}

