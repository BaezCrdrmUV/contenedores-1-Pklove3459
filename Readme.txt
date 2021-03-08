Tuve mismos problemas que mi compañero sammy a la hora de correr la aplicacion en contenedores y conectarse a la BD
La Bd se corre en un contenedor independiente con el comando 'docker-compose up mysql_registroPersonas'    

Y la aplicacion se corre aparte en terminal pero no en un contenedor de docker debido a errores
pero corriendo la aplicacion en la carpeta Programa con el comando 'dotnet run'
La base de datos no cuenta con registros por el momento, para poder probar la creacion de una persona