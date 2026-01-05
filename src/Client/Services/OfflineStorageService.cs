using Shared.Interfaces;
using System.Text.Json;

namespace Client.Services;

/// <summary>
/// Servicio para manejar almacenamiento offline
/// Guarda datos en IndexedDB cuando no hay conexión
/// </summary>
public class OfflineStorageService : IOfflineStorageService
{
    private readonly IIndexedDbService _indexedDbService;

    public OfflineStorageService(IIndexedDbService indexedDbService)
    {
        _indexedDbService = indexedDbService;
    }

    public async Task SavePendingAsync<T>(string storeName, string key, T entity) where T : class
    {
        // Guardar en IndexedDB con metadata de sincronización
        var syncItem = new SyncItem<T>
        {
            Key = key,
            Entity = entity,
            CreatedAt = DateTime.UtcNow,
            SyncStatus = SyncStatus.Pending
        };

        await _indexedDbService.SaveAsync(storeName, key, syncItem);
    }

    public async Task<List<T>> GetPendingAsync<T>(string storeName) where T : class
    {
        var allItems = await _indexedDbService.GetAllAsync<SyncItem<T>>(storeName);
        return allItems
            .Where(item => item.SyncStatus == SyncStatus.Pending)
            .Select(item => item.Entity)
            .ToList();
    }

    public async Task MarkAsSyncedAsync(string storeName, string key)
    {
        // Eliminar de pendientes (ya está sincronizado)
        await _indexedDbService.DeleteAsync(storeName, key);
    }

    public async Task<int> GetPendingCountAsync(string storeName)
    {
        try
        {
            var allItems = await _indexedDbService.GetAllAsync<SyncItem<object>>(storeName);
            return allItems.Count(item => item.SyncStatus == SyncStatus.Pending);
        }
        catch
        {
            return 0;
        }
    }

    private class SyncItem<T>
    {
        public string Key { get; set; } = string.Empty;
        public T Entity { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public SyncStatus SyncStatus { get; set; }
    }

    private enum SyncStatus
    {
        Pending,
        Synced
    }
}

