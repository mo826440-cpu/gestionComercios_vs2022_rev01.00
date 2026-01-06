using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Roles
/// Proporciona operaciones para gestionar roles del sistema
/// </summary>
public interface IRolService
{
    /// <summary>
    /// Obtiene todos los roles activos
    /// </summary>
    Task<List<Rol>> GetAllAsync();

    /// <summary>
    /// Obtiene un rol por su ID
    /// </summary>
    Task<Rol?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtiene un rol por su nombre
    /// </summary>
    Task<Rol?> GetByNameAsync(string nombre);

    /// <summary>
    /// Obtiene el rol de administrador
    /// </summary>
    Task<Rol?> GetAdminRoleAsync();

    /// <summary>
    /// Obtiene el rol de usuario (empleado)
    /// </summary>
    Task<Rol?> GetUserRoleAsync();

    /// <summary>
    /// Obtiene el rol de programador
    /// </summary>
    Task<Rol?> GetProgramadorRoleAsync();
}

