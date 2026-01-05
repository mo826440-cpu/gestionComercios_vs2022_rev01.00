using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Usuarios
/// Proporciona operaciones CRUD para usuarios
/// </summary>
public interface IUsuarioService
{
    /// <summary>
    /// Obtiene todos los usuarios de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de usuarios</returns>
    Task<List<Usuario>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene un usuario por su ID
    /// </summary>
    /// <param name="id">ID del usuario</param>
    /// <returns>El usuario si existe, null en caso contrario</returns>
    Task<Usuario?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtiene un usuario por su AuthUserId (ID de Supabase Auth)
    /// </summary>
    /// <param name="authUserId">ID del usuario en Supabase Auth</param>
    /// <returns>El usuario si existe, null en caso contrario</returns>
    Task<Usuario?> GetByAuthUserIdAsync(Guid authUserId);

    /// <summary>
    /// Crea un nuevo usuario
    /// </summary>
    /// <param name="usuario">Usuario a crear</param>
    /// <returns>El usuario creado</returns>
    Task<Usuario> CreateAsync(Usuario usuario);

    /// <summary>
    /// Actualiza un usuario existente
    /// </summary>
    /// <param name="usuario">Usuario con los datos actualizados</param>
    /// <returns>El usuario actualizado</returns>
    Task<Usuario> UpdateAsync(Usuario usuario);

    /// <summary>
    /// Elimina un usuario
    /// </summary>
    /// <param name="id">ID del usuario a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Obtiene todos los usuarios con un rol específico
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="rolId">ID del rol</param>
    /// <returns>Lista de usuarios con el rol especificado</returns>
    Task<List<Usuario>> GetByRolAsync(Guid comercioId, Guid rolId);
}

