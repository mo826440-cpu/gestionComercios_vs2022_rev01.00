namespace Client.Services;

/// <summary>
/// Servicio para detectar estado de conexión a internet
/// </summary>
public interface INetworkService
{
    /// <summary>
    /// Evento que se dispara cuando cambia el estado de conexión
    /// </summary>
    event Action<bool>? OnConnectionChanged;

    /// <summary>
    /// Verifica si hay conexión a internet
    /// </summary>
    Task<bool> IsOnlineAsync();

    /// <summary>
    /// Estado actual de conexión
    /// </summary>
    bool IsOnline { get; }

    /// <summary>
    /// Inicializa el servicio y registra los event listeners
    /// </summary>
    Task InitializeAsync();
}

