-- ============================================
-- Script SQL: Paso 4 FIX - Crear Roles
-- Fecha: 2025-01-XX
-- Descripción: Versión corregida para crear roles si no existen
-- ============================================

-- Insertar rol "Admin" si no existe
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM roles WHERE nombre = 'admin') THEN
        INSERT INTO roles (id, nombre, descripcion, activo, created_at)
        VALUES (gen_random_uuid(), 'admin', 'Administrador del comercio (propietario)', true, NOW());
    END IF;
END $$;

-- Insertar rol "User" si no existe
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM roles WHERE nombre = 'user') THEN
        INSERT INTO roles (id, nombre, descripcion, activo, created_at)
        VALUES (gen_random_uuid(), 'user', 'Usuario empleado del comercio', true, NOW());
    END IF;
END $$;

-- Insertar rol "Programador" si no existe
DO $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM roles WHERE nombre = 'programador') THEN
        INSERT INTO roles (id, nombre, descripcion, activo, created_at)
        VALUES (gen_random_uuid(), 'programador', 'Programador - Acceso completo incluyendo Mantenimiento', true, NOW());
    END IF;
END $$;

