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
    
    [Column("auth_user_id")]
    public Guid AuthUserId { get; set; } // FK a auth.users
    
    [Column("comercio_id")]
    public Guid ComercioId { get; set; } // FK a comercios
    
    [Column("rol_id")]
    public Guid? RolId { get; set; } // FK a roles
    
    [Column("nombre")]
    public string? Nombre { get; set; } // Nombre y apellido del usuario
    
    [Column("usuario")]
    public string? Usuario { get; set; } // Nombre de usuario (único por comercio)
    
    [Column("contacto")]
    public string? Contacto { get; set; } // Teléfono/celular
    
    [Column("referencias")]
    public string? Referencias { get; set; } // Referencias adicionales (opcional)
    
    [Column("id_publico")]
    public string? IdPublico { get; set; } // ID público con formato XX + ID_COMERCIO
    
    [Column("activo")]
    public bool Activo { get; set; } = true;
    
    [Column("es_propietario")]
    public bool EsPropietario { get; set; } = false;
    
    [Column("sync_id")]
    public Guid? SyncId { get; set; } // Para sincronización offline
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

