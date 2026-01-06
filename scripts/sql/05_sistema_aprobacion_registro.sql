-- ============================================
-- Script: Sistema de Aprobación de Registro
-- ============================================
-- Crea la tabla para manejar solicitudes de registro
-- y códigos de verificación
-- ============================================

-- Crear tabla de solicitudes de registro
CREATE TABLE IF NOT EXISTS solicitudes_registro (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    email_solicitante TEXT NOT NULL,
    codigo_verificacion TEXT,
    estado TEXT NOT NULL DEFAULT 'pendiente', -- 'pendiente', 'aprobada', 'rechazada', 'verificada', 'expirada'
    fecha_solicitud TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    fecha_aprobacion TIMESTAMP WITH TIME ZONE,
    fecha_verificacion TIMESTAMP WITH TIME ZONE,
    fecha_expiracion TIMESTAMP WITH TIME ZONE,
    aprobado_por TEXT, -- email del admin que aprobó
    intentos_verificacion INTEGER DEFAULT 0,
    max_intentos INTEGER DEFAULT 5,
    created_at TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    updated_at TIMESTAMP WITH TIME ZONE DEFAULT NOW(),
    CONSTRAINT unique_email_solicitante UNIQUE(email_solicitante)
);

-- Crear índice para búsquedas por email
CREATE INDEX IF NOT EXISTS idx_solicitudes_email ON solicitudes_registro(email_solicitante);

-- Crear índice para búsquedas por código
CREATE INDEX IF NOT EXISTS idx_solicitudes_codigo ON solicitudes_registro(codigo_verificacion) WHERE codigo_verificacion IS NOT NULL;

-- Crear índice para búsquedas por estado
CREATE INDEX IF NOT EXISTS idx_solicitudes_estado ON solicitudes_registro(estado);

-- Función para actualizar updated_at automáticamente
CREATE OR REPLACE FUNCTION update_solicitudes_registro_updated_at()
RETURNS TRIGGER AS $$
BEGIN
    NEW.updated_at = NOW();
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger para actualizar updated_at
DROP TRIGGER IF EXISTS trigger_update_solicitudes_registro_updated_at ON solicitudes_registro;
CREATE TRIGGER trigger_update_solicitudes_registro_updated_at
    BEFORE UPDATE ON solicitudes_registro
    FOR EACH ROW
    EXECUTE FUNCTION update_solicitudes_registro_updated_at();

-- Comentarios para documentación
COMMENT ON TABLE solicitudes_registro IS 'Tabla para manejar solicitudes de registro y códigos de verificación';
COMMENT ON COLUMN solicitudes_registro.email_solicitante IS 'Email del usuario que solicita registro';
COMMENT ON COLUMN solicitudes_registro.codigo_verificacion IS 'Código de 6 dígitos generado cuando se aprueba la solicitud';
COMMENT ON COLUMN solicitudes_registro.estado IS 'Estado de la solicitud: pendiente, aprobada, rechazada, verificada, expirada';
COMMENT ON COLUMN solicitudes_registro.fecha_expiracion IS 'Fecha en que expira el código de verificación (24 horas después de aprobación)';
COMMENT ON COLUMN solicitudes_registro.intentos_verificacion IS 'Número de intentos fallidos de verificación';
COMMENT ON COLUMN solicitudes_registro.max_intentos IS 'Máximo número de intentos permitidos (default: 5)';

