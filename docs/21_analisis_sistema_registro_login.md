# Análisis del Sistema Actual - Registro e Ingreso

**Fecha:** 2025-01-XX  
**Objetivo:** Documentar el estado actual del sistema de registro e ingreso y identificar qué falta según los requerimientos

---

## 📊 Estado Actual del Sistema

### Registro (Registro.razor)

**Ubicación:** `src/Client/Pages/Registro.razor`

**Flujo Actual:**
1. Paso 1: Validación de email (solo mo846440@gmail.com)
2. Paso 2: Datos personales (contraseña, confirmar contraseña)
3. Paso 3: Datos del comercio (nombre, teléfono, dirección)

**Campos Actuales:**
- ✅ Email (validación de autorización)
- ✅ Contraseña
- ✅ Confirmar Contraseña
- ✅ Nombre del Comercio
- ✅ Teléfono (opcional)
- ✅ Dirección (opcional)

**Lo que HACE:**
- ✅ Valida email autorizado
- ✅ Crea usuario en Supabase Auth
- ✅ Crea comercio en tabla `comercios`
- ✅ Crea usuario en tabla `usuarios` con `EsPropietario = true`
- ✅ Redirige al dashboard

**Lo que FALTA según requerimientos:**
- ❌ Campo "Email" (confirmación - 2 veces)
- ❌ Campo "Usuario" (nombre de usuario único por comercio)
- ❌ Campo "Contacto" (obligatorio)
- ❌ Checkbox "Aceptar términos y condiciones"
- ❌ Página de términos y condiciones
- ❌ Sistema de notificación por email a mo826440@gmail.com
- ❌ Sistema de aprobación manual de registros
- ❌ ID único con formato `XX + ID_COMERCIO` (actualmente usa UUIDs)
- ❌ Asignación de rol (actualmente solo usa `EsPropietario = true`)

---

### Login (Login.razor)

**Ubicación:** `src/Client/Pages/Login.razor`

**Flujo Actual:**
1. Usuario ingresa email
2. Usuario ingresa contraseña
3. Se valida con Supabase Auth
4. Redirige al dashboard

**Campos Actuales:**
- ✅ Email
- ✅ Contraseña

**Lo que HACE:**
- ✅ Autenticación con Supabase Auth
- ✅ Validación de credenciales
- ✅ Redirección al dashboard
- ✅ Manejo de errores

**Lo que FALTA según requerimientos:**
- ❌ Campo "ID del Comercio" (obligatorio para login)
- ❌ Autocompletado/selector de ID del Comercio (si usuario tiene múltiples comercios)
- ❌ Validación de que el usuario pertenece al comercio especificado
- ❌ Mensajes de error más específicos

---

## 🗄️ Estado de la Base de Datos

### Tabla `usuarios`

**Campos Actuales (según schema):**
- `id` (uuid, PK)
- `auth_user_id` (uuid, FK → auth.users)
- `comercio_id` (uuid, FK → comercios)
- `rol_id` (uuid, FK → roles, nullable)
- `activo` (boolean)
- `es_propietario` (boolean)
- `sync_id` (uuid, para offline)
- `created_at` (timestamp)
- `updated_at` (timestamp)

**Campos que FALTAN:**
- ❌ `nombre` (text) - Nombre y apellido del usuario
- ❌ `apellido` (text) - Separado o junto con nombre
- ❌ `usuario` (text, unique) - Nombre de usuario para login (único por comercio)
- ❌ `contacto` (text) - Teléfono/celular
- ❌ `referencias` (text, nullable) - Campo opcional de referencias
- ❌ `id_publico` (text) - ID público con formato `XX + ID_COMERCIO`

**Nota:** El modelo actual `Usuario.cs` probablemente no tiene todos estos campos. Necesito verificar.

### Tabla `comercios`

**Campos Actuales:**
- `id` (uuid, PK)
- `nombre` (text)
- `email` (text)
- `telefono` (text, nullable)
- `direccion` (text, nullable)
- `activo` (boolean)
- `created_at` (timestamp)
- `updated_at` (timestamp)

**Campos que FALTAN (posiblemente):**
- ❌ `id_publico` (text) - ID público con formato `XX + ID_COMERCIO`

### Tabla `roles`

**Estado:** Existe en la BD según schema, pero necesito verificar qué roles hay.

**Roles Requeridos:**
- ✅ Admin (usando `EsPropietario = true` actualmente)
- ❌ User (empleado) - debe existir en tabla `roles`
- ❌ Programador - debe existir en tabla `roles`

### Nueva Tabla `registros_pendientes` (si se necesita)

**Campos Sugeridos:**
- `id` (uuid, PK)
- `email` (text)
- `nombre_comercio` (text)
- `estado` (enum: Pendiente, Aprobado, Rechazado)
- `fecha_solicitud` (timestamp)
- `fecha_aprobacion` (timestamp, nullable)
- `aprobado_por` (text, nullable) - email del que aprobó
- `created_at` (timestamp)

**Nota:** Esta tabla es opcional. Podríamos usar un campo `estado` en la tabla `comercios` o `usuarios` en su lugar.

---

## 🔄 Comparación: Actual vs. Requerimientos

| Característica | Actual | Requerido | Estado |
|---------------|--------|-----------|--------|
| Email (2 veces) | ❌ Solo 1 vez | ✅ 2 veces con confirmación | ❌ Falta |
| Usuario (único) | ❌ No existe | ✅ Campo obligatorio | ❌ Falta |
| Contraseña (2 veces) | ✅ Sí | ✅ Sí | ✅ OK |
| Contacto | ❌ No existe | ✅ Obligatorio | ❌ Falta |
| Términos y condiciones | ❌ No existe | ✅ Checkbox obligatorio | ❌ Falta |
| Notificación email | ❌ No existe | ✅ A mo826440@gmail.com | ❌ Falta |
| Sistema de aprobación | ❌ No existe | ✅ Manual | ❌ Falta |
| ID formato especial | ❌ UUID | ✅ `XX + ID_COMERCIO` | ❌ Falta |
| Login con ID comercio | ❌ Solo email/password | ✅ Email + Password + ID Comercio | ❌ Falta |
| Rol Programador | ❌ No existe | ✅ Debe existir | ❌ Falta |

---

## 📋 Plan de Implementación

### Fase 1: Análisis y Preparación
1. ✅ Documentar estado actual (este documento)
2. ⏳ Verificar schema de BD actual
3. ⏳ Identificar campos faltantes en modelos
4. ⏳ Planificar cambios en BD (si necesarios)

### Fase 2: Mejoras en Modelos y BD
1. ⏳ Agregar campos faltantes a modelo `Usuario`
2. ⏳ Considerar tabla `registros_pendientes` o campo `estado` en `comercios`
3. ⏳ Verificar/crear roles en tabla `roles`
4. ⏳ Considerar campo `id_publico` en `comercios` y `usuarios`

### Fase 3: Mejoras en Backend
1. ⏳ Actualizar `UsuarioService` para nuevos campos
2. ⏳ Crear servicio de aprobación (si aplica)
3. ⏳ Lógica de generación de IDs con formato especial
4. ⏳ Actualizar `AuthService` para login con ID comercio

### Fase 4: Mejoras en Frontend
1. ⏳ Actualizar `Registro.razor` con nuevos campos
2. ⏳ Crear página de Términos y Condiciones
3. ⏳ Actualizar `Login.razor` con campo ID comercio
4. ⏳ Mejorar validaciones

### Fase 5: Sistema de Notificación (Básico)
1. ⏳ Preparar estructura para notificaciones
2. ⏳ Implementar notificación básica (puede ser manual al principio)

---

## ⚠️ Consideraciones Importantes

### 1. Formato de IDs (`XX + ID_COMERCIO`)

**Problema:** El formato requerido `XX + ID_COMERCIO` es diferente al formato UUID actual.

**Opciones:**
- **Opción A:** Mantener UUID como PK, agregar campo `id_publico` (text) para mostrar
- **Opción B:** Cambiar PK a formato `XX + ID_COMERCIO` (más complejo, requiere cambios en BD)

**Recomendación:** Opción A (mantener UUID, agregar `id_publico`)

### 2. Sistema de Aprobación

**Opciones:**
- **Opción A:** Tabla separada `registros_pendientes`
- **Opción B:** Campo `estado` en tabla `comercios` (Pendiente, Activo, Rechazado)
- **Opción C:** Solo notificación por email, aprobación manual externa (más simple para empezar)

**Recomendación:** Opción C para empezar (más simple), luego evolucionar a Opción B

### 3. Campo "Usuario" (nombre de usuario)

**Consideración:** El login actual usa `email`. El requerimiento pide un campo "Usuario" único por comercio.

**Opciones:**
- **Opción A:** Agregar campo `usuario` y cambiar login para usar `usuario + contraseña + ID_comercio`
- **Opción B:** Mantener email para login, `usuario` es solo para mostrar/identificación

**Recomendación:** Opción A (cumple requerimientos)

### 4. Notificación por Email

**Consideración:** Supabase tiene funciones de email, pero puede requerir configuración adicional.

**Opciones:**
- **Opción A:** Usar Supabase Functions/Edge Functions para enviar emails
- **Opción B:** Integración externa (SendGrid, Resend, etc.)
- **Opción C:** Por ahora, solo preparar estructura (notificación manual)

**Recomendación:** Opción C para empezar (notificación manual), luego evolucionar

---

## 🎯 Próximos Pasos Inmediatos

1. ✅ Análisis completado (este documento)
2. ⏳ Verificar modelo `Usuario.cs` actual
3. ⏳ Decidir sobre cambios en BD (consultar con usuario si es necesario)
4. ⏳ Comenzar implementación de mejoras (prioridad: campos faltantes en formulario)

---

**FIN DEL ANÁLISIS**

