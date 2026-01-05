using Client.Models;
using Shared.DTOs;
using Shared.Models;
using Shared.Services;

namespace Client.Services;

/// <summary>
/// Servicio para manejar sincronización offline/online
/// Integra IndexedDB con Supabase
/// </summary>
public class SyncManagerService : ISyncManagerService, IDisposable
{
    private readonly INetworkService _networkService;
    private readonly IOfflineStorageService _offlineStorage;
    private readonly IIndexedDbService _indexedDb;
    private readonly ISupabaseService _supabaseService;
    private readonly IProductoService _productoService;
    private readonly IClienteService _clienteService;
    private readonly IVentaService _ventaService;
    private readonly ICompraService _compraService;
    private readonly IToastService _toastService;
    private bool _initialized = false;

    public SyncManagerService(
        INetworkService networkService,
        IOfflineStorageService offlineStorage,
        IIndexedDbService indexedDb,
        ISupabaseService supabaseService,
        IProductoService productoService,
        IClienteService clienteService,
        IVentaService ventaService,
        ICompraService compraService,
        IToastService toastService)
    {
        _networkService = networkService;
        _offlineStorage = offlineStorage;
        _indexedDb = indexedDb;
        _supabaseService = supabaseService;
        _productoService = productoService;
        _clienteService = clienteService;
        _ventaService = ventaService;
        _compraService = compraService;
        _toastService = toastService;
    }

    public async Task InitializeAsync()
    {
        if (_initialized) return;

        // Inicializar IndexedDB
        await _indexedDb.InitializeAsync();

        // Suscribirse a cambios de conexión
        _networkService.OnConnectionChanged += OnConnectionChanged;

        _initialized = true;
    }

    private async void OnConnectionChanged(bool isOnline)
    {
        if (isOnline)
        {
            // Cuando vuelve la conexión, SyncStatus se encargará de sincronizar
            // No sincronizamos aquí porque no tenemos comercioId disponible
        }
    }

    public async Task SyncAllPendingAsync(Guid comercioId)
    {
        if (!_networkService.IsOnline)
        {
            _toastService.ShowWarning("No hay conexión. Los datos se sincronizarán cuando se restaure la conexión.");
            return;
        }

        try
        {
            int syncedCount = 0;

            // Sincronizar productos
            syncedCount += await SyncProductosAsync(comercioId);

            // Sincronizar clientes
            syncedCount += await SyncClientesAsync(comercioId);

            // Sincronizar ventas
            syncedCount += await SyncVentasAsync(comercioId);

            // Sincronizar compras
            syncedCount += await SyncComprasAsync(comercioId);

            if (syncedCount > 0)
            {
                _toastService.ShowSuccess($"{syncedCount} registro(s) sincronizado(s) correctamente");
            }
        }
        catch (Exception ex)
        {
            _toastService.ShowError($"Error al sincronizar: {ex.Message}");
        }
    }

    private async Task<int> SyncProductosAsync(Guid comercioId)
    {
        var pending = await _offlineStorage.GetPendingAsync<Producto>("productos");
        int count = 0;

        foreach (var producto in pending)
        {
            try
            {
                // Asignar ID si no tiene (nuevo)
                if (producto.Id == Guid.Empty)
                {
                    producto.Id = Guid.NewGuid();
                }

                producto.ComercioId = comercioId;
                await _productoService.CreateAsync(producto);

                // Marcar como sincronizado
                await _offlineStorage.MarkAsSyncedAsync("productos", producto.Id.ToString());
                count++;
            }
            catch
            {
                // Continuar con el siguiente si hay error
            }
        }

        return count;
    }

    private async Task<int> SyncClientesAsync(Guid comercioId)
    {
        var pending = await _offlineStorage.GetPendingAsync<Cliente>("clientes");
        int count = 0;

        foreach (var cliente in pending)
        {
            try
            {
                if (cliente.Id == Guid.Empty)
                {
                    cliente.Id = Guid.NewGuid();
                }

                cliente.ComercioId = comercioId;
                await _clienteService.CreateAsync(cliente);

                await _offlineStorage.MarkAsSyncedAsync("clientes", cliente.Id.ToString());
                count++;
            }
            catch
            {
                // Continuar con el siguiente
            }
        }

        return count;
    }

    private async Task<int> SyncVentasAsync(Guid comercioId)
    {
        var pending = await _offlineStorage.GetPendingAsync<VentaConDetalles>("ventas");
        int count = 0;

        foreach (var ventaConDetalles in pending)
        {
            try
            {
                var venta = ventaConDetalles.Venta;
                var detalles = ventaConDetalles.Detalles;

                if (venta.Id == Guid.Empty)
                {
                    venta.Id = Guid.NewGuid();
                }

                venta.ComercioId = comercioId;
                venta.Fecha = venta.Fecha != default ? venta.Fecha : DateTime.UtcNow;
                venta.CreatedAt = venta.CreatedAt != default ? venta.CreatedAt : DateTime.UtcNow;

                // Crear DTO con los detalles
                var ventaDto = new CreateVentaDto
                {
                    ComercioId = venta.ComercioId,
                    ClienteId = venta.ClienteId,
                    UsuarioId = venta.UsuarioId,
                    CajaId = venta.CajaId,
                    Fecha = venta.Fecha,
                    Descuento = venta.Descuento,
                    Observaciones = venta.Observaciones,
                    Detalles = detalles.Select(d => new DetalleVentaItemDto
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        Descuento = d.Descuento
                    }).ToList()
                };

                // Crear la venta en Supabase (incluye detalles)
                await _ventaService.CreateAsync(ventaDto);

                await _offlineStorage.MarkAsSyncedAsync("ventas", venta.Id.ToString());
                count++;
            }
            catch
            {
                // Continuar con el siguiente si hay error
            }
        }

        return count;
    }

    private async Task<int> SyncComprasAsync(Guid comercioId)
    {
        var pending = await _offlineStorage.GetPendingAsync<CompraConDetalles>("compras");
        int count = 0;

        foreach (var compraConDetalles in pending)
        {
            try
            {
                var compra = compraConDetalles.Compra;
                var detalles = compraConDetalles.Detalles;

                if (compra.Id == Guid.Empty)
                {
                    compra.Id = Guid.NewGuid();
                }

                compra.ComercioId = comercioId;
                compra.Fecha = compra.Fecha != default ? compra.Fecha : DateTime.UtcNow;
                compra.CreatedAt = compra.CreatedAt != default ? compra.CreatedAt : DateTime.UtcNow;

                // Crear DTO con los detalles
                var compraDto = new CreateCompraDto
                {
                    ComercioId = compra.ComercioId,
                    ProveedorId = compra.ProveedorId,
                    Fecha = compra.Fecha,
                    Descuento = compra.Descuento,
                    NumeroFactura = compra.NumeroFactura,
                    Observaciones = compra.Observaciones,
                    Detalles = detalles.Select(d => new DetalleCompraItemDto
                    {
                        ProductoId = d.ProductoId,
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        Descuento = d.Descuento
                    }).ToList()
                };

                // Crear la compra en Supabase (incluye detalles)
                await _compraService.CreateAsync(compraDto);

                await _offlineStorage.MarkAsSyncedAsync("compras", compra.Id.ToString());
                count++;
            }
            catch
            {
                // Continuar con el siguiente si hay error
            }
        }

        return count;
    }

    public async Task<int> GetTotalPendingCountAsync(Guid comercioId)
    {
        try
        {
            int total = 0;
            total += await _offlineStorage.GetPendingCountAsync("productos");
            total += await _offlineStorage.GetPendingCountAsync("clientes");
            total += await _offlineStorage.GetPendingCountAsync("ventas");
            total += await _offlineStorage.GetPendingCountAsync("compras");
            return total;
        }
        catch
        {
            return 0;
        }
    }

    public void Dispose()
    {
        _networkService.OnConnectionChanged -= OnConnectionChanged;
    }
}

