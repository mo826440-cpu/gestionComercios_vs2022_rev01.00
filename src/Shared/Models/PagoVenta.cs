namespace Shared.Models;

/// <summary>
/// Modelo para la tabla pagos_ventas
/// Representa un pago recibido por una venta
/// </summary>
public class PagoVenta
{
    public Guid Id { get; set; }
    public Guid VentaId { get; set; } // FK a ventas
    public decimal Monto { get; set; }
    public string MetodoPago { get; set; } = string.Empty; // "efectivo", "tarjeta", "transferencia", etc.
    public DateTime Fecha { get; set; }
    public string? Observaciones { get; set; }
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

