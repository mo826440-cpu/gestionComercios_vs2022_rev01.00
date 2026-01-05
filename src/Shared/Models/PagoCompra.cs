namespace Shared.Models;

/// <summary>
/// Modelo para la tabla pagos_compras
/// Representa un pago realizado por una compra
/// </summary>
public class PagoCompra
{
    public Guid Id { get; set; }
    public Guid CompraId { get; set; } // FK a compras
    public decimal Monto { get; set; }
    public string MetodoPago { get; set; } = string.Empty; // "efectivo", "tarjeta", "transferencia", etc.
    public DateTime Fecha { get; set; }
    public string? Observaciones { get; set; }
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

