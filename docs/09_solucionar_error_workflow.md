# Solucionar Error en GitHub Actions Workflow

## 🔍 Diagnóstico: Workflows Fallando

Si todos los workflows muestran ❌ (X roja) y se ejecutan muy rápido (5s-1m), el problema más probable es:

**❌ Secrets de Cloudflare NO configurados en GitHub**

---

## ✅ Solución Paso a Paso

### Paso 1: Ver el Error Específico

1. En GitHub Actions, click en el workflow que falló (el más reciente)
2. Click en el job que falló (ej: "build")
3. Verás los pasos del workflow
4. Buscar el paso que tiene ❌ (X roja)
5. Click en ese paso para ver el error específico

**Errores comunes que verás:**
- `CLOUDFLARE_API_TOKEN not found`
- `CLOUDFLARE_ACCOUNT_ID not found`
- `Error: Input required and not supplied: apiToken`

---

### Paso 2: Verificar si los Secrets Están Configurados

1. Ir a tu repositorio en GitHub
2. **Settings** (arriba a la derecha del repositorio)
3. En el menú lateral izquierdo: **Secrets and variables** → **Actions**
4. Verificar que existan estos dos secrets:
   - ✅ `CLOUDFLARE_API_TOKEN`
   - ✅ `CLOUDFLARE_ACCOUNT_ID`

**Si NO existen**, seguir al Paso 3.

**Si SÍ existen**, el problema puede ser:
- El token no tiene permisos correctos
- El Account ID está mal
- Verificar los valores nuevamente

---

### Paso 3: Obtener los Tokens de Cloudflare (si no los tenés)

#### 3.1 Obtener API Token

1. Ir a [Cloudflare Dashboard](https://dash.cloudflare.com/)
2. Click en tu perfil (arriba a la derecha) → **My Profile**
3. Click en **API Tokens** (menú lateral)
4. Click en **Create Token**
5. Usar la plantilla **"Edit Cloudflare Workers"** o crear uno personalizado:
   - **Permissions:**
     - **Account** → **Cloudflare Pages** → **Edit**
   - **Account Resources:**
     - Seleccionar tu cuenta
6. Click en **Continue to summary**
7. Click en **Create Token**
8. **⚠️ IMPORTANTE:** Copiar el token inmediatamente (solo se muestra una vez)
9. Guardarlo en un lugar seguro

#### 3.2 Obtener Account ID

1. En el [Cloudflare Dashboard](https://dash.cloudflare.com/)
2. En la página principal (Overview), en la columna derecha
3. Buscar **"Account ID"**
4. Copiar el ID (es un string alfanumérico)

---

### Paso 4: Configurar Secrets en GitHub

1. Ir a tu repositorio: https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00
2. **Settings** → **Secrets and variables** → **Actions**
3. Click en **New repository secret**

#### 4.1 Agregar CLOUDFLARE_API_TOKEN

- **Name:** `CLOUDFLARE_API_TOKEN` (exactamente así, con mayúsculas)
- **Secret:** Pegar el token que copiaste de Cloudflare
- Click en **Add secret**

#### 4.2 Agregar CLOUDFLARE_ACCOUNT_ID

- Click en **New repository secret** nuevamente
- **Name:** `CLOUDFLARE_ACCOUNT_ID` (exactamente así, con mayúsculas)
- **Secret:** Pegar el Account ID de Cloudflare
- Click en **Add secret**

---

### Paso 5: Re-ejecutar el Workflow

Una vez configurados los secrets:

#### Opción A: Hacer un nuevo push

```bash
git commit --allow-empty -m "Re-run deployment after configuring secrets"
git push
```

#### Opción B: Ejecutar manualmente desde GitHub

1. Ir a **Actions** en GitHub
2. Click en **"Build and Deploy to Cloudflare Pages"** (menú lateral)
3. Click en **"Run workflow"** (arriba a la derecha)
4. Seleccionar rama `main`
5. Click en **"Run workflow"**

---

## 🔍 Verificar que Funcionó

1. Ir a **Actions** en GitHub
2. Ver el nuevo workflow run
3. Debería mostrar:
   - ✅ Todos los pasos en verde
   - ⏱️ Tiempo de ejecución: 3-5 minutos
   - ✅ Estado: "Success"

---

## ❌ Otros Errores Posibles

### Error: "Permission denied" o "Unauthorized"

**Causa:** El token no tiene permisos correctos

**Solución:**
1. Crear un nuevo token en Cloudflare con permisos:
   - **Account** → **Cloudflare Pages** → **Edit**
2. Actualizar el secret `CLOUDFLARE_API_TOKEN` en GitHub

### Error: "Build failed"

**Causa:** Error en el código

**Solución:**
1. Click en el paso "Build" para ver el error
2. Revisar los logs
3. Corregir el error en el código
4. Hacer commit y push

### Error: "Project not found"

**Causa:** El proyecto no existe en Cloudflare Pages

**Solución:**
1. El workflow creará el proyecto automáticamente la primera vez
2. Si falla, crear el proyecto manualmente en Cloudflare Pages primero
3. O verificar que el nombre del proyecto sea correcto en el workflow

---

## 📝 Checklist de Verificación

Antes de re-ejecutar el workflow, verificar:

- [ ] `CLOUDFLARE_API_TOKEN` está configurado en GitHub Secrets
- [ ] `CLOUDFLARE_ACCOUNT_ID` está configurado en GitHub Secrets
- [ ] Los nombres de los secrets son exactos (con mayúsculas)
- [ ] El token tiene permisos de "Edit" en Cloudflare Pages
- [ ] El Account ID es correcto

---

## 🆘 Si Sigue Fallando

1. **Ver los logs completos:**
   - Click en el workflow fallido
   - Click en cada paso para ver los logs detallados
   - Buscar mensajes de error específicos

2. **Verificar el workflow:**
   - El archivo `.github/workflows/deploy-cloudflare.yml` debe estar correcto
   - Verificar que los nombres de los secrets coincidan

3. **Probar manualmente:**
   - Verificar que podés acceder a Cloudflare con el token
   - Verificar que el Account ID es correcto

---

## ✅ Cuando Funcione

Una vez que el workflow sea exitoso:

1. Ir a [Cloudflare Pages](https://dash.cloudflare.com/?to=/:account/pages)
2. Buscar el proyecto `gestion-comercios`
3. Ver el deployment activo
4. Abrir la app en: `https://gestion-comercios.pages.dev`

