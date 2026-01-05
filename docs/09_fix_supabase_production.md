# Solución: Error de Conexión con Supabase en Producción

## 🔍 Problema

Error `net_uri_BadHostName` al intentar conectar con Supabase en producción.

**Causa:** El archivo `appsettings.Production.json` tenía las credenciales vacías, y en producción puede estar sobrescribiendo `appsettings.json`.

---

## ✅ Solución Aplicada

Se copiaron las credenciales de Supabase desde `appsettings.json` a `appsettings.Production.json`:

- **URL:** `https://jnplnwpofxzfqchkvgpv.supabase.co`
- **AnonKey:** (la clave pública de Supabase)

---

## 📝 Nota sobre Seguridad

**IMPORTANTE:** La anon key de Supabase está diseñada para ser pública (se ejecuta en el navegador). Sin embargo, para mayor seguridad en el futuro, podrías:

1. **Usar variables de entorno** (más complejo en Blazor WebAssembly)
2. **Usar un backend proxy** (requiere servidor)
3. **Mantener la anon key pública** (recomendado para Blazor WebAssembly)

La anon key solo permite operaciones permitidas por RLS (Row Level Security) en Supabase, así que es segura para usar públicamente.

---

## 🚀 Próximos Pasos

1. El workflow se ejecutará automáticamente (por el push)
2. En 3-5 minutos el nuevo deployment estará listo
3. La conexión con Supabase debería funcionar correctamente

---

## 🔍 Verificar

Después del deployment:
1. Recargar `https://gestion-comercios.pages.dev`
2. Intentar iniciar sesión
3. La conexión con Supabase debería funcionar

