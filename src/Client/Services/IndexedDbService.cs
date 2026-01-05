using Microsoft.JSInterop;
using System.Text.Json;

namespace Client.Services;

/// <summary>
/// Servicio para manejar almacenamiento local usando IndexedDB
/// Implementación usando JSInterop directo
/// </summary>
public class IndexedDbService : IIndexedDbService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _module;
    private const string DbName = "GestionComerciosDB";
    private const int DbVersion = 1;
    private bool _initialized = false;

    public IndexedDbService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;

        try
        {
            _module = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/indexedDb.js");
            await _module.InvokeVoidAsync("initializeDb", DbName, DbVersion);
            _initialized = true;
        }
        catch
        {
            // Si falla, simplemente no tenemos IndexedDB disponible
            _initialized = false;
        }
    }

    public async Task SaveAsync<T>(string storeName, string key, T value) where T : class
    {
        if (!_initialized || _module == null) return;

        try
        {
            var json = JsonSerializer.Serialize(value);
            await _module.InvokeVoidAsync("save", storeName, key, json);
        }
        catch
        {
            // Silently fail si no está disponible
        }
    }

    public async Task<T?> GetAsync<T>(string storeName, string key) where T : class
    {
        if (!_initialized || _module == null) return null;

        try
        {
            var json = await _module.InvokeAsync<string?>("get", storeName, key);
            if (string.IsNullOrEmpty(json)) return null;
            return JsonSerializer.Deserialize<T>(json);
        }
        catch
        {
            return null;
        }
    }

    public async Task<List<T>> GetAllAsync<T>(string storeName) where T : class
    {
        if (!_initialized || _module == null) return new List<T>();

        try
        {
            var json = await _module.InvokeAsync<string>("getAll", storeName);
            if (string.IsNullOrEmpty(json)) return new List<T>();
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        catch
        {
            return new List<T>();
        }
    }

    public async Task DeleteAsync(string storeName, string key)
    {
        if (!_initialized || _module == null) return;

        try
        {
            await _module.InvokeVoidAsync("delete", storeName, key);
        }
        catch
        {
            // Silently fail
        }
    }

    public async Task ClearAsync(string storeName)
    {
        if (!_initialized || _module == null) return;

        try
        {
            await _module.InvokeVoidAsync("clear", storeName);
        }
        catch
        {
            // Silently fail
        }
    }

    public async Task<bool> ExistsAsync(string storeName, string key)
    {
        if (!_initialized || _module == null) return false;

        try
        {
            return await _module.InvokeAsync<bool>("exists", storeName, key);
        }
        catch
        {
            return false;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_module != null)
        {
            await _module.DisposeAsync();
        }
    }
}

