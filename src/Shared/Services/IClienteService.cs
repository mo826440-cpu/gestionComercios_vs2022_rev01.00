using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Clientes
/// Proporciona operaciones CRUD para clientes
/// </summary>
public interface IClienteService
{
    /// <summary>
    /// Obtiene todos los clientes de un comercio
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <returns>Lista de clientes</returns>
    Task<List<Cliente>> GetAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene un cliente por su ID
    /// </summary>
    /// <param name="id">ID del cliente</param>
    /// <returns>El cliente si existe, null en caso contrario</returns>
    Task<Cliente?> GetByIdAsync(Guid id);

    /// <summary>
    /// Crea un nuevo cliente
    /// </summary>
    /// <param name="cliente">Cliente a crear</param>
    /// <returns>El cliente creado</returns>
    Task<Cliente> CreateAsync(Cliente cliente);

    /// <summary>
    /// Actualiza un cliente existente
    /// </summary>
    /// <param name="cliente">Cliente con los datos actualizados</param>
    /// <returns>El cliente actualizado</returns>
    Task<Cliente> UpdateAsync(Cliente cliente);

    /// <summary>
    /// Elimina un cliente
    /// </summary>
    /// <param name="id">ID del cliente a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Busca clientes por término de búsqueda (nombre, email, teléfono, documento)
    /// </summary>
    /// <param name="comercioId">ID del comercio</param>
    /// <param name="searchTerm">Término de búsqueda</param>
    /// <returns>Lista de clientes que coinciden con la búsqueda</returns>
    Task<List<Cliente>> SearchAsync(Guid comercioId, string searchTerm);
}

