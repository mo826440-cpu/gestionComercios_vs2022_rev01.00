namespace Shared.Models;

/// <summary>
/// Modelo para la tabla movimientos_stock
/// Representa un movimiento de stock (entrada/salida)
/// </summary>
public class MovimientoStock
{
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid ProductoId { get; set; } // FK a productos
    public Guid? UsuarioId { get; set; } // FK a usuarios
    public decimal Cantidad { get; set; }
    public string Tipo { get; set; } = string.Empty; // "entrada", "salida", "ajuste", etc.
    public string? Motivo { get; set; }
    public Guid? ReferenciaId { get; set; } // ID de referencia (venta, compra, etc.)
    public string? ReferenciaTipo { get; set; } // Tipo de referencia ("venta", "compra", etc.)
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
}

