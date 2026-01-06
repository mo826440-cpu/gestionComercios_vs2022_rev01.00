# 🔧 Solución: Agregar Supabase al PATH con PowerShell

## ✅ Método Rápido con PowerShell (Como Administrador)

1. **Abrir PowerShell como Administrador:**
   - Clic derecho en el ícono de PowerShell
   - Seleccionar **"Ejecutar como administrador"**

2. **Ejecutar este comando:**
```powershell
[Environment]::SetEnvironmentVariable("Path", [Environment]::GetEnvironmentVariable("Path", "User") + ";C:\tools\supabase", "User")
```

3. **Cerrar COMPLETAMENTE PowerShell** (cerrar todas las ventanas)

4. **Abrir PowerShell NUEVO** (puede ser normal, no necesita ser admin)

5. **Verificar:**
```powershell
supabase --version
```

---

## 🔍 Si aún no funciona: Verificar el PATH manualmente

1. Presionar `Windows + R`
2. Escribir: `sysdm.cpl` y presionar Enter
3. Pestaña **"Opciones avanzadas"**
4. **"Variables de entorno"**
5. En **"Variables del usuario"** → Seleccionar `Path` → **"Editar"**
6. Verificar que aparezca: `C:\tools\supabase`
   - Si NO está: Agregarlo manualmente
   - Si SÍ está: Puede que necesites reiniciar Windows

---

## ⚠️ Si el ejecutable no funciona

Si al ejecutar `C:\tools\supabase\supabase.exe` directamente da error, puede ser:

1. **Archivo corrupto:** Descargar nuevamente
2. **Arquitectura incorrecta:** Verificar que descargaste `windows_amd64` (no ARM)
3. **Antivirus bloqueando:** Verificar si tu antivirus está bloqueando el archivo

