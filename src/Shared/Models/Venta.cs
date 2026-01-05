using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla ventas
/// Representa una venta realizada
/// </summary>
[Table("ventas")]
public class Venta : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid? ClienteId { get; set; } // FK a clientes (opcional, venta a consumidor final)
    public Guid UsuarioId { get; set; } // FK a usuarios
    public Guid? CajaId { get; set; } // FK a cajas
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    public decimal? Descuento { get; set; }
    public string? Observaciones { get; set; }
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

