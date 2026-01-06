using Shared.Models;

namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de Comercios
/// Proporciona operaciones CRUD para comercios
/// </summary>
public interface IComercioService
{
    /// <summary>
    /// Obtiene todos los comercios
    /// </summary>
    /// <returns>Lista de comercios</returns>
    Task<List<Comercio>> GetAllAsync();

    /// <summary>
    /// Obtiene un comercio por su ID
    /// </summary>
    /// <param name="id">ID del comercio</param>
    /// <returns>El comercio si existe, null en caso contrario</returns>
    Task<Comercio?> GetByIdAsync(Guid id);

    /// <summary>
    /// Crea un nuevo comercio
    /// </summary>
    /// <param name="comercio">Comercio a crear</param>
    /// <returns>El comercio creado</returns>
    Task<Comercio> CreateAsync(Comercio comercio);

    /// <summary>
    /// Actualiza un comercio existente
    /// </summary>
    /// <param name="comercio">Comercio con los datos actualizados</param>
    /// <returns>El comercio actualizado</returns>
    Task<Comercio> UpdateAsync(Comercio comercio);

    /// <summary>
    /// Elimina un comercio
    /// </summary>
    /// <param name="id">ID del comercio a eliminar</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Busca un comercio por su email
    /// </summary>
    /// <param name="email">Email del comercio</param>
    /// <returns>El comercio si existe, null en caso contrario</returns>
    Task<Comercio?> GetByEmailAsync(string email);

    /// <summary>
    /// Obtiene un comercio por su ID público
    /// </summary>
    /// <param name="idPublico">ID público del comercio (formato: 01, 02, etc.)</param>
    /// <returns>El comercio si existe, null en caso contrario</returns>
    Task<Comercio?> GetByIdPublicoAsync(string idPublico);
}

