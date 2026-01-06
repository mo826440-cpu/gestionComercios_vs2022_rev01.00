using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla solicitudes_registro
/// Representa una solicitud de registro pendiente de aprobación
/// </summary>
[Table("solicitudes_registro")]
public class SolicitudRegistro : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }

    [Column("email_solicitante")]
    public string EmailSolicitante { get; set; } = string.Empty;

    [Column("codigo_verificacion")]
    public string? CodigoVerificacion { get; set; }

    [Column("estado")]
    public string Estado { get; set; } = "pendiente"; // 'pendiente', 'aprobada', 'rechazada', 'verificada', 'expirada'

    [Column("fecha_solicitud")]
    public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;

    [Column("fecha_aprobacion")]
    public DateTime? FechaAprobacion { get; set; }

    [Column("fecha_verificacion")]
    public DateTime? FechaVerificacion { get; set; }

    [Column("fecha_expiracion")]
    public DateTime? FechaExpiracion { get; set; }

    [Column("aprobado_por")]
    public string? AprobadoPor { get; set; }

    [Column("intentos_verificacion")]
    public int IntentosVerificacion { get; set; } = 0;

    [Column("max_intentos")]
    public int MaxIntentos { get; set; } = 5;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

