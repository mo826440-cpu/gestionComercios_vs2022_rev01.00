# Decisión: Limpiar Datos de Supabase

## Situación Actual

- **2 comercios** registrados en Supabase
- **2 usuarios** registrados
- El sistema solo permite registro con email `mo846440@gmail.com` (hardcodeado)
- El login parece funcionar pero puede tener problemas de navegación

## Opciones

### Opción 1: Limpiar Todo y Empezar desde Cero ✅ RECOMENDADO

**Ventajas:**
- Estado limpio para testing
- Datos consistentes desde el inicio
- Evita problemas de datos antiguos incompletos
- Permite probar el flujo completo de registro

**Desventajas:**
- Se pierden los datos existentes
- Hay que volver a registrar todo

**Pasos:**
1. Ir a Supabase Dashboard → Table Editor
2. Eliminar registros de las tablas en este orden (para evitar errores de FK):
   - `detalle_ventas` (si existe)
   - `detalle_compras` (si existe)
   - `ventas`
   - `compras`
   - `existencias`
   - `productos`
   - `clientes`
   - `proveedores`
   - `usuarios`
   - `comercios`
3. También eliminar usuarios de `auth.users` en Supabase Auth
4. Registrar todo desde cero usando el formulario de registro

### Opción 2: Permitir Más Emails Temporalmente (Para Testing)

**Ventajas:**
- No se pierden datos
- Permite probar con diferentes emails

**Desventajas:**
- Los datos existentes pueden tener problemas
- No resuelve problemas de datos incompletos

**Implementación:**
- Cambiar la validación de email para permitir múltiples emails o desactivarla temporalmente

## Recomendación

**✅ RECOMENDADO: Opción 1 - Limpiar Todo**

Razones:
1. Es un entorno de desarrollo/testing
2. Los datos existentes pueden tener campos incompletos (vimos que `nombre`, `usuario`, `contacto` están en NULL)
3. Permite probar el flujo completo desde cero
4. Es más fácil debuggear con datos limpios

## Script SQL para Limpiar (Opcional)

Si prefieres usar SQL en lugar de la interfaz:

```sql
-- IMPORTANTE: Ejecutar en este orden para evitar errores de FK

-- Eliminar detalles primero
DELETE FROM detalle_ventas;
DELETE FROM detalle_compras;

-- Eliminar registros principales
DELETE FROM ventas;
DELETE FROM compras;
DELETE FROM existencias;
DELETE FROM productos;
DELETE FROM clientes;
DELETE FROM proveedores;

-- Eliminar usuarios y comercios
DELETE FROM usuarios;
DELETE FROM comercios;

-- Nota: Los usuarios de auth.users deben eliminarse manualmente desde
-- Supabase Dashboard → Authentication → Users
```

## Después de Limpiar

1. Probar el registro completo con `mo846440@gmail.com`
2. Verificar que se crean correctamente:
   - Usuario en `auth.users`
   - Registro en `comercios`
   - Registro en `usuarios` con todos los campos completos
3. Probar el login con los nuevos datos
4. Si todo funciona, considerar implementar el sistema de aprobación (Paso 3.3)

