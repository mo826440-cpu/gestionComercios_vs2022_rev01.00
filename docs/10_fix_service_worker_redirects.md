# Fix: Service Worker Redirects

## 🔍 Problema

Error `ERR_FAILED` y múltiples errores de `FetchEvent` en la consola:
- "The FetchEvent for "<URL>" resulted in a network error response: a redirected response was used for a request whose redirect mode is not "follow"."

## ✅ Solución

El Service Worker estaba interceptando requests pero no manejaba correctamente los redirects. 

**Cambio realizado:**
- Agregado `redirect: 'follow'` al fetch() en el Service Worker
- Agregado manejo de errores para requests de navegación
- Mejorado el fallback cuando hay errores de red

## 📝 Archivo Modificado

- `src/Client/wwwroot/service-worker.published.js`

## 🧪 Testing

Después del deployment:
1. Limpiar caché del navegador
2. Desregistrar Service Worker (DevTools → Application → Service Workers → Unregister)
3. Recargar la página
4. Verificar que no haya errores de FetchEvent en la consola
5. Intentar hacer login


