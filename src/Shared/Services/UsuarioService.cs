using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar usuarios
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class UsuarioService : IUsuarioService
{
    private readonly ISupabaseService _supabaseService;

    public UsuarioService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Usuario>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Usuario?> GetByAuthUserIdAsync(Guid authUserId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.AuthUserId == authUserId)
            .Single();

        return response;
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Insert(usuario);

        return response.Models.FirstOrDefault() ?? usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == usuario.Id)
            .Set(x => x.RolId, usuario.RolId)
            .Set(x => x.Activo, usuario.Activo)
            .Set(x => x.EsPropietario, usuario.EsPropietario)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? usuario;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Usuario>> GetByRolAsync(Guid comercioId, Guid rolId)
    {
        var response = await _supabaseService.Client
            .From<Usuario>()
            .Where(x => x.ComercioId == comercioId && x.RolId == rolId)
            .Get();

        return response.Models;
    }
}

