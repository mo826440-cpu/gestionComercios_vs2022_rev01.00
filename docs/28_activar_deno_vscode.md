# Cómo Activar Deno en VS Code

## 🔴 Si los errores en rojo persisten después de instalar la extensión:

### Paso 1: Recargar VS Code

1. Cerrar completamente VS Code
2. Volver a abrir VS Code
3. Abrir el proyecto

### Paso 2: Activar Deno Manualmente

1. Abrir cualquier archivo `.ts` en `supabase/functions/` (ej: `send-email/index.ts`)
2. Hacer clic en el botón de **lenguaje** en la barra de estado inferior (abajo a la derecha)
   - Debería decir "TypeScript" o "JavaScript"
3. Seleccionar **"Configure Deno for this workspace"** o **"Deno"**
4. Confirmar que quieres usar Deno

### Paso 3: Verificar que Está Activo

Después de activar Deno:

1. Ver en la barra de estado inferior (abajo a la derecha)
2. Debería decir **"Deno"** en lugar de "TypeScript"
3. Los errores en rojo deberían desaparecer

### Paso 4: Si No Aparece la Opción de Deno

1. Presionar **Ctrl+Shift+P** (o Cmd+Shift+P en Mac)
2. Escribir: **"Deno: Enable"**
3. Seleccionar **"Deno: Enable"** o **"Deno: Enable for workspace"**
4. Confirmar

### Paso 5: Verificar Configuración

Si los errores persisten, verificar que el archivo `.vscode/settings.json` tenga:

```json
{
  "deno.enable": true,
  "deno.enablePaths": ["supabase/functions"]
}
```

## ✅ Verificación Final

1. Abrir `supabase/functions/send-email/index.ts`
2. Los errores deberían desaparecer
3. El autocompletado de Deno debería funcionar
4. El objeto `Deno` debería ser reconocido

## ⚠️ Nota Importante

**Los errores NO afectan el funcionamiento de las funciones.** Son solo advertencias del editor. Las funciones funcionarán correctamente cuando las despliegues con Supabase CLI, porque Supabase usa Deno para ejecutarlas.

Si prefieres, puedes ignorar los errores y continuar con el despliegue de las funciones. Funcionarán perfectamente.

