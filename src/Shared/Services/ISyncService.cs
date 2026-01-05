namespace Shared.Services;

/// <summary>
/// Interfaz para el servicio de sincronización offline
/// Gestiona la sincronización de datos cuando hay conexión
/// </summary>
public interface ISyncService
{
    /// <summary>
    /// Sincroniza todos los datos pendientes
    /// </summary>
    Task SyncAllAsync(Guid comercioId);

    /// <summary>
    /// Obtiene el número de registros pendientes de sincronización
    /// </summary>
    Task<int> GetPendingSyncCountAsync(Guid comercioId);

    /// <summary>
    /// Verifica si hay conexión a internet
    /// </summary>
    Task<bool> IsOnlineAsync();
}

