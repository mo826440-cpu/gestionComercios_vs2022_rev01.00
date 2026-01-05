# Crear Proyecto en Cloudflare Pages

## 🔍 Problema

El error que estás viendo:
```
"Project not found. The specified project name does not match any of your existing projects."
```

Significa que el proyecto `gestion-comercios` no existe en Cloudflare Pages todavía.

---

## ✅ Solución: Crear el Proyecto Manualmente

El workflow necesita que el proyecto exista antes de poder desplegar. Hay dos opciones:

### Opción A: Crear el Proyecto Manualmente (Recomendado)

1. **Ir a Cloudflare Pages:**
   - https://dash.cloudflare.com/?to=/:account/pages
   - O desde el Dashboard: **Pages** (menú lateral)

2. **Click en "Create a project"** o **"Crear un proyecto"**

3. **Conectar con Git (Opcional):**
   - Podés conectar con GitHub, pero **NO es necesario** porque ya estamos usando GitHub Actions
   - Si querés, podés hacerlo, pero el deployment se hará por GitHub Actions de todas formas

4. **O crear proyecto vacío:**
   - Click en **"Upload assets"** o **"Direct Upload"**
   - **Nombre del proyecto:** `gestion-comercios` (exactamente como está en el workflow)
   - Click en **"Create project"**

5. **Importante:** El proyecto puede estar vacío, solo necesitás que exista con el nombre correcto.

---

### Opción B: Modificar el Workflow para Crear el Proyecto Automáticamente

Si preferís que se cree automáticamente, podríamos modificar el workflow, pero es más complejo.

---

## 🚀 Después de Crear el Proyecto

Una vez que el proyecto exista en Cloudflare Pages:

1. **Re-ejecutar el workflow:**
   - Ir a GitHub Actions
   - Click en **"Run workflow"** nuevamente
   - O hacer cualquier push

2. **El deployment debería funcionar ahora**

---

## 📝 Verificar el Nombre del Proyecto

En el workflow (`.github/workflows/deploy-cloudflare.yml`), el nombre del proyecto está en:

```yaml
projectName: gestion-comercios
```

Asegurate de que el proyecto en Cloudflare Pages tenga **exactamente** el mismo nombre (con guiones, sin espacios).

---

## 🆘 Si Sigue Fallando

### Error: "Project name mismatch"
- Verificar que el nombre en Cloudflare Pages sea exactamente `gestion-comercios`
- Verificar que el nombre en el workflow sea exactamente `gestion-comercios`

### Error: "Permission denied"
- Verificar que el token tenga permisos de **Edit** en Cloudflare Pages
- Crear un nuevo token si es necesario

---

## ✅ Checklist

Antes de re-ejecutar el workflow:

- [ ] Proyecto `gestion-comercios` creado en Cloudflare Pages
- [ ] El nombre del proyecto coincide exactamente con el del workflow
- [ ] El token tiene permisos de Edit en Cloudflare Pages
- [ ] El Account ID es correcto

