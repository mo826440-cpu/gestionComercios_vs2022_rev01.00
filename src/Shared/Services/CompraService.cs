using Shared.DTOs;
using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar compras
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class CompraService : ICompraService
{
    private readonly ISupabaseService _supabaseService;

    public CompraService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Compra>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Compra?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Compra> CreateAsync(CreateCompraDto compraDto)
    {
        // Calcular total
        var total = compraDto.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario - (d.Descuento ?? 0)) - (compraDto.Descuento ?? 0);

        // Crear compra
        var compra = new Compra
        {
            Id = Guid.NewGuid(),
            ComercioId = compraDto.ComercioId,
            ProveedorId = compraDto.ProveedorId,
            Fecha = compraDto.Fecha,
            Total = total,
            Descuento = compraDto.Descuento,
            NumeroFactura = compraDto.NumeroFactura,
            Observaciones = compraDto.Observaciones,
            CreatedAt = DateTime.UtcNow
        };

        var compraResponse = await _supabaseService.Client
            .From<Compra>()
            .Insert(compra);

        var compraCreada = compraResponse.Models.FirstOrDefault() ?? compra;

        // Crear detalles
        var detalles = compraDto.Detalles.Select(d => new DetalleCompra
        {
            Id = Guid.NewGuid(),
            CompraId = compraCreada.Id,
            ProductoId = d.ProductoId,
            Cantidad = d.Cantidad,
            PrecioUnitario = d.PrecioUnitario,
            Subtotal = d.Cantidad * d.PrecioUnitario - (d.Descuento ?? 0),
            Descuento = d.Descuento,
            CreatedAt = DateTime.UtcNow
        }).ToList();

        if (detalles.Any())
        {
            await _supabaseService.Client
                .From<DetalleCompra>()
                .Insert(detalles);
        }

        return compraCreada;
    }

    public async Task<Compra> UpdateAsync(Compra compra)
    {
        var response = await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.Id == compra.Id)
            .Set(x => x.ProveedorId, compra.ProveedorId)
            .Set(x => x.Fecha, compra.Fecha)
            .Set(x => x.Total, compra.Total)
            .Set(x => x.Descuento, compra.Descuento)
            .Set(x => x.NumeroFactura, compra.NumeroFactura)
            .Set(x => x.Observaciones, compra.Observaciones)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response.Models.FirstOrDefault() ?? compra;
    }

    public async Task DeleteAsync(Guid id)
    {
        // Eliminar detalles primero
        await _supabaseService.Client
            .From<DetalleCompra>()
            .Where(x => x.CompraId == id)
            .Delete();

        // Eliminar compra
        await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Compra>> GetByProveedorAsync(Guid comercioId, Guid proveedorId)
    {
        var response = await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.ComercioId == comercioId && x.ProveedorId == proveedorId)
            .Get();

        return response.Models;
    }

    public async Task<List<Compra>> GetByFechaAsync(Guid comercioId, DateTime fechaInicio, DateTime fechaFin)
    {
        var response = await _supabaseService.Client
            .From<Compra>()
            .Where(x => x.ComercioId == comercioId && x.Fecha >= fechaInicio && x.Fecha <= fechaFin)
            .Get();

        return response.Models;
    }

    public async Task<List<DetalleCompra>> GetDetallesAsync(Guid compraId)
    {
        var response = await _supabaseService.Client
            .From<DetalleCompra>()
            .Where(x => x.CompraId == compraId)
            .Get();

        return response.Models;
    }
}

