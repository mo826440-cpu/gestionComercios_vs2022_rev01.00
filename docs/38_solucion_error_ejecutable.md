# 🔧 Solución: Error "No es una aplicación válida para esta plataforma"

## ❌ Problema
Al ejecutar `C:\tools\supabase\supabase.exe` aparece:
```
Error: El ejecutable especificado no es una aplicación válida para esta plataforma de sistema operativo
```

## 🔍 Posibles Causas

1. **Arquitectura incorrecta:** Descargaste la versión para otra CPU (ARM vs x64)
2. **Archivo corrupto:** El archivo no se descargó/extrayó correctamente
3. **Archivo incompleto:** El .tar.gz no se extrajo completamente

---

## ✅ Soluciones

### Opción 1: Verificar y Re-descargar (RECOMENDADO)

1. **Verificar tu arquitectura:**
   - La mayoría de PCs Windows son **x64 (AMD64)**
   - Si tienes una Surface Pro X o similar, puede ser **ARM64**

2. **Verificar qué descargaste:**
   - Deberías haber descargado: `supabase_windows_amd64.tar.gz`
   - Si descargaste `supabase_windows_arm64.tar.gz` por error, descarga la versión AMD64

3. **Re-descargar y extraer:**
   - Ir a: https://github.com/supabase/cli/releases/latest
   - Descargar: `supabase_windows_amd64.tar.gz` (si tu PC es x64)
   - **Eliminar** la carpeta `C:\tools\supabase` completa
   - Extraer el nuevo archivo
   - Mover `supabase.exe` a `C:\tools\supabase\`

---

### Opción 2: Usar Scoop (Más fácil, instalación automática)

Si tienes Scoop instalado:

```powershell
scoop bucket add supabase https://github.com/supabase/scoop-bucket.git
scoop install supabase
```

Si NO tienes Scoop, puedes instalarlo primero:
```powershell
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
irm get.scoop.sh | iex
```

Luego instalar Supabase:
```powershell
scoop bucket add supabase https://github.com/supabase/scoop-bucket.git
scoop install supabase
```

---

### Opción 3: Usar winget (Windows Package Manager)

```powershell
winget install --id=Supabase.CLI
```

**Nota:** Requiere Windows 10/11 con Microsoft Store habilitado.

---

### Opción 4: Usar NPM (Alternativa)

Aunque npm install -g no funciona directamente, puedes usar `npx`:

```powershell
npx supabase@latest login
npx supabase@latest link --project-ref jnplnwpofxzfqchkvgpv
npx supabase@latest functions deploy send-email
```

**Desventaja:** Necesitas poner `npx supabase@latest` antes de cada comando.

---

## 🎯 Recomendación

**Usa la Opción 2 (Scoop)** si puedes, o **Opción 3 (winget)**. Son más confiables que la descarga manual.

---

## ✅ Verificar instalación

Después de reinstalar, verificar:

```powershell
supabase --version
```

O con ruta completa:
```powershell
C:\tools\supabase\supabase.exe --version
```

---

## 📝 Nota sobre el archivo .tar.gz

Si usaste Windows para extraer el `.tar.gz`, es posible que:
1. Solo extrajo el `.tar` pero no el contenido interno
2. O extrajo mal el ejecutable

**Solución:** Usar 7-Zip o WinRAR para extraer, o usar PowerShell:
```powershell
# Navegar a donde está el .tar.gz
cd C:\Users\[tu-usuario]\Downloads

# Extraer
tar -xzf supabase_windows_amd64.tar.gz

# Verificar que extrajo supabase.exe
ls supabase.exe
```

