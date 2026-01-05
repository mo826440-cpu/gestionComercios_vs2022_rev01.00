using Shared.Models;

namespace Client.Services;

/// <summary>
/// Servicio para obtener el contexto del usuario actual autenticado
/// Proporciona información sobre el usuario y su comercio
/// </summary>
public interface IUserContextService
{
    /// <summary>
    /// Obtiene el usuario actual autenticado
    /// </summary>
    Task<Usuario?> GetCurrentUsuarioAsync();

    /// <summary>
    /// Obtiene el ID del comercio del usuario actual
    /// </summary>
    Task<Guid?> GetCurrentComercioIdAsync();

    /// <summary>
    /// Verifica si el usuario actual es propietario/admin
    /// </summary>
    Task<bool> IsCurrentUserAdminAsync();
}

