# Solución: Errores en VS Code para Archivos Deno

## 🔴 Problema

Los archivos TypeScript en `supabase/functions/` muestran errores en rojo en VS Code porque:

1. **VS Code intenta validarlos como TypeScript de Node.js** en lugar de Deno
2. **Deno permite importaciones desde URLs** (ej: `https://deno.land/std@0.168.0/http/server.ts`)
3. **El objeto global `Deno`** no existe en Node.js pero sí en Deno
4. **Las importaciones de ESM** funcionan diferente en Deno

## ✅ Solución

Se han creado dos archivos de configuración:

### 1. `.vscode/settings.json`
Configura VS Code para reconocer archivos Deno en `supabase/functions/`.

### 2. `supabase/functions/deno.json`
Configuración específica de Deno para las funciones.

## 📋 Pasos Adicionales (si los errores persisten)

### Opción 1: Instalar Extensión Deno para VS Code

1. Abrir VS Code
2. Ir a **Extensions** (Ctrl+Shift+X)
3. Buscar "Deno" (por denoland)
4. Instalar la extensión **"Deno"** oficial
5. Recargar VS Code

### Opción 2: Verificar que la Extensión Esté Activada

1. Abrir un archivo `.ts` en `supabase/functions/`
2. Ver en la barra de estado inferior (abajo a la derecha)
3. Debería decir "Deno" activo
4. Si dice "TypeScript", hacer clic y seleccionar "Deno"

### Opción 3: Configuración Manual por Workspace

Si los errores persisten, crear `.vscode/settings.json` en la raíz con:

```json
{
  "deno.enable": true,
  "deno.enablePaths": ["supabase/functions"],
  "[typescript]": {
    "editor.defaultFormatter": "denoland.vscode-deno"
  }
}
```

## ⚠️ Nota Importante

**Los errores en rojo NO afectan el funcionamiento de las funciones**. Son solo advertencias del editor porque VS Code no sabe que son archivos Deno.

Cuando despliegues las funciones con `supabase functions deploy`, funcionarán correctamente porque Supabase usa Deno para ejecutarlas.

## 🧪 Verificar que Funciona

Después de instalar la extensión y recargar VS Code:

1. Abrir cualquier archivo `.ts` en `supabase/functions/`
2. Los errores deberían desaparecer
3. El autocompletado de Deno debería funcionar
4. El objeto `Deno` debería ser reconocido

## 📚 Recursos

- [Extensión Deno para VS Code](https://marketplace.visualstudio.com/items?itemName=denoland.vscode-deno)
- [Documentación de Deno](https://deno.land/manual)
- [Supabase Edge Functions](https://supabase.com/docs/guides/functions)

