# Guía de Pruebas - Registro e Ingreso

## Fecha: 2025-01-XX
## Objetivo: Verificar que el sistema de registro e ingreso funciona correctamente con los nuevos campos

---

## 🔍 Pruebas de Registro

### Paso 1: Validación de Email
1. Ir a `/registro`
2. **Prueba 1.1:** Intentar continuar sin email
   - ✅ **Esperado:** Mensaje de error "Por favor, ingresa un email"
   
3. **Prueba 1.2:** Ingresar email inválido (ej: "test")
   - ✅ **Esperado:** Mensaje "El formato del email no es válido"
   
4. **Prueba 1.3:** Ingresar email válido pero no autorizado (ej: "test@gmail.com")
   - ✅ **Esperado:** Mensaje "El email test@gmail.com no está autorizado para registrarse"
   
5. **Prueba 1.4:** Ingresar email autorizado `mo846440@gmail.com`
   - ✅ **Esperado:** Avanzar al Paso 2

6. **Prueba 1.5:** Confirmar email con valor diferente
   - ✅ **Esperado:** Mensaje "Los emails no coinciden"

### Paso 2: Datos Personales
1. **Prueba 2.1:** Continuar sin completar campos
   - ✅ **Esperado:** Mensajes de validación para campos obligatorios

2. **Prueba 2.2:** Completar campos:
   - Nombre y Apellido: "Juan Pérez"
   - Usuario: "juanperez" (mínimo 3 caracteres)
   - Contacto: "3512345678"
   - Contraseña: "123456" (mínimo 6 caracteres)
   - Confirmar Contraseña: "123456"
   - ✅ **Esperado:** Avanzar al Paso 3

3. **Prueba 2.3:** Contraseñas no coinciden
   - ✅ **Esperado:** Mensaje "Las contraseñas no coinciden"

4. **Prueba 2.4:** Usuario muy corto (< 3 caracteres)
   - ✅ **Esperado:** Mensaje de validación

### Paso 3: Datos del Comercio
1. **Prueba 3.1:** Completar datos:
   - Nombre del Comercio: "Mi Kiosco de Prueba"
   - Teléfono: "3512345678" (opcional)
   - Dirección: "Av. Principal 123" (opcional)
   - ✅ **Esperado:** Avanzar a crear cuenta

2. **Prueba 3.2:** Intentar crear cuenta sin aceptar términos
   - ✅ **Esperado:** Mensaje "Debes aceptar los términos y condiciones"

3. **Prueba 3.3:** Aceptar términos y crear cuenta
   - ✅ **Esperado:** 
     - Mensaje de éxito
     - Redirección a `/login` después de 3 segundos
     - Comercio creado en BD con `id_publico` generado
     - Usuario creado con rol `admin` asignado
     - ID público de usuario generado (formato: XX-ID_COMERCIO)

### Verificaciones en Base de Datos (Supabase)
1. Verificar tabla `comercios`:
   - ✅ Debe existir un nuevo registro con:
     - `nombre` = "Mi Kiosco de Prueba"
     - `email` = "mo846440@gmail.com"
     - `id_publico` = "01" (o siguiente número secuencial)
     - `activo` = true

2. Verificar tabla `usuarios`:
   - ✅ Debe existir un nuevo registro con:
     - `nombre` = "Juan Pérez"
     - `usuario` = "juanperez"
     - `contacto` = "3512345678"
     - `id_publico` = "01-XXXXXXXXXXXX" (formato: XX + primeros caracteres del comercio ID)
     - `rol_id` = (ID del rol "admin")
     - `es_propietario` = true
     - `activo` = true

3. Verificar tabla `roles`:
   - ✅ Debe existir el rol "admin"
   - ✅ El usuario debe tener `rol_id` apuntando al rol admin

---

## 🔐 Pruebas de Login

### Prueba 1: Login con Email
1. Ir a `/login`
2. Ingresar:
   - Usuario o Email: `mo846440@gmail.com`
   - ID del Comercio: `01` (el `id_publico` del comercio creado)
   - Contraseña: `123456`
3. ✅ **Esperado:**
   - Login exitoso
   - Mensaje "Bienvenido, Juan Pérez"
   - Redirección a `/dashboard`

### Prueba 2: Login con Nombre de Usuario
1. Ir a `/login`
2. Ingresar:
   - Usuario o Email: `juanperez`
   - ID del Comercio: `01`
   - Contraseña: `123456`
3. ✅ **Esperado:**
   - Login exitoso
   - Mensaje de bienvenida
   - Redirección a `/dashboard`

### Prueba 3: Login con ID de Comercio Incorrecto
1. Intentar login con:
   - Usuario o Email: `mo846440@gmail.com`
   - ID del Comercio: `99` (no existe)
   - Contraseña: `123456`
2. ✅ **Esperado:**
   - Mensaje: "No se encontró un comercio con ID: 99"

### Prueba 4: Login con Credenciales Incorrectas
1. Intentar login con:
   - Usuario o Email: `mo846440@gmail.com`
   - ID del Comercio: `01`
   - Contraseña: `incorrecta`
2. ✅ **Esperado:**
   - Mensaje: "Credenciales inválidas. Por favor, verifica tu usuario/email, ID de comercio y contraseña."

### Prueba 5: Login con Usuario que no Pertenece al Comercio
1. Crear otro comercio y usuario
2. Intentar login con:
   - Usuario del Comercio 1
   - ID del Comercio: `02` (otro comercio)
3. ✅ **Esperado:**
   - Mensaje: "El usuario no pertenece al comercio con ID: 02"

### Prueba 6: Login con Usuario Inactivo
1. Desactivar usuario en BD (poner `activo = false`)
2. Intentar login
3. ✅ **Esperado:**
   - Mensaje: "Tu cuenta está inactiva. Por favor, contacta al administrador."

---

## 📝 Checklist de Verificación

### Funcionalidades Básicas
- [ ] Registro completo de nuevo usuario funciona
- [ ] Validaciones de campos funcionan correctamente
- [ ] Generación de IDs públicos funciona
- [ ] Asignación de rol admin funciona
- [ ] Login con email funciona
- [ ] Login con nombre de usuario funciona
- [ ] Validación de ID de comercio funciona
- [ ] Mensajes de error son claros y útiles

### Integración con BD
- [ ] Datos se guardan correctamente en `comercios`
- [ ] Datos se guardan correctamente en `usuarios`
- [ ] Rol `admin` está asignado correctamente
- [ ] IDs públicos se generan en formato correcto
- [ ] Índices únicos funcionan (no permite usuarios duplicados por comercio)

### UI/UX
- [ ] Formulario de registro es intuitivo
- [ ] Pasos del registro se muestran claramente
- [ ] Validaciones se muestran en tiempo real
- [ ] Mensajes de éxito/error son visibles
- [ ] Redirecciones funcionan correctamente

---

## 🐛 Problemas Conocidos y Soluciones

### Problema 1: Login con nombre de usuario no funciona
**Causa:** El sistema busca el email del comercio como fallback.
**Solución:** Mejorar lógica para obtener email real desde `auth.users` usando `AuthUserId`.

### Problema 2: IDs públicos no se generan correctamente
**Solución:** Verificar que el servicio `IdGeneratorService` está funcionando y que los comercios tienen `id_publico` asignado.

---

## 📊 Resultados Esperados

Después de todas las pruebas, deberías poder:
1. ✅ Registrar un nuevo usuario exitosamente
2. ✅ Ver el comercio y usuario creados en Supabase
3. ✅ Ingresar al sistema con las credenciales creadas
4. ✅ Ver el dashboard después del login
5. ✅ Validar que los datos están completos y correctos

---

## 🔄 Próximos Pasos

Después de verificar que todo funciona:
1. Continuar con Paso 3.3: Sistema de Notificación y Aprobación
2. Implementar notificación por email al registrarse
3. Crear sistema de aprobación manual de registros

