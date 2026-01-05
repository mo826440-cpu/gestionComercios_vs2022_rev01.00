using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla usuarios
/// Representa un usuario del sistema vinculado a Supabase Auth
/// </summary>
[Table("usuarios")]
public class Usuario : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    public Guid AuthUserId { get; set; } // FK a auth.users
    public Guid ComercioId { get; set; } // FK a comercios
    public Guid? RolId { get; set; } // FK a roles
    public bool Activo { get; set; } = true;
    public bool EsPropietario { get; set; } = false;
    public Guid? SyncId { get; set; } // Para sincronización offline
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

