using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar stock
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class StockService : IStockService
{
    private readonly ISupabaseService _supabaseService;

    public StockService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Stock>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Stock?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Stock?> GetByProductoAsync(Guid comercioId, Guid productoId)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.ComercioId == comercioId && x.ProductoId == productoId)
            .Single();

        return response;
    }

    public async Task<Stock> CreateAsync(Stock stock)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Insert(stock);

        return response.Models.FirstOrDefault() ?? stock;
    }

    public async Task<Stock> UpdateAsync(Stock stock)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.Id == stock.Id)
            .Set(x => x.Cantidad, stock.Cantidad)
            .Set(x => x.CantidadMinima, stock.CantidadMinima)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? stock;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<Stock> AjustarStockAsync(Guid comercioId, Guid productoId, decimal cantidad)
    {
        var stockExistente = await GetByProductoAsync(comercioId, productoId);

        if (stockExistente == null)
        {
            // Crear nuevo registro de stock
            var nuevoStock = new Stock
            {
                Id = Guid.NewGuid(),
                ComercioId = comercioId,
                ProductoId = productoId,
                Cantidad = cantidad,
                CreatedAt = DateTime.UtcNow
            };

            return await CreateAsync(nuevoStock);
        }
        else
        {
            // Actualizar stock existente
            stockExistente.Cantidad += cantidad;
            return await UpdateAsync(stockExistente);
        }
    }

    public async Task<List<Stock>> GetStockBajoAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Stock>()
            .Where(x => x.ComercioId == comercioId)
            .Filter(x => x.CantidadMinima, Constants.Operator.GreaterThan, 0)
            .Get();

        // Filtrar en memoria los que están por debajo del mínimo
        var stocks = response.Models
            .Where(s => s.CantidadMinima.HasValue && s.Cantidad <= s.CantidadMinima.Value)
            .ToList();

        return stocks;
    }
}

