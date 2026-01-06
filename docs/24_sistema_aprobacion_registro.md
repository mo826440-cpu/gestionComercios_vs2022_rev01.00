# Sistema de Aprobación de Registro por Email

## 📋 Objetivo
Implementar un sistema donde usuarios no autorizados puedan solicitar permiso para registrarse, y un administrador pueda aprobar/rechazar estas solicitudes mediante email.

## 🔄 Flujo Propuesto

### 1. Usuario Solicita Registro
- Usuario ingresa email no autorizado (ej: `ortiz_martinfsc@hotmail.com`)
- Al hacer clic en "Continuar", en lugar de mostrar solo error:
  - Se muestra un panel: "Ingrese código de verificación"
  - Se crea una solicitud pendiente en la BD
  - Se envía email a `mo826440@gmail.com` pidiendo permiso

### 2. Administrador Aprueba/Rechaza
- `mo826440@gmail.com` recibe email con:
  - Email del solicitante
  - Fecha de solicitud
  - Botones/links para: "Aprobar" o "Rechazar"
- Al aprobar:
  - Se genera código de verificación aleatorio (ej: 6 dígitos)
  - Se guarda en BD vinculado a la solicitud
  - Se envía email al solicitante con el código
  - Estado de solicitud: "Aprobada"

### 3. Usuario Verifica Código
- Usuario recibe email con código
- Ingresa código en el panel de registro
- Sistema valida código:
  - ✅ Correcto → Permite continuar con registro
  - ❌ Incorrecto → Muestra error, permite reintentar

### 4. Registro Completo
- Una vez verificado el código, el usuario puede completar el registro normalmente
- Se crea comercio y usuario como admin

## 🗄️ Estructura de Base de Datos

### Tabla: `solicitudes_registro`
```sql
CREATE TABLE solicitudes_registro (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    email_solicitante TEXT NOT NULL,
    codigo_verificacion TEXT,
    estado TEXT NOT NULL DEFAULT 'pendiente', -- 'pendiente', 'aprobada', 'rechazada', 'verificada'
    fecha_solicitud TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    fecha_aprobacion TIMESTAMP WITH TIME ZONE,
    fecha_verificacion TIMESTAMP WITH TIME ZONE,
    aprobado_por TEXT, -- email del admin que aprobó
    intentos_verificacion INTEGER DEFAULT 0,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    updated_at TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    UNIQUE(email_solicitante)
);
```

## 📧 Opciones para Envío de Emails

### Opción 1: Supabase Edge Functions (Recomendado)
- Usar Supabase Edge Functions con servicio de email (Resend, SendGrid, etc.)
- Ventajas: Integrado con Supabase, fácil de mantener
- Desventajas: Requiere configurar servicio externo

### Opción 2: Supabase Auth Email Templates
- Usar las plantillas de email de Supabase Auth
- Ventajas: Ya está configurado
- Desventajas: Limitado a templates de Supabase

### Opción 3: Servicio Externo (Resend, SendGrid, etc.)
- Integrar directamente desde el cliente
- Ventajas: Más control
- Desventajas: Expone API keys en el cliente (no recomendado)

**Recomendación: Opción 1 (Supabase Edge Functions)**

## 🎨 Cambios en la UI

### Modificar `Registro.razor`:
1. Agregar nuevo paso: "Paso 1.5: Verificación de Email"
2. Si email no autorizado:
   - Mostrar panel de código de verificación
   - Botón "Solicitar permiso" (si no hay solicitud pendiente)
   - Campo para ingresar código
   - Botón "Verificar código"
3. Si código verificado correctamente:
   - Marcar email como autorizado temporalmente
   - Continuar con registro normal

## 🔐 Generación de Códigos

- Formato: 6 dígitos numéricos (ej: 123456)
- Expiración: 24 horas
- Intentos máximos: 5 intentos incorrectos

## 📝 Pasos de Implementación

1. **Crear tabla `solicitudes_registro`** en Supabase
2. **Crear Edge Function** para envío de emails
3. **Modificar `Registro.razor`** para incluir flujo de verificación
4. **Crear servicio `ISolicitudRegistroService`** para manejar solicitudes
5. **Crear página/componente** para que admin apruebe solicitudes (opcional, puede ser solo por email)
6. **Implementar generación y validación de códigos**
7. **Probar flujo completo**

## ⚠️ Consideraciones

- Los códigos deben ser únicos y seguros
- Implementar rate limiting para evitar spam
- Los códigos deben expirar después de cierto tiempo
- Limitar intentos de verificación incorrectos
- Logs de todas las solicitudes para auditoría

