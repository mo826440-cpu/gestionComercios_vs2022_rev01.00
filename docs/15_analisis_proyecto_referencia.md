# Análisis del Proyecto de Referencia

**Ruta:** `C:\Sistema_Gestión_Kioscos.05`  
**Fecha de análisis:** 2025-01-XX  
**Objetivo:** Entender completamente la estructura, flujos y lógica del proyecto de referencia para replicar su funcionalidad en el nuevo proyecto Blazor.

---

## 📋 Descripción General

El proyecto de referencia es una **aplicación web PWA (Progressive Web App)** desarrollada con tecnologías web estándar:
- **Frontend:** HTML5, CSS3, JavaScript (Vanilla JS)
- **Backend:** Supabase (PostgreSQL + Auth)
- **Almacenamiento Local:** IndexedDB (para funcionamiento offline)
- **Arquitectura:** Monolítica frontend (todo el código en el navegador)

### Nombre del Proyecto
**AdminisGo v1.0.0** - Sistema de gestión para kioscos y pequeños comercios

---

## 🏗️ Estructura del Proyecto

### Organización de Archivos

```
Sistema_Gestión_Kioscos.05/
├── index.html              # Landing page (página principal pública)
├── landing.html            # Landing page alternativa
├── login.html              # Página de inicio de sesión
├── registro.html           # Página de registro de usuarios
├── inicio.html             # Dashboard principal (requiere autenticación)
│
├── categorias.html         # Gestión de categorías
├── marcas.html             # Gestión de marcas
├── proveedores.html        # Gestión de proveedores
├── clientes.html           # Gestión de clientes
├── productos.html          # Gestión de productos
├── compras.html            # Gestión de compras
├── ventas.html             # Gestión de ventas
├── usuarios.html           # Gestión de usuarios
├── configuracion.html      # Configuración del sistema
├── mantenimiento.html      # Panel de mantenimiento (programador)
├── referencias.html        # Menú de referencias
├── dashboard.html          # Dashboard con gráficos
│
├── css/                    # Estilos CSS (uno por página)
│   ├── global.css
│   ├── landing.css
│   ├── login.css
│   ├── categorias.css
│   └── ...
│
├── js/                     # Lógica JavaScript (uno por página)
│   ├── supabase.js         # Configuración y conexión a Supabase
│   ├── indexeddb.js        # Gestión de IndexedDB (offline)
│   ├── sync.js             # Sincronización offline/online
│   ├── landing.js
│   ├── login.js
│   ├── registro.js
│   ├── productos.js
│   └── ...
│
├── db/                     # Documentación de base de datos
│   ├── supabase_schema.md  # Esquema de Supabase
│   └── indexeddb_schema.md # Esquema de IndexedDB
│
├── docs/                   # Documentación del proyecto
│   ├── estructuraVentanas.md  # Especificación de cada ventana
│   └── ...
│
└── assets/                 # Recursos estáticos
    ├── icons/              # Iconos para PWA
    └── fonts/              # Fuentes personalizadas
```

---

## 🔄 Flujo Principal del Sistema

### 1. Flujo de Usuario (Desde Landing)

```
Landing Page (index.html)
    ↓
    ├─→ Registrarse (registro.html)
    │       ↓
    │   Crear cuenta en Supabase Auth
    │       ↓
    │   Crear comercio y usuario admin
    │       ↓
    │   Login automático
    │       ↓
    │   Dashboard (inicio.html)
    │
    └─→ Ingresar (login.html)
            ↓
        Autenticación Supabase
            ↓
        Cargar datos del usuario/comercio
            ↓
        Sincronizar con IndexedDB (offline)
            ↓
        Dashboard (inicio.html)
```

### 2. Flujo de Autenticación

1. **Usuario ingresa credenciales** en `login.html`
2. **Autenticación con Supabase Auth** (`js/login.js`)
3. **Verificación de sesión** en Supabase
4. **Carga de datos del usuario** desde tabla `usuarios`
5. **Carga de datos del comercio** desde tabla `comercios`
6. **Sincronización inicial** con IndexedDB (para modo offline)
7. **Redirección al Dashboard** (`inicio.html`)

### 3. Flujo de Registro

1. **Usuario completa formulario** en `registro.html`
2. **Validaciones en cliente** (JavaScript)
3. **Registro en Supabase Auth** (crear usuario)
4. **Creación automática de comercio** (tabla `comercios`)
5. **Creación de usuario admin** (tabla `usuarios`, `es_propietario = true`)
6. **Login automático** después del registro
7. **Redirección al Dashboard**

### 4. Flujo de Operaciones (Ventas/Compras)

**Ventas:**
```
Dashboard → Ventas (ventas.html)
    ↓
Cargar nueva venta (Modal/Panel)
    ↓
Agregar productos (código de barras, nombre, cantidad, precio)
    ↓
Agregar pagos (método de pago, monto)
    ↓
Finalizar venta
    ↓
Guardar en Supabase (si hay conexión)
    └─→ O guardar en IndexedDB (si está offline)
    ↓
Actualizar stock automáticamente
    ↓
Mostrar en tabla de ventas
```

**Compras:** Similar a ventas, pero actualiza stock sumando en lugar de restando.

---

## 🎯 Módulos y Ventanas Identificadas

### Módulo 1: Autenticación y Acceso
- **Landing Page** (`index.html`)
- **Login** (`login.html`)
- **Registro** (`registro.html`)

### Módulo 2: Referencias (Datos Maestros)
- **Categorías** (`categorias.html`)
- **Marcas** (`marcas.html`)
- **Proveedores** (`proveedores.html`)
- **Clientes** (`clientes.html`)
- **Productos** (`productos.html`)

### Módulo 3: Operaciones
- **Ventas** (`ventas.html`)
- **Compras** (`compras.html`)

### Módulo 4: Gestión
- **Usuarios** (`usuarios.html`)
- **Configuración** (`configuracion.html`)
- **Mantenimiento** (`mantenimiento.html`) - Solo programador

### Módulo 5: Información y Reportes
- **Dashboard** (`dashboard.html`) - Con gráficos
- **Inicio/Dashboard** (`inicio.html`) - Dashboard principal

---

## 🔑 Características Clave Identificadas

### 1. Funcionamiento Offline-First
- **IndexedDB** como almacenamiento local
- **Sincronización bidireccional** cuando hay conexión
- **Service Worker** para PWA
- **Marcado de registros** con `sync_id` para tracking

### 2. Autenticación y Autorización
- **Supabase Auth** para autenticación
- **Roles:** Admin (propietario), Usuario (empleado), Programador
- **RBAC (Role-Based Access Control)** a nivel de aplicación
- **RLS (Row Level Security)** en Supabase (cada comercio solo ve sus datos)

### 3. Estructura de Ventanas

Todas las ventanas de gestión siguen un patrón similar:

```
┌─────────────────────────────────────┐
│ PARTE SUPERIOR: Indicadores         │
│ - Cantidad total                    │
│ - Cantidad activos                  │
│ - Métricas adicionales (si aplica)  │
└─────────────────────────────────────┘
┌─────────────────────────────────────┐
│ PARTE MEDIA: Botón Cargar Nuevo     │
│ + Panel/Modal de carga              │
│ - Campos del formulario             │
│ - Validaciones                      │
│ - Botones Guardar/Cancelar          │
└─────────────────────────────────────┘
┌─────────────────────────────────────┐
│ PARTE INFERIOR: Tabla de Registros  │
│ - Columnas con datos                │
│ - Filtros tipo Excel                │
│ - Paginación                        │
│ - Acciones (Ver, Editar, Eliminar)  │
└─────────────────────────────────────┘
```

### 4. Funcionalidades Especiales

**Productos:**
- Código de barras (escáner o cámara)
- Autocompletado avanzado para categorías y marcas
- Control de stock (mínimo, actual, estados visuales)

**Ventas/Compras:**
- Flujo tipo POS (Point of Sale)
- Múltiples productos en una transacción
- Pagos parciales y deudas
- Actualización automática de stock
- Impresión POS 80

**Dashboard:**
- Gráficos de barras y torta
- Filtros por fecha
- Métricas de ventas, compras, deudas

### 5. Formatos y Convenciones

- **Moneda:** Pesos argentinos ($1.000.000,00)
- **Fechas:** dd/mm/yyyy HH:mm (Argentina/Buenos Aires)
- **IDs:** Formato `XX + ID_COMERCIO` (según requerimientos)
- **Estados:** Activo (Verde) / Inactivo (Rojo)
- **Stock:** Sin Stock (Rojo) / Stock Bajo (Amarillo) / Stock OK (Verde)

---

## 💾 Arquitectura de Datos

### Base de Datos (Supabase/PostgreSQL)

**Tablas principales identificadas:**
- `comercios` - Comercios/negocios
- `usuarios` - Usuarios del sistema
- `roles` - Roles del sistema
- `categorias` - Categorías de productos
- `marcas` - Marcas de productos
- `proveedores` - Proveedores
- `clientes` - Clientes
- `productos` - Productos
- `stock` - Control de stock
- `ventas` - Ventas
- `detalle_venta` - Detalles de ventas
- `compras` - Compras
- `detalle_compra` - Detalles de compras
- `pagos_venta` - Pagos de ventas
- `pagos_compra` - Pagos de compras
- `configuraciones` - Configuraciones del sistema

### Almacenamiento Local (IndexedDB)

- Replicación de tablas principales
- Cola de sincronización (`syncQueue`)
- Sincronización bidireccional cuando hay conexión

---

## 🔐 Sistema de Roles y Permisos

### Roles Identificados

1. **Admin (Propietario)**
   - Acceso completo a todas las ventanas
   - Puede crear/editar/eliminar usuarios
   - Puede configurar el sistema
   - NO puede acceder a Mantenimiento

2. **Usuario (Empleado)**
   - Acceso limitado (según permisos)
   - Puede realizar ventas/compras
   - Puede ver productos, clientes, etc.
   - NO puede gestionar usuarios ni configuración

3. **Programador**
   - Acceso completo (igual que Admin)
   - **Adicionalmente:** Puede acceder a Mantenimiento
   - Panel de administración avanzado
   - Exportación de backups
   - Gestión de sugerencias

### Control de Acceso

- **A nivel de aplicación:** JavaScript verifica roles antes de mostrar ventanas
- **A nivel de base de datos:** RLS (Row Level Security) en Supabase
- **Cada comercio:** Solo ve sus propios datos (filtrado por `comercio_id`)

---

## 🎨 Interfaz de Usuario

### Diseño
- **Estilo:** Moderno, limpio, funcional
- **Colores:** Azul como color primario (#2563eb)
- **Responsive:** Adaptable a móviles y tablets
- **Temas:** Soporte para tema claro/oscuro (preparado)

### Componentes Reutilizables
- Modales/Paneles para carga/edición
- Tablas con filtros tipo Excel
- Indicadores (cards con métricas)
- Formularios con validación
- Botones de acción

### Navegación
- **Sidebar/Menú lateral** con todas las opciones
- **Breadcrumbs** en algunas páginas
- **Atajos de teclado** (F2, Ctrl+Intro, etc.)

---

## 📊 Funcionalidades de Negocio

### Gestión de Stock
- Stock actual, stock mínimo
- Actualización automática en ventas/compras
- Alertas visuales (colores)
- Control de unidades

### Gestión de Ventas
- Múltiples productos por venta
- Descuentos por producto
- Múltiples formas de pago
- Pagos parciales y deudas
- Impresión de tickets (POS 80)

### Gestión de Compras
- Similar a ventas
- Múltiples productos
- Múltiples pagos
- Control de deudas con proveedores

### Reportes y Dashboard
- Gráficos de ventas mensuales
- Gráficos de compras mensuales
- Productos más vendidos
- Deudas de clientes
- Deudas a proveedores
- Ventas por usuario
- Filtros por fecha

---

## 🔧 Tecnologías y Librerías

### Frontend
- **HTML5** (estructura)
- **CSS3** (estilos, responsive)
- **JavaScript (Vanilla)** (lógica, sin frameworks)
- **Supabase JS SDK** (conexión a backend)
- **Chart.js** o similar (gráficos, inferido)

### Backend
- **Supabase** (PostgreSQL + Auth + Storage)
- **Row Level Security (RLS)** habilitado
- **API REST** de Supabase

### PWA
- **Service Worker** (`service-worker.js`)
- **Manifest** (`manifest.json`)
- **Iconos** múltiples tamaños
- **Offline support** completo

---

## 📝 Notas y Observaciones

### Fortalezas del Proyecto de Referencia
1. ✅ Funcionamiento offline completo
2. ✅ PWA instalable
3. ✅ Estructura clara y organizada
4. ✅ Separación de responsabilidades (HTML/CSS/JS)
5. ✅ Documentación de ventanas (`estructuraVentanas.md`)
6. ✅ Sincronización bidireccional bien implementada

### Desafíos para la Migración
1. 🔄 Migrar de Vanilla JS a Blazor (componentes)
2. 🔄 Mantener funcionalidad offline (IndexedDB ya implementado)
3. 🔄 Replicar autocomplete avanzado (componentes Blazor)
4. 🔄 Replicar filtros tipo Excel (componentes personalizados)
5. 🔄 Mantener formato de moneda y fechas (Argentina)
6. 🔄 Replicar gráficos (librería compatible con Blazor)

### Diferencias con el Proyecto Actual (Blazor)
- **Arquitectura:** Monolito JS → Componentes Blazor
- **Estado:** LocalStorage/IndexedDB → IndexedDB + Servicios C#
- **Renderizado:** DOM manipulation → Razor components
- **Routing:** Navegación manual → Blazor Router
- **Validación:** JavaScript → DataAnnotations + Blazor

---

## ✅ Conclusiones

El proyecto de referencia es una aplicación PWA funcional y completa, con:
- ✅ Funcionamiento offline robusto
- ✅ Estructura de ventanas bien definida
- ✅ Flujos de negocio claros
- ✅ Sistema de roles y permisos implementado
- ✅ Integración con Supabase funcionando

**El objetivo es replicar esta funcionalidad en Blazor WebAssembly, manteniendo:**
- La misma estructura de ventanas
- Los mismos flujos de negocio
- La misma experiencia de usuario
- La funcionalidad offline
- El sistema de autenticación y autorización

**Mejorando:**
- Arquitectura más escalable (componentes Blazor)
- Tipado fuerte (C# en lugar de JS)
- Mejor organización del código (Separación Client/Shared)
- Facilidad de mantenimiento

---

**FIN DEL ANÁLISIS**

