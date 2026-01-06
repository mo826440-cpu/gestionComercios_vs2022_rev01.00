using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Shared.Models;

/// <summary>
/// Modelo para la tabla comercios
/// Representa un comercio/negocio en el sistema
/// </summary>
[Table("comercios")]
public class Comercio : BaseModel
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("nombre")]
    public string Nombre { get; set; } = string.Empty;
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("telefono")]
    public string? Telefono { get; set; }
    
    [Column("direccion")]
    public string? Direccion { get; set; }
    
    [Column("id_publico")]
    public string? IdPublico { get; set; } // ID público del comercio
    
    [Column("activo")]
    public bool Activo { get; set; } = true;
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

