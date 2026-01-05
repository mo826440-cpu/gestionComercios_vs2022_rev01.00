using Shared.Models;

namespace Client.Models;

/// <summary>
/// Modelo para guardar compra con detalles en IndexedDB
/// </summary>
public class CompraConDetalles
{
    public Compra Compra { get; set; } = null!;
    public List<DetalleCompra> Detalles { get; set; } = new();
}

