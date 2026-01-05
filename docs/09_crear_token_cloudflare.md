# Crear Token de Cloudflare para GitHub Actions

## 🔍 Verificar Tokens Existentes

Veo que tenés dos tokens en Cloudflare:

1. **"Editar trabajadores de Cloudflare"** - Para Workers (no sirve para Pages)
2. **"gestioncomercios-vs2022-rev0100 token de compilación"** - Necesitamos verificar sus permisos

### ¿Puedo usar un token existente?

**Respuesta corta:** Probablemente NO. Necesitás un token específico con permisos de **Cloudflare Pages → Edit**.

**Recomendación:** Crear un token nuevo específico para este proyecto.

---

## ✅ Crear Token Nuevo (Recomendado)

### Paso 1: Crear el Token

1. En la página de API Tokens que estás viendo, click en el botón **"+"** (arriba a la derecha)
   - O click en **"Create Token"** si aparece

2. **Opción A: Usar Plantilla (Más Fácil)**
   - Buscar la plantilla **"Edit Cloudflare Workers"** o **"Cloudflare Pages"**
   - Click en **"Use template"** o **"Usar plantilla"**

3. **Opción B: Crear Personalizado (Más Control)**
   - Click en **"Create Custom Token"** o **"Crear token personalizado"**
   - **Nombre del token:** `GitHub Actions - gestion-comercios`
   - **Permisos:**
     - **Account** → **Cloudflare Pages** → **Edit**
   - **Account Resources:**
     - Seleccionar tu cuenta: `mo826440@gmail.com`
     - O seleccionar **"All accounts"** si querés que funcione para todas

4. Click en **"Continue to summary"** o **"Continuar con el resumen"**

5. Revisar el resumen y click en **"Create Token"** o **"Crear token"**

6. **⚠️ IMPORTANTE:** Copiar el token inmediatamente
   - Se muestra solo UNA vez
   - Es un string largo que empieza con algo como: `xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`
   - Guardarlo en un lugar seguro temporalmente

---

### Paso 2: Obtener el Account ID

El Account ID lo necesitás también. Está en otra parte:

1. En Cloudflare, click en el logo de Cloudflare (arriba a la izquierda) para volver al Dashboard principal
2. En la página principal (Overview), en la **columna derecha**
3. Buscar **"Account ID"** o **"ID de cuenta"**
4. Es un string alfanumérico (ejemplo: `a1b2c3d4e5f6g7h8i9j0`)
5. Copiar el ID

**Alternativa:** También podés verlo en la URL cuando estás en el dashboard:
- La URL tiene algo como: `dash.cloudflare.com/xxxxxxxxxxxxxxxx/pages`
- El `xxxxxxxxxxxxxxxx` es tu Account ID

---

## 📋 Resumen de lo que Necesitás

Antes de ir a GitHub, asegurate de tener:

- ✅ **API Token:** El token que acabas de crear (string largo)
- ✅ **Account ID:** El ID de tu cuenta (string alfanumérico)

---

## 🚀 Siguiente Paso

Una vez que tengas ambos valores:

1. Ir a GitHub: https://github.com/mo826440-cpu/gestionComercios_vs2022_rev01.00/settings/secrets/actions
2. **Cambiar a la pestaña "Secrets"** (no "Variables")
3. Click en **"New repository secret"**
4. Agregar:
   - **Name:** `CLOUDFLARE_API_TOKEN`
   - **Value:** El token que copiaste
5. Click en **"New repository secret"** nuevamente
6. Agregar:
   - **Name:** `CLOUDFLARE_ACCOUNT_ID`
   - **Value:** El Account ID que copiaste

---

## ⚠️ Notas Importantes

- **No compartas el token** con nadie
- **No lo subas a GitHub** (por eso usamos secrets)
- Si perdés el token, podés crear uno nuevo y actualizar el secret en GitHub
- El token solo se muestra una vez al crearlo

---

## 🆘 Si Tenés Problemas

### No veo la opción "Cloudflare Pages" en permisos
- Asegurate de tener una cuenta activa de Cloudflare
- Verificar que tu cuenta tenga acceso a Pages

### No encuentro el Account ID
- Está en el Dashboard principal, columna derecha
- O en la URL cuando estás en Pages: `dash.cloudflare.com/[ACCOUNT_ID]/pages`

### El token no funciona
- Verificar que tenga permisos de **"Edit"** (no solo "Read")
- Verificar que el Account ID sea correcto

