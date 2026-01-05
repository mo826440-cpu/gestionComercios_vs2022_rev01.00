# Diagnosticar Login que Queda Cargando

## 🔍 Problema

El login queda cargando pero no ingresa a la aplicación.

---

## ✅ Pasos para Diagnosticar

### Paso 1: Verificar Consola del Navegador

1. Abrir la consola del navegador (F12 o Click derecho → Inspeccionar → Console)
2. Hacer login
3. **Buscar errores en rojo** en la consola
4. Copiar cualquier error que aparezca

### Paso 2: Verificar Red (Network Tab)

1. En DevTools, ir a la pestaña **"Network"**
2. Hacer login
3. Buscar requests a Supabase (debería haber uno a `/auth/v1/token`)
4. Verificar si:
   - ✅ **200 OK** = Login exitoso
   - ❌ **401/403** = Credenciales incorrectas
   - ❌ **500/Network Error** = Problema de conexión

### Paso 3: Verificar Storage (Application Tab)

1. En DevTools, ir a la pestaña **"Application"**
2. En el menú izquierdo, expandir **"Local Storage"** o **"Session Storage"**
3. Buscar claves relacionadas con Supabase (ej: `sb-*`)
4. Verificar si hay tokens guardados después del login

---

## 🔧 Posibles Causas

### 1. Problema con la Sesión de Supabase

**Síntoma:** Login exitoso pero no redirige

**Solución:** Verificar que la sesión se esté guardando correctamente en el cliente de Supabase.

### 2. Problema con AuthorizeRouteView

**Síntoma:** Login exitoso pero redirige al login de nuevo

**Solución:** Verificar que `AuthorizeRouteView` detecte correctamente la autenticación.

### 3. Problema con la Navegación

**Síntoma:** Login exitoso pero queda en blanco

**Solución:** Verificar que la ruta `/` esté correctamente configurada.

### 4. Problema de Caché/Service Worker

**Síntoma:** Comportamiento inconsistente

**Solución:** 
- Limpiar caché del navegador
- Desactivar Service Worker temporalmente en DevTools → Application → Service Workers → Unregister

---

## 🆘 Información Necesaria para Diagnosticar

Para ayudar mejor, necesito:

1. **Errores en la consola** (si hay)
2. **Estado del request de login** (Network tab - status code)
3. **Si hay tokens en Storage** (Application tab)
4. **Qué pasa después del login** (¿queda en blanco? ¿vuelve al login? ¿muestra algún error?)

