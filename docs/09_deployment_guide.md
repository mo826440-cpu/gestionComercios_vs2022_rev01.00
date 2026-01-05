# Guía de Deployment - Gestión Comercios

## Opciones de Hosting para Blazor WebAssembly

Blazor WebAssembly se compila como una aplicación estática, por lo que puede desplegarse en cualquier servicio de hosting estático.

### Opciones Disponibles:

2. **Azure Static Web Apps**
   - ✅ Integración nativa con GitHub
   - ✅ SSL automático
   - ✅ Azure Functions para backend (si se necesita)
   - ⚠️ Requiere cuenta de Azure

3. **GitHub Pages**
   - ✅ Gratis
   - ✅ Integración nativa con GitHub Actions
   - ⚠️ No tiene .NET SDK (necesitas build externo)
   - ⚠️ Limitaciones para SPAs

1. **Cloudflare Pages** ⭐ (RECOMENDADO - Completamente Gratis)
   - ✅ 100% Gratis (sin límites de ancho de banda ni builds)
   - ✅ SSL automático
   - ✅ CDN global (Cloudflare)
   - ✅ Integración nativa con GitHub
   - ✅ Deployment automático en cada push
   - ✅ Preview deployments para pull requests

## Configuración Recomendada: Cloudflare Pages (GRATIS)

Cloudflare Pages es completamente gratuito y ofrece SSL automático, CDN global e integración nativa con GitHub.

**⚠️ IMPORTANTE:** Cloudflare Pages **NO tiene .NET SDK** en su entorno de build nativo. Por lo tanto, **NO se puede usar la integración directa con GitHub** (Opción A) para proyectos Blazor/ASP.NET. 

**✅ SOLUCIÓN:** Usar **GitHub Actions + Cloudflare Pages API** (Opción B - la única que funciona para .NET).

### Opción B: GitHub Actions + Cloudflare Pages API (RECOMENDADO - Única opción para .NET)

Esta es la única forma de desplegar Blazor WebAssembly en Cloudflare Pages. GitHub Actions hace el build con .NET y luego despliega los archivos estáticos a Cloudflare Pages.

#### Paso 1: Crear el Proyecto en Cloudflare Pages (Manual)

Primero necesitás crear un proyecto vacío en Cloudflare Pages para obtener el nombre del proyecto:

1. Ir a [Cloudflare Dashboard](https://dash.cloudflare.com/) → **Workers & Pages**
2. Hacer clic en **Create application** → **Pages** → **Connect to Git**
3. **IMPORTANTE:** Seleccionar **"Upload assets"** en lugar de conectar Git (esto creará un proyecto vacío)
4. O mejor: Ir directamente a crear un proyecto manualmente usando la API (pero es más fácil crear uno vacío primero)
5. Anotar el nombre del proyecto que creas (puede ser `gestion-comercios` o el que prefieras)

**Alternativa más simple:** El workflow ya está configurado para crear el proyecto automáticamente si no existe (nombre: `gestion-comercios`). Podés saltar este paso si querés.

#### Paso 2: Obtener Tokens de Cloudflare

1. Ir a [Cloudflare Dashboard](https://dash.cloudflare.com/)
2. En la barra lateral derecha, hacer clic en **My Profile** → **API Tokens**
3. Hacer clic en **Create Token**
4. Usar la plantilla **Edit Cloudflare Workers** (tiene los permisos necesarios)
5. Configurar permisos:
   - **Account** → **Cloudflare Pages** → **Edit**
6. Copiar el token (solo se muestra una vez)
7. También necesitas tu **Account ID**: Está en la página principal del dashboard, en la columna derecha

#### Paso 3: Configurar Secrets en GitHub

1. Ir a tu repositorio en GitHub
2. Settings → Secrets and variables → Actions
3. Agregar los siguientes secrets:
   - `CLOUDFLARE_API_TOKEN`: El token que copiaste
   - `CLOUDFLARE_ACCOUNT_ID`: Tu Account ID de Cloudflare

#### Paso 4: Activar el Workflow

1. El workflow ya está creado en `.github/workflows/deploy-cloudflare.yml`
2. Hacer commit y push a la rama `main`
3. GitHub Actions ejecutará el workflow automáticamente
4. El deployment se realizará en Cloudflare Pages

#### Paso 5: Configurar Dominio Personalizado (adminisgo.com.ar)

1. Después del primer deployment exitoso, ir a [Cloudflare Pages Dashboard](https://dash.cloudflare.com/?to=/:account/pages)
2. Seleccionar tu proyecto: `gestion-comercios`
3. Ir a la pestaña **Custom domains**
4. Hacer clic en **Set up a custom domain**
5. Ingresar: `adminisgo.com.ar`
6. Cloudflare te dará un registro CNAME para configurar:
   - Tipo: `CNAME`
   - Nombre: `@` (o dejar en blanco para el dominio raíz)
   - Valor: `gestion-comercios.pages.dev` (o el dominio que Cloudflare te asigne)

7. **Si tu dominio está en Cloudflare DNS:**
   - El DNS se configurará automáticamente
   - SSL se activará automáticamente en minutos

8. **Si tu dominio NO está en Cloudflare:**
   - Ir a tu proveedor de DNS (donde compraste el dominio)
   - Agregar el registro CNAME que Cloudflare te proporcionó
   - Esperar propagación DNS (generalmente 5-15 minutos)
   - Cloudflare detectará automáticamente y activará SSL

## Alternativa: Azure Static Web Apps

Si prefieres Azure:

1. Crear recurso "Static Web App" en Azure Portal
2. Conectar con GitHub
3. Configuración:
   - Source: GitHub
   - Repository: tu-repo
   - Branch: main
   - Build presets: Blazor
   - App location: `/src/Client`
   - Output location: `wwwroot`

4. Dominio personalizado:
   - En Azure Portal → Custom domains → Add
   - Seguir instrucciones para configurar DNS

## Configuración de appsettings.Production.json

**IMPORTANTE:** En Blazor WASM, las configuraciones se incluyen en el build. Para producción:

### Opción 1: Valores en el archivo (menos seguro)
Completar `src/Client/wwwroot/appsettings.Production.json` con valores reales.

### Opción 2: Script de reemplazo en build (recomendado)
Crear un script que reemplace valores durante el build usando variables de entorno del CI/CD.

### Opción 3: Configuración runtime (más complejo)
Implementar carga de configuración desde un endpoint API o archivo JSON externo.

## Comandos Útiles

### Build Local para Testing
```bash
dotnet publish src/Client/Client.csproj -c Release -o ./publish
```

### Verificar archivos generados
Los archivos estáticos estarán en `publish/wwwroot/`

## Checklist de Deployment

- [ ] Elegir hosting (Netlify recomendado)
- [ ] Crear cuenta y conectar repositorio
- [ ] Configurar build settings
- [ ] Completar `appsettings.Production.json` con valores reales
- [ ] Configurar dominio personalizado (adminisgo.com.ar)
- [ ] Configurar registros DNS
- [ ] Verificar SSL/HTTPS
- [ ] Probar la aplicación en producción

