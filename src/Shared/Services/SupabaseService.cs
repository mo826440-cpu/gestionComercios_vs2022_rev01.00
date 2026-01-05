using Microsoft.Extensions.Configuration;

namespace Shared.Services;

/// <summary>
/// Servicio de Supabase
/// Implementación del servicio que proporciona acceso al cliente de Supabase
/// </summary>
public class SupabaseService : ISupabaseService
{
    private readonly Supabase.Client _client;

    public SupabaseService(IConfiguration configuration)
    {
        var supabaseUrl = configuration["Supabase:Url"] 
            ?? throw new InvalidOperationException("Supabase:Url no está configurado en appsettings.json");
        
        var supabaseKey = configuration["Supabase:AnonKey"] 
            ?? throw new InvalidOperationException("Supabase:AnonKey no está configurado en appsettings.json");

        var options = new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = false
        };

        _client = new Supabase.Client(supabaseUrl, supabaseKey, options);
    }

    /// <summary>
    /// Cliente de Supabase configurado
    /// </summary>
    public Supabase.Client Client => _client;
}
