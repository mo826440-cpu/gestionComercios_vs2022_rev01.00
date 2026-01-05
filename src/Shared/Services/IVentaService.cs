using Shared.DTOs;
using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Ventas
/// Proporciona operaciones para gestionar ventas
/// </summary>
public interface IVentaService
{
    /// <summary>
    /// Obtiene todas las ventas de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de ventas</returns>
    Task<List<Venta>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene una venta por su ID
    /// </summary>
    /// <param name="id">ID de la venta</param>
    /// <returns>La venta si existe, null en caso contrario</returns>
    Task<Venta?> GetByIdAsync(Guid id);

    /// <summary>
    /// Crea una nueva venta con sus detalles
    /// </summary>
    /// <param name="ventaDto">DTO con los datos de la venta y sus detalles</param>
    /// <returns>La venta creada</returns>
    Task<Venta> CreateAsync(CreateVentaDto ventaDto);

    /// <summary>
    /// Actualiza una venta existente
    /// </summary>
    /// <param name="venta">Venta con los datos actualizados</param>
    /// <returns>La venta actualizada</returns>
    Task<Venta> UpdateAsync(Venta venta);

    /// <summary>
    /// Elimina una venta y sus detalles
    /// </summary>
    /// <param name="id">ID de la venta a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Obtiene todas las ventas de un cliente específico
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="clienteId">ID del cliente</param>
    /// <returns>Lista de ventas del cliente</returns>
    Task<List<Venta>> GetByClienteAsync(Guid comercioId, Guid clienteId);

    /// <summary>
    /// Obtiene todas las ventas en un rango de fechas
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="fechaInicio">Fecha de inicio del rango</param>
    /// <param name="fechaFin">Fecha de fin del rango</param>
    /// <returns>Lista de ventas en el rango de fechas</returns>
    Task<List<Venta>> GetByFechaAsync(Guid comercioId, DateTime fechaInicio, DateTime fechaFin);

    /// <summary>
    /// Obtiene los detalles (items) de una venta
    /// </summary>
    /// <param name="ventaId">ID de la venta</param>
    /// <returns>Lista de detalles de la venta</returns>
    Task<List<DetalleVenta>> GetDetallesAsync(Guid ventaId);
}

