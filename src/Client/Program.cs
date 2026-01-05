using Client;
using Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Shared.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configurar servicio de Supabase
builder.Services.AddScoped<ISupabaseService, SupabaseService>();

// Configurar servicio de autenticación
builder.Services.AddScoped<IAuthService, AuthService>();

// Configurar servicio de autorización
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

// Configurar servicios de entidades
builder.Services.AddScoped<IComercioService, ComercioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<IStockService, StockService>();

// Configurar servicios de negocio
builder.Services.AddScoped<ISyncService, SyncService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<ICalculationService, CalculationService>();

// Configurar servicios del cliente
builder.Services.AddScoped<IToastService, ToastService>();
builder.Services.AddSingleton<INetworkService, NetworkService>();
builder.Services.AddScoped<IIndexedDbService, IndexedDbService>();
builder.Services.AddScoped<IOfflineStorageService, OfflineStorageService>();
builder.Services.AddScoped<ISyncManagerService, SyncManagerService>();

await builder.Build().RunAsync();
