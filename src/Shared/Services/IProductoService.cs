using Shared.Models;
using Supabase.Postgrest.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Productos
/// Proporciona operaciones CRUD para productos
/// </summary>
public interface IProductoService
{
    /// <summary>
    /// Obtiene todos los productos de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de productos</returns>
    Task<List<Producto>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene un producto por su ID
    /// </summary>
    /// <param name="id">ID del producto</param>
    /// <returns>El producto si existe, null en caso contrario</returns>
    Task<Producto?> GetByIdAsync(Guid id);

    /// <summary>
    /// Crea un nuevo producto
    /// </summary>
    /// <param name="producto">Producto a crear</param>
    /// <returns>El producto creado</returns>
    Task<Producto> CreateAsync(Producto producto);

    /// <summary>
    /// Actualiza un producto existente
    /// </summary>
    /// <param name="producto">Producto con los datos actualizados</param>
    /// <returns>El producto actualizado</returns>
    Task<Producto> UpdateAsync(Producto producto);

    /// <summary>
    /// Elimina un producto
    /// </summary>
    /// <param name="id">ID del producto a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Obtiene todos los productos de una categoría específica
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="categoriaId">ID de la categoría</param>
    /// <returns>Lista de productos de la categoría</returns>
    Task<List<Producto>> GetByCategoriaAsync(Guid comercioId, Guid categoriaId);

    /// <summary>
    /// Busca productos por término de búsqueda (nombre, código, descripción)
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="searchTerm">Término de búsqueda</param>
    /// <returns>Lista de productos que coinciden con la búsqueda</returns>
    Task<List<Producto>> SearchAsync(Guid comercioId, string searchTerm);
}

