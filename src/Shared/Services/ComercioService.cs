using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar comercios
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class ComercioService : IComercioService
{
    private readonly ISupabaseService _supabaseService;

    public ComercioService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Comercio>> GetAllAsync()
    {
        var response = await _supabaseService.Client
            .From<Comercio>()
            .Get();

        return response.Models;
    }

    public async Task<Comercio?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Comercio>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Comercio> CreateAsync(Comercio comercio)
    {
        var response = await _supabaseService.Client
            .From<Comercio>()
            .Insert(comercio);

        return response.Models.FirstOrDefault() ?? comercio;
    }

    public async Task<Comercio> UpdateAsync(Comercio comercio)
    {
        var response = await _supabaseService.Client
            .From<Comercio>()
            .Where(x => x.Id == comercio.Id)
            .Set(x => x.Nombre, comercio.Nombre)
            .Set(x => x.Email, comercio.Email)
            .Set(x => x.Telefono, comercio.Telefono)
            .Set(x => x.Direccion, comercio.Direccion)
            .Set(x => x.IdPublico, comercio.IdPublico)
            .Set(x => x.Activo, comercio.Activo)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? comercio;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Comercio>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<Comercio?> GetByEmailAsync(string email)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<Comercio>()
                .Where(x => x.Email == email)
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Comercio?> GetByIdPublicoAsync(string idPublico)
    {
        try
        {
            var response = await _supabaseService.Client
                .From<Comercio>()
                .Where(x => x.IdPublico == idPublico)
                .Single();

            return response;
        }
        catch
        {
            return null;
        }
    }
}

