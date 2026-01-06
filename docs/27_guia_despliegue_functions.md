# Guía de Despliegue de Edge Functions

## ✅ Estado Actual

- ✅ Extensión Deno instalada en VS Code
- ✅ Archivos de funciones creados
- ✅ Configuración de VS Code lista
- ⏳ Pendiente: Configurar Resend API Key
- ⏳ Pendiente: Desplegar funciones

## 📋 Próximos Pasos

### 1. Configurar Resend API Key en Supabase

1. Ir a **Supabase Dashboard** → **Edge Functions** → **Secrets**
2. Hacer clic en **"New Secret"**
3. Ingresar:
   - **Name:** `RESEND_API_KEY`
   - **Value:** (tu API Key de Resend)
4. Guardar

### 2. Desplegar las Funciones

Tienes dos opciones:

#### Opción A: Desde Supabase Dashboard (Más Fácil)

1. Ir a **Edge Functions** → **Functions**
2. Hacer clic en **"Deploy a new function"**
3. Subir los archivos desde tu proyecto local

**Nota:** Esta opción requiere tener los archivos listos. Puedes usar la opción B que es más directa.

#### Opción B: Desde Terminal con Supabase CLI (Recomendado)

1. Instalar Supabase CLI (si no lo tienes):
   ```bash
   npm install -g supabase
   ```

2. Login en Supabase:
   ```bash
   supabase login
   ```

3. Link al proyecto:
   ```bash
   supabase link --project-ref jnplnwpofxzfqchkvgpv
   ```

4. Desplegar cada función:
   ```bash
   supabase functions deploy send-email
   supabase functions deploy solicitar-registro
   supabase functions deploy aprobar-registro
   ```

### 3. Verificar Despliegue

Después de desplegar, deberías ver las 3 nuevas funciones en el dashboard:
- `send-email`
- `solicitar-registro`
- `aprobar-registro`

## 🧪 Probar las Funciones

### Probar `solicitar-registro`:

Desde el código (Registro.razor ya lo llama), o manualmente:

```typescript
const response = await supabase.functions.invoke('solicitar-registro', {
  body: { emailSolicitante: 'test@example.com' }
})
```

## ⚠️ Notas Importantes

1. **RESEND_API_KEY debe estar configurado antes de desplegar**, o las funciones fallarán al intentar enviar emails.

2. **Las variables SUPABASE_URL y SUPABASE_SERVICE_ROLE_KEY** se configuran automáticamente por Supabase, no necesitas agregarlas manualmente.

3. **Verificar dominio en Resend** (opcional pero recomendado):
   - Sin dominio verificado: Puedes usar `onboarding@resend.dev` (puede ir a spam)
   - Con dominio verificado: Puedes usar `noreply@adminisgo.com.ar` (mejor entregabilidad)

