using Shared.DTOs;
using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Compras
/// Proporciona operaciones para gestionar compras
/// </summary>
public interface ICompraService
{
    /// <summary>
    /// Obtiene todas las compras de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de compras</returns>
    Task<List<Compra>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene una compra por su ID
    /// </summary>
    /// <param name="id">ID de la compra</param>
    /// <returns>La compra si existe, null en caso contrario</returns>
    Task<Compra?> GetByIdAsync(Guid id);

    /// <summary>
    /// Crea una nueva compra con sus detalles
    /// </summary>
    /// <param name="compraDto">DTO con los datos de la compra y sus detalles</param>
    /// <returns>La compra creada</returns>
    Task<Compra> CreateAsync(CreateCompraDto compraDto);

    /// <summary>
    /// Actualiza una compra existente
    /// </summary>
    /// <param name="compra">Compra con los datos actualizados</param>
    /// <returns>La compra actualizada</returns>
    Task<Compra> UpdateAsync(Compra compra);

    /// <summary>
    /// Elimina una compra y sus detalles
    /// </summary>
    /// <param name="id">ID de la compra a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Obtiene todas las compras de un proveedor específico
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="proveedorId">ID del proveedor</param>
    /// <returns>Lista de compras del proveedor</returns>
    Task<List<Compra>> GetByProveedorAsync(Guid comercioId, Guid proveedorId);

    /// <summary>
    /// Obtiene todas las compras en un rango de fechas
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="fechaInicio">Fecha de inicio del rango</param>
    /// <param name="fechaFin">Fecha de fin del rango</param>
    /// <returns>Lista de compras en el rango de fechas</returns>
    Task<List<Compra>> GetByFechaAsync(Guid comercioId, DateTime fechaInicio, DateTime fechaFin);

    /// <summary>
    /// Obtiene los detalles (items) de una compra
    /// </summary>
    /// <param name="compraId">ID de la compra</param>
    /// <returns>Lista de detalles de la compra</returns>
    Task<List<DetalleCompra>> GetDetallesAsync(Guid compraId);
}

