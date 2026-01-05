namespace Shared.Interfaces;

/// <summary>
/// Interfaz para entidades que soportan sincronización offline
/// Las entidades que implementan esta interfaz tienen sync_id para manejar sincronización
/// </summary>
public interface ISyncEntity
{
    /// <summary>
    /// ID de sincronización usado para tracking offline
    /// Nullable porque se asigna después de sincronizar
    /// </summary>
    Guid? SyncId { get; set; }
}

