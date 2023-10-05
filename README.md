# Person Generator API
Este proyecto es un generador de datos de personas ficticias que actualmente esta alimentado de la p�gina [FAKE Name Generator ES](https://es.fakenamegenerator.com/).

Los datos que muestra la API son datos ficticios y provistos por la p�gina *FAKE Name Generator* a la que le hemos aplicado la t�cnica de *Web Scrapping* para extraer los datos de esta a un formato mas manejable como lo es JSON.

### Funcionamiento
La llamada a la API es muy sencilla, basta con ejecutar el programa con el comando `dotnet run` dentro de la carpeta del proyecto.

Una vez se ha lanzado la API basta con realizar llamadas del tipo GET con el siguiente formato:

	https://localhost:7266/api/Person/Get/{cantidad}

donde cantidad es un numero entero que indica el numero de personas de las cuales se desea conseguir informaci�n y el programa se encargar� de devolverte toda la informaci�n en un formato manejable por otros programas.

### Retrocompatibilidad
Usted puede usar esta API en sus proyectos siempre y cuando cumpla la licencia de *FAKE NAME GENERATOR* la cual dejamos adjunta [aqu�](https://es.fakenamegenerator.com/license.php).

Para hacer uso de la API en alguno de sus proyectos primero debe ejecutar la API y despues ya se puede encargar de realizar las peticiones que necesite desde sus otros programas.