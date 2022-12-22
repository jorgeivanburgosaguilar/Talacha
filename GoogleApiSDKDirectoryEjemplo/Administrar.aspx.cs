using System;
using System.Data;
using System.Web;
using System.Threading;
using DevExpress.Web.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Google.Apis.Services;
using DevExpress.Web;
using System.Text.RegularExpressions;

namespace GoogleApiSDKDirectoryEjemplo
{
    public partial class Administrar : System.Web.UI.Page
    {
        private const string MensajeErrorPorDefecto = "Error General";

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

        public static DataTable ObtenerUsuariosComoDataTable()
        {
            var sesion = HttpContext.Current.Session;
            if (sesion["UsuariosDT"] == null)
                return new DataTable();

            return (DataTable) sesion["UsuariosDT"];
        }

        private void AgregarUsuarioAlDataTable(User usuario)
        {
            var dtUsuarios = (DataTable) Session["UsuariosDT"];
            var fila = dtUsuarios.NewRow();
            fila["Id"] = usuario.Id;
            fila["NombreCompleto"] = $"{usuario.Name.GivenName} {usuario.Name.FamilyName}";
            fila["Nombre"] = usuario.Name.GivenName;
            fila["Apellido"] = usuario.Name.FamilyName;
            fila["CorreoElectronico"] = usuario.PrimaryEmail;
            fila["FechaCreacion"] = (object) usuario.CreationTime ?? DBNull.Value;
            fila["UltimoAcceso"] = (object) usuario.LastLoginTime ?? DBNull.Value;
            dtUsuarios.Rows.Add(fila);
            dtUsuarios.AcceptChanges();
            Session["UsuariosDT"] = dtUsuarios;
        }

        private void ModificarUsuarioEnDataTable(User usuario)
        {
            var dtUsuarios = (DataTable) Session["UsuariosDT"];
            var filas = dtUsuarios.Select($"Id = '{usuario.Id}'");
            foreach (var fila in filas)
            {
                fila["NombreCompleto"] = $"{usuario.Name.GivenName} {usuario.Name.FamilyName}";
                fila["Nombre"] = usuario.Name.GivenName;
                fila["Apellido"] = usuario.Name.FamilyName;
                fila["CorreoElectronico"] = usuario.PrimaryEmail;
                fila["FechaCreacion"] = (object) usuario.CreationTime ?? DBNull.Value;
                fila["UltimoAcceso"] = (object) usuario.LastLoginTime ?? DBNull.Value;
            }

            dtUsuarios.AcceptChanges();
            Session["UsuariosDT"] = dtUsuarios;
        }

        private void QuitarUsuarioDelDataTable(string userId)
        {
            var dtUsuarios = (DataTable) Session["UsuariosDT"];
            var filas = dtUsuarios.Select($"Id = '{userId}'");
            foreach(var fila in filas)
                fila.Delete();

            dtUsuarios.AcceptChanges();
            Session["UsuariosDT"] = dtUsuarios;
        }

        protected void DxGrVwUsuarios_OnInitNewRow(object sender, ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["Nombre"] = string.Empty;
            e.NewValues["Apellido"] = string.Empty;
            e.NewValues["CorreoElectronico"] = $"@{ObtenerConfiguracion("DominioPrincipal")}";
        }

        protected void DxGrVwUsuarios_OnRowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            if (!(sender is ASPxGridView dxGrid))
                throw new Exception(MensajeErrorPorDefecto);

            var dxTxtBxNombre = dxGrid.FindEditFormTemplateControl("DxTxtBxNombre") as ASPxTextBox;
            var dxTxtBxApellido = dxGrid.FindEditFormTemplateControl("DxTxtBxApellido") as ASPxTextBox;
            var dxTxtBxCorreoElectronico = dxGrid.FindEditFormTemplateControl("DxTxtBxCorreoElectronico") as ASPxTextBox;
            var dxTxtBxContrasena = dxGrid.FindEditFormTemplateControl("DxTxtBxContrasena") as ASPxTextBox;

            if (dxTxtBxNombre == null ||
                dxTxtBxApellido == null ||
                dxTxtBxCorreoElectronico == null ||
                dxTxtBxContrasena == null)
                throw new Exception(MensajeErrorPorDefecto);

            if (string.IsNullOrWhiteSpace(dxTxtBxNombre.Text))
                throw new Exception("El campo Nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(dxTxtBxApellido.Text))
                throw new Exception("El campo Apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(dxTxtBxCorreoElectronico.Text))
                throw new Exception("El campo Correo Electrónico es obligatorio.");

            if (string.IsNullOrWhiteSpace(dxTxtBxContrasena.Text))
                throw new Exception("El campo Contraseña es obligatorio.");

            if (!Regex.IsMatch(dxTxtBxContrasena.Text, "^.{8,100}$"))
                throw new Exception("El campo Contraseña no debe ser menor a 8 ni mayor a 100 caracteres.");

            var credenciales = SolicitarAutorizacionGoogle();
            var service = new DirectoryService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credenciales,
                ApplicationName = ObtenerConfiguracion("NombreAplicacion")
            });

            var user = new User
            {
                PrimaryEmail = dxTxtBxCorreoElectronico.Text.Trim(),
                Name = new UserName
                {
                    GivenName = dxTxtBxNombre.Text.Trim(),
                    FamilyName = dxTxtBxApellido.Text.Trim()
                },
                Password = dxTxtBxContrasena.Text,
                ChangePasswordAtNextLogin = true
            };

            var request = service.Users.Insert(user);
            var result = request.Execute();
            if (result == null)
                throw new Exception("No se pudo crear el usuario");

            AgregarUsuarioAlDataTable(result);
            dxGrid.CancelEdit();
            e.Cancel = true;
            dxGrid.DataBind();
        }

        protected void DxGrVwUsuarios_OnRowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            if (!(sender is ASPxGridView dxGrid))
                throw new Exception(MensajeErrorPorDefecto);

            var dxTxtBxNombre = dxGrid.FindEditFormTemplateControl("DxTxtBxNombre") as ASPxTextBox;
            var dxTxtBxApellido = dxGrid.FindEditFormTemplateControl("DxTxtBxApellido") as ASPxTextBox;
            //var dxTxtBxCorreoElectronico = dxGrid.FindEditFormTemplateControl("DxTxtBxCorreoElectronico") as ASPxTextBox;
            var dxTxtBxContrasena = dxGrid.FindEditFormTemplateControl("DxTxtBxContrasena") as ASPxTextBox;

            if (dxTxtBxNombre == null ||
                dxTxtBxApellido == null ||
               //dxTxtBxCorreoElectronico == null ||
                dxTxtBxContrasena == null)
                throw new Exception(MensajeErrorPorDefecto);

            if (string.IsNullOrWhiteSpace(dxTxtBxNombre.Text))
                throw new Exception("El campo Nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(dxTxtBxApellido.Text))
                throw new Exception("El campo Apellido es obligatorio.");

            //if (string.IsNullOrWhiteSpace(dxTxtBxCorreoElectronico.Text))
            //    throw new Exception("El campo Correo Electrónico es obligatorio.");

            if (!string.IsNullOrWhiteSpace(dxTxtBxContrasena.Text) && !Regex.IsMatch(dxTxtBxContrasena.Text, "^.{8,100}$"))
                throw new Exception("El campo Contraseña no debe ser menor a 8 ni mayor a 100 caracteres.");

            var credenciales = SolicitarAutorizacionGoogle();
            var service = new DirectoryService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credenciales,
                ApplicationName = ObtenerConfiguracion("NombreAplicacion")
            });

            var userId = Convert.ToString(e.Keys[dxGrid.KeyFieldName]);
            var usuario = service.Users.Get(userId).Execute();
            if (usuario == null)
                throw new Exception("No se pudo obtener la informacion del usuario");

            //usuario.PrimaryEmail = dxTxtBxCorreoElectronico.Text.Trim();
            usuario.Name.GivenName = dxTxtBxNombre.Text.Trim();
            usuario.Name.FamilyName = dxTxtBxApellido.Text.Trim();

            if (!string.IsNullOrWhiteSpace(dxTxtBxContrasena.Text))
                usuario.Password = dxTxtBxContrasena.Text;

            var request = service.Users.Update(usuario, userId);
            var userActualizado = request.Execute();
            if (userActualizado == null)
                throw new Exception("No se pudo actualizar al usuario");

            ModificarUsuarioEnDataTable(userActualizado);
            dxGrid.CancelEdit();
            e.Cancel = true;
            dxGrid.DataBind();
        }

        protected void DxGrVwUsuarios_OnRowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            if (!(sender is ASPxGridView dxGrid))
                throw new Exception(MensajeErrorPorDefecto);

            var credenciales = SolicitarAutorizacionGoogle();
            var service = new DirectoryService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credenciales,
                ApplicationName = ObtenerConfiguracion("NombreAplicacion")
            });

            var userId = Convert.ToString(e.Keys[dxGrid.KeyFieldName]);
            var request = service.Users.Delete(userId);
            var result = request.Execute();
            if (result == null)
                throw new Exception("No se pudo borrar el usuario");

            QuitarUsuarioDelDataTable(userId);
            e.Cancel = true;
            dxGrid.DataBind();
        }

        protected void DxTxtBxCorreoElectronico_OnLoad(object sender, EventArgs e)
        {
            if (!(sender is ASPxTextBox dxTextBox))
                return;

            if (!(dxTextBox.Parent is GridViewEditFormTemplateContainer dxGridViewEditFormTemplateContainer))
                return;

            if (!(dxGridViewEditFormTemplateContainer.Grid is ASPxGridView dxGrid))
                return;

            dxTextBox.ClientEnabled = dxGrid.IsNewRowEditing;
            dxTextBox.ReadOnly = !dxGrid.IsNewRowEditing;
        }

        protected void DxTxtBxContrasena_OnLoad(object sender, EventArgs e)
        {
            if (!(sender is ASPxTextBox dxTextBox))
                return;

            if (!(dxTextBox.Parent is GridViewEditFormTemplateContainer dxGridViewEditFormTemplateContainer))
                return;

            if (!(dxGridViewEditFormTemplateContainer.Grid is ASPxGridView dxGrid))
                return;

            dxTextBox.NullText = dxGrid.IsNewRowEditing ? string.Empty : "(Sin cambio de contraseña)";
        }
    }
}