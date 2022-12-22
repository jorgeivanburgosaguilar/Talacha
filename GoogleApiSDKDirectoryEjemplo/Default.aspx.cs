using System;
using System.Data;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Services;

namespace GoogleApiSDKDirectoryEjemplo
{
    public partial class Default : System.Web.UI.Page
    {
        private static string ObtenerConfiguracion(string nombreConfiguracion)
        {
            return System.Configuration.ConfigurationManager.AppSettings[nombreConfiguracion];
        }

        private UserCredential SolicitarAutorizacionGoogle()
        {
            // Cargar roles/permisos y secretos de la API
            var scopes = new[] { DirectoryService.Scope.AdminDirectoryUser };
            var secrets = GoogleClientSecrets.FromFile(Server.MapPath("~/client_secret.json"));

            // Solicitar autorizacion desde el navegador web
            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                secrets.Secrets,
                scopes,
                ObtenerConfiguracion("AdminEmail"),
                CancellationToken.None
            ).Result;

            return credential;
        }

        protected void DxIniciarSesionGoogleApi_OnClick(object sender, EventArgs e)
        {
            var credenciales = SolicitarAutorizacionGoogle();

            // Inicializar el servicio para acceso a la Directory API v1
            var service = new DirectoryService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credenciales,
                ApplicationName = ObtenerConfiguracion("NombreAplicacion")
            });

            // Crea la solicitud de lista de usuarios
            var request = service.Users.List();
            request.Domain = ObtenerConfiguracion("DominioPrincipal");
            request.OrderBy = UsersResource.ListRequest.OrderByEnum.Email;
            request.MaxResults = 200;
            var users = request.Execute();

            // Creo una estructura basica de datatable para almacenar los usuarios
            // Fuente estructura del usuario: https://developers.google.com/admin-sdk/directory/reference/rest/v1/users?hl=es-419
            // ToDo: Se podria mejorar esto usando una tabla local la cual ir sincronizando con los ids
            var usuarios = new DataTable();
            usuarios.Clear();
            usuarios.Columns.Add("Id", typeof(string));
            usuarios.Columns.Add("NombreCompleto", typeof(string));
            usuarios.Columns.Add("Nombre", typeof(string));
            usuarios.Columns.Add("Apellido", typeof(string));
            usuarios.Columns.Add("CorreoElectronico", typeof(string));

            var colFechaCreacion = usuarios.Columns.Add("FechaCreacion", typeof(DateTime));
            colFechaCreacion.AllowDBNull = true;

            var colUltimoAcceso = usuarios.Columns.Add("UltimoAcceso", typeof(DateTime));
            colUltimoAcceso.AllowDBNull = true;

            // Llenar datatable
            foreach (var user in users.UsersValue)
            {
                var fila = usuarios.NewRow();
                fila["Id"] = user.Id;
                fila["NombreCompleto"] = user.Name.FullName;
                fila["Nombre"] = user.Name.GivenName;
                fila["Apellido"] = user.Name.FamilyName;
                fila["CorreoElectronico"] = user.PrimaryEmail;
                fila["FechaCreacion"] = user.CreationTime;
                fila["UltimoAcceso"] = user.LastLoginTime;
                usuarios.Rows.Add(fila);
            }

            // Guardar en variable de sesion
            usuarios.AcceptChanges();
            Session["UsuariosDT"] = usuarios;
            Response.Redirect("Administrar.aspx");
        }
    }
}