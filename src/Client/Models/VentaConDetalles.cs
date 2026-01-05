using Shared.Models;

namespace Client.Models;

/// <summary>
/// Modelo para guardar venta con detalles en IndexedDB
/// </summary>
public class VentaConDetalles
{
    public Venta Venta { get; set; } = null!;
    public List<DetalleVenta> Detalles { get; set; } = new();
}

