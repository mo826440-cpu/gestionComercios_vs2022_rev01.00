using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar productos
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class ProductoService : IProductoService
{
    private readonly ISupabaseService _supabaseService;

    public ProductoService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Producto>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Producto?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Producto> CreateAsync(Producto producto)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Insert(producto);

        return response.Models.FirstOrDefault() ?? producto;
    }

    public async Task<Producto> UpdateAsync(Producto producto)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.Id == producto.Id)
            .Set(x => x.Nombre, producto.Nombre)
            .Set(x => x.Codigo, producto.Codigo)
            .Set(x => x.Descripcion, producto.Descripcion)
            .Set(x => x.CategoriaId, producto.CategoriaId)
            .Set(x => x.MarcaId, producto.MarcaId)
            .Set(x => x.PrecioVenta, producto.PrecioVenta)
            .Set(x => x.PrecioCompra, producto.PrecioCompra)
            .Set(x => x.Activo, producto.Activo)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? producto;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Producto>> GetByCategoriaAsync(Guid comercioId, Guid categoriaId)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.ComercioId == comercioId && x.CategoriaId == categoriaId)
            .Get();

        return response.Models;
    }

    public async Task<List<Producto>> SearchAsync(Guid comercioId, string searchTerm)
    {
        var response = await _supabaseService.Client
            .From<Producto>()
            .Where(x => x.ComercioId == comercioId)
            .Filter(x => x.Nombre, Constants.Operator.ILike, $"%{searchTerm}%")
            .Get();

        return response.Models;
    }
}

