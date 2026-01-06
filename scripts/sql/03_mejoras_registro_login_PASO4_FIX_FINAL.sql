-- ============================================
-- Script SQL: Paso 4 FIX FINAL - Crear Roles
-- Fecha: 2025-01-XX
-- Descripción: Verifica y crea la estructura de roles si falta, luego inserta los roles
-- ============================================

-- Primero, asegurémonos de que la tabla roles tenga las columnas necesarias
-- Agregar columna 'activo' si no existe
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns 
        WHERE table_schema = 'public' 
        AND table_name = 'roles' 
        AND column_name = 'activo'
    ) THEN
        ALTER TABLE roles ADD COLUMN activo BOOLEAN DEFAULT true;
    END IF;
END $$;

-- Agregar columna 'descripcion' si no existe
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns 
        WHERE table_schema = 'public' 
        AND table_name = 'roles' 
        AND column_name = 'descripcion'
    ) THEN
        ALTER TABLE roles ADD COLUMN descripcion TEXT;
    END IF;
END $$;

-- Agregar columna 'created_at' si no existe
DO $$
BEGIN
    IF NOT EXISTS (
        SELECT 1 FROM information_schema.columns 
        WHERE table_schema = 'public' 
        AND table_name = 'roles' 
        AND column_name = 'created_at'
    ) THEN
        ALTER TABLE roles ADD COLUMN created_at TIMESTAMP WITH TIME ZONE DEFAULT NOW();
    END IF;
END $$;

-- Ahora insertar los roles si no existen
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

