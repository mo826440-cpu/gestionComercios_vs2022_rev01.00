# Checklist de Desarrollo Completo - Sistema Gestión Comercios

## 📋 Estado General
- **Última actualización:** 2025-01-XX
- **Fase actual:** Análisis completado, listos para desarrollo progresivo
- **Metodología:** Desarrollo paso a paso, sin romper funcionalidades existentes

---

## ⚠️ REGLAS IMPORTANTES
- ✅ NO romper funcionalidades existentes
- ✅ NO eliminar archivos ni esquemas sin justificar
- ✅ Analizar antes de modificar
- ✅ Avanzar paso a paso, con checklist aprobado antes de implementar
- ✅ Cada paso debe probarse antes de avanzar al siguiente

---

## 1️⃣ ANÁLISIS DEL PROYECTO DE REFERENCIA ✅ COMPLETADO

**Ruta:** `C:\Sistema_Gestión_Kioscos.05`

**Objetivo:** Entender completamente el proyecto de referencia para replicar su flujo funcional

### Tareas:
- [x] Acceder y analizar el proyecto de referencia
- [x] Identificar flujo general del sistema
  - [x] Login/Registro
  - [x] Gestión de datos
  - [x] Operaciones (Ventas/Compras)
  - [x] Roles y permisos
- [x] Identificar módulos y ventanas
- [x] Identificar lógica de negocio principal
- [x] Documentar diferencias con proyecto actual

### Entregables:
- [x] **Archivo resumen** (`docs/15_analisis_proyecto_referencia.md`) ✅
  - Lenguaje claro y comprensible
  - Descripción del proyecto
  - Módulos identificados
  - Flujos principales
- [x] **Archivo diagrama de flujo** (`docs/16_diagrama_flujo_referencia.md`) ✅
  - Flujo completo del sistema
  - Login → Gestión → Operaciones
  - Roles y permisos

### Dependencias:
- Ninguna (primer paso)

### Capas Afectadas:
- Documentación solamente

---

## 2️⃣ ANÁLISIS DEL PROYECTO ACTUAL + VISIÓN COMERCIAL ✅ COMPLETADO

**Ruta:** `C:\VS 2022\gestionComercios_vs2022_rev01.00`

**Objetivo:** Documentar el proyecto actual y alinearlo con la visión del proyecto de referencia

### Tareas:
- [x] Analizar estado actual del proyecto
- [x] Comparar con proyecto de referencia
- [x] Identificar gaps y diferencias
- [x] Documentar visión comercial

### Entregables:
- [x] **Documento marketing/ventas** (`docs/17_vision_comercial.md`) ✅
  - Qué problema resuelve
  - A quién está dirigido
  - Beneficios clave
  - Valor diferencial
- [x] **Documento técnico** (`docs/18_documento_tecnico.md`) ✅
  - Arquitectura actual
  - Stack tecnológico
  - Roles y permisos
  - Módulos y estructura
  - Modelo de datos
- [x] **Diagrama de flujo técnico** (`docs/19_diagrama_flujo_tecnico.md`) ✅
  - Detallado y técnico
  - Flujo de datos
  - Autenticación y autorización
  - Sincronización offline
- [x] **Diagrama de flujo general/comercial** (`docs/20_diagrama_flujo_comercial.md`) ✅
  - Versión simplificada
  - Para presentaciones
  - Enfoque en flujo de usuario

### Dependencias:
- Paso 1️⃣ (análisis de referencia)

### Capas Afectadas:
- Documentación solamente

---

## 3️⃣ REVISIÓN Y MEJORA DEL REGISTRO E INGRESO DE USUARIOS

**Concepto clave:** Cada usuario registrado = un nuevo comercio (BD vacía)

**Objetivo:** Mejorar el sistema actual de registro para que cumpla con los nuevos requerimientos

### 3.1 Análisis del Sistema Actual ✅ COMPLETADO
- [x] Revisar flujo de registro actual
- [x] Revisar flujo de login actual
- [x] Identificar qué falta según requerimientos
- [x] Documentar cambios necesarios
- [x] **Entregable:** `docs/21_analisis_sistema_registro_login.md`

### 3.2 Mejoras en el Formulario de Registro ✅ COMPLETADO
- [x] Agregar campo Email (confirmación - 2 veces)
- [x] Agregar campo Usuario (único por comercio)
- [x] Mejorar campo Contraseña (confirmación - 2 veces)
- [x] Agregar campo Contacto (obligatorio)
- [x] Agregar checkbox "Aceptar términos y condiciones"
- [x] Crear/actualizar página de términos y condiciones
- [x] Validaciones en formulario
  - [x] Email válido y coincidencia
  - [x] Usuario único
  - [x] Contraseña segura y coincidencia
  - [x] Contacto válido
  - [x] Términos aceptados

### 3.3 Sistema de Notificación y Aprobación
- [ ] Configurar servicio de email (Supabase o externo)
- [ ] Crear tabla/estado para registros pendientes de aprobación
- [ ] Implementar notificación a mo826440@gmail.com al registrarse
- [ ] Crear sistema de aprobación (manual, vía email o panel admin)
- [ ] Estados: Pendiente → Aprobado → Rechazado

### 3.4 Generación de IDs ✅ COMPLETADO
- [x] ID único de Usuario (formato: XX + ID_COMERCIO)
- [x] ID único de Comercio (automático al aprobar registro)
- [x] Lógica de numeración secuencial por comercio

### 3.5 Mejoras en el Login ✅ COMPLETADO
- [x] Agregar campo "ID del Comercio" al formulario
- [x] Autocompletado/selector de ID del Comercio (si usuario tiene múltiples)
- [x] Validación de credenciales + ID de comercio
- [x] Mensajes de error claros

### 3.6 Sistema de Roles ✅ COMPLETADO (Parcial)
- [x] Verificar/actualizar tabla `roles` en BD (script SQL creado)
- [x] Roles requeridos:
  - [x] Admin (dueño del comercio) - EsPropietario=true
  - [x] User (empleado) - EsPropietario=false
  - [x] Programador (rol especial, acceso a Mantenimiento)
- [x] Asignación automática de rol Admin al registrarse
- [x] Lógica de permisos por rol (estructura base implementada)

### 3.7 Autenticación Adicional (Preparar)
- [ ] Estructura para segunda capa de autenticación
- [ ] Preparar para: Email OTP, Biometría (futuro)
- [ ] NO implementar aún, solo preparar estructura

### 3.8 Testing
- [ ] Probar registro completo
- [ ] Probar aprobación
- [ ] Probar login con ID de comercio
- [ ] Probar validaciones y errores

### Dependencias:
- Paso 2️⃣ (análisis y documentación)
- Sistema actual de registro (no romper)

### Capas Afectadas:
- **Base de Datos:**
  - [ ] Nueva tabla `registros_pendientes` (si se necesita)
  - [ ] Campo `contacto` en tabla `usuarios`
  - [ ] Campo `id_comercio_publico` o similar
  - [ ] Actualizar tabla `roles` si falta "Programador"
- **Backend (Shared):**
  - [ ] Actualizar `UsuarioService` para nuevo registro
  - [ ] Nuevo servicio de aprobación (si aplica)
  - [ ] Actualizar `AuthService` para login con ID comercio
- **Frontend (Client):**
  - [ ] Actualizar `Registro.razor`
  - [ ] Actualizar `Login.razor`
  - [ ] Crear página Términos y Condiciones
  - [ ] Componentes de validación

---

## 4️⃣ DESARROLLO DE LA VENTANA USUARIOS (Solo Admin)

**Objetivo:** CRUD completo de usuarios del comercio, accesible solo para administradores

### 4.1 Estructura de la Página
- [ ] Crear/actualizar `Usuarios.razor`
- [ ] Layout: Parte Superior, Media, Inferior

### 4.2 Parte Superior - Indicadores
- [ ] Indicador: Cantidad de registros cargados
- [ ] Indicador: Cantidad de registros activos
- [ ] Lógica de conteo en tiempo real

### 4.3 Parte Media - Panel de Carga
- [ ] Botón "Cargar nuevo Usuario" (atajo: Ctrl+F2)
- [ ] Modal/Panel de carga con campos:
  - [ ] Nombre y apellido* (obligatorio)
  - [ ] Usuario* (obligatorio, único en el comercio)
  - [ ] Mail* (obligatorio, sin confirmación para no-admin)
  - [ ] Contraseña* (obligatorio)
  - [ ] Rol* (dropdown: administrador, vendedor, encargado)
  - [ ] Referencias (opcional, textarea)
  - [ ] Botón Guardar (atajo: Ctrl+Intro)
  - [ ] Botón Cancelar
- [ ] Validaciones:
  - [ ] Usuario único en el comercio
  - [ ] Email válido
  - [ ] Contraseña segura
  - [ ] Campos obligatorios
- [ ] Mensajes:
  - [ ] Confirmación antes de guardar
  - [ ] Error si faltan datos
  - [ ] Éxito al guardar
- [ ] Generación automática:
  - [ ] ID único (formato: XX + ID_COMERCIO)
  - [ ] Estado Activo por defecto
  - [ ] Fecha/hora de registro
  - [ ] Usuario responsable (admin logueado)

### 4.4 Parte Inferior - Tabla
- [ ] Tabla con columnas:
  - [ ] Usuario (con filtro tipo Excel)
  - [ ] Rol
  - [ ] Estado (Activo=Verde, Inactivo=Rojo)
  - [ ] Acciones (Ver detalle, Editar)
- [ ] Filtros tipo Excel en columna Usuario
- [ ] Paginación:
  - [ ] 20 registros por página por defecto
  - [ ] Selector de cantidad de registros por página
  - [ ] Navegación entre páginas
- [ ] Acción "Ver detalle":
  - [ ] Panel/Modal con toda la información
  - [ ] Contraseña oculta (con opción mostrar/ocultar)
  - [ ] Referencias
  - [ ] ID único
  - [ ] Estado
  - [ ] Fecha/hora de registro/edición
  - [ ] Responsable de registro/edición
- [ ] Acción "Editar":
  - [ ] Panel/Modal editable (similar a carga)
  - [ ] NO permitir editar ID
  - [ ] Validaciones iguales a creación
  - [ ] Actualizar fecha/hora y responsable

### 4.5 Backend y Servicios
- [ ] Verificar/actualizar `UsuarioService` en Shared
- [ ] Métodos necesarios:
  - [ ] GetAllAsync (con filtros y paginación)
  - [ ] GetByIdAsync
  - [ ] CreateAsync (con validación de usuario único)
  - [ ] UpdateAsync
  - [ ] DeleteAsync (o desactivar)
  - [ ] CountAsync (total y activos)
- [ ] Validación de rol Admin (solo admin puede acceder)

### 4.6 Testing
- [ ] Probar creación de usuario
- [ ] Probar validaciones
- [ ] Probar edición
- [ ] Probar filtros y paginación
- [ ] Probar acceso solo para admin

### Dependencias:
- Paso 3️⃣ (sistema de registro y roles)
- Sistema de autenticación actual

### Capas Afectadas:
- **Base de Datos:**
  - [ ] Verificar/actualizar tabla `usuarios`
  - [ ] Campos: nombre, apellido, usuario, mail, contacto, referencias
  - [ ] Índices para búsqueda y unicidad
- **Backend (Shared):**
  - [ ] Actualizar `UsuarioService`
  - [ ] DTOs para creación/edición
  - [ ] Validaciones de negocio
- **Frontend (Client):**
  - [ ] `Usuarios.razor` completo
  - [ ] Componentes: Modal, DataTable con filtros, Paginación
  - [ ] Servicios de autorización

---

## 5️⃣ VENTANA PROVEEDORES

**Objetivo:** CRUD completo de proveedores del comercio

### 5.1 Estructura (Similar a Usuarios)
- [ ] Parte Superior: Indicadores (total, activos)
- [ ] Parte Media: Panel de carga (Ctrl+F2)
- [ ] Parte Inferior: Tabla con filtros y paginación

### 5.2 Campos del Panel de Carga
- [ ] Nombre y apellido y/o nombre del comercio* (obligatorio)
- [ ] Contacto* (número de celular, obligatorio)
- [ ] Mail* (obligatorio)
- [ ] Estado ante ARCA-AFIP (dropdown: MONOTRIBUTISTA, S.R.L, etc.)
- [ ] CUIT del comercio
- [ ] Referencias (opcional)
- [ ] Botón Guardar (Ctrl+Intro)
- [ ] Botón Cancelar
- [ ] ID único automático (XX + ID_COMERCIO)
- [ ] Estado Activo por defecto

### 5.3 Tabla
- [ ] Columnas: Nombre/Apellido/Comercio, Estado, Acciones
- [ ] Filtros tipo Excel
- [ ] Paginación
- [ ] Acciones: Ver detalle, Editar

### 5.4 Backend
- [ ] Verificar/actualizar `ProveedorService`
- [ ] Métodos CRUD completos
- [ ] Validaciones

### Dependencias:
- Paso 4️⃣ (estructura base de ventanas)
- Tabla `proveedores` en BD

### Capas Afectadas:
- **Base de Datos:** Tabla `proveedores`
- **Backend:** `ProveedorService`
- **Frontend:** `Proveedores.razor`

---

## 6️⃣ VENTANA CLIENTES

**Objetivo:** CRUD completo de clientes del comercio

### 6.1 Estructura (Similar a Proveedores)
- [ ] Parte Superior: Indicadores
- [ ] Parte Media: Panel de carga
- [ ] Parte Inferior: Tabla con filtros

### 6.2 Campos del Panel de Carga
- [ ] Nombre y apellido* (obligatorio)
- [ ] Contacto* (número de celular, obligatorio)
- [ ] Mail (opcional)
- [ ] DNI (opcional)
- [ ] Referencias (opcional)
- [ ] ID único automático
- [ ] Estado Activo por defecto

### 6.3 Tabla
- [ ] Columnas: Nombre y Apellido, Estado, Acciones
- [ ] Filtros tipo Excel
- [ ] Paginación
- [ ] Acciones: Ver detalle, Editar

### 6.4 Backend
- [ ] Verificar/actualizar `ClienteService`
- [ ] Métodos CRUD completos

### Dependencias:
- Paso 5️⃣ (estructura similar)
- Tabla `clientes` en BD

### Capas Afectadas:
- **Base de Datos:** Tabla `clientes`
- **Backend:** `ClienteService`
- **Frontend:** `Clientes.razor`

---

## 7️⃣ VENTANA CATEGORÍAS

**Objetivo:** CRUD simple de categorías (uso posterior en Productos)

### 7.1 Estructura (Simplificada)
- [ ] Parte Superior: Indicadores (total, activos)
- [ ] Parte Media: Panel de carga (Ctrl+F2)
- [ ] Parte Inferior: Tabla

### 7.2 Campos del Panel de Carga
- [ ] Nombre* (obligatorio)
- [ ] Referencias (opcional)
- [ ] ID único automático
- [ ] Estado Activo por defecto

### 7.3 Tabla
- [ ] Columnas: Nombre, Estado, Acciones
- [ ] Filtros tipo Excel
- [ ] Paginación
- [ ] Acciones: Ver detalle, Editar

### 7.4 Backend
- [ ] Verificar/actualizar `CategoriaService`
- [ ] Métodos CRUD completos

### Dependencias:
- Tabla `categorias` en BD
- Se usa en Paso 9️⃣ (Productos)

### Capas Afectadas:
- **Base de Datos:** Tabla `categorias`
- **Backend:** `CategoriaService`
- **Frontend:** `Categorias.razor`

---

## 8️⃣ VENTANA MARCAS

**Objetivo:** CRUD simple de marcas (estructura idéntica a Categorías)

### 8.1 Estructura (Idéntica a Categorías)
- [ ] Parte Superior: Indicadores
- [ ] Parte Media: Panel de carga
- [ ] Parte Inferior: Tabla

### 8.2 Campos
- [ ] Nombre* (obligatorio)
- [ ] Referencias (opcional)
- [ ] ID único automático
- [ ] Estado Activo por defecto

### 8.3 Backend
- [ ] Verificar/actualizar `MarcaService`
- [ ] Métodos CRUD completos

### Dependencias:
- Paso 7️⃣ (estructura similar)
- Tabla `marcas` en BD
- Se usa en Paso 9️⃣ (Productos)

### Capas Afectadas:
- **Base de Datos:** Tabla `marcas`
- **Backend:** `MarcaService`
- **Frontend:** `Marcas.razor`

---

## 9️⃣ VENTANA PRODUCTOS

**Objetivo:** CRUD completo de productos con gestión de stock

### 9.1 Parte Superior - Indicadores
- [ ] Cantidad de registros cargados
- [ ] Cantidad de registros activos
- [ ] Cantidad de registros sin stock
- [ ] Cantidad con stock inferior al límite mínimo

### 9.2 Parte Media - Panel de Carga
- [ ] Código de barras* (obligatorio, único)
  - [ ] Input manual
  - [ ] Scanner común (preparar)
  - [ ] Scanner con cámara (preparar)
- [ ] Nombre* (obligatorio, único)
- [ ] Categoría (dropdown con autocomplete avanzado)
  - [ ] Lista desplegable
  - [ ] Filtrado por letras
  - [ ] Navegación con flechas
  - [ ] Selección con Enter
  - [ ] Valor por defecto: "NO APLICA"
- [ ] Marca (igual que Categoría)
- [ ] Precio Costo (numérico, >= 0, default: "NO APLICA")
- [ ] Precio Venta* (numérico, >= 0, obligatorio)
- [ ] Stock mínimo aceptable* (numérico, >= 0, default: "NO APLICA")
- [ ] Ajuste de Stock* (numérico, >= 0, default: 0)
- [ ] Descripción (opcional)
- [ ] ID único automático
- [ ] Estado Activo por defecto

### 9.3 Parte Inferior - Tabla
- [ ] Columnas:
  - [ ] Código de barras (con filtro)
  - [ ] Nombre (con filtro)
  - [ ] Estado (Verde/Rojo)
  - [ ] Stock (Sin Stock=Rojo, Stock Bajo=Amarillo, Stock Aceptable=Verde, con filtro)
  - [ ] Acciones (Ver detalle, Editar)
- [ ] Filtros tipo Excel
- [ ] Paginación

### 9.4 Autocomplete Avanzado (Componente Reutilizable)
- [ ] Componente genérico para Categoría/Marca
- [ ] Filtrado en tiempo real
- [ ] Navegación con teclado
- [ ] Selección visual (fondo azul, texto blanco)
- [ ] Selección con Enter

### 9.5 Backend
- [ ] Verificar/actualizar `ProductoService`
- [ ] Integración con `StockService`
- [ ] Validaciones:
  - [ ] Código de barras único
  - [ ] Nombre único
  - [ ] Precios >= 0
  - [ ] Stock >= 0

### Dependencias:
- Paso 7️⃣ (Categorías)
- Paso 8️⃣ (Marcas)
- Tabla `productos` y `stock` en BD

### Capas Afectadas:
- **Base de Datos:** Tablas `productos`, `stock`
- **Backend:** `ProductoService`, `StockService`
- **Frontend:** `Productos.razor`, componente Autocomplete

---

## 🔟 VENTANA CONFIGURACIONES (Admin y Programador)

**Objetivo:** Configuración general del comercio y sistema

### 10.1 Parte Superior - Indicadores
- [ ] Nombre del tema seleccionado
- [ ] Nombre del Comercio

### 10.2 Parte Media - Opciones
- [ ] **Actualizar Información del Comercio:**
  - [ ] Logo (upload)
  - [ ] Nombre
  - [ ] Razón social ante ARCA-AFIP
  - [ ] Dirección
  - [ ] Mail
  - [ ] Contacto
- [ ] **Actualizar Tema del Sistema:**
  - [ ] Tema oscuro
  - [ ] Tema claro
  - [ ] Otros temas (recomendar)
- [ ] **Actualizar/Agregar Formas de Pago:**
  - [ ] Efectivo
  - [ ] Transferencia
  - [ ] QR
  - [ ] Débito
  - [ ] Crédito
  - [ ] Cheque
  - [ ] Otros
- [ ] **Formatos de Fecha y Hora:**
  - [ ] Por defecto: "dd/mm/yyyy 00:00" (Argentina/Buenos Aires)
  - [ ] Configuración personalizable
- [ ] **Formatos de Moneda:**
  - [ ] Por defecto: Pesos Argentinos ($1.000.000,00)
  - [ ] Configuración personalizable

### 10.3 Parte Inferior
- [ ] Recomendaciones de uso

### 10.4 Backend
- [ ] Servicio de configuración
- [ ] Tabla de configuraciones (o campos en `comercios`)
- [ ] Tabla de formas de pago

### Dependencias:
- Tabla `comercios` en BD
- Se usa en Pasos 13️⃣ y 14️⃣ (Compras/Ventas)

### Capas Afectadas:
- **Base de Datos:** Tabla `configuraciones`, `formas_pago`
- **Backend:** `ConfiguracionService`
- **Frontend:** `Configuraciones.razor`

---

## 1️⃣1️⃣ VENTANA MANTENIMIENTO (Solo Programador)

**Objetivo:** Panel de administración avanzado para programador

### 11.1 Parte Superior - Indicadores
- [ ] Nombre del Comercio
- [ ] Nombre del usuario admin
- [ ] ID del comercio ingresado
- [ ] Total de registros en Supabase para ese comercio

### 11.2 Parte Media - Paneles
- [ ] **Panel de Información de BD:**
  - [ ] Nombre de la base de datos
  - [ ] Tablas creadas
  - [ ] Columnas por tabla
  - [ ] Registros por columna (por comercio)
  - [ ] Registros totales (todos los comercios)
  - [ ] Memoria ocupada por comercio
  - [ ] Memoria total ocupada
  - [ ] Memoria disponible
- [ ] **Panel de Usuarios:**
  - [ ] Lista de usuarios registrados
  - [ ] Edición de estado (Activo/Inactivo)
  - [ ] Lógica: Usuario inactivo no puede ingresar (ni él ni usuarios creados por él)
- [ ] **Panel de Sugerencias:**
  - [ ] Tipo de sugerencia
  - [ ] Descripción
  - [ ] Fecha y hora de carga
  - [ ] Estados: Revisión, En tratamiento, Tratadas
  - [ ] Marcar estado de sugerencias
- [ ] **Exportación de Backups:**
  - [ ] Por comercio (SQL, Excel, JSON)
  - [ ] Total de BD (SQL, Excel, JSON)

### 11.3 Parte Inferior
- [ ] Links externos:
  - [ ] Supabase
  - [ ] GitHub
  - [ ] Cloudflare
  - [ ] DonWeb (dominios)

### 11.4 Backend
- [ ] Servicio de mantenimiento
- [ ] Integración con Supabase API (estadísticas)
- [ ] Generación de backups

### Dependencias:
- Paso 12️⃣ (Sugerencias)
- Rol Programador (Paso 3️⃣)

### Capas Afectadas:
- **Base de Datos:** Tabla `sugerencias` (si no existe)
- **Backend:** `MantenimientoService`
- **Frontend:** `Mantenimiento.razor`

---

## 1️⃣2️⃣ VENTANA SUGERENCIAS DE MEJORA (Anónima)

**Objetivo:** Sistema para que usuarios envíen sugerencias anónimas

### 12.1 Parte Superior - Indicadores
- [ ] Cantidad de sugerencias propuestas (por comercio)
- [ ] Cantidad en revisión
- [ ] Cantidad en tratamiento
- [ ] Cantidad tratadas

### 12.2 Parte Media - Panel de Carga
- [ ] Botón "Cargar nueva sugerencia" (Ctrl+F2)
- [ ] Tipo de sugerencia (dropdown: Estilos, Funcionalidades, Errores, Otras)
- [ ] Descripción (textarea)
- [ ] Botón Guardar
- [ ] Botón Editar

### 12.3 Parte Inferior - Tabla
- [ ] Columnas: Tipo, Descripción, Acciones (Editar, Eliminar)
- [ ] Filtros por estado (opcional)

### 12.4 Base de Datos
- [ ] Crear tabla `sugerencias` si no existe:
  - [ ] id (uuid)
  - [ ] comercio_id (uuid, FK)
  - [ ] tipo (enum o string)
  - [ ] descripcion (text)
  - [ ] estado (enum: Propuesta, Revisión, En Tratamiento, Tratada)
  - [ ] fecha_creacion (timestamp)
  - [ ] fecha_actualizacion (timestamp)
  - [ ] anonimo (boolean, true por defecto)

### 12.5 Backend
- [ ] `SugerenciaService`
- [ ] Métodos CRUD
- [ ] Filtrado por estado

### Dependencias:
- Tabla `sugerencias` en BD
- Se usa en Paso 11️⃣ (Mantenimiento)

### Capas Afectadas:
- **Base de Datos:** Nueva tabla `sugerencias`
- **Backend:** `SugerenciaService`
- **Frontend:** `Sugerencias.razor`

---

## 1️⃣3️⃣ VENTANA COMPRAS

**Objetivo:** Gestión de compras con flujo tipo POS

### 13.1 Parte Superior - Indicadores
- [ ] Cantidad de compras cargadas
- [ ] Cantidad con deudas + monto total (se actualiza con filtros)

### 13.2 Parte Media - Panel de Carga (Ctrl+F2)
- [ ] Facturación (manual, default: "No Aplica")
- [ ] Proveedor (autocomplete avanzado, default: "NO APLICA")
- [ ] **Productos:**
  - [ ] Código de barras* (focus inicial, manual/scanner)
  - [ ] Nombre del producto* (autocomplete, se completa con código de barras)
  - [ ] Unidades (numérico, default: 1.0, > 0)
  - [ ] Precio Costo por unidad (manual, default: precio del producto, >= 0)
  - [ ] % Descuento (1.00% - 100.00%, default: 0.00%)
  - [ ] Botón Cargar / Enter (agrega a tabla temporal)
- [ ] **Tabla de Productos Registrados:**
  - [ ] Columnas: Nombre, Unidades, Costo Unitario, Costo Total, Acciones (Editar, Eliminar)
  - [ ] Sumatoria de costos totales (inferior derecha)
- [ ] **Pagos:**
  - [ ] Botón "Cargar pago" (Ctrl+P, focus en método de pago)
  - [ ] Método de pago (dropdown desde Configuraciones)
  - [ ] Total Abonado (default: suma de costos, editable)
  - [ ] Tabla de Pagos Registrados:
    - [ ] Columnas: Método Pago, Suma Costo Total, Total Abonado, Total Deuda, Acciones (Editar, Eliminar)
- [ ] Observaciones (opcional)
- [ ] Botón Finalizar Compra (Ctrl+F, con confirmación)
- [ ] Botón Cancelar (Ctrl+E, con confirmación)
- [ ] ID único automático (XX + ID_COMERCIO)

### 13.3 Lógica de Negocio
- [ ] Actualización automática de stock al finalizar compra
- [ ] Cálculo de deudas (si Total Abonado < Costo Total)
- [ ] Validaciones:
  - [ ] Al menos un producto
  - [ ] Unidades > 0
  - [ ] Precios >= 0

### 13.4 Parte Inferior - Tabla
- [ ] Columnas:
  - [ ] Facturación (con filtro)
  - [ ] Proveedor (con filtro)
  - [ ] Unidades (suma total)
  - [ ] Costo Total
  - [ ] Total Abonado
  - [ ] Deuda
  - [ ] Acciones (Ver detalle, Imprimir, Editar, Eliminar - solo admin)
- [ ] Filtros tipo Excel
- [ ] Paginación

### 13.5 Funcionalidades Adicionales
- [ ] Ver detalle (modal con toda la información)
- [ ] Imprimir (formato POS 80)
- [ ] Editar (solo admin)
- [ ] Eliminar (solo admin, con confirmación)

### 13.6 Backend
- [ ] Verificar/actualizar `CompraService`
- [ ] Integración con `DetalleCompraService`
- [ ] Integración con `StockService` (actualización automática)
- [ ] Lógica de pagos y deudas

### Dependencias:
- Paso 5️⃣ (Proveedores)
- Paso 9️⃣ (Productos)
- Paso 10️⃣ (Configuraciones - formas de pago)
- Tablas `compras`, `detalle_compra`, `stock` en BD

### Capas Afectadas:
- **Base de Datos:** Tablas `compras`, `detalle_compra`, `pagos_compra` (si aplica)
- **Backend:** `CompraService`, `DetalleCompraService`, integración con `StockService`
- **Frontend:** `Compras.razor`, componente de impresión POS

---

## 1️⃣4️⃣ VENTANA VENTAS

**Objetivo:** Gestión de ventas con flujo similar a Compras

### 14.1 Estructura (Similar a Compras)
- [ ] Parte Superior: Indicadores (ventas cargadas, deudas)
- [ ] Parte Media: Panel de carga
- [ ] Parte Inferior: Tabla

### 14.2 Diferencias con Compras
- [ ] Cliente (en lugar de Proveedor)
- [ ] Precio Venta (en lugar de Precio Costo)
- [ ] Descuentos aplicables
- [ ] Deuda de clientes (en lugar de deuda a proveedores)

### 14.3 Lógica de Negocio
- [ ] Actualización automática de stock (resta)
- [ ] Cálculo de deudas de clientes
- [ ] Validaciones similares a Compras

### 14.4 Backend
- [ ] Verificar/actualizar `VentaService`
- [ ] Integración con `DetalleVentaService`
- [ ] Integración con `StockService` (actualización automática)
- [ ] Lógica de pagos y deudas

### Dependencias:
- Paso 6️⃣ (Clientes)
- Paso 9️⃣ (Productos)
- Paso 10️⃣ (Configuraciones)
- Paso 13️⃣ (estructura similar a Compras)
- Tablas `ventas`, `detalle_venta`, `stock` en BD

### Capas Afectadas:
- **Base de Datos:** Tablas `ventas`, `detalle_venta`, `pagos_venta` (si aplica)
- **Backend:** `VentaService`, `DetalleVentaService`, integración con `StockService`
- **Frontend:** `Ventas.razor`, componente de impresión POS

---

## 1️⃣5️⃣ DASHBOARD

**Objetivo:** Panel principal con gráficos y métricas

### 15.1 Sub Ventana - Gráficos de Usuarios
- [ ] Gráfico de barras: Ventas por usuario
- [ ] Filtro por fecha

### 15.2 Sub Ventana - Gráficos de Proveedores
- [ ] Gráfico de barras: Deudas por proveedor
- [ ] Solo mostrar proveedores con deuda > 0
- [ ] Filtro por fecha

### 15.3 Sub Ventana - Gráficos de Clientes
- [ ] Gráfico de barras: Deudas por cliente
- [ ] Solo mostrar clientes con deuda > 0
- [ ] Filtro por fecha

### 15.4 Sub Ventana - Gráficos de Productos
- [ ] Gráfico de barras: Productos más vendidos
- [ ] Columnas: Nombre, Cantidad de unidades, Monto total en pesos
- [ ] Filtro por fecha
- [ ] Scroll si hay muchos productos

### 15.5 Sub Ventana - Gráficos de Compras
- [ ] Gráfico de barras: Compras mensuales
- [ ] Columnas: Mes, Monto total en pesos
- [ ] Filtro por fecha
- [ ] Scroll si hay muchos meses

### 15.6 Sub Ventana - Gráficos de Ventas
- [ ] Gráfico de barras: Ventas mensuales
- [ ] Columnas: Mes, Monto total en pesos
- [ ] Filtro por fecha
- [ ] Scroll si hay muchos meses

### 15.7 Librería de Gráficos
- [ ] Elegir librería (Chart.js, Blazorise Charts, etc.)
- [ ] Integrar en proyecto
- [ ] Componentes reutilizables de gráficos

### 15.8 Backend
- [ ] Servicios de consultas agregadas:
  - [ ] Ventas por usuario
  - [ ] Deudas por proveedor
  - [ ] Deudas por cliente
  - [ ] Productos más vendidos
  - [ ] Compras mensuales
  - [ ] Ventas mensuales
- [ ] Filtros por fecha en todas las consultas

### Dependencias:
- Paso 13️⃣ (Compras)
- Paso 14️⃣ (Ventas)
- Paso 4️⃣ (Usuarios)
- Paso 5️⃣ (Proveedores)
- Paso 6️⃣ (Clientes)
- Paso 9️⃣ (Productos)

### Capas Afectadas:
- **Base de Datos:** Consultas agregadas (no nuevas tablas)
- **Backend:** Servicios de reportes/consultas
- **Frontend:** `Dashboard.razor`, componentes de gráficos

---

## 📝 NOTAS GENERALES

### Componentes Reutilizables a Crear
- [ ] Modal/Panel genérico (usado en todas las ventanas)
- [ ] DataTable con filtros tipo Excel
- [ ] Paginación
- [ ] Autocomplete avanzado (usado en Productos, Compras, Ventas)
- [ ] Selector de fecha con formato argentino
- [ ] Input de moneda con formato argentino
- [ ] Componente de impresión POS 80

### Validaciones Comunes
- [ ] IDs únicos por comercio
- [ ] Formato de IDs: XX + ID_COMERCIO
- [ ] Estados: Activo (Verde) / Inactivo (Rojo)
- [ ] Fechas: formato dd/mm/yyyy HH:mm (Argentina)
- [ ] Monedas: formato $1.000.000,00 (Pesos Argentinos)

### Atajos de Teclado
- [ ] Ctrl+F2: Abrir panel de carga
- [ ] Ctrl+Intro: Guardar
- [ ] Ctrl+E: Cancelar
- [ ] Ctrl+P: Cargar pago (Compras/Ventas)
- [ ] Ctrl+F: Finalizar (Compras/Ventas)
- [ ] Enter: Seleccionar en autocomplete

### Testing
- [ ] Cada paso debe probarse antes de avanzar
- [ ] Validar no romper funcionalidades existentes
- [ ] Probar en diferentes roles (Admin, User, Programador)
- [ ] Probar filtros, paginación, validaciones

---

## 🎯 ORDEN DE EJECUCIÓN RECOMENDADO

1. **Fase de Análisis:** Pasos 1️⃣ y 2️⃣ (solo documentación)
2. **Fase de Autenticación:** Paso 3️⃣ (crítico, base de todo)
3. **Fase de Gestión Básica:** Pasos 4️⃣, 5️⃣, 6️⃣, 7️⃣, 8️⃣ (CRUDs simples)
4. **Fase de Productos:** Paso 9️⃣ (complejo, requiere 7️⃣ y 8️⃣)
5. **Fase de Configuración:** Paso 10️⃣ (requerido para operaciones)
6. **Fase de Operaciones:** Pasos 13️⃣ y 14️⃣ (requieren múltiples dependencias)
7. **Fase de Mantenimiento:** Pasos 11️⃣ y 12️⃣ (especiales)
8. **Fase de Dashboard:** Paso 15️⃣ (requiere todas las operaciones)

---

**FIN DEL CHECKLIST**

