using Microsoft.JSInterop;

namespace Client.Services;

/// <summary>
/// Servicio para detectar estado de conexión a internet
/// </summary>
public class NetworkService : INetworkService, IDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<NetworkService>? _dotNetRef;
    private bool _isOnline = true; // Por defecto asumir online (mejor UX)

    public NetworkService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public event Action<bool>? OnConnectionChanged;

    public bool IsOnline => _isOnline;

    public async Task<bool> IsOnlineAsync()
    {
        try
        {
            // Usar navigator.onLine como indicador primario
            // Nota: navigator.onLine puede dar falsos positivos, pero es mejor asumir online
            // para no mostrar el mensaje innecesariamente
            _isOnline = await _jsRuntime.InvokeAsync<bool>("eval", "navigator.onLine");
            return _isOnline;
        }
        catch
        {
            // Si hay error, asumir online por defecto (mejor UX)
            _isOnline = true;
            return true;
        }
    }

    public async Task InitializeAsync()
    {
        _dotNetRef = DotNetObjectReference.Create(this);
        await _jsRuntime.InvokeVoidAsync("registerNetworkService", _dotNetRef);
        // Verificar estado inicial
        _isOnline = await IsOnlineAsync();
    }

    [JSInvokable]
    public void OnOnline()
    {
        var wasOnline = _isOnline;
        _isOnline = true;
        
        if (!wasOnline)
        {
            OnConnectionChanged?.Invoke(true);
        }
    }

    [JSInvokable]
    public void OnOffline()
    {
        var wasOnline = _isOnline;
        _isOnline = false;
        
        if (wasOnline)
        {
            OnConnectionChanged?.Invoke(false);
        }
    }

    public void Dispose()
    {
        _dotNetRef?.Dispose();
    }
}

