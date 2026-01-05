namespace Shared.Models;

/// <summary>
/// Modelo para la tabla cajas
/// Representa una caja/arqueo de caja
/// </summary>
public class Caja
{
    public Guid Id { get; set; }
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid UsuarioAperturaId { get; set; } // FK a usuarios (quien abre la caja)
    public Guid? UsuarioCierreId { get; set; } // FK a usuarios (quien cierra la caja)
    public DateTime FechaApertura { get; set; }
    public DateTime? FechaCierre { get; set; }
    public decimal MontoInicial { get; set; }
    public decimal? MontoCierre { get; set; }
    public bool Abierta { get; set; } = true;
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

