# 🎯 Próximos Pasos - Guía Simple

## 📝 Situación Actual
- ✅ Descargaste Supabase CLI
- ✅ Lo colocaste en `C:\tools\supabase\`
- ⏳ PATH necesita configurarse (o usar ruta completa)

---

## 🚀 Opción 1: Usar Ruta Completa (Rápido para empezar)

Mientras configuramos el PATH, puedes usar la ruta completa:

### Paso 1: Login
```powershell
C:\tools\supabase\supabase.exe login
```

### Paso 2: Link al proyecto
```powershell
C:\tools\supabase\supabase.exe link --project-ref jnplnwpofxzfqchkvgpv
```

### Paso 3: Desplegar funciones
```powershell
C:\tools\supabase\supabase.exe functions deploy send-email
C:\tools\supabase\supabase.exe functions deploy solicitar-registro
C:\tools\supabase\supabase.exe functions deploy aprobar-registro
```

**Ventaja:** No necesitas configurar PATH ahora mismo.

---

## 🔧 Opción 2: Configurar PATH Correctamente

### Método A: Desde PowerShell (Como Administrador)

1. Abrir PowerShell como **Administrador**
2. Ejecutar:
```powershell
[Environment]::SetEnvironmentVariable("Path", [Environment]::GetEnvironmentVariable("Path", "User") + ";C:\tools\supabase", "User")
```
3. Cerrar TODAS las ventanas de PowerShell
4. Abrir PowerShell NUEVO
5. Probar: `supabase --version`

### Método B: Manualmente en Windows

1. Presionar `Windows + R`
2. Escribir: `sysdm.cpl` → Enter
3. Pestaña **"Opciones avanzadas"**
4. **"Variables de entorno"**
5. En **"Variables del usuario"** (arriba):
   - Seleccionar `Path`
   - Clic en **"Editar"**
   - Clic en **"Nuevo"**
   - Escribir: `C:\tools\supabase`
   - Clic en **"Aceptar"** en todas las ventanas
6. **Cerrar y reabrir PowerShell/Terminal**
7. Probar: `supabase --version`

---

## ✅ Después de configurar PATH (o usando ruta completa)

### 1. Crear cuenta en Resend

1. Ir a: https://resend.com
2. Crear cuenta y verificar email
3. Ir a **"API Keys"** → **"Create API Key"**
4. Copiar la API Key (solo se muestra una vez)

### 2. Configurar en Supabase

1. Ir a: https://supabase.com/dashboard
2. Seleccionar tu proyecto
3. **Edge Functions** → **Secrets**
4. **"New Secret"**:
   - Name: `RESEND_API_KEY`
   - Value: (pegar la API Key)
5. Guardar

### 3. Login y desplegar

```powershell
# Si configuraste PATH:
supabase login
supabase link --project-ref jnplnwpofxzfqchkvgpv

# Si NO configuraste PATH (usar ruta completa):
C:\tools\supabase\supabase.exe login
C:\tools\supabase\supabase.exe link --project-ref jnplnwpofxzfqchkvgpv
```

Luego desplegar las 3 funciones (con o sin ruta completa).

---

## 🐛 Si el ejecutable no funciona

Si al ejecutar `C:\tools\supabase\supabase.exe` da error de plataforma:

1. Verificar que descargaste `supabase_windows_amd64.tar.gz` (no ARM)
2. Intentar descargar nuevamente
3. Verificar que el archivo no esté corrupto
4. Probar con Scoop o winget como alternativa

