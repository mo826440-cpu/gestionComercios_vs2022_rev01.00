# Configurar Nameservers de Cloudflare en DonWeb

## 📋 Información Necesaria

**Nameservers de Cloudflare (copiar estos):**
- `lex.ns.cloudflare.com`
- `marissa.ns.cloudflare.com`

**Nameservers actuales (eliminar estos):**
- `ns1.donweb.com`
- `ns2.donweb.com`

---

## 🚀 Pasos en DonWeb

### Paso 1: Iniciar Sesión en DonWeb

1. Ir a: https://www.donweb.com/ (o tu panel de DonWeb)
2. Iniciar sesión con tu cuenta

### Paso 2: Ir a la Sección de Dominios

1. En el panel de DonWeb, buscar la sección **"Dominios"** o **"Mis Dominios"**
2. Buscar y click en el dominio `adminisgo.com.ar`

### Paso 3: Desactivar DNSSEC (Si está activado)

1. Buscar la opción **"DNSSEC"** o **"Seguridad DNS"**
2. Si está activado, desactivarlo
3. Guardar los cambios

### Paso 4: Cambiar los Nameservers

1. Buscar la sección **"Servidores de nombres"** o **"Nameservers"** o **"DNS"**
2. Cambiar de **"Usar nameservers de DonWeb"** a **"Nameservers personalizados"** (si aplica)
3. **Eliminar** los nameservers actuales:
   - `ns1.donweb.com`
   - `ns2.donweb.com`
4. **Agregar** los nameservers de Cloudflare:
   - `lex.ns.cloudflare.com`
   - `marissa.ns.cloudflare.com`
5. **Guardar** los cambios

---

## 📝 Pasos Específicos en DonWeb

La interfaz de DonWeb puede variar, pero generalmente:

1. **Panel de Control** → **Dominios** → `adminisgo.com.ar`
2. Buscar **"DNS"** o **"Nameservers"** o **"Servidores DNS"**
3. Click en **"Cambiar nameservers"** o **"Editar"**
4. Reemplazar con los de Cloudflare
5. Guardar

---

## ⏱️ Qué Esperar

- **Tiempo de propagación:** 15 minutos - 2 horas (a veces hasta 24 horas)
- **Cloudflare enviará un email** cuando el dominio esté activo
- **Mientras tanto:** El dominio seguirá funcionando normalmente

---

## ✅ Verificar

Después de cambiar los nameservers:

1. Cloudflare verificará automáticamente
2. Podés verificar manualmente con herramientas como:
   - https://www.whatsmydns.net/
   - Buscar: `adminisgo.com.ar` → Tipo: NS
   - Deberían aparecer: `lex.ns.cloudflare.com` y `marissa.ns.cloudflare.com`

---

## 🚀 Siguiente Paso

Una vez que Cloudflare detecte los nameservers (recibirás un email):

1. Volver a Cloudflare Pages
2. Ir a: https://dash.cloudflare.com/?to=/:account/pages
3. Click en el proyecto `gestion-comercios`
4. Pestaña **"Custom domains"**
5. Agregar `adminisgo.com.ar` (ahora debería funcionar)

---

## 🆘 Si Tenés Problemas

### No encuentro la sección de nameservers en DonWeb
- Buscar en la sección de DNS o Configuración del dominio
- Contactar soporte de DonWeb si no lo encontrás

### Los cambios no se guardan
- Verificar que tengas permisos de administrador
- Intentar desde otro navegador
- Contactar soporte de DonWeb

### Pasaron más de 24 horas y no funciona
- Verificar que los nameservers estén correctamente configurados
- Contactar soporte de Cloudflare

