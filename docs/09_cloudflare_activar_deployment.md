# Guía Detallada: Activar Deployment en Cloudflare Pages

## ⚠️ ANTES DE COMENZAR

Asegurate de haber completado los pasos 1 y 2:
- ✅ **Paso 1:** Obtener tokens de Cloudflare (API Token y Account ID)
- ✅ **Paso 2:** Configurar secrets en GitHub

Si no los completaste, volvé a `docs/09_cloudflare_setup_quick.md` y completá esos pasos primero.

---

## Paso 4: Activar el Deployment

El workflow ya está en GitHub (está en `.github/workflows/deploy-cloudflare.yml`). Hay **dos formas** de activarlo:

### Opción A: Activación Automática (Recomendada)

El workflow se ejecutará automáticamente cuando hagas cualquier push a la rama `main`.

**Pasos:**

1. **Hacer cualquier cambio pequeño** (para forzar un push):
   ```bash
   # Opción 1: Hacer un cambio mínimo en el README
   # (Abrir README.md y agregar una línea o espacio)
   
   # Opción 2: O simplemente hacer un commit vacío
   git commit --allow-empty -m "Trigger deployment"
   git push
   ```

2. **O hacer un cambio real** (si tenés algo que subir):
   ```bash
   git add .
   git commit -m "Activar deployment inicial"
   git push
   ```

3. **Ver el progreso en GitHub:**
   - Ir a: https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00
   - Click en la pestaña **"Actions"** (arriba del repositorio)
   - Deberías ver el workflow "Build and Deploy to Cloudflare Pages"
   - Click en el workflow para ver el progreso en tiempo real

---

### Opción B: Activación Manual (Desde GitHub)

Si ya hiciste push y querés ejecutar el workflow manualmente:

1. Ir a: https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00
2. Click en la pestaña **"Actions"**
3. En el menú lateral izquierdo, click en **"Build and Deploy to Cloudflare Pages"**
4. Click en el botón **"Run workflow"** (arriba a la derecha)
5. Seleccionar la rama `main`
6. Click en **"Run workflow"**

---

## Qué Esperar Durante el Deployment

### 1. En GitHub Actions verás estos pasos:

1. **Checkout** - Descarga el código
2. **Setup .NET** - Instala .NET 8.0
3. **Restore dependencies** - Restaura paquetes NuGet
4. **Build** - Compila el proyecto
5. **Publish** - Genera los archivos estáticos en `./publish/wwwroot`
6. **Deploy to Cloudflare Pages** - Sube los archivos a Cloudflare

### 2. Tiempo estimado: 3-5 minutos

### 3. Si todo sale bien:
- ✅ Verás un check verde en GitHub Actions
- ✅ El proyecto aparecerá en Cloudflare Pages Dashboard
- ✅ Tu app estará disponible en: `https://gestion-comercios.pages.dev`

### 4. Si hay errores:
- ❌ Verás un X rojo en GitHub Actions
- Click en el error para ver los detalles
- Los errores comunes:
  - **Secrets no configurados:** Verificar que `CLOUDFLARE_API_TOKEN` y `CLOUDFLARE_ACCOUNT_ID` estén en GitHub Settings → Secrets
  - **Error de build:** Revisar los logs para ver qué falló
  - **Error de deploy:** Verificar que el token tenga permisos correctos

---

## Verificar el Deployment

Una vez que el workflow termine exitosamente:

1. **Ir a Cloudflare Pages:**
   - https://dash.cloudflare.com/?to=/:account/pages
   - O desde el dashboard principal → **Pages** (menú lateral)

2. **Buscar el proyecto:**
   - Deberías ver `gestion-comercios` en la lista
   - Click para ver los detalles

3. **Ver el deployment:**
   - Verás el último deployment con estado "Active"
   - Click para ver los logs

4. **Abrir la aplicación:**
   - Click en **"Visit site"** o ir directamente a: `https://gestion-comercios.pages.dev`
   - Deberías ver tu aplicación Blazor funcionando

---

## Troubleshooting

### Error: "CLOUDFLARE_API_TOKEN not found"
**Solución:** Verificar que el secret esté configurado en GitHub:
- Settings → Secrets and variables → Actions
- Debe llamarse exactamente `CLOUDFLARE_API_TOKEN`

### Error: "CLOUDFLARE_ACCOUNT_ID not found"
**Solución:** Verificar que el secret esté configurado:
- Debe llamarse exactamente `CLOUDFLARE_ACCOUNT_ID`

### Error: "Permission denied" al hacer deploy
**Solución:** El token de Cloudflare no tiene los permisos correctos:
- Crear un nuevo token con permisos: **Account** → **Cloudflare Pages** → **Edit**

### Error: "Build failed"
**Solución:** Revisar los logs del build:
- Click en el step "Build" o "Publish" para ver el error específico
- Puede ser un error de compilación que hay que corregir en el código

### El workflow no se ejecuta automáticamente
**Solución:** Verificar que el archivo `.github/workflows/deploy-cloudflare.yml` esté en la rama `main`:
```bash
git branch  # Verificar que estás en main
git pull    # Asegurarte de tener la última versión
```

---

## Siguiente Paso

Una vez que el deployment funcione:
- ✅ Ir al paso 5: Verificar el Deployment
- ✅ Ir al paso 6: Configurar Dominio Personalizado (`adminisgo.com.ar`)

Volver a: `docs/09_cloudflare_setup_quick.md`

