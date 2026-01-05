using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using Supabase.Postgrest;

namespace Shared.Services;

/// <summary>
/// Servicio para sincronización offline
/// Gestiona la sincronización de datos con sync_id pendiente
/// </summary>
public class SyncService : ISyncService
{
    private readonly ISupabaseService _supabaseService;

    public SyncService(ISupabaseService supabaseService)
    {
        _supabaseService = supabaseService;
    }

    public async Task SyncAllAsync(Guid comercioId)
    {
        // Nota: La sincronización completa se implementará cuando tengamos
        // IndexedDB configurado. Por ahora, este servicio está preparado
        // para la estructura futura.

        // TODO: Implementar sincronización de:
        // - Productos con sync_id
        // - Clientes con sync_id
        // - Ventas con sync_id
        // - Compras con sync_id
        // - etc.

        await Task.CompletedTask;
    }

    public async Task<int> GetPendingSyncCountAsync(Guid comercioId)
    {
        // TODO: Contar registros pendientes de sincronización
        // Por ahora retornamos 0
        return await Task.FromResult(0);
    }

    public async Task<bool> IsOnlineAsync()
    {
        try
        {
            // Intentar hacer una petición simple a Supabase
            var response = await _supabaseService.Client
                .From<Comercio>()
                .Limit(1)
                .Get();

            return true;
        }
        catch
        {
            return false;
        }
    }
}

