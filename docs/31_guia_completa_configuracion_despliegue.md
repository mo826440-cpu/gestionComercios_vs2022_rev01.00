# Guía Completa: Configuración y Despliegue

## 📋 Checklist de Pasos

- [ ] 1. Crear cuenta en Resend y obtener API Key
- [ ] 2. Configurar RESEND_API_KEY en Supabase Secrets
- [ ] 3. Instalar Supabase CLI (si no está instalado)
- [ ] 4. Login en Supabase CLI
- [ ] 5. Link al proyecto
- [ ] 6. Desplegar las 3 Edge Functions
- [ ] 7. Verificar que las funciones estén desplegadas
- [ ] 8. Probar el flujo completo

---

## Paso 1: Crear cuenta en Resend y obtener API Key

### 1.1 Crear cuenta
1. Ir a [https://resend.com](https://resend.com)
2. Hacer clic en **"Sign Up"** o **"Get Started"**
3. Crear cuenta con tu email
4. Verificar tu email

### 1.2 Obtener API Key
1. Una vez dentro del dashboard, ir a **"API Keys"** en el menú lateral
2. Hacer clic en **"Create API Key"**
3. Darle un nombre (ej: "Supabase Edge Functions")
4. Seleccionar permisos: **"Sending access"**
5. Hacer clic en **"Add"**
6. **⚠️ IMPORTANTE:** Copiar la API Key inmediatamente (solo se muestra una vez)
   - Formato: `re_xxxxxxxxxxxxxxxxxxxxxxxxxxxxx`

---

## Paso 2: Configurar RESEND_API_KEY en Supabase

### 2.1 Ir a Secrets
1. Abrir Supabase Dashboard
2. Ir a **Edge Functions** → **Secrets** (en el menú lateral izquierdo)

### 2.2 Agregar Secret
1. Hacer clic en **"New Secret"** o **"Add Secret"**
2. Ingresar:
   - **Name:** `RESEND_API_KEY`
   - **Value:** (pegar la API Key que copiaste de Resend)
3. Hacer clic en **"Save"** o **"Add"**

### 2.3 Verificar
- Deberías ver `RESEND_API_KEY` en la lista de secrets

---

## Paso 3: Instalar Supabase CLI

### Verificar si ya está instalado:
```powershell
supabase --version
```

Si muestra un número de versión, ya está instalado. Si no:

### Instalar con npm (si tienes Node.js):
```powershell
npm install -g supabase
```

### O descargar binario:
1. Ir a [https://github.com/supabase/cli/releases](https://github.com/supabase/cli/releases)
2. Descargar la versión para Windows
3. Agregar al PATH

---

## Paso 4: Login en Supabase CLI

```powershell
supabase login
```

Esto abrirá el navegador para autenticarte. Una vez autenticado, volverás a la terminal.

---

## Paso 5: Link al proyecto

```powershell
supabase link --project-ref jnplnwpofxzfqchkvgpv
```

**Nota:** El `project-ref` es `jnplnwpofxzfqchkvgpv` (lo vimos en las URLs del dashboard).

---

## Paso 6: Desplegar las Edge Functions

Desplegar cada función una por una:

```powershell
supabase functions deploy send-email
supabase functions deploy solicitar-registro
supabase functions deploy aprobar-registro
```

### Verificar despliegue exitoso:
Cada comando debería mostrar:
- ✅ "Deployed Function send-email"
- ✅ "Deployed Function solicitar-registro"
- ✅ "Deployed Function aprobar-registro"

---

## Paso 7: Verificar en Dashboard

1. Ir a Supabase Dashboard → **Edge Functions** → **Functions**
2. Deberías ver las 3 nuevas funciones:
   - `send-email`
   - `solicitar-registro`
   - `aprobar-registro`

---

## Paso 8: Probar el Flujo Completo

### 8.1 Probar Registro con Email No Autorizado

1. Ir a la aplicación: `gestion-comercios.pages.dev/registro`
2. Ingresar un email NO autorizado (ej: `test@example.com`)
3. Hacer clic en "Continuar"
4. **Esperado:**
   - Se muestra panel de código de verificación
   - Se crea solicitud en BD
   - Se envía email a `mo826440@gmail.com`

### 8.2 Verificar Email al Admin

1. Revisar el email `mo826440@gmail.com`
2. Deberías recibir un email con:
   - Email del solicitante
   - Botones "Aprobar" y "Rechazar"

### 8.3 Aprobar Solicitud

1. Hacer clic en **"Aprobar"** en el email
2. **Esperado:**
   - Se genera código de 6 dígitos
   - Se envía email al solicitante con el código

### 8.4 Verificar Código

1. El usuario recibe email con código
2. Ingresar código en el panel de registro
3. Hacer clic en "Verificar Código"
4. **Esperado:**
   - Si el código es correcto → Avanza al Paso 2 (Datos Personales)
   - Si es incorrecto → Muestra error con intentos restantes

### 8.5 Completar Registro

1. Completar todos los pasos del registro
2. Verificar en Supabase que se crearon:
   - Usuario en `auth.users`
   - Registro en `comercios`
   - Registro en `usuarios`

---

## 🐛 Troubleshooting

### Error: "RESEND_API_KEY not configured"
- Verificar que el secret esté configurado en Supabase
- Verificar que el nombre sea exactamente `RESEND_API_KEY`

### Error: "Failed to send email"
- Verificar que la API Key de Resend sea correcta
- Verificar que Resend tenga créditos disponibles (plan gratuito: 3,000 emails/mes)

### Error al desplegar función
- Verificar que estés logueado: `supabase login`
- Verificar que el proyecto esté linkeado: `supabase link --project-ref jnplnwpofxzfqchkvgpv`
- Verificar que los archivos existan en `supabase/functions/[nombre-funcion]/index.ts`

### No se reciben emails
- Verificar spam/correo no deseado
- Si no verificaste dominio, usar `onboarding@resend.dev` temporalmente
- Verificar logs de la función en Supabase Dashboard

---

## ✅ Checklist Final

- [ ] Resend API Key configurada en Supabase
- [ ] 3 funciones desplegadas correctamente
- [ ] Flujo de registro con código funcionando
- [ ] Emails se envían correctamente
- [ ] Código de verificación funciona

