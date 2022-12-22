# Google Admin SDK Directory API - Ejemplo con ASP.NET Web Forms y DevExpress

Aplicacion CRUD basica para administrar los usuarios de Google Workspace (antes G Suite/Google Apps for Work/Business)
con la Google Admin SDK API, ASP.NET Web Forms y DevExpress.

## ** ATENCION **
Este ejemplo no es apto para produccion, es solo un codigo de ejemplo para demostracion de como conectar la API con .NET y DevExpress.
A manera de sugerencia si se quiere llevar este codigo a produccion se necesitara crear una base de datos espejo a la de google
para evitar tener que estar llamando a cada rato a la API asi como para evitar usar System.Data.DataTables en memoria/sesion.
Por ultimo esta aplicacion no protege de manera adecuada las credenciales de autenticacion a la API (client_secret.json).

## Requerimientos API
1. Crear un proyecto desde la [consola de google cloud](https://console.cloud.google.com/) con acceso a la Google Admin SDK.
2. Generar credenciales de autenticacion OAuth 2.0 con los siguientes permisos/alcances:
    - https://www.googleapis.com/auth/admin.directory.user
    - https://www.googleapis.com/auth/admin.directory.user.readonly
    - https://www.googleapis.com/auth/cloud-platform
3. Si se va a probar el proyecto con el IIS Express hay que dar de alta las siguientes urls en "URI de redireccionamiento autorizados":
    - http://localhost:52574/
    - http://127.0.0.1/authorize/
3. Descargar las credenciales de autenticacion (client_secret.json) y ponerlas en la raiz del proyecto.
4. Activar "Confiar en las apps internas que pertenecen al dominio" desde controles de API en el panel del administrador del dominio de Google.

## Documentacion recomendada
- https://developers.google.com/api-client-library/dotnet/get_started?hl=es-419
- https://developers.google.com/api-client-library/dotnet/guide/aaa_oauth?hl=es-419
- https://developers.google.com/api-client-library/dotnet/guide/aaa_client_secrets?hl=es-419
- https://developers.google.com/admin-sdk/directory/reference/rest/v1/users?hl=es-419
- https://developers.google.com/admin-sdk/directory/reference/rest/v1/users/list?hl=es-419
- https://developers.google.com/admin-sdk/directory/reference/rest/v1/users/get?hl=es-419
- https://developers.google.com/admin-sdk/directory/reference/rest/v1/users/insert?hl=es-419
- https://developers.google.com/admin-sdk/directory/reference/rest/v1/users/update?hl=es-419
- https://github.com/googleworkspace/dotnet-samples

## Tecnologias usadas
- Microsoft Visual Studio 2022
- Microsoft .NET Framework 4.8
- Microsoft ASP.NET Web Forms
- DevExpress 22.1.3
- Google.Apis.Admin.Directory.directory_v1


