using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;

namespace Shared.Services;

/// <summary>
/// Servicio de autorización (RBAC)
/// Gestiona permisos y roles basado en la tabla usuarios, roles y roles_permisos
/// </summary>
public class AuthorizationService : IAuthorizationService
{
    private readonly ISupabaseService _supabaseService;
    private readonly IUsuarioService _usuarioService;

    public AuthorizationService(ISupabaseService supabaseService, IUsuarioService usuarioService)
    {
        _supabaseService = supabaseService;
        _usuarioService = usuarioService;
    }

    public async Task<bool> HasPermissionAsync(Guid usuarioId, string permisoNombre)
    {
        var usuario = await _usuarioService.GetByIdAsync(usuarioId);
        if (usuario == null || !usuario.RolId.HasValue)
            return false;

        // Obtener permisos del rol
        var permisos = await GetUserPermissionsAsync(usuarioId);
        return permisos.Any(p => p.Nombre.Equals(permisoNombre, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<bool> HasRoleAsync(Guid usuarioId, string rolNombre)
    {
        var rol = await GetUserRoleAsync(usuarioId);
        return rol != null && rol.Nombre.Equals(rolNombre, StringComparison.OrdinalIgnoreCase);
    }

    public async Task<List<Permiso>> GetUserPermissionsAsync(Guid usuarioId)
    {
        var usuario = await _usuarioService.GetByIdAsync(usuarioId);
        if (usuario == null || !usuario.RolId.HasValue)
            return new List<Permiso>();

        // Obtener rol_permisos
        var rolPermisosResponse = await _supabaseService.Client
            .From<RolPermiso>()
            .Where(x => x.RolId == usuario.RolId.Value)
            .Get();

        var rolPermisoIds = rolPermisosResponse.Models.Select(rp => rp.PermisoId).ToList();

        if (!rolPermisoIds.Any())
            return new List<Permiso>();

        // Obtener permisos
        var permisosResponse = await _supabaseService.Client
            .From<Permiso>()
            .Get();

        var permisos = permisosResponse.Models
            .Where(p => rolPermisoIds.Contains(p.Id) && p.Activo)
            .ToList();

        return permisos;
    }

    public async Task<Rol?> GetUserRoleAsync(Guid usuarioId)
    {
        var usuario = await _usuarioService.GetByIdAsync(usuarioId);
        if (usuario == null || !usuario.RolId.HasValue)
            return null;

        var response = await _supabaseService.Client
            .From<Rol>()
            .Where(x => x.Id == usuario.RolId.Value)
            .Single();

        return response;
    }

    public async Task<bool> IsPropietarioAsync(Guid usuarioId)
    {
        var usuario = await _usuarioService.GetByIdAsync(usuarioId);
        return usuario?.EsPropietario ?? false;
    }

    public async Task<bool> BelongsToComercioAsync(Guid usuarioId, Guid comercioId)
    {
        var usuario = await _usuarioService.GetByIdAsync(usuarioId);
        return usuario != null && usuario.ComercioId == comercioId;
    }
}

