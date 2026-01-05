namespace Client.Services;

/// <summary>
/// Servicio para manejar almacenamiento local usando IndexedDB
/// Permite guardar y recuperar datos cuando no hay conexión
/// </summary>
public interface IIndexedDbService
{
    /// <summary>
    /// Inicializa la base de datos IndexedDB
    /// </summary>
    Task InitializeAsync();

    /// <summary>
    /// Guarda un objeto en IndexedDB
    /// </summary>
    Task SaveAsync<T>(string storeName, string key, T value) where T : class;

    /// <summary>
    /// Obtiene un objeto de IndexedDB
    /// </summary>
    Task<T?> GetAsync<T>(string storeName, string key) where T : class;

    /// <summary>
    /// Obtiene todos los objetos de un store
    /// </summary>
    Task<List<T>> GetAllAsync<T>(string storeName) where T : class;

    /// <summary>
    /// Elimina un objeto de IndexedDB
    /// </summary>
    Task DeleteAsync(string storeName, string key);

    /// <summary>
    /// Limpia todos los datos de un store
    /// </summary>
    Task ClearAsync(string storeName);

    /// <summary>
    /// Verifica si existe una clave en el store
    /// </summary>
    Task<bool> ExistsAsync(string storeName, string key);
}

