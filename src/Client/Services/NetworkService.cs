using Microsoft.JSInterop;

namespace Client.Services;

/// <summary>
/// Servicio para detectar estado de conexión a internet
/// </summary>
public class NetworkService : INetworkService, IDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private DotNetObjectReference<NetworkService>? _dotNetRef;
    private bool _isOnline = true;

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
            _isOnline = await _jsRuntime.InvokeAsync<bool>("navigator.onLine");
            return _isOnline;
        }
        catch
        {
            _isOnline = false;
            return false;
        }
    }

    public async Task InitializeAsync()
    {
        _dotNetRef = DotNetObjectReference.Create(this);
        await _jsRuntime.InvokeVoidAsync("registerNetworkService", _dotNetRef);
        _isOnline = await IsOnlineAsync();
    }

    [JSInvokable]
    public void OnOnline()
    {
        _isOnline = true;
        OnConnectionChanged?.Invoke(true);
    }

    [JSInvokable]
    public void OnOffline()
    {
        _isOnline = false;
        OnConnectionChanged?.Invoke(false);
    }

    public void Dispose()
    {
        _dotNetRef?.Dispose();
    }
}

