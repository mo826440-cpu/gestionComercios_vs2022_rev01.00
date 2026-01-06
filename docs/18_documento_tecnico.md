# Documento Técnico - Gestión Comercios

**Proyecto:** Sistema de Gestión para Comercios y Kioscos  
**Stack:** Blazor WebAssembly + Supabase  
**Versión:** 1.0.0 (En desarrollo)

---

## 📋 Índice

1. [Arquitectura General](#arquitectura-general)
2. [Stack Tecnológico](#stack-tecnológico)
3. [Estructura del Proyecto](#estructura-del-proyecto)
4. [Modelo de Datos](#modelo-de-datos)
5. [Autenticación y Autorización](#autenticación-y-autorización)
6. [Servicios y Lógica de Negocio](#servicios-y-lógica-de-negocio)
7. [Interfaz de Usuario](#interfaz-de-usuario)
8. [Funcionalidad Offline](#funcionalidad-offline)
9. [Despliegue y Hosting](#despliegue-y-hosting)
10. [Seguridad](#seguridad)

---

## 🏗️ Arquitectura General

### Tipo de Arquitectura

**Frontend SPA (Single Page Application) con Backend as a Service (BaaS)**

```
┌─────────────────────────────────────────────────────────────┐
│                    CLIENTE (Navegador)                      │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  Blazor WebAssembly (C# compilado a WebAssembly)    │  │
│  │  - Componentes Razor                                 │  │
│  │  - Lógica C# (Shared Library)                        │  │
│  │  - IndexedDB (Almacenamiento Local)                  │  │
│  └──────────────────────────────────────────────────────┘  │
│                        │                                    │
│                        │ HTTP/REST                          │
│                        ▼                                    │
└─────────────────────────────────────────────────────────────┘
                         │
                         │ HTTPS
                         ▼
┌─────────────────────────────────────────────────────────────┐
│                    SUPABASE (Backend)                       │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  PostgreSQL (Base de Datos)                          │  │
│  │  - Tablas de negocio                                 │  │
│  │  - Row Level Security (RLS)                          │  │
│  └──────────────────────────────────────────────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  Supabase Auth (Autenticación)                       │  │
│  │  - Usuarios y sesiones                               │  │
│  │  - JWT tokens                                        │  │
│  └──────────────────────────────────────────────────────┘  │
│  ┌──────────────────────────────────────────────────────┐  │
│  │  PostgREST API (API REST automática)                 │  │
│  │  - CRUD sobre tablas                                 │  │
│  │  - Filtros y consultas                               │  │
│  └──────────────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────────────┘
```

### Características Arquitectónicas

- **Offline-First:** IndexedDB como almacenamiento principal, Supabase como sincronización
- **Component-Based:** Componentes Blazor reutilizables
- **Service-Oriented:** Servicios separados por responsabilidad (Repository Pattern)
- **Type-Safe:** C# tipado fuerte en todo el stack
- **PWA:** Progressive Web App, instalable y offline-capable

---

## 🛠️ Stack Tecnológico

### Frontend

| Tecnología | Versión | Propósito |
|-----------|---------|-----------|
| **Blazor WebAssembly** | .NET 8.0 | Framework de UI (C# en el navegador) |
| **C#** | 12.0 | Lenguaje de programación |
| **Razor** | .NET 8.0 | Sintaxis de templates (HTML + C#) |
| **Bootstrap** | 5.x | Framework CSS (responsive) |
| **IndexedDB** | (API nativa) | Almacenamiento local del navegador |
| **Service Worker** | (PWA) | Cache y funcionamiento offline |

### Backend

| Tecnología | Versión | Propósito |
|-----------|---------|-----------|
| **Supabase** | Cloud | Backend as a Service |
| **PostgreSQL** | 17.6 (managed) | Base de datos relacional |
| **PostgREST** | (managed) | API REST automática |
| **Supabase Auth** | (managed) | Autenticación y autorización |
| **Row Level Security** | (PostgreSQL) | Seguridad a nivel de fila |

### Librerías y SDKs

| Paquete | Versión | Propósito |
|---------|---------|-----------|
| **Supabase.NET** | 1.1.1 | SDK de C# para Supabase |
| **Microsoft.Extensions.Configuration** | 8.0.0 | Configuración de la aplicación |

### Herramientas de Desarrollo

| Herramienta | Propósito |
|------------|-----------|
| **Visual Studio 2022** | IDE principal |
| **.NET SDK 8.0** | Compilador y runtime |
| **Git** | Control de versiones |
| **GitHub** | Repositorio remoto |
| **Cloudflare Pages** | Hosting estático (gratis) |

---

## 📁 Estructura del Proyecto

```
gestionComercios_vs2022_rev01.00/
├── gestionComercios.sln          # Archivo de solución Visual Studio
│
├── src/
│   ├── Client/                   # Proyecto Blazor WebAssembly
│   │   ├── Components/           # Componentes reutilizables
│   │   │   ├── Alert.razor
│   │   │   ├── Modal.razor
│   │   │   ├── DataTable.razor
│   │   │   ├── AuthorizeView.razor
│   │   │   └── ...
│   │   ├── Layout/               # Layouts de la aplicación
│   │   │   ├── MainLayout.razor
│   │   │   ├── LoginLayout.razor
│   │   │   └── NavMenu.razor
│   │   ├── Pages/                # Páginas/Componentes de rutas
│   │   │   ├── Landing.razor
│   │   │   ├── Login.razor
│   │   │   ├── Dashboard.razor
│   │   │   ├── Productos.razor
│   │   │   └── ...
│   │   ├── Services/             # Servicios del cliente
│   │   │   ├── IToastService.cs
│   │   │   ├── INetworkService.cs
│   │   │   ├── IIndexedDbService.cs
│   │   │   ├── ISyncManagerService.cs
│   │   │   └── ...
│   │   ├── Models/               # Modelos específicos del cliente
│   │   │   ├── VentaConDetalles.cs
│   │   │   └── CompraConDetalles.cs
│   │   ├── wwwroot/              # Archivos estáticos
│   │   │   ├── css/
│   │   │   ├── js/
│   │   │   ├── appsettings.json
│   │   │   ├── manifest.webmanifest
│   │   │   └── service-worker.js
│   │   ├── Program.cs            # Punto de entrada
│   │   └── Client.csproj
│   │
│   └── Shared/                   # Librería compartida
│       ├── Models/               # Modelos de datos (entidades)
│       │   ├── Comercio.cs
│       │   ├── Usuario.cs
│       │   ├── Producto.cs
│       │   └── ...
│       ├── DTOs/                 # Data Transfer Objects
│       │   ├── CreateProductoDto.cs
│       │   ├── CreateVentaDto.cs
│       │   └── ...
│       ├── Services/             # Servicios de negocio
│       │   ├── ISupabaseService.cs
│       │   ├── IAuthService.cs
│       │   ├── IProductoService.cs
│       │   └── ...
│       ├── Interfaces/           # Interfaces comunes
│       │   └── ISyncEntity.cs
│       └── Shared.csproj
│
├── docs/                         # Documentación
│   ├── 06_cursor_checklist.md
│   ├── 14_checklist_desarrollo_completo.md
│   └── ...
│
├── scripts/                      # Scripts de utilidad
│   └── powershell/
│
└── .github/                      # Configuración de GitHub
    └── workflows/
        └── deploy-cloudflare.yml
```

### Separación de Responsabilidades

- **Client:** UI, componentes, servicios del cliente (IndexedDB, Network, Toast)
- **Shared:** Lógica de negocio, modelos, servicios de datos, DTOs
- **No hay Server:** Todo corre en el navegador (WebAssembly)

---

## 💾 Modelo de Datos

### Base de Datos (Supabase/PostgreSQL)

**Esquema Principal:**

```
comercios
├── id (uuid, PK)
├── nombre (text)
├── email (text)
├── telefono (text)
├── direccion (text)
├── activo (boolean)
└── created_at, updated_at

usuarios
├── id (uuid, PK)
├── auth_user_id (uuid, FK → auth.users)
├── comercio_id (uuid, FK → comercios)
├── rol_id (uuid, FK → roles)
├── activo (boolean)
├── es_propietario (boolean)
├── sync_id (uuid, para offline)
└── created_at, updated_at

roles
├── id (uuid, PK)
├── nombre (text)
└── descripcion (text)

productos
├── id (uuid, PK)
├── comercio_id (uuid, FK → comercios)
├── categoria_id (uuid, FK → categorias)
├── marca_id (uuid, FK → marcas)
├── nombre (text)
├── codigo (text, código de barras)
├── precio_venta (decimal)
├── precio_compra (decimal)
├── activo (boolean)
├── sync_id (uuid)
└── created_at, updated_at

ventas
├── id (uuid, PK)
├── comercio_id (uuid, FK → comercios)
├── cliente_id (uuid, FK → clientes)
├── usuario_id (uuid, FK → usuarios)
├── fecha (timestamp)
├── total (decimal)
├── descuento (decimal)
└── created_at, updated_at

detalle_venta
├── id (uuid, PK)
├── venta_id (uuid, FK → ventas)
├── producto_id (uuid, FK → productos)
├── cantidad (decimal)
├── precio_unitario (decimal)
├── subtotal (decimal)
└── created_at

stock
├── id (uuid, PK)
├── comercio_id (uuid, FK → comercios)
├── producto_id (uuid, FK → productos)
├── cantidad (decimal)
├── cantidad_minima (decimal)
└── updated_at

... (más tablas: compras, clientes, proveedores, categorias, marcas, etc.)
```

### Características del Modelo

- **UUIDs:** Todos los IDs son UUIDs (GUIDs)
- **Sync_ID:** Campo `sync_id` en tablas principales para sincronización offline
- **Timestamps:** `created_at` y `updated_at` automáticos
- **Soft Delete:** Campo `activo` (boolean) en lugar de eliminar registros
- **RLS:** Row Level Security habilitado (cada comercio solo ve sus datos)

### Almacenamiento Local (IndexedDB)

**Object Stores:**
- `productos` - Cache local de productos
- `clientes` - Cache local de clientes
- `ventas` - Ventas pendientes de sincronización
- `compras` - Compras pendientes de sincronización
- `stock` - Cache local de stock
- `syncQueue` - Cola de sincronización

---

## 🔐 Autenticación y Autorización

### Autenticación (Supabase Auth)

**Flujo:**
1. Usuario ingresa email/contraseña en `Login.razor`
2. `AuthService.SignInAsync()` → Supabase Auth
3. Supabase retorna JWT token y sesión
4. Token se almacena en el navegador (Supabase SDK maneja esto)
5. Token se incluye automáticamente en todas las peticiones a Supabase

### Autorización (RBAC + RLS)

**Roles:**
- **Admin (Propietario):** `es_propietario = true`
  - Acceso completo a todas las ventanas
  - Puede gestionar usuarios
  - Puede configurar el sistema
  - NO puede acceder a Mantenimiento

- **User (Empleado):** `es_propietario = false`
  - Acceso limitado
  - Puede realizar ventas/compras
  - Puede ver productos, clientes, etc.
  - NO puede gestionar usuarios ni configuración

- **Programador:** (Futuro)
  - Acceso completo
  - Adicionalmente: Acceso a Mantenimiento

**Row Level Security (RLS):**
- Políticas en Supabase que filtran automáticamente por `comercio_id`
- Cada usuario solo ve datos de su comercio
- Aplicado a nivel de base de datos (seguro)

**Control de Acceso en Aplicación:**
- `AuthorizeRouteView.razor` - Protección de rutas
- `AuthorizeView.razor` - Renderizado condicional
- `UserContextService` - Servicio para verificar roles
- `AuthorizationService` - Lógica de autorización

---

## 🔌 Servicios y Lógica de Negocio

### Servicios Base

| Servicio | Propósito |
|----------|-----------|
| `ISupabaseService` | Cliente de Supabase (singleton) |
| `IAuthService` | Autenticación (login, logout, registro) |
| `IAuthorizationService` | Autorización (permisos, roles) |

### Servicios por Entidad (Repository Pattern)

| Servicio | Propósito |
|----------|-----------|
| `IComercioService` | CRUD de comercios |
| `IUsuarioService` | CRUD de usuarios |
| `IProductoService` | CRUD de productos |
| `IClienteService` | CRUD de clientes |
| `IProveedorService` | CRUD de proveedores |
| `IVentaService` | CRUD de ventas (+ detalles) |
| `ICompraService` | CRUD de compras (+ detalles) |
| `IStockService` | Gestión de stock |

### Servicios de Negocio

| Servicio | Propósito |
|----------|-----------|
| `ISyncService` | Sincronización offline/online |
| `IValidationService` | Validaciones de negocio |
| `ICalculationService` | Cálculos (totales, descuentos) |

### Servicios del Cliente

| Servicio | Propósito |
|----------|-----------|
| `IToastService` | Notificaciones toast |
| `INetworkService` | Detección de estado de red |
| `IIndexedDbService` | Acceso a IndexedDB |
| `IOfflineStorageService` | Almacenamiento offline |
| `ISyncManagerService` | Gestión de sincronización |
| `IUserContextService` | Contexto del usuario actual |

---

## 🎨 Interfaz de Usuario

### Tecnología

- **Blazor Razor Components:** Componentes reutilizables (.razor)
- **Bootstrap 5:** Framework CSS (responsive, componentes UI)
- **CSS Personalizado:** Estilos específicos del proyecto

### Estructura de Componentes

**Layouts:**
- `MainLayout.razor` - Layout principal (con sidebar)
- `LoginLayout.razor` - Layout para login/registro (sin sidebar)

**Componentes Reutilizables:**
- `Alert.razor` - Mensajes de alerta
- `Modal.razor` - Ventanas modales
- `DataTable.razor` - Tablas de datos (con filtros, paginación)
- `LoadingSpinner.razor` - Indicador de carga
- `ToastNotification.razor` - Notificaciones toast
- `NetworkStatus.razor` - Indicador de estado de red
- `SyncStatus.razor` - Indicador de sincronización

**Páginas Principales:**
- `Landing.razor` - Página pública de inicio
- `Login.razor` - Inicio de sesión
- `Registro.razor` - Registro de usuarios
- `Dashboard.razor` - Panel principal
- `Productos.razor`, `Ventas.razor`, `Compras.razor`, etc.

### Navegación

- **Router de Blazor:** Routing declarativo (`@page "/ruta"`)
- **NavMenu.razor:** Menú lateral con todas las opciones
- **AuthorizeRouteView:** Protección de rutas automática

---

## 📴 Funcionalidad Offline

### Estrategia Offline-First

1. **IndexedDB como Fuente Primaria:**
   - Los datos se guardan primero en IndexedDB
   - La UI siempre lee de IndexedDB (rápido, sin latencia)

2. **Sincronización Bidireccional:**
   - Cuando hay conexión: Sincronizar IndexedDB → Supabase
   - Cuando no hay conexión: Operar solo con IndexedDB

3. **Sync Queue:**
   - Operaciones pendientes se marcan con `sync_id`
   - Se almacenan en `syncQueue` (IndexedDB)
   - Se procesan cuando hay conexión

### Componentes de Offline

- **IndexedDbService:** Acceso a IndexedDB (JSInterop)
- **OfflineStorageService:** Almacenamiento offline (wrapper sobre IndexedDB)
- **SyncManagerService:** Gestión de sincronización
- **NetworkService:** Detección de estado de red

### Service Worker (PWA)

- **Cache de recursos:** HTML, CSS, JS, imágenes
- **Estrategia:** Network First, Fallback to Cache
- **Actualización:** Automática cuando hay cambios

---

## 🚀 Despliegue y Hosting

### Hosting Actual

- **Plataforma:** Cloudflare Pages (gratis)
- **Tipo:** Static Site Hosting
- **URL:** https://gestion-comercios.pages.dev
- **Dominio Personalizado:** adminisgo.com.ar

### CI/CD

- **GitHub Actions:** Automatización de builds y despliegues
- **Workflow:** `.github/workflows/deploy-cloudflare.yml`
- **Trigger:** Push a branch `main`
- **Proceso:**
  1. Checkout código
  2. Setup .NET SDK
  3. `dotnet restore`
  4. `dotnet build --configuration Release`
  5. `dotnet publish` → `./publish/wwwroot`
  6. Deploy a Cloudflare Pages

### Configuración de Entornos

- **Development:** `appsettings.Development.json`
- **Production:** `appsettings.Production.json`
- **Variables:** Supabase URL y API Key

---

## 🔒 Seguridad

### Autenticación

- **Supabase Auth:** Manejo seguro de usuarios y contraseñas
- **JWT Tokens:** Tokens firmados, expiración automática
- **HTTPS:** Todas las comunicaciones encriptadas

### Autorización

- **RBAC:** Role-Based Access Control en aplicación
- **RLS:** Row Level Security en base de datos
- **Filtrado por Comercio:** Cada usuario solo ve datos de su comercio

### Datos Sensibles

- **API Keys:** Almacenadas en configuración (no en código fuente)
- **Secrets:** No committeados a Git
- **Environment Variables:** Para producción (Cloudflare Pages)

### Validación

- **Client-Side:** Validaciones en formularios (UX)
- **Server-Side:** Validaciones en Supabase (seguridad)
- **RLS Policies:** Validación a nivel de base de datos

---

## 📊 Estado Actual del Proyecto

### Completado ✅

- ✅ Estructura del proyecto (Client/Shared)
- ✅ Conexión con Supabase
- ✅ Modelos de datos (todas las entidades)
- ✅ Servicios básicos (CRUD para entidades principales)
- ✅ Autenticación y autorización básica
- ✅ Landing Page, Login, Registro
- ✅ Layout y navegación básica
- ✅ Páginas principales (estructura básica)
- ✅ Componentes reutilizables básicos
- ✅ Funcionalidad offline (IndexedDB, sincronización)
- ✅ PWA configurada
- ✅ Deployment a Cloudflare Pages

### En Desarrollo 🚧

- 🚧 Formularios completos de CRUD (solo estructuras básicas)
- 🚧 Dashboard con gráficos
- 🚧 Validaciones avanzadas
- 🚧 Filtros tipo Excel en tablas
- 🚧 Autocomplete avanzado
- 🚧 Impresión POS

### Pendiente 📋

- 📋 Ventana de Usuarios completa
- 📋 Ventana de Configuraciones
- 📋 Ventana de Mantenimiento
- 📋 Sistema de sugerencias
- 📋 Reportes avanzados

---

**FIN DEL DOCUMENTO**

