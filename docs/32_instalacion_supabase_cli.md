# Instalación de Supabase CLI

## 🔍 Verificar si ya está instalado

```powershell
supabase --version
```

Si muestra un número de versión, ya está instalado. Si no, sigue estos pasos.

---

## 📦 Opción 1: Instalar con npm (Recomendado)

### Requisito previo: Node.js

Si no tienes Node.js instalado:

1. Ir a [https://nodejs.org](https://nodejs.org)
2. Descargar la versión LTS (Long Term Support)
3. Instalar con las opciones por defecto
4. Reiniciar PowerShell/Terminal

### Instalar Supabase CLI:

```powershell
npm install -g supabase
```

### Verificar instalación:

```powershell
supabase --version
```

Debería mostrar algo como: `supabase/1.x.x`

---

## 📦 Opción 2: Instalar con Scoop (Windows)

Si tienes Scoop instalado:

```powershell
scoop bucket add supabase https://github.com/supabase/scoop-bucket.git
scoop install supabase
```

---

## 📦 Opción 3: Descargar binario manualmente

1. Ir a [https://github.com/supabase/cli/releases](https://github.com/supabase/cli/releases)
2. Descargar `supabase_windows_amd64.zip` (o la versión para tu arquitectura)
3. Extraer el archivo
4. Agregar la carpeta al PATH de Windows:
   - Buscar "Variables de entorno" en Windows
   - Editar "Path" del usuario
   - Agregar la carpeta donde extrajiste el archivo
5. Reiniciar PowerShell

---

## ✅ Después de instalar

Una vez instalado, continúa con:

1. Login: `supabase login`
2. Link al proyecto: `supabase link --project-ref jnplnwpofxzfqchkvgpv`
3. Desplegar funciones

