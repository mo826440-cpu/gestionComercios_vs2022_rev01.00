Excelente base 👏. Lo que te faltaba no era “más detalle”, sino orden, jerarquía y control del alcance, para que Cursor no se pierda ni intente hacer todo junto.

Abajo te dejo el PROMPT MEJORADO Y PROFESIONAL, listo para pegar en Cursor.
Está pensado para que la IA:

Primero entienda

Después planifique

Y recién después implemente paso a paso

Sin romper lo que ya funciona

Con checklist claro y controlable

🔹 PROMPT MEJORADO PARA CURSOR (VERSIÓN DEFINITIVA)
CONTEXTO GENERAL DEL PROYECTO

Estoy desarrollando un Sistema de Gestión Comercial / Kioscos, actualmente funcional en su versión base (landing + login).

✔ Ya se puede ingresar desde la landing page
✔ El proyecto principal se encuentra en:
C:\VS 2022\gestionComercios_vs2022_rev01.00

También existe un proyecto anterior de referencia ubicado en:
C:\Sistema_Gestión_Kioscos.05

La base de datos utilizada es Supabase.

⚠️ Reglas importantes antes de avanzar

NO romper funcionalidades existentes

NO eliminar archivos ni esquemas sin justificar

Analizar antes de modificar

Avanzar paso a paso, con checklist aprobado antes de implementar

OBJETIVO DE ESTE PROMPT

👉 NO quiero que implementes nada todavía
👉 Quiero que primero me armes un CHECKLIST DE AVANCES, ordenado exactamente como lo detallo abajo, para ejecutar el desarrollo de forma progresiva y controlada.

El checklist debe:

Estar numerado

Tener subtareas claras

Indicar dependencias entre pasos

Aclarar si requiere cambios en BD, frontend o backend

Servir como hoja de ruta del proyecto

📋 CHECKLIST DE DESARROLLO (ORDEN OBLIGATORIO)
1️⃣ Análisis del proyecto de referencia

Ruta: C:\Sistema_Gestión_Kioscos.05

Tareas:

Verificar y entender completamente el proyecto

Identificar flujo general del sistema

Identificar módulos, ventanas y lógica de negocio

Entregables:

📄 Archivo resumen explicando el proyecto (lenguaje claro)

📄 Archivo con diagrama de flujo completo del sistema

Login

Gestión

Operaciones

Roles

2️⃣ Análisis del proyecto actual + visión comercial

Ruta: C:\VS 2022\gestionComercios_vs2022_rev01.00

Objetivo:

Que el proyecto actual tenga el mismo o muy similar flujo funcional al proyecto de referencia

Entregables:

📄 Documento explicativo con enfoque marketing / ventas

Qué problema resuelve

A quién está dirigido

Beneficios

📄 Documento técnico del proyecto

Arquitectura

Roles

Módulos

📄 Diagrama de flujo:

Versión técnica (detallada)

Versión general (presentación comercial)

3️⃣ Revisión y mejora del Registro e Ingreso de Usuarios

Concepto clave:

Cada usuario registrado = un nuevo comercio

Ejemplo:

Juan Pérez → Comercio de Juan Pérez (BD vacía)

Hermindo Areco → Comercio de Hermindo Areco (BD vacía)

Requisitos del registro:

Email (2 veces)

Usuario

Contraseña (2 veces)

Contacto

Aceptar términos y condiciones (seguridad recomendada)

Flujo de autorización:

Al registrarse → correo de notificación a: mo826440@gmail.com

Solo si ese mail autoriza, el usuario podrá ingresar

Al aprobarse:

Se genera ID único de usuario

Se genera ID único de comercio

Login requerido:

Usuario

Contraseña

ID del comercio

Roles iniciales:

Admin (dueño del comercio)

Usuario

Programador (rol especial)

Extras deseables:

Segunda capa de autenticación (email, OTP, biometría – dejar preparado)

4️⃣ Desarrollo de la Ventana Usuarios (solo Admin)

✔ Indicadores superiores
✔ Panel de carga con validaciones y atajos
✔ ID automático con formato:
XX + ID_COMERCIO
✔ Tabla paginada con:

Filtros tipo Excel

Estados con colores

Acciones (Ver detalle / Editar)

5️⃣ Ventana Proveedores

Estructura idéntica en lógica a Usuarios:

CRUD

ID automático

Estado

Tabla con filtros

Historial y responsable de cambios

6️⃣ Ventana Clientes

Similar a Proveedores pero con:

DNI opcional

Mail opcional

Seguimiento de deudas

7️⃣ Ventana Categorías

Simple

ID automático

Estado

Uso posterior en Productos

8️⃣ Ventana Marcas

Estructura idéntica a Categorías

9️⃣ Ventana Productos

Incluye:

Código de barras (manual / scanner / cámara)

Categorías y marcas con autocomplete avanzado

Stock mínimo

Indicadores de stock

Estados visuales (verde / amarillo / rojo)

🔟 Ventana Configuraciones (Admin y Programador)

Datos del comercio

Tema del sistema

Formas de pago

Formatos de fecha y moneda (Argentina por defecto)

Recomendaciones de uso

1️⃣1️⃣ Ventana Mantenimiento (solo Programador)

Información completa de BD

Uso de memoria

Control de usuarios

Exportación de backups:

SQL

Excel

JSON

Gestión de sugerencias

Links externos (Supabase, GitHub, Cloudflare, DonWeb)

1️⃣2️⃣ Ventana Sugerencias de Mejora (anónima)

Tipos

Estados

Tabla editable

Nueva tabla en BD (guiar creación)

1️⃣3️⃣ Ventana Compras

Flujo tipo POS

Autocompletado

Pagos parciales

Deudas

Actualización automática de stock

Impresión POS 80

1️⃣4️⃣ Ventana Ventas

Flujo similar a Compras

Descuento

Deuda de clientes

Impresión POS 80

Actualización de stock

1️⃣5️⃣ Dashboard

Gráficos:

Ventas por usuario

Deudas por proveedor

Deudas por cliente

Productos más vendidos

Compras mensuales

Ventas mensuales

Todos con:

Filtro por fecha

Scroll si exceden tamaño

CIERRE

👉 Primero entregá SOLO el checklist completo, bien estructurado
👉 NO implementar código aún
👉 Luego de aprobar el checklist, avanzamos módulo por módulo