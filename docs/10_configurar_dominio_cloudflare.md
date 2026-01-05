# Configurar Dominio Personalizado en Cloudflare Pages

## 📋 Prerequisitos

- ✅ Proyecto desplegado en Cloudflare Pages
- ✅ Dominio `adminisgo.com.ar` registrado
- ✅ DNS administrado por Cloudflare (o acceso al panel DNS)

---

## 🚀 Pasos para Configurar el Dominio

### Paso 1: Ir a Cloudflare Pages

1. Ir a: https://dash.cloudflare.com/?to=/:account/pages
2. Click en el proyecto `gestion-comercios`

### Paso 2: Agregar Dominio Personalizado

1. En el proyecto, ir a la pestaña **"Custom domains"** o **"Dominios personalizados"**
2. Click en **"Set up a custom domain"** o **"Configurar un dominio personalizado"**
3. Escribir: `adminisgo.com.ar`
4. Click en **"Continue"** o **"Continuar"**

### Paso 3: Configurar DNS

Cloudflare te dará las instrucciones específicas. Normalmente:

1. **Si tu dominio está en Cloudflare:**
   - Cloudflare configurará automáticamente los registros DNS
   - Solo necesitás esperar a que se propaguen (puede tardar unos minutos)

2. **Si tu dominio NO está en Cloudflare:**
   - Agregar un registro CNAME en tu proveedor DNS:
     - **Tipo:** CNAME
     - **Nombre:** @ (o adminisgo.com.ar)
     - **Valor:** `gestion-comercios.pages.dev`
   - O agregar un registro A con la IP que Cloudflare te proporcione

### Paso 4: Verificar SSL

Cloudflare configurará automáticamente el certificado SSL (HTTPS). Esto puede tardar unos minutos.

### Paso 5: Verificar

1. Esperar 5-10 minutos para que los DNS se propaguen
2. Visitar: `https://adminisgo.com.ar`
3. Deberías ver tu aplicación funcionando

---

## 🔧 Configuración Adicional

### Redirección de www a dominio principal (Opcional)

Si querés que `www.adminisgo.com.ar` redirija a `adminisgo.com.ar`:

1. En Cloudflare Pages → Custom domains
2. Agregar también `www.adminisgo.com.ar`
3. Cloudflare manejará la redirección automáticamente

### Configuración en Cloudflare DNS (Si el dominio está en Cloudflare)

1. Ir a Cloudflare Dashboard → DNS
2. Seleccionar el dominio `adminisgo.com.ar`
3. Verificar que los registros estén configurados correctamente:
   - **Tipo:** CNAME
   - **Nombre:** @
   - **Contenido:** `gestion-comercios.pages.dev`
   - **Proxy:** Activado (nube naranja)

---

## ⏱️ Tiempos de Propagación

- **DNS:** 5-10 minutos (si el dominio está en Cloudflare)
- **SSL:** 5-15 minutos (configuración automática)
- **Total:** 10-30 minutos aproximadamente

---

## 🆘 Troubleshooting

### El dominio no carga

1. Verificar que los DNS estén configurados correctamente
2. Usar herramientas como `dig` o `nslookup` para verificar los registros DNS
3. Esperar más tiempo (la propagación puede tardar hasta 24 horas en algunos casos)

### Error de SSL

1. Esperar unos minutos más (Cloudflare configura SSL automáticamente)
2. Verificar que el dominio esté correctamente configurado en Cloudflare Pages
3. Si persiste, contactar soporte de Cloudflare

### El dominio carga pero muestra error

1. Verificar que el proyecto esté desplegado correctamente
2. Verificar que el dominio apunte al proyecto correcto en Cloudflare Pages
3. Revisar los logs del proyecto en Cloudflare Pages

---

## 📝 Notas

- Cloudflare maneja automáticamente el certificado SSL (gratis)
- No necesitás configuración adicional en el código
- El dominio personalizado no afecta el dominio `.pages.dev` (sigue funcionando)

---

## ✅ Checklist

Antes de configurar:

- [ ] Proyecto desplegado y funcionando en `gestion-comercios.pages.dev`
- [ ] Dominio `adminisgo.com.ar` registrado
- [ ] Acceso al panel DNS (o dominio en Cloudflare)
- [ ] 10-30 minutos de tiempo para esperar la propagación

Después de configurar:

- [ ] Dominio agregado en Cloudflare Pages
- [ ] DNS configurados correctamente
- [ ] SSL activado (automático)
- [ ] Sitio accesible en `https://adminisgo.com.ar`

