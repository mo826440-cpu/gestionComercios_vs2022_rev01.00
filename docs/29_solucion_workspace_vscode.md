# Solución: Error "no workspace is opened"

## 🔴 Problema

Al intentar ejecutar "Deno: Enable" aparece el error:
> "Unable to write to Workspace Settings because no workspace is opened. Please open a workspace first and try again."

## ✅ Solución

**NO necesitas ejecutar el comando manualmente.** La configuración ya está en `.vscode/settings.json` y debería funcionar automáticamente.

### Paso 1: Asegurarse de tener la carpeta abierta

1. En VS Code, verificar que tienes la carpeta del proyecto abierta
2. Deberías ver el nombre de la carpeta en la barra superior (ej: `gestionComercios_vs2022_rev01.00`)

### Paso 2: Recargar VS Code

1. Cerrar completamente VS Code
2. Volver a abrir VS Code
3. Abrir la carpeta del proyecto: `File` → `Open Folder` → Seleccionar la carpeta `gestionComercios_vs2022_rev01.00`

### Paso 3: Verificar que Deno esté activo

1. Abrir cualquier archivo `.ts` en `supabase/functions/` (ej: `send-email/index.ts`)
2. Ver en la barra de estado inferior (abajo a la derecha)
3. Debería decir **"Deno"** (si está activo) o "TypeScript" (si no está activo)

### Paso 4: Si aún dice "TypeScript"

**Opción A: Habilitar Deno desde el archivo**

1. Abrir un archivo `.ts` en `supabase/functions/`
2. Hacer clic en el texto "TypeScript" en la barra inferior
3. Seleccionar **"Deno"** de la lista

**Opción B: Habilitar desde la configuración de usuario**

1. Presionar `Ctrl+Shift+P`
2. Escribir: `Preferences: Open User Settings (JSON)`
3. Agregar:
   ```json
   {
     "deno.enable": true,
     "deno.enablePaths": ["supabase/functions"]
   }
   ```
4. Guardar y recargar VS Code

## ⚠️ Nota Importante

**Los errores en rojo NO afectan el funcionamiento.** Las funciones funcionarán perfectamente cuando las despliegues, porque Supabase usa Deno para ejecutarlas.

Si prefieres, puedes ignorar los errores en rojo y continuar con la configuración de Resend y el despliegue de funciones.

