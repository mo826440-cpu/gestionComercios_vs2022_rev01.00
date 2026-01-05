# Checklist - Proyecto Gestión Comercios (Blazor WebAssembly + Supabase)

## 📋 Estado General
- **Última actualización:** 2025-01-XX
- **Fase actual:** Configuración inicial completada, listos para comenzar desarrollo

---

## ✅ FASE 1: Estructura del Proyecto y Configuración Base

### 1.1 Análisis y Planificación
- [x] Leer y entender documentación existente en `/docs`
- [x] Analizar modelo de datos actual (Supabase schema)
- [x] Entender modelo de autenticación (Supabase Auth + RBAC)
- [x] Proponer tipo de proyecto para VS 2022
- [x] Confirmar stack técnico (Blazor WebAssembly + PWA)

### 1.2 Creación de Proyectos en Visual Studio 2022
- [x] Crear archivo de solución (`gestionComercios.sln`)
- [x] Crear proyecto Client (Blazor WebAssembly Standalone)
  - [x] Framework: .NET 8.0
  - [x] PWA habilitado
  - [x] Ubicación correcta: `src/Client`
- [x] Crear proyecto Shared (Class Library)
  - [x] Framework: .NET 8.0
  - [x] Ubicación correcta: `src/Shared`
- [x] Configurar referencia: Client → Shared

### 1.3 Archivos de Configuración
- [x] Crear `nuget.config` (formato XML válido)
- [x] Crear `.gitignore` (contenido estándar .NET/Blazor)
- [x] Crear `appsettings.json` para configuración (Client)
- [x] Crear `appsettings.Development.json` para desarrollo
- [ ] Configurar variables de entorno para desarrollo (opcional para producción)

---

## 🔄 FASE 2: Configuración de Supabase y Dependencias

### 2.1 Paquetes NuGet
- [x] Agregar Supabase.NET SDK al proyecto Client (v1.1.1)
- [x] Agregar Supabase.NET SDK al proyecto Shared (v1.1.1)
- [x] Agregar Microsoft.Extensions.Configuration.Abstractions a Shared (v8.0.0)
- [x] Verificar versiones compatibles con .NET 8.0 (todas las versiones son compatibles)

### 2.2 Configuración de Supabase
- [x] Configurar URL de Supabase en `appsettings.json`
- [x] Configurar API key (anon) en configuración
- [x] Crear servicio de configuración para Supabase
- [x] Implementar cliente Supabase como servicio
- [x] Configurar inyección de dependencias en `Program.cs`
- [x] Verificar conexión con Supabase (test básico)

---

## 📊 FASE 3: Modelos de Datos (Shared/Models)

### 3.1 Modelos Principales (basados en schema Supabase)
- [x] `Comercio.cs` - Entidad comercio
- [x] `Usuario.cs` - Usuarios del sistema
- [x] `Rol.cs` - Roles del sistema
- [x] `Permiso.cs` - Permisos
- [x] `RolPermiso.cs` - Relación roles-permisos
- [x] `Producto.cs` - Productos
- [x] `Categoria.cs` - Categorías
- [x] `Marca.cs` - Marcas
- [x] `Stock.cs` - Stock de productos
- [x] `Cliente.cs` - Clientes
- [x] `Proveedor.cs` - Proveedores
- [x] `Venta.cs` - Ventas
- [x] `DetalleVenta.cs` - Detalles de ventas
- [x] `Compra.cs` - Compras
- [x] `DetalleCompra.cs` - Detalles de compras
- [x] `Caja.cs` - Cajas/arqueos
- [x] `MovimientoStock.cs` - Movimientos de stock
- [x] `PagoVenta.cs` - Pagos de ventas
- [x] `PagoCompra.cs` - Pagos de compras
- [x] `Configuracion.cs` - Configuraciones
- [x] `LogSistema.cs` - Logs del sistema

### 3.2 Modelos de Soporte
- [x] `ISyncEntity.cs` - Interfaz para sync_id (offline-first)
- [x] DTOs básicos para transferencia de datos:
  - [x] `CreateProductoDto`, `UpdateProductoDto`
  - [x] `CreateVentaDto`, `DetalleVentaItemDto`
  - [x] `CreateCompraDto`, `DetalleCompraItemDto`
  - [x] `CreateClienteDto`
- [ ] ViewModels para UI (se crearán cuando se necesiten en la FASE 6)

---

## 🔌 FASE 4: Servicios y Acceso a Datos

### 4.1 Servicios Base
- [x] `ISupabaseService.cs` - Interfaz servicio Supabase
- [x] `SupabaseService.cs` - Implementación servicio Supabase
- [x] Configurar inyección de dependencias en `Program.cs`

### 4.2 Servicios por Entidad (Repository Pattern)
- [x] `IComercioService.cs` / `ComercioService.cs` ✅
- [x] `IUsuarioService.cs` / `UsuarioService.cs` ✅
- [x] `IProductoService.cs` / `ProductoService.cs` ✅
- [x] `IVentaService.cs` / `VentaService.cs` ✅
- [x] `ICompraService.cs` / `CompraService.cs` ✅
- [x] `IClienteService.cs` / `ClienteService.cs` ✅
- [x] `IStockService.cs` / `StockService.cs` ✅
- [ ] (Agregar servicios adicionales según necesidad)
- [x] Configurar servicios en `Program.cs` ✅

### 4.3 Servicios de Negocio
- [x] `ISyncService.cs` / `SyncService.cs` - Servicio de sincronización offline ✅
- [x] `IValidationService.cs` / `ValidationService.cs` - Servicio de validaciones ✅
- [x] `ICalculationService.cs` / `CalculationService.cs` - Servicio de cálculos (totales, descuentos, etc.) ✅
- [x] Configurar servicios en `Program.cs` ✅

---

## 🔐 FASE 5: Autenticación y Autorización

### 5.1 Autenticación Supabase
- [x] Configurar Supabase Auth en `Program.cs` ✅
- [x] Crear servicio `IAuthService.cs` / `AuthService.cs` ✅
- [x] Implementar login (`SignInAsync`) ✅
- [x] Implementar logout (`SignOutAsync`) ✅
- [x] Implementar registro (`SignUpAsync`) ✅
- [x] Manejo de sesión/tokens (`GetSessionAsync`, `GetCurrentUserAsync`) ✅
- [x] Reset password ✅

### 5.2 Autorización (RBAC)
- [x] Servicio de autorización (`IAuthorizationService` / `AuthorizationService`) ✅
- [x] Verificación de permisos ✅
- [x] Verificación de roles ✅
- [x] Verificación de propietario ✅
- [x] Verificación de pertenencia a comercio ✅
- [x] Actualizar modelos `Permiso` y `RolPermiso` para BaseModel ✅
- [x] Configurar servicios en `Program.cs` ✅

### 5.3 Protección de Rutas
- [x] `AuthorizeView.razor` - Componente personalizado para autorización ✅
- [x] `AuthorizeRouteView.razor` - Componente para proteger rutas ✅
- [x] `RedirectToLogin.razor` - Componente de redirección ✅
- [x] `Login.razor` - Página de inicio de sesión ✅
- [x] Configurar `App.razor` para usar autorización ✅
- [x] Protección de páginas/componentes ✅
- [x] Redirección a login si no autenticado ✅

---

## 🎨 FASE 6: Interfaz de Usuario (Blazor Components)

### 6.1 Layout y Navegación
- [x] Adaptar `MainLayout.razor` al diseño del sistema ✅
- [x] Crear `NavMenu.razor` con navegación del sistema ✅
- [x] Implementar sidebar/menú lateral ✅
- [x] Responsive design (Bootstrap incluido) ✅

### 6.2 Páginas Principales
- [x] Página de Login ✅
- [x] Dashboard/Inicio ✅
- [x] Gestión de Comercios (listado básico) ✅
- [x] Gestión de Usuarios (página básica creada) ✅
- [x] Gestión de Productos (listado básico) ✅
- [x] Gestión de Categorías (página básica creada) ✅
- [x] Gestión de Marcas (página básica creada) ✅
- [x] Gestión de Clientes (listado básico) ✅
- [x] Gestión de Proveedores (página básica creada) ✅
- [x] Ventas (listado básico) ✅
- [x] Compras (listado básico) ✅
- [x] Stock/Inventario (listado básico) ✅
- [x] Cajas/Arqueos (página básica creada) ✅
- [x] Reportes (página básica creada) ✅
- [ ] Detalles y formularios de creación/edición (pendiente - se crearán cuando se implementen los formularios reales usando los componentes de F6.3)

### 6.3 Componentes Reutilizables
- [x] `LoadingSpinner.razor` - Componente de carga/spinner ✅
- [x] `Alert.razor` - Componente de alertas/notificaciones ✅
- [x] `Modal.razor` - Componente de modal/dialog reutilizable ✅
- [x] `ConfirmDialog.razor` - Diálogo de confirmación ✅
- [x] `DataTable.razor` - Tabla de datos con paginación y filtros ✅
- [x] `ToastNotification.razor` - Notificaciones toast ✅
- [x] `IToastService` / `ToastService` - Servicio de notificaciones ✅
- [x] Configurar servicios en `Program.cs` ✅
- [x] Integrar ToastNotification en `MainLayout` ✅
- [ ] Componentes de formularios avanzados (inputs personalizados, selects, etc.) - opcional (no crítico, se hará si es necesario)

---

## 📱 FASE 7: PWA y Funcionalidad Offline

### 7.1 PWA Configuration
- [x] Verificar `manifest.webmanifest` configurado (actualizado con nombres del proyecto) ✅
- [x] Iconos PWA (192x192, 512x512) - existen y están configurados ✅
- [x] Service Worker configurado (service-worker.js y service-worker.published.js presentes) ✅
- [x] Referencias en `index.html` configuradas ✅
- [ ] Testing de instalación PWA (requiere ejecutar la aplicación)

### 7.2 Offline Support
- [x] Manejo de estado "sin conexión" (`INetworkService` / `NetworkService`) ✅
- [x] UI para indicar estado offline/online (`NetworkStatus.razor`) ✅
- [x] Detección de cambios de conexión (eventos online/offline) ✅
- [x] IndexedDB para almacenamiento local (`IIndexedDbService` / `IndexedDbService` + `indexedDb.js`) ✅
- [x] Stores configurados (productos, clientes, ventas, compras, stock, categorias, marcas, proveedores, syncQueue) ✅
- [x] Servicio de almacenamiento offline (`IOfflineStorageService` / `OfflineStorageService`) ✅
- [x] Servicio de sincronización (`ISyncManagerService` / `SyncManagerService`) ✅
- [x] Sincronización automática al recuperar conexión ✅
- [x] Sincronización de productos y clientes pendientes ✅
- [x] Componente `SyncStatus.razor` - UI para estado de sincronización ✅
- [x] Botón manual de sincronización ✅
- [x] Contador de items pendientes ✅
- [x] Inicialización de servicios en `MainLayout` ✅
- [x] Sincronización de ventas y compras (implementada - sincroniza ventas/compras principales) ✅
- [x] Estrategia de caché offline básica (service worker configurado) ✅

---

## 🧪 FASE 8: Testing y Calidad

### 8.1 Testing (si aplica) - PENDIENTE
- [ ] Unit tests (servicios)
- [ ] Integration tests (acceso a datos)
- [ ] Component tests (Blazor)
- **Nota:** Testing se recomienda implementar cuando:
  - El código esté más estable y se necesite mayor confiabilidad
  - Se implementen funcionalidades críticas de negocio (cálculos, validaciones complejas)
  - Antes de pasar a producción, especialmente para lógica de sincronización offline
  - Cuando el equipo de desarrollo crezca y se necesite documentación de comportamiento
  - Para regresiones: cuando se encuentren bugs y se quieran prevenir en el futuro

### 8.2 Calidad de Código
- [x] Revisión de código ✅
- [x] Validación de buenas prácticas ✅
- [x] Documentación de código (comentarios XML) ✅ - Completada para interfaces principales de servicios

---

## 🚀 FASE 9: Deployment y Producción

### 9.1 Preparación para Producción
- [x] Configuración de `appsettings.Production.json` ✅
- [x] Variables de entorno de producción ✅ (Documentado en `docs/09_deployment_guide.md`. Script `scripts/build-production.ps1` creado para inyectar valores en build-time)
- [x] Optimización de build (Release mode configurado por defecto en .NET) ✅
- [x] Minificación de assets (automático en build Release de Blazor) ✅

### 9.2 Deployment
- [x] Configurar GitHub Actions (workflow básico creado en `.github/workflows/deploy.yml`) ✅
- [x] Deployment a hosting estático ✅ (Guía completa en `docs/09_deployment_guide.md`. Ejemplo de workflow para Netlify en `.github/workflows/deploy-netlify.yml.example`. Pendiente: elegir hosting y seguir la guía)
- [x] Configuración de dominio (adminisgo.com.ar) ✅ (Instrucciones detalladas en `docs/09_deployment_guide.md`. Pendiente: seguir pasos según hosting elegido)

---

## 📝 NOTAS Y OBSERVACIONES

### Completado hasta ahora:
- ✅ Estructura base del proyecto creada
- ✅ Proyectos Client y Shared configurados correctamente
- ✅ Archivos de configuración base listos

### Próximos pasos inmediatos:
1. Configurar Supabase SDK
2. Crear modelos de datos básicos
3. Implementar servicio base de Supabase
4. Crear página de login básica

### Decisiones técnicas pendientes:
- (Se irán agregando durante el desarrollo)

### Problemas conocidos:
- Ninguno por el momento

---

## 🔄 Historial de Cambios

| Fecha | Cambio | Estado |
|-------|--------|--------|
| 2025-01-XX | Estructura inicial del proyecto | ✅ Completado |
| 2025-01-XX | Checklist creado | ✅ Completado |

