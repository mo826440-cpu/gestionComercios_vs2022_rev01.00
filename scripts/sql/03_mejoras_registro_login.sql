-- ============================================
-- Script SQL: Mejoras en Registro e Ingreso
-- Fecha: 2025-01-XX
-- Descripción: Agrega campos faltantes a las tablas usuarios y comercios
-- ============================================

-- ============================================
-- 1. AGREGAR CAMPOS A TABLA usuarios
-- ============================================

-- Agregar campo 'nombre' (nombre y apellido)
ALTER TABLE usuarios 
ADD COLUMN IF NOT EXISTS nombre TEXT;

-- Agregar campo 'usuario' (nombre de usuario único por comercio)
ALTER TABLE usuarios 
ADD COLUMN IF NOT EXISTS usuario TEXT;

-- Agregar campo 'contacto' (teléfono/celular)
ALTER TABLE usuarios 
ADD COLUMN IF NOT EXISTS contacto TEXT;

-- Agregar campo 'referencias' (texto opcional)
ALTER TABLE usuarios 
ADD COLUMN IF NOT EXISTS referencias TEXT;

-- Agregar campo 'id_publico' (ID público con formato XX + ID_COMERCIO)
ALTER TABLE usuarios 
ADD COLUMN IF NOT EXISTS id_publico TEXT;

-- ============================================
-- 2. CREAR ÍNDICES PARA OPTIMIZAR BÚSQUEDAS
-- ============================================

-- Índice único para usuario + comercio_id (evitar duplicados de usuario por comercio)
CREATE UNIQUE INDEX IF NOT EXISTS idx_usuarios_usuario_comercio 
ON usuarios(usuario, comercio_id) 
WHERE usuario IS NOT NULL;

-- Índice para búsqueda por id_publico
CREATE INDEX IF NOT EXISTS idx_usuarios_id_publico 
ON usuarios(id_publico) 
WHERE id_publico IS NOT NULL;

-- ============================================
-- 3. AGREGAR CAMPO A TABLA comercios
-- ============================================

-- Agregar campo 'id_publico' (ID público del comercio)
ALTER TABLE comercios 
ADD COLUMN IF NOT EXISTS id_publico TEXT;

-- Índice para búsqueda por id_publico en comercios
CREATE UNIQUE INDEX IF NOT EXISTS idx_comercios_id_publico 
ON comercios(id_publico) 
WHERE id_publico IS NOT NULL;

-- ============================================
-- 4. VERIFICAR/CREAR ROLES EN TABLA roles
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

-- ============================================
-- 5. ACTUALIZAR RLS (Row Level Security) - COMENTARIO
-- ============================================
-- NOTA: Las políticas RLS existentes deberían seguir funcionando.
-- Si es necesario, se pueden crear políticas adicionales para los nuevos campos.
-- Por ahora, las políticas basadas en comercio_id deberían ser suficientes.

-- ============================================
-- 6. COMENTARIOS SOBRE LOS CAMBIOS
-- ============================================

-- CAMPO 'nombre':
--   - Almacena el nombre completo del usuario (nombre y apellido)
--   - Tipo: TEXT
--   - Puede ser NULL (para compatibilidad con registros existentes)

-- CAMPO 'usuario':
--   - Nombre de usuario único por comercio (para login)
--   - Tipo: TEXT
--   - Debe ser único dentro del mismo comercio (índice único)
--   - Puede ser NULL (para compatibilidad con registros existentes)

-- CAMPO 'contacto':
--   - Teléfono o celular del usuario
--   - Tipo: TEXT
--   - Puede ser NULL (pero será obligatorio en nuevos registros)

-- CAMPO 'referencias':
--   - Información adicional/referencias del usuario
--   - Tipo: TEXT
--   - Opcional (siempre puede ser NULL)

-- CAMPO 'id_publico':
--   - ID público con formato "XX + ID_COMERCIO" (ej: "01-abc123-def456")
--   - Tipo: TEXT
--   - Se generará automáticamente en el código
--   - Único por tabla (índice único)

-- ROLES:
--   - Se crean los roles básicos si no existen
--   - admin: Administrador/propietario
--   - user: Usuario empleado
--   - programador: Rol especial con acceso a Mantenimiento

-- ============================================
-- FIN DEL SCRIPT
-- ============================================

