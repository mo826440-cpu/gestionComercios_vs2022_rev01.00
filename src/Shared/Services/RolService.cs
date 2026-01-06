using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar roles
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class RolService : IRolService
{
    private readonly ISupabaseService _supabaseService;

    public RolService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Rol>> GetAllAsync()
    {
        var response = await _supabaseService.Client
            .From<Rol>()
            .Where(x => x.Activo == true)
            .Get();

        return response.Models;
    }

    public async Task<Rol?> GetByIdAsync(Guid id)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<Rol>()
                .Where(x => x.Id == id)
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Rol?> GetByNameAsync(string nombre)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<Rol>()
                .Where(x => x.Nombre == nombre && x.Activo == true)
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Rol?> GetAdminRoleAsync()
    {
        return await GetByNameAsync("admin");
    }

    public async Task<Rol?> GetUserRoleAsync()
    {
        return await GetByNameAsync("user");
    }

    public async Task<Rol?> GetProgramadorRoleAsync()
    {
        return await GetByNameAsync("programador");
    }
}

