# Guía: Subir Proyecto a GitHub

## ⚠️ IMPORTANTE: Antes de subir

El archivo `src/Client/wwwroot/appsettings.json` contiene credenciales de Supabase. 

**OPCIONES:**

### Opción A: Subir sin credenciales (Recomendado)
Antes de hacer commit, asegurate de que `.gitignore` excluya los archivos con credenciales, o crear un `appsettings.json.example` sin datos sensibles.

### Opción B: Las credenciales ya están en el archivo
Si las credenciales ya están en el código y son públicas (anon key), podés subirlas. La anon key de Supabase está diseñada para ser pública (se ejecuta en el navegador).

---

## Pasos para subir el proyecto a GitHub

### 1. Inicializar Git (si no está inicializado)

Abrir PowerShell o Terminal en la carpeta del proyecto y ejecutar:

```bash
git init
git branch -M main
```

### 2. Configurar el remote de GitHub

El repositorio en GitHub es: `mo826440-cpu/gestionComercios_vs2022_rev01.00`

```bash
git remote add origin https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00.git
```

### 3. Verificar qué se va a subir

```bash
git status
```

Esto mostrará todos los archivos que se van a agregar. El `.gitignore` ya está configurado para excluir:
- `bin/`, `obj/` (archivos de compilación)
- `.vs/` (configuración de Visual Studio)
- Y otros archivos temporales

### 4. Agregar todos los archivos

```bash
git add .
```

### 5. Hacer commit inicial

```bash
git commit -m "Initial commit - Blazor WebAssembly project setup

- Estructura completa del proyecto
- Modelos de datos y servicios
- Autenticación y autorización
- Componentes UI reutilizables
- Soporte offline con IndexedDB
- Configuración PWA
- Workflows de deployment preparados"
```

### 6. Subir a GitHub

```bash
git push -u origin main
```

Si es la primera vez, GitHub te pedirá autenticación (usuario y contraseña o token personal).

---

## Verificación

Después de subir, verificar en GitHub:
1. Ir a: https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00
2. Verificar que todos los archivos estén ahí
3. Verificar que `.gitignore` esté funcionando (no debería haber carpetas `bin/` o `obj/`)

---

## Después de subir a GitHub

Una vez que el código esté en GitHub, podrás:

1. ✅ Ver el código en GitHub
2. ✅ Configurar GitHub Actions (el workflow ya está en `.github/workflows/deploy-cloudflare.yml`)
3. ✅ Configurar Cloudflare Pages con GitHub Actions
4. ✅ Configurar los secrets necesarios (CLOUDFLARE_API_TOKEN, etc.)

---

## Notas

- El `.gitignore` ya está configurado correctamente
- Los workflows de GitHub Actions ya están incluidos
- La documentación está incluida
- `appsettings.json` contiene la anon key de Supabase (es pública, está bien subirla)
