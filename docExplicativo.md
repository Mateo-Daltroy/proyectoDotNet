Documento Explicativo de la Consola del Proyecto
Este documento explicativo mencionara los detalles necesarios para utilizar la consola
y validar las funcionalidades requeridas por el enunciado. Confiamos en que la interfaz es
intuitiva de utilizar, pero por las dudas, aqui se encontraran los detalles del acceso
administrativo.
Dado que en ningún lugar del enunciado se menciona que método se utilizará para
iniciar sesión, decidimos que provisionalmente cada usuario inicia sesión ingresando su DNI
sin puntos. Para acceder a las funcionalidades del administrador se utiliza el DNI 1, que
establece automáticamente el ID del usuario en 1 también para garantizar los permisos
adecuados. Una vez ingresado el DNI 1, se imprimirá en pantalla un gráfico que muestra
todos los casos de uso con su número de opción correspondiente, ingresando el número llama
al método que cumple la funcionalidad.
En operaciones de eliminación y modificación, se mostrará una lista de las entidades
disponibles de la cual tendría que elegir el elemento correspondiente ingresando su id por
teclado. Dentro de la modificación, cualquier dato que no desee modificar, simplemente
puede presionar enter con la casilla de texto vacía para dejarlo como estaba.
Las tareas enunciadas en el sector de “casos de uso” se las dejamos de uso exclusivo
al administrador debido a que el enunciado de validación pedía que si el ID era igual a 1,
debe retornar true, en cualquier otro caso, false para todos los permisos.
El usuario normal solo puede ver los eventos actuales con cupo disponible, por ende
se muestran automáticamente una vez que se valida que su cuenta existe
