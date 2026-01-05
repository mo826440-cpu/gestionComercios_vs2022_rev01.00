using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla roles_permisos
/// Representa la relación muchos a muchos entre roles y permisos
/// </summary>
[Table("roles_permisos")]
public class RolPermiso : BaseModel
{
    [PrimaryKey("rol_id", false)]
    [Column("rol_id")]
    public Guid RolId { get; set; } // FK a roles

    [PrimaryKey("permiso_id", false)]
    [Column("permiso_id")]
    public Guid PermisoId { get; set; } // FK a permisos

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}

