# ✅ QUÉ HACER AHORA - Pasos Claros

## 🎯 Tu situación:
- ✅ Supabase CLI descargado en `C:\tools\supabase\`
- ✅ PATH configurado (pero necesita reiniciar PowerShell)
- ⏳ Necesitas continuar con login y despliegue

---

## 🚀 OPCIÓN RÁPIDA: Usar ruta completa

**No necesitas cerrar PowerShell**, usa la ruta completa directamente:

### Paso 1: Login en Supabase
```powershell
C:\tools\supabase\supabase.exe login
```
Esto abrirá el navegador para autenticarte.

### Paso 2: Link al proyecto
```powershell
C:\tools\supabase\supabase.exe link --project-ref jnplnwpofxzfqchkvgpv
```

### Paso 3: Antes de desplegar - Configurar Resend

**A. Crear cuenta en Resend:**
1. Ir a: https://resend.com
2. Crear cuenta (puedes usar tu email de Google)
3. Verificar email
4. Ir a **"API Keys"** → **"Create API Key"**
5. Nombre: "Supabase Edge Functions"
6. **⚠️ COPIAR LA API KEY** (solo se muestra una vez)
   - Formato: `re_xxxxxxxxxxxxx`

**B. Configurar en Supabase:**
1. Ir a: https://supabase.com/dashboard
2. Seleccionar tu proyecto
3. Menú lateral → **"Edge Functions"** → **"Secrets"**
4. Clic en **"New Secret"** o **"Add Secret"**
5. Ingresar:
   - **Name:** `RESEND_API_KEY` (exactamente así, mayúsculas)
   - **Value:** (pegar la API Key que copiaste)
6. Clic en **"Save"** o **"Add"**

### Paso 4: Desplegar las 3 funciones
```powershell
C:\tools\supabase\supabase.exe functions deploy send-email
C:\tools\supabase\supabase.exe functions deploy solicitar-registro
C:\tools\supabase\supabase.exe functions deploy aprobar-registro
```

Cada comando debería mostrar: `✅ Deployed Function [nombre]`

---

## 🔄 OPCIÓN ALTERNATIVA: Reiniciar PowerShell (si prefieres usar `supabase` sin ruta completa)

1. **Cerrar TODAS las ventanas de PowerShell**
2. **Abrir PowerShell NUEVO**
3. Ejecutar: `supabase --version` (debería funcionar ahora)
4. Si funciona, puedes usar `supabase` en lugar de `C:\tools\supabase\supabase.exe`

---

## ✅ Verificar que todo funcionó

1. Ir a Supabase Dashboard → **Edge Functions** → **Functions**
2. Deberías ver las 3 funciones:
   - `send-email`
   - `solicitar-registro`
   - `aprobar-registro`

---

## 🧪 Probar el flujo completo

1. Ir a: `https://gestion-comercios.pages.dev/registro`
2. Ingresar un email NO autorizado (ej: `test@example.com`)
3. Deberías recibir email en `mo826440@gmail.com` para aprobar

---

## 💡 Resumen de comandos (copiar y pegar)

```powershell
# Login
C:\tools\supabase\supabase.exe login

# Link al proyecto
C:\tools\supabase\supabase.exe link --project-ref jnplnwpofxzfqchkvgpv

# Desplegar funciones (después de configurar Resend)
C:\tools\supabase\supabase.exe functions deploy send-email
C:\tools\supabase\supabase.exe functions deploy solicitar-registro
C:\tools\supabase\supabase.exe functions deploy aprobar-registro
```

---

## ❓ ¿Necesitas ayuda?

Si algo no funciona:
1. Revisar los mensajes de error
2. Verificar que Resend API Key esté configurada en Supabase
3. Verificar los logs en Supabase Dashboard → Edge Functions → Logs

