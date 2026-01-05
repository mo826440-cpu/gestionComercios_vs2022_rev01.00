using Shared.Services;
using Supabase.Gotrue;

namespace Shared.Services;

/// <summary>
/// Servicio de autenticación usando Supabase Auth
/// </summary>
public class AuthService : IAuthService
{
    private readonly ISupabaseService _supabaseService;

    public AuthService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<Session?> SignInAsync(string email, string password)
    {
        var response = await _supabaseService.Client.Auth.SignInWithPassword(email, password);
        return response;
    }

    public async Task SignOutAsync()
    {
        await _supabaseService.Client.Auth.SignOut();
    }

    public async Task<Session?> GetSessionAsync()
    {
        var session = _supabaseService.Client.Auth.CurrentSession;
        return session;
    }

    public async Task<bool> IsAuthenticatedAsync()
    {
        var session = await GetSessionAsync();
        return session != null && !string.IsNullOrEmpty(session.AccessToken);
    }

    public async Task<User?> GetCurrentUserAsync()
    {
        var session = await GetSessionAsync();
        return session?.User;
    }

    public async Task<Session?> SignUpAsync(string email, string password)
    {
        var response = await _supabaseService.Client.Auth.SignUp(email, password);
        return response;
    }

    public async Task ResetPasswordAsync(string email)
    {
        await _supabaseService.Client.Auth.ResetPasswordForEmail(email);
    }
}

