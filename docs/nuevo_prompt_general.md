Ahora me gustaría pedirte que avancemos con los siguientes pasos, pero antes de avanzar, necesito que me armes un checklist de seguimiento de avances para ir realizando todo de a poco, paso a paso. el orden de lo que quiero y como tiene que aparecer en el chiecklist es el siguiente:

1º Verificar y entender el proyecto creado en C:\Sistema_Gestión_Kioscos.05 y crear un archivo resumiendo todo lo que entendiste y un archivo con un diagrama de flujo completo de este proyecto.

2º Teniendo en cuenta que mi proyecto actual, el ubicado en C:\VS 2022\gestionComercios_vs2022_rev01.00, me gustaría que tenga el mismo o muy similar diagrama de flujo que el proyecto anterior, quiero que me crees un archivo explicando todo el proyecto, con una mirada onda marketinera, tipo explicación de venta. También quiero que me crees un archivo con la misma explicación pero más técnica. También voy a necesitar que me detalles un diagrama de flujo recomendado (uno super técnico y uno bien general, onda marketinera para ventas).

3º Verificar y si es necesario, actualizar el proceso de Registro e Ingreso de usuarios. Cómo se nombro anteriormente, lo vuelvo a remarcar, la idea es qué, al registrarse un nuevo usuario, el sistema se abre como un nuevo negocio (ejemplo, Se registro Juan Perez = Negocio de Juan Perez con registros totalmente vacíos, se registro Hermindo Areco = Negocio de Hermindo Areco con registros totalmente vacíos y asi sucesivamente). Para poder registrarse, el usuario debe colocar si o si su mail dos veces, nombre de usuario, contraseña dos veces, contacto y aceptar terminos de condiciones (los terminos deberíamos implementarlos según seguridad sugerida). Una vez que el usuario se registra, debería llegar un mail de confirmación al correo mo826440@gmail.com. Solamente si el usuario del mail mo826440@gmail.com autoriza el registro del nuevo usuario, este ya podrá entrar al sistema cada vez que lo desee desde la landingpage, aplicando la opción "Ingresar" y colocando su Nombre de usuario, contraseña e ID del comercio (este id se deberá otorgar automaticamente al confirmarse el registro del usuario), (y estaría bueno sumar alguna herrmienta de autenticación, ejemplo confirmar por correo que eres el usuario o huella dactilar, etc). Luego, el usuario al registrarse, tendra el rol de administrador del Comercio, lo cual le dará el permiso para poder ver y editar todas las ventanas del sistema, menos la ventana de Mantenimiento (esta ventana la podrá ver solo el usuario registrado como programador, lo explico más adelante). Cada vez que se registra un nuevo Usuario es = A que se registre un Nuevo comercio, por ende, cada usuario nuevo deberá tener automaticamente un ID único y Cada comercio también si ID único (como si fuera un DNI único). Una vez ingresado al sistema, el usuario admin, desde la ventana de Usuarios podrá agregar usuarios nevos (lo explicamos en el siguiente paso).

4º Implementar el desarrollo de la ventana Usuarios. (a esta ventana solo podra ingresar el usuario admin).

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo Usuario (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO USUARIO: Deberá contener los siguientes campos y opciones:
    1. Nombre y apellido*
    2. Usuario* (el cual va a servir parA ingresar al sistema, no se debe repetir si ya esta en uso para el mismo comercio).
    3. Mail* (no debe requerir confirmación de mail para usuarios que no son admin).
    4. Contraseña* (esta se va a usar para ingresar al sistema).
    5. Rol* (administrador, vendedor o encargado).
    6. Referencias (opcional)
    7. Botón de Guardar (al clikear o con el atajo "Control + Intro" se registrará el nuevo usuario, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    8. Automaticamente al crearse un usuario desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante + id del comercio (se entiende eso?).
    9. Por defecto, al registrarse un usuario, debe aparecer en estado Activo.
    10. Botón de Cancelar (servira para cancelar el proceso y salir del panel de cargar nuevo usuario)
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Usuario (esta columna mostrará el usuario elegido para ingresar al sistema. debe tener una opción muy similar al filtrado de excel para filtrar los usuarios).
   2. Rol (esta columna debe mostrar el rol asignado a cada usuario)
   3. Estado (esta columna debe mostrar el estado del usuario, Activo en color verde e Inactivo en color rojo).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del usuario,     
           ejemplo, Nombre y Apellido, Usuario, mail, contraseña (oculta y con opción de ver), 
           referencias, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el admin logueado que realizo el proceso).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).

5º Implementar el desarrollo de la ventana de Proveedores.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo Proveedor (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO proveedor: Deberá contener los siguientes campos y opciones:
    1. Nombre y apellido y/o nombre del comercio*
    2. Contacto* (número de celular)
    3. Mail* 
    4. Estado ante ARCA - AFIP (MONOTRIBUTISTA, S.R.L, etc). + CUIT del comercio.
    5. Referencias (opcional)
    6. Botón de Guardar (al clikear o con el atajo "Control + Intro" se creará el nuevo registro, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    7. Automaticamente al crearse un nuevo registro desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante  + id del comercio.
    8. Por defecto, al crearse un nuevo registro, debe aparecer en estado Activo.
    9. Botón de Cancelar (servira para cancelar el proceso y salir del panel de carga).
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Nombre y Apellido y/o nombre del comercio (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
   3. Estado (esta columna debe mostrar el estado, Activo en color verde e Inactivo en color rojo).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del registro,     
           ejemplo, Nombre y Apellido y/o nombre del comercio, Contacto, mail, estado ante arca-afip, cuit del comercio, 
           referencias, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


6º Implementar el desarrollo de la ventana de Clientes.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo Cliente (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Nombre y apellido*
    2. Contacto* (número de celular)
    3. Mail (opcional)
    4. DNI.(opcional)
    5. Referencias (opcional)
    6. Botón de Guardar (al clikear o con el atajo "Control + Intro" se creará el nuevo registro, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    7. Automaticamente al crearse un nuevo registro desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante  + id del comercio.
    8. Por defecto, al crearse un nuevo registro, debe aparecer en estado Activo.
    9. Botón de Cancelar (servira para cancelar el proceso y salir del panel de carga).
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Nombre y Apellido (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
   3. Estado (esta columna debe mostrar el estado, Activo en color verde e Inactivo en color rojo).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del registro,     
           ejemplo, Nombre y Apellido, Contacto, mail, DNI, 
           referencias, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


7º Implementar el desarrollo de la ventana de Categorias.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo registro (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Nombre* (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
    2. Referencias (opcional)
    3. Botón de Guardar (al clikear o con el atajo "Control + Intro" se creará el nuevo registro, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    4. Automaticamente al crearse un nuevo registro desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante  + id del comercio.
    5. Por defecto, al crearse un nuevo registro, debe aparecer en estado Activo.
    6. Botón de Cancelar (servira para cancelar el proceso y salir del panel de carga).
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Nombre (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
   3. Estado (esta columna debe mostrar el estado, Activo en color verde e Inactivo en color rojo).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del registro,     
           ejemplo, Nombre, referencias, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


8º Implementar el desarrollo de la ventana de Marcaas.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo registro (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Nombre* (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
    2. Referencias (opcional)
    3. Botón de Guardar (al clikear o con el atajo "Control + Intro" se creará el nuevo registro, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    4. Automaticamente al crearse un nuevo registro desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante  + id del comercio.
    5. Por defecto, al crearse un nuevo registro, debe aparecer en estado Activo.
    6. Botón de Cancelar (servira para cancelar el proceso y salir del panel de carga).
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Nombre (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna).
   3. Estado (esta columna debe mostrar el estado, Activo en color verde e Inactivo en color rojo).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del registro,     
           ejemplo, Nombre, referencias, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


9º Implementar el desarrollo de la ventana de Productos.

   ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de registros cargados 
   2. Cantidad de registros en estado activo.
   3. Cantidad de registros sin stock.
   4. Cantidad de registros con stock inferior al límite mínimo.
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo registro (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Código de barras* (con opción de ponerlo de forma manual, con scanner común o scaneando con cámara del celular. No se deben repetir los códigos).
    2. Nombre* (esta columna debe tener una opción muy similar al filtrado de excel para filtrar esta columna). (no se deben repetir los nombres).
    3. Categoria (este campo para cargarlo, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todas las categorias cargadas en la ventana Categorias - Tambieén me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo), por defecto debe aparecer "NO APLICA".
    4. Marca (este campo para cargarlo, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todas las Marcas cargadas en la ventana Marcas - Tambieén me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo), por defecto debe aparecer "NO APLICA".
    5. Precio Costo (por defecto debe aparecer "NO APLICA" - nunca menor a cero pesos)
    6. Precio Venta* (nunca menor a cero pesos)
    7. Stock mínimo aceptable* (nunca debe ser menor a cero - por defecto debe aparecer como no aplica)
    8. Ajuste de Stock* (para poner el stock actual - nunca deberá ser menor a cero - por defecto debe aparecer en cero).
    9. Descripción (opcional)
    10. Botón de Guardar (al clikear o con el atajo "Control + Intro" se creará el nuevo registro, pero antes debe mostrarse un mensaje de confirmación. Si falta algún dato importante debe mostrar mensaje de error y si se registro correctamente también debe mostrar un mensaje de exito).
    8. Automaticamente al crearse un nuevo registro desde esta ventana, el sistema le debe generar un ID único. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante + id del comercio.
    9. Por defecto, al crearse un nuevo registro, debe aparecer en estado Activo.
    10. Botón de Cancelar (servira para cancelar el proceso y salir del panel de carga).
    NOTA: lo marcado con * es porque debe ser una información obligatoria.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Código de barras (esta columna debe tener una opción muy similar al filtrado de excel para filtrar sus registros).
   1. Nombre (esta columna debe tener una opción muy similar al filtrado de excel para filtrar  sus registros).
   3. Estado (esta columna debe mostrar el estado, Activo en color verde e Inactivo en color rojo).
   4. Stock (Sin Stock en rojo, Stock Bajo en amarillo y Stock Aceptable en verde - esta columna debe tener una opción muy similar al filtrado de excel para filtrar sus registros según el estado del stock).
   4. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información del registro,     
           ejemplo, Cód barras, Nombre, Categoria, Marca, precio costo y venta, stock minimo aceptable, stoc actual, descripción, id único, estado, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso), etc.
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo).

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


10º Implementar el desarrollo de la ventana de Configuraciones. (solo puede acceder el usuario admin y programador)

 ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Nombre del tema seleccionado
   2. Nombre del Comercio
 - PARTE MEDIA: La ventana deberá mostrar las siguientes opciónes:
       * Actualizar Información del comercio (la cual deberá mostrar un panel para cargar o actualizar info del comercio, ejemplo, logo, nombre, razon social ante arca-afip, dirección, mail, contacto, etc).
       * Actualizar tema del sistema (ejemplo, tema oscuro, claro, etc, según los que me puedas recomendar).
       * Actualizar o Agregar formas de pago (ejemplo, Efectivo, Transferencia, QR, Debito, Credito, Cheque, Otros).
       * Formatos de fecha y hora (Por defecto, En todos los campos, opciones y/o información de fecha y hora, se debe manejar con el formato "dd/mm/yyy 00:00" y con el horario argentino o de buenos aires. Ejemplo, 05/01/2026 18:25.)
       * Formatos de moneda (por defecto, En todos los campos y opciones e información de precios, se debe manejar con el formato de pesos argentinos, ejemplo: $1.000.000,00.)

 - PARTE INFERIOR: Debe contener recomendaciones de uso que me puedas sugerir.

11º Implementar el desarrollo de la ventana de Mantenimeinto. (solo puede acceder el usuario programador)

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
    1. Nombre del Comercio.
    2. Numbre del usuario admin.
    3. Id del comercio ingresado.
    4. Total de Registros cargados en Supabase para ese comercio.
 - PARTE MEDIA: La ventana deberá mostrar lo siguiente:
       * Un panel que me informe:
         1. El nombre de la base de datos usada.
         2. El nombre de las tablas creadas
         3. Cuantas columnas tiene cada tabla.
         4. Cuantos registros existen cargados en cada columna para el comercio ingresado.
         5. Cuantos registros existen cargados en cada columna de forma total (o sea, todos los registros de todos los comercios).
         6. La cantidad de memoria que ocupa el comercio.
         7. La cantidad de memoria total ocupada de la base de datos.
         8. La cantidad de memoria disponible que tengo en esa base de datos.
       * Un panel que me muestre los usuarios registrados, con opción de editar el estado, Activo o Inactivo. El usuario marcado como Inactivo ya no podra ingresar a la app, ni el, ni los usuarios que el creo para su comercio.
       * Panel que me muestre sugerencias de usuarios, me debe mostrar solamente el tipo de sugerencia, su descripción y fecha y hora de carga. (para esto vamos a desarrollar una ventana donde todos los usuarios pueden ingresar de forma anónima y dejar sugerencias de mejora para el sistema).
       * Una opción que me permita exportar un backup de todos los registros según el comercio seleccionado. Que me lo permita exportar en formato sql, formato excel, y formato SJonson.
       * Una opción que me permita exportar un backup de todos los registros de la bse de datos en general, o sea de todos los comercios. Que me lo permita exportar en formato sql, formato excel, y formato SJonson.
       Este panel me debe permitir marcar cada sugerencia en estados de Revisión, En tratamiento y Tratadas.
 - PARTE INFERIOR: Debe contener link para ingresar a mi proyecto en supabase, en hithub y en cloudflare y para que me lleve al sector donde compre mis dominios (https://micuenta.donweb.com/es-ar/servicios/dominios).

12º Implementar el desarrollo de la ventana de Sugerecias de Mejoras. (todos los usuarios ingresaran de forma anónima)

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
    1. Cantidad de Sugerencias propuestas para ese comercio.
    2. Cantidad de sugerencias En revisión para ese comercio.
    3. Cantidad de sugerencias En tratamiento para ese comercio.
    4. Cantidad de sugerencias Tratadas para ese comercio.
 - PARTE MEDIA: La ventana deberá mostrar la opción de cargar nueva sugerencia (botón o atajo con Control + F2)
 - PANEL DE CARGA: Debe mostrar los siguientes campos y opciones:
    1. Tipo de sugerencia (Estilos, Funcionalidades, Errores, Otras).
    2. Descripción
    3. Botón Guardar
    4. Botón Editar
 - PARTE INFERIOR: Debe mostrar una tabla con las siguientes columnas:
    1. Tipo de sugerencia
    2. Descripción
    3. Acciones (Editar o Eliminar)

    NOTA: Para la gestión de sugerencias seguramente tendremos que crear una nueva tabla en la base de dtos, anda guiandome con eso.

13º Implementar el desarrollo de la ventana de Compras.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de compras cargadas
   2. Cantidad de registros con deudas y etiqueta del monto total de deudas (esto se debe actualizar junto con los filtros, ejemplo, filtro un proveedor puntual, este indicador me debe mostrar la deuda que tengo con él).
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo registro (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Facturación: Se deberá cargar maual, pero por defecto debe aparecer "No Aplica".
    2. Proveedor: (este campo para cargarlo, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todas los proveedores cargados en la ventana Proveedores - Tambieén me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo), por defecto debe aparecer "NO APLICA".
    3. Código de barras*, Por defecto, al entrar al panel de CARGAR NUEVO REGISTRO o NUEVA COMPRA, ya me debe posicionar el cursor en el campo Código de barras, con opción de ponerlo de forma manual, con scanner común o scaneando con cámara del celular. También debe tener la opción de cargarse automaticamente según el producto cargado en el campo Nombre del Producto.
    4. Nombre del producto* este campo se debe cargar automaticamente según el nombre que coincida con el código de barras cargado en el campo Código de barras. Sino también, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todos los productos cargados en la ventana Productos - Tambieén me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir  coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo.
    5. Unidades, este campo se debe cargar de forma manual, con formato número, ejemplo 1.0. Por defecto debe aparecer 1.0. Nunca debe ser menor o igual a cero.
    5. Precio Costo por unidad Este campo se debe poder actualizar de forma manual. (por defecto debe aparecer el costo que coincide en la ventana Productos para el producto que se esta cargando en compras - nunca debe ser menor a cero pesos).
    6. % Descuento. Este campo se debe poder actualizar manualmente desde el 1.00% al 100.00%. Por defecto debe aparecer 0.00%.
    7. Botón de cargar o atajo con enter (intro): Esta acción me debe cargar lo registrado en una tabla dentro de este panel y automaticamente me debe lmpiar los campos y posicionar el cursor en el campo de código de barras para cargar un nuevo producto.
    8. Tabla de productos registrados: Esta tabla me deberá ir mostrando dentro de este mismo panel, los productos registrados de la siguiente forma:
      - Primer columna: Nombre Producto
      - Segunda columna: Unidades
      - Tercer columna: Costo Unitario
      - Cuarta columna: Costo Total
      - Quinta columna: Acciones (Editar - Eliminar)
      - Sumatoria de costos totales en la part inferior derecha de la tabla.
    9. Botón de Cargar pago o atajo Control + P, esta acción me debe posicionar el cursor en el campo Metodo de pago.
    10. Campo método de pago, se debe cargar mediante lista desplegable que tomrá las opciones desde la ventana de configuraciones.
    11. Campo Total Abonado, en este campo se debe cargar por defecto el costo total de la compra, o sea, la suma del costo total de cada producto cargado, ejemplo Producto 1 compre 2 unidades a $10,00 por unidad y producto 2 compre 2 unidades a $5,00 por unidad. Entonces, el costo total de la compra es de $30,00. Pero el campo debe tener la posibilidad de cambiar el monto manualmente.
    12. Tabla de pagos registrados: Esta tabla me deberá ir mostrando dentro de este mismo panel, los pagos registrados de la siguiente forma:
      - Primer columna: Metodo Pago
      - Segunda columna: Suma de costo total de la compra
      - Tercer columna: Total Abonado
      - Cuarta columna: Total deuda
      - Quinta columna: Acciones (Editar - Eliminar)
    13. Campo de observaciones (opcional)  
    14. Botón de finalizar compra o atajo "Control + F, esta acción me debe registrar la compra en la Tabla ubicada en la parte inferior de la ventana Compras (luego describo lo que va a mostrar la tabla), pero antes de registrarlo me debe mostrar un mensaje de exito, o de error. Si es éxito, el panel se debe cerrar automaticamente, si es de error, el panel debe indicar el error y no cerrarse.
    15. Botón de Cancelar o atajo "Control + E", esta opción me debe limpiar todos los campos y cerrar el panel sin registrar nada. Pero antes, me debe mostrar un mensaje con opción de corfimar esa acción.     
    16. Automaticamente al crearse un nuevo registro desde este panel, el sistema le debe generar un ID único a la compra general, ejemplo Producto 01 con id compra= 0125 y producto 02con id compra= 0125. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante + id del comercio.
    NOTA: Cada vez que se finalice una nueva compra, automaticamente se debe actualizar el stock de los productos comprados.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Facturación (esta columna debe tener una opción muy similar al filtrado de excel para filtrar sus registros).
   1. Proveedor (esta columna debe tener una opción muy similar al filtrado de excel para filtrar  sus registros).
   3. Unidades (esta columna debe mostrar la suma total de las unidades compradaas).
   4. Costo Total (esta columna debe mostrar el costo total de la compra)
   5. Total Abonado (esta columna debe mostrar la suma del monto total abonado).
   6. Deuda (esta columna debe mostrar la suma total de lo que todavía debo para esa compra).
   7. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información registrada de la compra,     
           ejemplo, Facturación, proveedor, info de productos cargados, info o historial de pagos, observaciones, id único, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso), etc.
        * Imprimir detalle de compra (debe estar modificado para imprimir en impresora tipo POS 80).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo). Solo el usuario admin podra realizar esta acción.
        * Eliminar Compra. Solo el usuario admin podra realizar esta acción. Antes de eliminar debe mostrar mensajes de confirmación

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


14º Implementar el desarrollo de la ventana de Ventas.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA:

 - PARTE SUPERIOR: La ventana debera mostrar los siguientes indicadores: 
   1. Cantidad de ventas cargadas
   2. Cantidad de registros con deudas y etiqueta del monto total de deudas (esto se debe actualizar junto con los filtros, ejemplo, filtro un cliente puntual, este indicador me debe mostrar la deuda que tengo con él).
 - PARTE MEDIA: La ventana deberá mostrar la opción de Cargar nuevo registro (la cual se podrá acceder con atajo "Control + F2").
 - PANEL DE CARGAR NUEVO REGISTRO: Deberá contener los siguientes campos y opciones:
    1. Facturación: Se deberá cargar maual, pero por defecto debe aparecer "No Aplica".
    2. Cliente: (este campo para cargarlo, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todas los clientes cargados en la ventana Clientes - También me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo), por defecto debe aparecer "NO APLICA".
    3. Código de barras*, Por defecto, al entrar al panel de CARGAR NUEVO REGISTRO o NUEVA VENTA, ya me debe posicionar el cursor en el campo Código de barras, con opción de ponerlo de forma manual, con scanner común o scaneando con cámara del celular. También debe tener la opción de cargarse automaticamente según el producto cargado en el campo Nombre del Producto.
    4. Nombre del producto* este campo se debe cargar automaticamente según el nombre que coincida con el código de barras cargado en el campo Código de barras. Sino también, me debe mostrar una lista desplegable para elegir la opción deseada, mostrando todos los productos cargados en la ventana Productos - Tambieén me debe permitir ir poniendo letras manualmente en el campo y que me vaya mostrando lista desplegable de opciones según lo que vaya filtrando con las letras que voy poniendo - También me debe permitir elegir la opción deseada mediante un clik con el mause o mediante desplazamiento con las flechas de abajo o arriba del teclado, mientras vaya desplazando las opciones se deben ir  coloreando por ejemplo con fondo azul y letras blancas y al dar enter se debe cargar esa opción en el campo.
    5. Unidades, este campo se debe cargar de forma manual, con formato número, ejemplo 1.0. Por defecto debe aparecer 1.0. Nunca debe ser menor o igual a cero.
    5. Precio Venta por unidad Este campo se debe poder actualizar de forma manual. (por defecto debe aparecer el costo que coincide en la ventana Productos para el producto que se esta cargando en ventas - nunca debe ser menor a cero pesos).
    6. % Descuento. Este campo se debe poder actualizar manualmente desde el 1.00% al 100.00%. Por defecto debe aparecer 0.00%.
    7. Botón de cargar o atajo con enter (intro): Esta acción me debe cargar lo registrado en una tabla dentro de este panel y automaticamente me debe lmpiar los campos y posicionar el cursor en el campo de código de barras para cargar un nuevo producto.
    8. Tabla de productos registrados: Esta tabla me deberá ir mostrando dentro de este mismo panel, los productos registrados de la siguiente forma:
      - Primer columna: Nombre Producto
      - Segunda columna: Unidades
      - Tercer columna: Precio Unitario
      - Cuarta columna: Precio Total
      - Quinta columna: Acciones (Editar - Eliminar)
      - Sumatoria de Precios totales en la part inferior derecha de la tabla.
    9. Botón de Cargar pago o atajo Control + P, esta acción me debe posicionar el cursor en el campo Metodo de pago.
    10. Campo método de pago, se debe cargar mediante lista desplegable que tomrá las opciones desde la ventana de configuraciones.
    11. Campo Total Abonado, en este campo se debe cargar por defecto el costo total de la venta, o sea, la suma del costo total de cada producto cargado, ejemplo Producto 1 vendi 2 unidades a $10,00 por unidad y producto 2 vendi 2 unidades a $5,00 por unidad. Entonces, el costo total de la Venta es de $30,00. Pero el campo debe tener la posibilidad de cambiar el monto manualmente.
    12. Tabla de pagos registrados: Esta tabla me deberá ir mostrando dentro de este mismo panel, los pagos registrados de la siguiente forma:
      - Primer columna: Metodo Pago
      - Segunda columna: Suma de precio total de la venta
      - Tercer columna: Total Abonado
      - Cuarta columna: Total deuda
      - Quinta columna: Acciones (Editar - Eliminar)
    13. Campo de observaciones (opcional)  
    14. Botón de finalizar venta o atajo "Control + F", esta acción me debe registrar la venta en la Tabla ubicada en la parte inferior de la ventana Ventas (luego describo lo que va a mostrar la tabla), pero antes de registrarlo me debe mostrar un mensaje de exito, o de error. Si es éxito, el panel se debe cerrar automaticamente, si es de error, el panel debe indicar el error y no cerrarse.
    15. Botón de Cancelar o atajo "Control + E", esta opción me debe limpiar todos los campos y cerrar el panel sin registrar nada. Pero antes, me debe mostrar un mensaje con opción de corfimar esa acción.     
    16. Automaticamente al crearse un nuevo registro desde este panel, el sistema le debe generar un ID único a la venta general, ejemplo Producto 01 con id venta= 0125 y producto 02con id venta= 0125. Este id me gustaría que tenga el siguiente formato: Número desde el 01 en adelante + id del comercio.
    NOTA: Cada vez que se finalice una nueva venta, automaticamente se debe actualizar el stock de los productos vendidos.
 - PARTE INFERIOR: En la parte inferior de la pantalla se debe mostrar una tabla con las siguientes columnas:
   1. Facturación (esta columna debe tener una opción muy similar al filtrado de excel para filtrar sus registros).
   1. Cliente (esta columna debe tener una opción muy similar al filtrado de excel para filtrar  sus registros).
   3. Unidades (esta columna debe mostrar la suma total de las unidades vendidas).
   4. Precio Total (esta columna debe mostrar el precio total de la venta)
   5. Total Abonado (esta columna debe mostrar la suma del monto total abonado).
   6. Deuda (esta columna debe mostrar la suma total de lo que todavía me deben para esa venta).
   7. Acciones: esta columnas deberá mostrar las siguientes acciones: 
        * Ver detalle: acción que mostrará un panel con el detalle de toda la información registrada de la venta,     
           ejemplo, Facturación, cliente, info de productos cargados, info o historial de pagos, observaciones, id único, fecha y hora de registro o última edición y responsable de registro o última edición (el usuario logueado que realizo el proceso), etc.
        * Imprimir detalle de venta (debe estar modificado para imprimir en impresora tipo POS 80).
        * Editar: acción que mostrará un panel para editar toda información cargada del registro (menos 
          el id, eso siempre deberá ser el mismo). Solo el usuario admin podra realizar esta acción.
        * Eliminar Venta. Solo el usuario admin podra realizar esta acción. Antes de eliminar debe mostrar mensajes de confirmación

NOTA: La tabla debe tener la opción de verse por páginas, ejemplo, tengo cargado 200 registros, la página 1 me debe mostrar los últimos 20 cargados, la página 2 los siguientes 20 y así sucesivamente. (estaría bueno tener una opción para elegir cuántos registros quiero ver por página).


15º Implementar el desarrollo de la Ventana Dashboard.

  ARQUITECTURA Y FUNCIONES DE LA VENTANA

  - Sub Ventana Graficos de Usuarios: Debe contener los siguientes gráficos:
      * Grafico de barras indicando las ventas por usuario (con posibilidad de filtrar por fecha)

  - Sub Ventana Graficos de Proveedores: Debe contener los siguientes gráficos:
      * Grafico de barras indicando las deudas por proveedores, o sea, me debe mostrar en cada barra el nombre del proveedor y el monto total de la deuda. No me debe mostrar proveedores que no les debo (con posibilidad de filtrar por fecha)

  - Sub Ventana Graficos de Clientes: Debe contener los siguientes gráficos:
      * Grafico de barras indicando las deudas por clientes, o sea, me debe mostrar en cada barra el nombre del cliente y el monto total de la deuda. No me debe mostrar clientes que no me deben (con posibilidad de filtrar por fecha)

  - Sub Ventana Graficos de Productos: Debe contener los siguientes gráficos:
      * Grafico de barras indicando los productos más vendidos, o sea, el nombre de los productos, cantidad de unidades y monto total en pesos (con posibilidad de filtrar por fecha). Si son muchos productos me debe mostrar una barra de desplazamiento.

  - Sub Ventana Graficos de Compras: Debe contener los siguientes gráficos:
      * Grafico de barras indicando las compras mensuales, mostrando el mes y el monto total en pesos. (con posibilidad de filtrar por fecha). Si son muchos productos me debe mostrar una barra de desplazamiento.

  - Sub Ventana Graficos de Ventas: Debe contener los siguientes gráficos:
      * Grafico de barras indicando las ventas mensuales, mostrando el mes y el monto total en pesos. (con posibilidad de filtrar por fecha). Si son muchos productos me debe mostrar una barra de desplazamiento.


      FIN DEL PROMPT!!!