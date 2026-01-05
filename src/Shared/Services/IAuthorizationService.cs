using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de autorización (RBAC)
/// Gestiona permisos y roles de usuarios
/// </summary>
public interface IAuthorizationService
{
    /// <summary>
    /// Verifica si el usuario tiene un permiso específico
    /// </summary>
    Task<bool> HasPermissionAsync(Guid usuarioId, string permisoNombre);

    /// <summary>
    /// Verifica si el usuario tiene un rol específico
    /// </summary>
    Task<bool> HasRoleAsync(Guid usuarioId, string rolNombre);

    /// <summary>
    /// Obtiene todos los permisos de un usuario
    /// </summary>
    Task<List<Permiso>> GetUserPermissionsAsync(Guid usuarioId);

    /// <summary>
    /// Obtiene el rol de un usuario
    /// </summary>
    Task<Rol?> GetUserRoleAsync(Guid usuarioId);

    /// <summary>
    /// Verifica si el usuario es propietario del comercio
    /// </summary>
    Task<bool> IsPropietarioAsync(Guid usuarioId);

    /// <summary>
    /// Verifica si el usuario pertenece al comercio
    /// </summary>
    Task<bool> BelongsToComercioAsync(Guid usuarioId, Guid comercioId);
}

