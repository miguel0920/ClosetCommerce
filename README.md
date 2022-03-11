# Closet Commerce

## Pasos para migrar tipo CodeFirst con EntityFramework 6.0.1

### Microservicio: Catalog

1. Colocar cadena de conexión en el appsettings.json.
2. Seleccionar el proyecto **Catalog.Api** como proyecto de inicio.
3. Abrir la consola del adminitrador de paquetes y seleccionar el proyecto **Catalog.Persistence.Database**
4. Correr los siguiente comandos.

~~~bash
add-migration Initialize.
~~~

~~~bash
update-database
~~~
