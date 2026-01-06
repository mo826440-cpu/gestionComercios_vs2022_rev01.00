# Instalar Deno Localmente (Opcional)

## ⚠️ Importante

**NO necesitas instalar Deno localmente** para que las Edge Functions funcionen. Las funciones se ejecutan en el servidor de Supabase usando Deno.

Los errores en VS Code son solo del editor y NO afectan el funcionamiento real de las funciones.

## 🔧 Si quieres instalar Deno (para desarrollo local)

### Windows (PowerShell)

```powershell
irm https://deno.land/install.ps1 | iex
```

### Después de instalar:

1. Reiniciar VS Code
2. Los errores deberían desaparecer
3. El autocompletado de Deno funcionará

### Verificar instalación:

```powershell
deno --version
```

## ✅ Recomendación

**NO es necesario instalar Deno ahora.** Puedes:

1. **Ignorar los errores** y continuar con la configuración de Resend
2. **Desplegar las funciones** - funcionarán perfectamente
3. **Instalar Deno más tarde** si quieres hacer desarrollo local

Las funciones funcionarán correctamente al desplegarlas en Supabase.

