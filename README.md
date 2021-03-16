- 1-	Se crea un proyecto de tipo web api con > dotnet new webapi -o projectSoft o desde VS de la misma forma del curso.
- 2-	Se modifica el ./Properties/launchSetting.json quitando la entrada https de applicationUrl para evitar el uso de un certificado SSL en la conexión.
- 3-	Se crean las siguientes carpetas: Entities,Interfaces,Repositories,Data
- 4-	Se verifica la compilacion con > dotnet run o se ejecuta en VS con IISExpress
- 5-	Se prueba el endpoint GET http://localhost:5000/WeatherForecast desde postman o http://localhost:5000/swagger/index.html
- 6-	Se crea el gestor de archivos que se encarga de leer y escribir en json https://www.newtonsoft.com/json/help/html/SerializingJSON.htm dotnet add projectSoft.csproj package Newtonsoft.Json
- 7-	Para cada actor se debe crear: Entidad->Interfaz->Repositorio->Controlador
- 8-	En el startup.cs de debe especificar la inyección de dependencias con AddTransient
- 9-	Como mejor opción se implementa el uso de https://github.com/ttu/json-flatfile-datastore para facilitar el manejo del json que contendrá la informacion de todas las tablas.
- 10-	Se hace el uso de validaciones básicas para evitar datos duplicados y consultas inexistentes.

SDK de .NET (que refleje cualquier global.json):
 Version:   5.0.201
 Commit:    a09bd5c86c

Entorno de tiempo de ejecución:
 OS Name:     ubuntu
 OS Version:  18.04
 OS Platform: Linux
 RID:         ubuntu.18.04-x64
 Base Path:   /usr/share/dotnet/sdk/5.0.201/

Host (useful for support):
  Version: 5.0.4
  Commit:  f27d337295

.NET SDKs installed:
  5.0.201 [/usr/share/dotnet/sdk]

.NET runtimes installed:
  Microsoft.AspNetCore.App 5.0.4 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
  Microsoft.NETCore.App 5.0.4 [/usr/share/dotnet/shared/Microsoft.NETCore.App]

To install additional .NET runtimes or SDKs:
  https://aka.ms/dotnet-download
