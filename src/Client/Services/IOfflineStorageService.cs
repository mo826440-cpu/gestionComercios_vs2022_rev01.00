namespace Client.Services;

/// <summary>
/// Servicio para manejar almacenamiento offline
/// Guarda datos en IndexedDB cuando no hay conexión
/// </summary>
public interface IOfflineStorageService
{
    /// <summary>
    /// Guarda una entidad en IndexedDB como pendiente de sincronización
    /// </summary>
    Task SavePendingAsync<T>(string storeName, string key, T entity) where T : class;

    /// <summary>
    /// Obtiene todas las entidades pendientes de un store
    /// </summary>
    Task<List<T>> GetPendingAsync<T>(string storeName) where T : class;

    /// <summary>
    /// Marca una entidad como sincronizada (elimina de pendientes)
    /// </summary>
    Task MarkAsSyncedAsync(string storeName, string key);

    /// <summary>
    /// Obtiene el conteo de elementos pendientes de sincronización
    /// </summary>
    Task<int> GetPendingCountAsync(string storeName);
}

