namespace Client.Services;

/// <summary>
/// Servicio para manejar sincronización offline/online
/// Integra IndexedDB con Supabase
/// </summary>
public interface ISyncManagerService
{
    /// <summary>
    /// Sincroniza todos los datos pendientes desde IndexedDB hacia Supabase
    /// </summary>
    Task SyncAllPendingAsync(Guid comercioId);

    /// <summary>
    /// Obtiene el conteo total de items pendientes de sincronización
    /// </summary>
    Task<int> GetTotalPendingCountAsync(Guid comercioId);

    /// <summary>
    /// Inicializa el servicio y se suscribe a cambios de conexión
    /// </summary>
    Task InitializeAsync();
}

