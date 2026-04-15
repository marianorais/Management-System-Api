# ManagementSystemAPI

## Objetivo

Desarrollar una API RESTful que permita gestionar operaciones básicas (CRUD) sobre una base de datos.

Tiempo de resolución: 48 hs.

## Requisitos técnicos

- Framework: .NET 8 (o superior)
- ORM: Entity Framework Core
- Base de datos: SQL Server

## Alcance funcional

La API contempla operaciones CRUD sobre las siguientes entidades:

- Gestión de usuarios
- Gestión de productos (inventario)
- Gestión de libros
- Gestión de órdenes

Cada módulo permite crear, consultar, actualizar y eliminar registros.

## Requisitos mínimos

- Implementación de operaciones CRUD completas
- Validaciones de datos mediante Data Annotations
- Manejo de errores con respuestas HTTP apropiadas
- Al menos una prueba unitaria
- Uso de arquitectura en capas

## Arquitectura

El proyecto está dividido en tres capas:

- ManagementSystemAPI.Api → Controllers y configuración de la API
- ManagementSystemAPI.Core → Entidades del dominio
- ManagementSystemAPI.Data → DbContext, repositorios y migraciones

## Base de datos

El proyecto utiliza Entity Framework Core.

### Connection String

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ManagementSystemApi;Trusted_Connection=True;TrustServerCertificate=True"
}

## Testing

El proyecto incluye pruebas unitarias implementadas con xUnit, las cuales validan el comportamiento de los servicios principales y aseguran el correcto funcionamiento de la lógica de negocio. Para ejecutar los tests, simplemente se debe utilizar el comando "dotnet test" desde la raíz del repositorio, lo que permitirá correr todas las pruebas disponibles y visualizar sus resultados en consola.

## Instrucciones de ejecución

1_ Clonar el repositorio en tu máquina local: "git clone https://github.com/tu-usuario/ManagementSystemAPI.git"
2_ Ingresar a la carpeta del proyecto: "cd ManagementSystemAPI"
3_ Restaurar las dependencias del proyecto: "dotnet restore"
4_ Crear la base de datos aplicando las migraciones de Entity Framework Core: 
    "dotnet ef database update --project ManagementSystemAPI.Data --startup-project ManagementSystemAPI.Api"
5_ Ejecutar API: "dotnet run --project ManagementSystemAPI.Api"
6_ Abrir el navegador y acceder a la documentación Swagger: "https://localhost:{puerto}/swagger"