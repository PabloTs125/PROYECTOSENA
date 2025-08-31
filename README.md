# 🌱 Tienda de Maleza

Este proyecto es una aplicación en **C# con .NET Framework**, desarrollada con arquitectura en capas, que simula una **tienda virtual de productos**.  
La aplicación permite mostrar productos, con un enfoque de ejemplo académico / demostrativo para entender el flujo de una tienda en línea.

## 🏗️ Estructura del Proyecto
El proyecto sigue una arquitectura en capas:

- **CapaAdministrador** → Gestión general de la aplicación.  
- **CapaDatos** → Conexión y consultas a la base de datos.  
- **CapaEntidad** → Definición de las entidades (modelos).  
- **CapaNegocio** → Lógica de negocio.  
- **CapaTienda** → Interfaz principal de la aplicación (UI).  

## 🚀 Requisitos Previos
Antes de ejecutar el proyecto asegúrate de tener instalado:

- [Visual Studio](https://visualstudio.microsoft.com/) (versión 2022 recomendada).
- [.NET Framework / .NET SDK](https://dotnet.microsoft.com/en-us/download)  
- SQL Server (si la base de datos está conectada).  

## ⚙️ Instalación y Ejecución en Local
1. Clona este repositorio:
   ```bash
   git clone https://github.com/PabloTs125/PROYECTOSENA.git
Abre el archivo de solución en Visual Studio:

Copiar código
TiendaDeMaleza.sln
Restaura los paquetes NuGet necesarios:

Menú: Herramientas → Administrador de paquetes NuGet → Restaurar paquetes

O desde consola:

bash
Copiar código
dotnet restore
Configura la base de datos (si aplica):

Edita el archivo de configuración app.config o web.config en la CapaDatos para apuntar a tu instancia de SQL Server.

Ejecuta el proyecto:

Selecciona el proyecto CapaTienda como proyecto de inicio.

Pulsa ▶️ Iniciar (F5) en Visual Studio.

Vista Previa
La aplicación muestra un catálogo de productos de ejemplo.

 Contribuciones
Si quieres contribuir:

Haz un fork del repositorio.

Crea una nueva rama (git checkout -b feature/nueva-funcionalidad).

Realiza los cambios y haz commit.

Envía un Pull Request.

Licencia
Este proyecto está bajo la licencia MIT.
Puedes usarlo y modificarlo libremente.