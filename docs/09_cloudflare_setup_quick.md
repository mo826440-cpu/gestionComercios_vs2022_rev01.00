# Guía Rápida: Cloudflare Pages con GitHub Actions

## ⚠️ Error Común: "Error al obtener el repositorio"

Si ves este error en Cloudflare, es porque estás intentando usar la **integración directa de Cloudflare con Git**, que **NO funciona para .NET/Blazor**.

**Solución:** Usar GitHub Actions + Cloudflare Pages API (no la integración directa de Cloudflare).

---

## Pasos Rápidos

### 1. Obtener Tokens de Cloudflare

1. Ir a [Cloudflare Dashboard](https://dash.cloudflare.com/)
2. **My Profile** (arriba a la derecha) → **API Tokens**
3. **Create Token** → Usar plantilla **"Edit Cloudflare Workers"**
4. Configurar permisos:
   - **Account** → **Cloudflare Pages** → **Edit**
5. **Continue to summary** → **Create Token**
6. **Copiar el token** (solo se muestra una vez)
7. **Account ID**: Está en la página principal del dashboard, columna derecha

### 2. Configurar Secrets en GitHub

1. Ir a tu repositorio en GitHub
2. **Settings** → **Secrets and variables** → **Actions**
3. **New repository secret** → Agregar:
   - **Name:** `CLOUDFLARE_API_TOKEN`
   - **Value:** El token que copiaste
4. **New repository secret** → Agregar:
   - **Name:** `CLOUDFLARE_ACCOUNT_ID`
   - **Value:** Tu Account ID

### 3. El Workflow ya está listo

El archivo `.github/workflows/deploy-cloudflare.yml` ya está creado y configurado.

### 4. Activar el Deployment

**📖 Guía detallada:** Ver `docs/09_cloudflare_activar_deployment.md` para pasos completos.

**Resumen rápido:**
1. El workflow ya está en GitHub (`.github/workflows/deploy-cloudflare.yml`)
2. Hacer cualquier push a la rama `main` para activarlo automáticamente
   ```bash
   git commit --allow-empty -m "Trigger deployment"
   git push
   ```
3. O ejecutarlo manualmente desde GitHub: **Actions** → **Build and Deploy to Cloudflare Pages** → **Run workflow**
4. Ver el progreso en: **Actions** tab en GitHub
5. Tiempo estimado: 3-5 minutos

### 5. Verificar el Deployment

1. Ir a [Cloudflare Pages Dashboard](https://dash.cloudflare.com/?to=/:account/pages)
2. Deberías ver tu proyecto `gestion-comercios`
3. Hacer clic para ver los deployments
4. Tu app estará disponible en: `https://gestion-comercios.pages.dev`

### 6. Configurar Dominio Personalizado

1. En el proyecto de Cloudflare Pages → **Custom domains**
2. **Set up a custom domain** → `adminisgo.com.ar`
3. Seguir las instrucciones para configurar DNS
4. SSL se activará automáticamente

---

## ¿Por qué no funciona la integración directa?

Cloudflare Pages no incluye el SDK de .NET en su entorno de build. Por eso falla cuando intenta compilar proyectos Blazor directamente desde Git. La solución es hacer el build en GitHub Actions (que SÍ tiene .NET) y luego subir los archivos estáticos a Cloudflare Pages.

nBme7ad8Kexq-57_jfDZC9FtdwvKyxilOb0jdXBv