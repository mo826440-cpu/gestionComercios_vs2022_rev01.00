    # 🚀 Pasos Inmediatos: Configuración y Despliegue

## ✅ Estado Actual
- ✅ Edge Functions creadas (send-email, solicitar-registro, aprobar-registro)
- ✅ Código listo para desplegar
- ⏳ Supabase CLI: Necesita instalación
- ⏳ Resend API Key: Necesita configuración
- ⏳ Edge Functions: Pendientes de desplegar

---

## 📋 Próximos Pasos (En Orden)

### **PASO 1: Instalar Supabase CLI** ⚠️ IMPORTANTE

Tienes 3 opciones:

#### Opción A: Con winget (si está disponible)
```powershell
winget install --id=Supabase.CLI
```
**Luego:** Cerrar y reabrir PowerShell/Terminal

#### Opción B: Descargar manualmente (Más confiable)
1. Ir a: https://github.com/supabase/cli/releases/latest
2. Descargar: `supabase_windows_amd64.zip`
3. Extraer en una carpeta (ej: `C:\Tools\supabase`)
4. Agregar al PATH:
   - Buscar "Variables de entorno" en Windows
   - Editar "Path" del usuario
   - Agregar: `C:\Tools\supabase` (o donde lo extrajiste)
5. **Cerrar y reabrir PowerShell**

#### Opción C: Con Scoop (si lo tienes)
```powershell
scoop bucket add supabase https://github.com/supabase/scoop-bucket.git
scoop install supabase
```

**Verificar instalación:**
```powershell
supabase --version
```
Debería mostrar: `supabase/1.x.x`

---

### **PASO 2: Crear cuenta en Resend y obtener API Key** 📧

1. Ir a: https://resend.com
2. Hacer clic en **"Sign Up"** o **"Get Started"**
3. Crear cuenta con tu email
4. Verificar tu email
5. Una vez dentro:
   - Ir a **"API Keys"** en el menú lateral
   - Hacer clic en **"Create API Key"**
   - Nombre: "Supabase Edge Functions"
   - Permisos: **"Sending access"**
   - Hacer clic en **"Add"**
   - **⚠️ COPIAR LA API KEY** (solo se muestra una vez)
     - Formato: `re_xxxxxxxxxxxxxxxxxxxxxxxxxxxxx`

---

### **PASO 3: Configurar RESEND_API_KEY en Supabase** 🔐

1. Abrir Supabase Dashboard: https://supabase.com/dashboard
2. Seleccionar tu proyecto
3. Ir a **Edge Functions** → **Secrets** (menú lateral izquierdo)
4. Hacer clic en **"New Secret"** o **"Add Secret"**
5. Ingresar:
   - **Name:** `RESEND_API_KEY` (exactamente así, en mayúsculas)
   - **Value:** (pegar la API Key que copiaste de Resend)
6. Hacer clic en **"Save"** o **"Add"**
7. Verificar que aparece en la lista

---

### **PASO 4: Login en Supabase CLI** 🔑

Abrir PowerShell/Terminal y ejecutar:

```powershell
supabase login
```

Esto abrirá el navegador para autenticarte. Una vez autenticado, volverás a la terminal.

---

### **PASO 5: Link al proyecto** 🔗

```powershell
cd "C:\VS 2022\gestionComercios_vs2022_rev01.00"
supabase link --project-ref jnplnwpofxzfqchkvgpv
```

**Nota:** El `project-ref` es `jnplnwpofxzfqchkvgpv` (de tu URL del dashboard).

---

### **PASO 6: Desplegar las Edge Functions** 🚀

Desplegar cada función una por una:

```powershell
supabase functions deploy send-email
supabase functions deploy solicitar-registro
supabase functions deploy aprobar-registro
```

**Esperado:**
- ✅ "Deployed Function send-email"
- ✅ "Deployed Function solicitar-registro"
- ✅ "Deployed Function aprobar-registro"

---

### **PASO 7: Verificar en Dashboard** ✅

1. Ir a Supabase Dashboard → **Edge Functions** → **Functions**
2. Deberías ver las 3 nuevas funciones:
   - `send-email`
   - `solicitar-registro`
   - `aprobar-registro`

---

### **PASO 8: Probar el Flujo Completo** 🧪

#### 8.1 Probar Registro con Email No Autorizado

1. Ir a: `https://gestion-comercios.pages.dev/registro`
2. Ingresar un email NO autorizado (ej: `test@example.com`)
3. Hacer clic en "Continuar"
4. **Esperado:**
   - Se muestra panel de código de verificación
   - Se crea solicitud en BD
   - Se envía email a `mo826440@gmail.com`

#### 8.2 Verificar Email al Admin

1. Revisar el email `mo826440@gmail.com`
2. Deberías recibir un email con:
   - Email del solicitante
   - Botones "Aprobar" y "Rechazar"

#### 8.3 Aprobar Solicitud

1. Hacer clic en **"Aprobar"** en el email
2. **Esperado:**
   - Se genera código de 6 dígitos
   - Se envía email al solicitante con el código

#### 8.4 Verificar Código

1. El usuario recibe email con código
2. Ingresar código en el panel de registro
3. Hacer clic en "Verificar Código"
4. **Esperado:**
   - Si el código es correcto → Avanza al Paso 2 (Datos Personales)
   - Si es incorrecto → Muestra error con intentos restantes

#### 8.5 Completar Registro

1. Completar todos los pasos del registro
2. Verificar en Supabase que se crearon:
   - Usuario en `auth.users`
   - Registro en `comercios`
   - Registro en `usuarios`

---

## 🐛 Troubleshooting

### Error: "supabase: command not found"
- Cerrar y reabrir PowerShell/Terminal
- Verificar que esté en el PATH
- Reinstalar usando otro método

### Error: "RESEND_API_KEY not configured"
- Verificar que el secret esté configurado en Supabase
- Verificar que el nombre sea exactamente `RESEND_API_KEY` (mayúsculas)

### Error: "Failed to send email"
- Verificar que la API Key de Resend sea correcta
- Verificar que Resend tenga créditos (plan gratuito: 3,000 emails/mes)
- Revisar logs en Supabase Dashboard → Edge Functions → Logs

### Error al desplegar función
- Verificar que estés logueado: `supabase login`
- Verificar que el proyecto esté linkeado
- Verificar que los archivos existan en `supabase/functions/[nombre-funcion]/index.ts`

---

## ✅ Checklist Final

- [ ] Supabase CLI instalado y funcionando
- [ ] Resend API Key obtenida
- [ ] RESEND_API_KEY configurada en Supabase Secrets
- [ ] Login en Supabase CLI exitoso
- [ ] Proyecto linkeado correctamente
- [ ] 3 funciones desplegadas
- [ ] Flujo de registro probado y funcionando
- [ ] Emails se envían correctamente

---

## 📝 Notas Importantes

1. **Resend Plan Gratuito:** 3,000 emails/mes. Suficiente para testing.
2. **Dominio de Resend:** Si no verificas un dominio, usarás `onboarding@resend.dev` como remitente (temporal).
3. **Logs:** Siempre revisa los logs en Supabase Dashboard si algo falla.
4. **Secrets:** Los secrets se configuran por proyecto, no globalmente.

