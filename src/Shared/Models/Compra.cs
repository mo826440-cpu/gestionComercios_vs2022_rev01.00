using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla compras
/// Representa una compra a proveedores
/// </summary>
[Table("compras")]
public class Compra : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid ProveedorId { get; set; } // FK a proveedores
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public decimal? Descuento { get; set; }
    public string? NumeroFactura { get; set; }
    public string? Observaciones { get; set; }
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

