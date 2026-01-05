using Shared.Models;
using Shared.Services;

namespace Client.Services;

/// <summary>
/// Servicio para obtener el contexto del usuario actual autenticado
/// </summary>
public class UserContextService : IUserContextService
{
    private readonly IAuthService _authService;
    private readonly IUsuarioService _usuarioService;
    private Usuario? _cachedUsuario;

    public UserContextService(IAuthService authService, IUsuarioService usuarioService)
    {
        _authService = authService;
        _usuarioService = usuarioService;
    }

    public async Task<Usuario?> GetCurrentUsuarioAsync()
    {
        // Si ya tenemos el usuario en caché y la sesión sigue activa, devolverlo
        if (_cachedUsuario != null)
        {
            var isAuthenticated = await _authService.IsAuthenticatedAsync();
            if (isAuthenticated)
            {
                return _cachedUsuario;
            }
            else
            {
                _cachedUsuario = null; // Limpiar caché si no está autenticado
            }
        }

        var authUser = await _authService.GetCurrentUserAsync();
        if (authUser == null)
            return null;

        // El ID de Supabase Auth puede ser string, intentar parsearlo
        if (!Guid.TryParse(authUser.Id, out var authUserId))
            return null;

        try
        {
            _cachedUsuario = await _usuarioService.GetByAuthUserIdAsync(authUserId);
            return _cachedUsuario;
        }
        catch
        {
            // Si no se encuentra el usuario, puede ser que aún no se haya creado en la tabla usuarios
            return null;
        }
    }

    public async Task<Guid?> GetCurrentComercioIdAsync()
    {
        var usuario = await GetCurrentUsuarioAsync();
        return usuario?.ComercioId;
    }

    public async Task<bool> IsCurrentUserAdminAsync()
    {
        var usuario = await GetCurrentUsuarioAsync();
        return usuario?.EsPropietario ?? false;
    }
}

