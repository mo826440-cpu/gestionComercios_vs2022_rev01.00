using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Stock
/// Proporciona operaciones para gestionar stock de productos
/// </summary>
public interface IStockService
{
    /// <summary>
    /// Obtiene todo el stock de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de registros de stock</returns>
    Task<List<Stock>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene un registro de stock por su ID
    /// </summary>
    /// <param name="id">ID del registro de stock</param>
    /// <returns>El stock si existe, null en caso contrario</returns>
    Task<Stock?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtiene el stock de un producto específico
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="productoId">ID del producto</param>
    /// <returns>El registro de stock si existe, null en caso contrario</returns>
    Task<Stock?> GetByProductoAsync(Guid comercioId, Guid productoId);

    /// <summary>
    /// Crea un nuevo registro de stock
    /// </summary>
    /// <param name="stock">Registro de stock a crear</param>
    /// <returns>El stock creado</returns>
    Task<Stock> CreateAsync(Stock stock);

    /// <summary>
    /// Actualiza un registro de stock existente
    /// </summary>
    /// <param name="stock">Stock con los datos actualizados</param>
    /// <returns>El stock actualizado</returns>
    Task<Stock> UpdateAsync(Stock stock);

    /// <summary>
    /// Elimina un registro de stock
    /// </summary>
    /// <param name="id">ID del stock a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Ajusta el stock de un producto (suma o resta cantidad)
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="productoId">ID del producto</param>
    /// <param name="cantidad">Cantidad a ajustar (positiva para aumentar, negativa para disminuir)</param>
    /// <returns>El registro de stock actualizado</returns>
    Task<Stock> AjustarStockAsync(Guid comercioId, Guid productoId, decimal cantidad);

    /// <summary>
    /// Obtiene todos los productos con stock bajo (cantidad menor o igual a cantidad mínima)
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de productos con stock bajo</returns>
    Task<List<Stock>> GetStockBajoAsync(Guid comercioId);
}

