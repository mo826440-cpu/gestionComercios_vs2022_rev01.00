using Shared.DTOs;
using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;
using Supabase.Postgrest.Responses;

namespace Shared.Services;

/// <summary>
/// Servicio para gestionar ventas
/// Implementa operaciones CRUD usando Supabase PostgREST
/// </summary>
public class VentaService : IVentaService
{
    private readonly ISupabaseService _supabaseService;

    public VentaService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task<List<Venta>> GetAllAsync(Guid comercioId)
    {
        var response = await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.ComercioId == comercioId)
            .Get();

        return response.Models;
    }

    public async Task<Venta?> GetByIdAsync(Guid id)
    {
        var response = await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.Id == id)
            .Single();

        return response;
    }

    public async Task<Venta> CreateAsync(CreateVentaDto ventaDto)
    {
        // Calcular total
        var total = ventaDto.Detalles.Sum(d => d.Cantidad * d.PrecioUnitario - (d.Descuento ?? 0)) - (ventaDto.Descuento ?? 0);

        // Crear venta
        var venta = new Venta
        {
            Id = Guid.NewGuid(),
            ComercioId = ventaDto.ComercioId,
            ClienteId = ventaDto.ClienteId,
            UsuarioId = ventaDto.UsuarioId,
            CajaId = ventaDto.CajaId,
            Fecha = ventaDto.Fecha,
            Total = total,
            Descuento = ventaDto.Descuento,
            Observaciones = ventaDto.Observaciones,
            CreatedAt = DateTime.UtcNow
        };

        var ventaResponse = await _supabaseService.Client
            .From<Venta>()
            .Insert(venta);

        var ventaCreada = ventaResponse.Models.FirstOrDefault() ?? venta;

        // Crear detalles
        var detalles = ventaDto.Detalles.Select(d => new DetalleVenta
        {
            Id = Guid.NewGuid(),
            VentaId = ventaCreada.Id,
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
                .From<DetalleVenta>()
                .Insert(detalles);
        }

        return ventaCreada;
    }

    public async Task<Venta> UpdateAsync(Venta venta)
    {
        var response = await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.Id == venta.Id)
            .Set(x => x.ClienteId, venta.ClienteId)
            .Set(x => x.Fecha, venta.Fecha)
            .Set(x => x.Total, venta.Total)
            .Set(x => x.Descuento, venta.Descuento)
            .Set(x => x.Observaciones, venta.Observaciones ?? (string?)null)
            .Set(x => x.UpdatedAt, DateTime.UtcNow)
            .Update();

        return response?.Models?.FirstOrDefault() ?? venta;
    }

    public async Task DeleteAsync(Guid id)
    {
        // Eliminar detalles primero
        await _supabaseService.Client
            .From<DetalleVenta>()
            .Where(x => x.VentaId == id)
            .Delete();

        // Eliminar venta
        await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.Id == id)
            .Delete();
    }

    public async Task<List<Venta>> GetByClienteAsync(Guid comercioId, Guid clienteId)
    {
        var response = await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.ComercioId == comercioId && x.ClienteId == clienteId)
            .Get();

        return response.Models;
    }

    public async Task<List<Venta>> GetByFechaAsync(Guid comercioId, DateTime fechaInicio, DateTime fechaFin)
    {
        var response = await _supabaseService.Client
            .From<Venta>()
            .Where(x => x.ComercioId == comercioId && x.Fecha >= fechaInicio && x.Fecha <= fechaFin)
            .Get();

        return response.Models;
    }

    public async Task<List<DetalleVenta>> GetDetallesAsync(Guid ventaId)
    {
        var response = await _supabaseService.Client
            .From<DetalleVenta>()
            .Where(x => x.VentaId == ventaId)
            .Get();

        return response.Models;
    }
}

