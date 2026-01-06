using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar clientes
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class ClienteService : IClienteService
{
    private readonly ISupabaseService _supabaseService;

    public ClienteService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Cliente>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Cliente>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Cliente?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Cliente>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        var response = await _supabaseService.Client
            .From<Cliente>()
            .Insert(cliente);

        return response.Models.FirstOrDefault() ?? cliente;
    }

    public async Task<Cliente> UpdateAsync(Cliente cliente)
    {
        var response = await _supabaseService.Client
            .From<Cliente>()
            .Where(x => x.Id == cliente.Id)
            .Set(x => x.Nombre, cliente.Nombre)
            .Set(x => x.Email, cliente.Email ?? (string?)null)
            .Set(x => x.Telefono, cliente.Telefono ?? (string?)null)
            .Set(x => x.Direccion, cliente.Direccion ?? (string?)null)
            .Set(x => x.Activo, cliente.Activo)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response?.Models?.FirstOrDefault() ?? cliente;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Cliente>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Cliente>> SearchAsync(Guid comercioId, string searchTerm)
    {
        var response = await _supabaseService.Client
            .From<Cliente>()
            .Where(x => x.ComercioId == comercioId)
            .Filter(x => x.Nombre, Constants.Operator.ILike, $"%{searchTerm}%")
            .Get();

        return response.Models;
    }
}

