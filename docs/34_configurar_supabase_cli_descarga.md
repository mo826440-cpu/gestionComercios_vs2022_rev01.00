# ⚙️ Configurar Supabase CLI después de descargar

## 📦 Paso 1: Extraer el archivo

1. Buscar el archivo descargado: `supabase_windows_amd64.tar.gz`
   - Generalmente está en: `C:\Users\[tu-usuario]\Downloads\`
2. **Extraer el archivo** (Windows 10/11 puede extraer `.tar.gz` directamente, o usar 7-Zip/WinRAR)
3. Dentro del `.tar.gz` encontrarás un archivo `supabase.exe`

## 📁 Paso 2: Crear carpeta y mover el ejecutable

### Opción A: Carpeta específica (Recomendado)

1. Crear una carpeta para herramientas:
   - `C:\Tools\supabase\`
2. Mover `supabase.exe` a esa carpeta
3. La ruta final será: `C:\Tools\supabase\supabase.exe`

### Opción B: Usar una carpeta existente

Puedes moverlo a cualquier carpeta que prefieras, por ejemplo:
- `C:\Program Files\Supabase\`
- `C:\Users\[tu-usuario]\Tools\supabase\`

## 🔧 Paso 3: Agregar al PATH de Windows

### Método 1: Desde Configuración de Windows (Más fácil)

1. Presionar `Windows + R`
2. Escribir: `sysdm.cpl` y presionar Enter
3. Ir a la pestaña **"Opciones avanzadas"**
4. Hacer clic en **"Variables de entorno"**
5. En la sección **"Variables del usuario"** (arriba), buscar y seleccionar `Path`
6. Hacer clic en **"Editar"**
7. Hacer clic en **"Nuevo"**
8. Agregar la ruta donde está `supabase.exe` (ej: `C:\Tools\supabase`)
9. Hacer clic en **"Aceptar"** en todas las ventanas

### Método 2: Desde PowerShell (Avanzado)

Abrir PowerShell como Administrador y ejecutar:

```powershell
[Environment]::SetEnvironmentVariable(
    "Path",
    [Environment]::GetEnvironmentVariable("Path", "User") + ";C:\Tools\supabase",
    "User"
)
```

**Nota:** Ajustar la ruta según donde hayas colocado el archivo.

## ✅ Paso 4: Verificar instalación

1. **Cerrar y reabrir PowerShell/Terminal** (IMPORTANTE: Para que tome el nuevo PATH)
2. Ejecutar:

```powershell
supabase --version
```

Debería mostrar algo como:
```
supabase/2.67.1
```

Si funciona, ¡listo! 🎉

## 🚀 Paso 5: Continuar con los siguientes pasos

Una vez verificado, continúa con:

1. **Login:** `supabase login`
2. **Link al proyecto:** `supabase link --project-ref jnplnwpofxzfqchkvgpv`
3. **Desplegar funciones**

---

## 🐛 Problemas comunes

### "supabase: command not found" después de agregar al PATH

- **Solución:** Cerrar COMPLETAMENTE PowerShell/Terminal y volver a abrirlo
- Verificar que la ruta sea correcta en las Variables de entorno
- Verificar que `supabase.exe` esté realmente en esa carpeta

### Error al ejecutar supabase.exe directamente

- Verificar que sea el archivo correcto para Windows (no Linux/Mac)
- Intentar ejecutarlo directamente desde el explorador de archivos para ver si hay algún error

### No puedo extraer el .tar.gz

- Usar 7-Zip o WinRAR
- O usar PowerShell:
```powershell
tar -xzf supabase_windows_amd64.tar.gz
```

