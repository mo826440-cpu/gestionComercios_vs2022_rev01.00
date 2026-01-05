# Guía Paso a Paso: Configurar Secrets en GitHub

## ✅ Buenas Noticias

El error de acciones deprecadas ya está resuelto. El workflow está ejecutándose correctamente.

---

## 🔧 Configurar Secrets de Cloudflare

### Paso 1: Cambiar a la Pestaña "Secrets"

En la página de GitHub Settings que estás viendo:

1. **Arriba de "Environment variables"** verás dos pestañas:
   - **"Secrets"** (esta es la que necesitás)
   - **"Variables"** (estás aquí ahora)

2. **Click en la pestaña "Secrets"**

---

### Paso 2: Obtener el API Token de Cloudflare

**IMPORTANTE:** Si ya tenés tokens, probablemente necesitás crear uno nuevo con permisos específicos para Cloudflare Pages.

**📖 Guía detallada:** Ver `docs/09_crear_token_cloudflare.md` para instrucciones paso a paso con capturas.

**Resumen rápido:**
1. En la página de API Tokens, click en el botón **"+"** (arriba a la derecha)
2. Usar plantilla **"Edit Cloudflare Workers"** o crear personalizado:
   - **Permissions:** Account → Cloudflare Pages → Edit
3. Click en **Create Token**
4. **⚠️ IMPORTANTE:** Copiar el token inmediatamente (solo se muestra una vez)

---

### Paso 3: Obtener el Account ID

1. En el [Cloudflare Dashboard](https://dash.cloudflare.com/)
2. En la página principal (Overview), en la **columna derecha**
3. Buscar **"Account ID"** (es un string alfanumérico)
4. Copiar el ID

---

### Paso 4: Agregar CLOUDFLARE_API_TOKEN

En GitHub (en la pestaña "Secrets"):

1. Click en el botón verde **"New repository secret"**
2. En el campo **"Name"**, escribir exactamente:
   ```
   CLOUDFLARE_API_TOKEN
   ```
   (Todo en mayúsculas, con guiones bajos)
3. En el campo **"Secret"**, pegar el token que copiaste de Cloudflare
4. Click en **"Add secret"**

---

### Paso 5: Agregar CLOUDFLARE_ACCOUNT_ID

1. Click en **"New repository secret"** nuevamente
2. En el campo **"Name"**, escribir exactamente:
   ```
   CLOUDFLARE_ACCOUNT_ID
   ```
   (Todo en mayúsculas, con guiones bajos)
3. En el campo **"Secret"**, pegar el Account ID que copiaste
4. Click en **"Add secret"**

---

### Paso 6: Verificar que los Secrets Están Configurados

En la página de Secrets deberías ver:

- ✅ **CLOUDFLARE_API_TOKEN** (con icono de candado)
- ✅ **CLOUDFLARE_ACCOUNT_ID** (con icono de candado)

**Nota:** Los valores están ocultos por seguridad, solo ves los nombres.

---

## 🚀 Después de Configurar los Secrets

Una vez configurados los secrets:

### Opción A: Esperar al próximo push
Cualquier push futuro activará el workflow automáticamente.

### Opción B: Re-ejecutar el workflow manualmente
1. Ir a **Actions** en GitHub
2. Click en **"Build and Deploy to Cloudflare Pages"**
3. Click en **"Run workflow"** (arriba a la derecha)
4. Seleccionar rama `main`
5. Click en **"Run workflow"**

---

## ✅ Qué Esperar

Cuando el workflow se ejecute con los secrets configurados:

1. **Todos los pasos deberían pasar** (checkout, setup .NET, build, publish)
2. **El deployment a Cloudflare debería ser exitoso**
3. **Tu app estará disponible en:** `https://gestion-comercios.pages.dev`

---

## 🆘 Troubleshooting

### "CLOUDFLARE_API_TOKEN not found"
- Verificar que el nombre sea exactamente `CLOUDFLARE_API_TOKEN` (con mayúsculas)
- Verificar que esté en la pestaña "Secrets", no "Variables"

### "Permission denied"
- El token no tiene permisos correctos
- Crear un nuevo token con permisos: **Account** → **Cloudflare Pages** → **Edit**

### "Account ID invalid"
- Verificar que copiaste el Account ID correcto
- Está en el Dashboard de Cloudflare, columna derecha

---

## 📝 Checklist

Antes de re-ejecutar el workflow, verificar:

- [ ] Estás en la pestaña **"Secrets"** (no "Variables")
- [ ] `CLOUDFLARE_API_TOKEN` está configurado
- [ ] `CLOUDFLARE_ACCOUNT_ID` está configurado
- [ ] Los nombres están en mayúsculas exactamente como se muestra
- [ ] El token tiene permisos de "Edit" en Cloudflare Pages

