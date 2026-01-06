# Configuración de Resend para Edge Functions

## 📋 Objetivo
Configurar Resend (servicio de email) para enviar emails desde Supabase Edge Functions.

## 🔧 Pasos de Configuración

### 1. Crear cuenta en Resend

1. Ir a [https://resend.com](https://resend.com)
2. Crear cuenta (gratis hasta 3,000 emails/mes)
3. Verificar tu email
4. Ir a **API Keys** en el dashboard
5. Crear una nueva API Key
6. **Copiar la API Key** (solo se muestra una vez)

### 2. Configurar en Supabase

1. Ir a Supabase Dashboard → **Edge Functions**
2. Ir a **Settings** → **Secrets**
3. Agregar secret:
   - **Name:** `RESEND_API_KEY`
   - **Value:** (pegar la API Key de Resend)
4. Guardar

### 3. Verificar dominio (Opcional pero recomendado)

Para enviar desde `noreply@adminisgo.com.ar`:

1. En Resend Dashboard → **Domains**
2. Agregar dominio: `adminisgo.com.ar`
3. Agregar los registros DNS que Resend te indique:
   - En Cloudflare (o tu proveedor DNS):
     - Agregar registro SPF
     - Agregar registro DKIM
     - Agregar registro DMARC
4. Esperar verificación (puede tardar hasta 24 horas)

**Nota:** Si no verificas el dominio, puedes usar el dominio de prueba de Resend (ej: `onboarding@resend.dev`), pero los emails pueden ir a spam.

### 4. Desplegar Edge Functions

Las funciones ya están creadas en:
- `supabase/functions/send-email/index.ts`
- `supabase/functions/solicitar-registro/index.ts`
- `supabase/functions/aprobar-registro/index.ts`

Para desplegar:

```bash
# Instalar Supabase CLI (si no lo tienes)
npm install -g supabase

# Login en Supabase
supabase login

# Link al proyecto
supabase link --project-ref jnplnwpofxzfqchkvgpv

# Desplegar funciones
supabase functions deploy send-email
supabase functions deploy solicitar-registro
supabase functions deploy aprobar-registro
```

### 5. Variables de Entorno Necesarias

Asegúrate de que estas variables estén configuradas en Supabase:

- `RESEND_API_KEY` - API Key de Resend
- `SUPABASE_URL` - Ya está configurada automáticamente
- `SUPABASE_SERVICE_ROLE_KEY` - Ya está configurada automáticamente

## 📧 Funciones Disponibles

### 1. `send-email`
Envía un email genérico usando Resend.

**Request:**
```json
{
  "to": "usuario@example.com",
  "subject": "Asunto del email",
  "html": "<h1>Contenido HTML</h1>",
  "from": "noreply@adminisgo.com.ar" // opcional
}
```

### 2. `solicitar-registro`
Crea una solicitud de registro y envía email al admin.

**Request:**
```json
{
  "emailSolicitante": "usuario@example.com"
}
```

### 3. `aprobar-registro`
Aprueba o rechaza una solicitud y envía código al solicitante.

**Request (GET con query params):**
```
?solicitudId=uuid&accion=aprobar
```

O (POST):
```json
{
  "solicitudId": "uuid",
  "accion": "aprobar" // o "rechazar"
}
```

## 🧪 Probar las Funciones

### Desde Supabase Dashboard:
1. Ir a **Edge Functions**
2. Seleccionar la función
3. Ir a **Invoke**
4. Ingresar el JSON de request
5. Ejecutar

### Desde el código:
```typescript
const { data, error } = await supabase.functions.invoke('solicitar-registro', {
  body: { emailSolicitante: 'test@example.com' }
})
```

## ⚠️ Troubleshooting

### Error: "RESEND_API_KEY not configured"
- Verificar que el secret esté configurado en Supabase
- Verificar que el nombre sea exactamente `RESEND_API_KEY`

### Emails van a spam
- Verificar dominio en Resend
- Agregar registros SPF, DKIM, DMARC
- Usar un dominio verificado

### Error 401 al enviar email
- Verificar que la API Key sea correcta
- Verificar que la API Key no haya expirado

## 📚 Recursos

- [Resend Documentation](https://resend.com/docs)
- [Supabase Edge Functions](https://supabase.com/docs/guides/functions)
- [Resend API Reference](https://resend.com/docs/api-reference/emails/send-email)

