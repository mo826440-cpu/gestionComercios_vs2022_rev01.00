# Plan de Implementación: Referencias y Sistema de Autenticación

## 📋 Resumen de Requisitos

### 1️⃣ Módulo "Referencias" en NavMenu
- Agregar sección "Referencias" con submenú colapsable
- Submenú: Categorías, Marcas, Proveedores, Clientes, Productos
- Cada opción dirige a su respectiva vista
- Preparar vistas para CRUD completo

### 2️⃣ Landing Page Pública
- Página inicial accesible sin autenticación
- Opciones: "Ingresar / Login" y "Registrarse"
- Redirigir a dashboard solo si está autenticado

### 3️⃣ Login Mejorado
- Validaciones básicas
- Redirección al dashboard después de login exitoso

### 4️⃣ Sistema de Registro
- Página de registro con:
  - Datos personales
  - Datos del comercio
- Cada registro crea un nuevo comercio
- El usuario registrado es admin de ese comercio
- Validación de email autorizado: `mo846440@gmail.com` (temporal)
- Control de acceso: solo admin puede ver/crear usuarios

### 5️⃣ Sistema de Roles
- Roles básicos: admin y user
- Preparar para RLS en Supabase
- Cada usuario solo ve datos de su comercio

---

## 🔄 Orden de Implementación

1. ✅ **NavMenu - Módulo Referencias** (Más simple, rápido)
2. ✅ **Landing Page Pública**
3. ✅ **Login Mejorado**
4. ✅ **Página de Registro**
5. ✅ **Flujo de Registro Completo**
6. ✅ **Sistema de Roles y Control de Acceso**
7. ✅ **Preparación para RLS**

---

## 📝 Notas Técnicas

- Usar Supabase Auth para autenticación
- Preparar estructura para RLS (cada usuario solo ve datos de su comercio)
- El email autorizado es temporal, preparar para sistema de pago futuro
- Roles: admin (puede gestionar usuarios), user (usuario regular)

