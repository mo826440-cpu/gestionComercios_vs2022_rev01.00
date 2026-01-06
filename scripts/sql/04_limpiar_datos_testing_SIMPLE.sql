-- ============================================
-- Script SIMPLE para Limpiar Datos de Testing
-- ============================================
-- IMPORTANTE: Usa DELETE FROM (SQL estándar en inglés)
-- Solo usar en entorno de desarrollo/testing
-- ============================================

-- Paso 1: Eliminar detalles y relaciones primero
DELETE FROM detalle_ventas;
DELETE FROM detalle_compras;
DELETE FROM pagos_ventas;
DELETE FROM pagos_compras;
DELETE FROM movimientos_stock;

-- Paso 2: Eliminar registros principales
DELETE FROM ventas;
DELETE FROM compras;
DELETE FROM stock;
DELETE FROM productos;
DELETE FROM clientes;
DELETE FROM proveedores;
DELETE FROM cajas;

-- Paso 3: Eliminar usuarios y comercios (al final)
DELETE FROM usuarios;
DELETE FROM comercios;

-- Paso 4: Verificar que se eliminaron correctamente
SELECT 'comercios' as tabla, COUNT(*) as registros FROM comercios
UNION ALL
SELECT 'usuarios', COUNT(*) FROM usuarios
UNION ALL
SELECT 'productos', COUNT(*) FROM productos
UNION ALL
SELECT 'clientes', COUNT(*) FROM clientes
UNION ALL
SELECT 'ventas', COUNT(*) FROM ventas
UNION ALL
SELECT 'compras', COUNT(*) FROM compras;

-- ============================================
-- IMPORTANTE: Después de ejecutar este script,
-- también debes eliminar los usuarios de Supabase Auth:
-- 
-- 1. Ir a Supabase Dashboard
-- 2. Authentication → Users
-- 3. Eliminar manualmente los usuarios de prueba
-- ============================================

