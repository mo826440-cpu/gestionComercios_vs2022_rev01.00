using Supabase.Gotrue;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de autenticación
/// Gestiona login, logout y sesión de usuarios
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Inicia sesión con email y contraseña
    /// </summary>
    Task<Session?> SignInAsync(string email, string password);

    /// <summary>
    /// Cierra la sesión del usuario actual
    /// </summary>
    Task SignOutAsync();

    /// <summary>
    /// Obtiene la sesión actual del usuario
    /// </summary>
    Task<Session?> GetSessionAsync();

    /// <summary>
    /// Verifica si hay un usuario autenticado
    /// </summary>
    Task<bool> IsAuthenticatedAsync();

    /// <summary>
    /// Obtiene el usuario actual autenticado
    /// </summary>
    Task<User?> GetCurrentUserAsync();

    /// <summary>
    /// Registra un nuevo usuario (si aplica)
    /// </summary>
    Task<Session?> SignUpAsync(string email, string password);

    /// <summary>
    /// Restablece la contraseña
    /// </summary>
    Task ResetPasswordAsync(string email);
}

