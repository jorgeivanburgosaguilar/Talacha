<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="GoogleApiSDKDirectoryEjemplo.Administrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphContenidos" runat="server">
    <div style="text-align: left; padding-bottom: 10px;">
        <dx:ASPxButton runat="server" ID="DxBtnAnadirNuevo" Text="Añadir Nuevo Usuario" ToolTip="Añadir Nuevo Usuario"
            ImagePosition="Left" UseSubmitBehavior="False" AutoPostBack="False" CausesValidation="False">
            <Image Url="~/Estilos/Imagenes/Iconos/Agregar.png" Width="16" Height="16"
                AlternateText="Añadir Nueva Usuario" ToolTip="Añadir Nueva Usuario" />
            <ClientSideEvents Click="function(s, e) { DxcGrVwUsuarios.AddNewRow(); }" />
        </dx:ASPxButton>
    </div>
    <script type="text/javascript">
        function DxcTxtBxContrasena_OnClientValidation(s, e) {
            var validacionLargoPassword = new RegExp("^.{8,100}$");
            var contrasena = s.GetText();

            if (window.DxcGrVwUsuarios.IsNewRowEditing()) {
                e.isValid = validacionLargoPassword.test(contrasena);
            } else {
                e.isValid = contrasena ? validacionLargoPassword.test(contrasena) : true;
            }

            e.errorText = "El campo Contraseña no debe ser menor a 8 ni mayor a 100 caracteres.";
        }
    </script>
    <dx:ASPxGridView runat="server" ID="DxGrVwUsuarios" ClientInstanceName="DxcGrVwUsuarios"
        DataSourceID="ObjUsuariosGoogle" KeyFieldName="Id" AutoGenerateColumns="False"
        OnInitNewRow="DxGrVwUsuarios_OnInitNewRow" OnRowInserting="DxGrVwUsuarios_OnRowInserting"
        OnRowUpdating="DxGrVwUsuarios_OnRowUpdating" OnRowDeleting="DxGrVwUsuarios_OnRowDeleting"
        EnableCallBacks="True" Width="1024px">
        <Settings ShowColumnHeaders="True" ShowTitlePanel="False" ShowFilterRow="True" />
        <SettingsBehavior AllowSort="False" AllowHeaderFilter="False" AllowDragDrop="False" AllowSelectSingleRowOnly="True" ConfirmDelete="True" />
        <SettingsEditing Mode="EditFormAndDisplayRow" NewItemRowPosition="Top" EditFormColumnCount="1" />
        <SettingsDetail ShowDetailRow="False" ShowDetailButtons="False" AllowOnlyOneMasterRowExpanded="False" />
        <SettingsText ConfirmDelete="¿Estas seguro que deseas eliminar este usuario?" />
        <SettingsPager PageSize="15" />
        <SettingsCommandButton>
            <ClearFilterButton Text="Borrar Filtro">
                <Image Url="~/Estilos/Imagenes/Iconos/Borrador.png" ToolTip="Borrar Filtro" AlternateText="Borrar Filtro" />
            </ClearFilterButton>
            <EditButton Text="Editar">
                <Image Url="~/Estilos/Imagenes/Iconos/Editar.gif" ToolTip="Editar Usuario" AlternateText="Editar Usuario" />
            </EditButton>
            <DeleteButton Text="Eliminar">
                <Image Url="~/Estilos/Imagenes/Iconos/Eliminar.gif" ToolTip="Eliminar Usuario" AlternateText="Eliminar Usuario" />
            </DeleteButton>
        </SettingsCommandButton>
        <Columns>
            <dx:GridViewDataTextColumn Name="NombreCompleto" FieldName="NombreCompleto" Caption="Nombre" VisibleIndex="0">
                <Settings AutoFilterCondition="Contains" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
                <CellStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="True" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Name="CorreoElectronico" FieldName="CorreoElectronico" Caption="Correo Electronico" VisibleIndex="1" Width="300px">
                <Settings AutoFilterCondition="Contains" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Name="FechaCreacion" FieldName="FechaCreacion" Caption="Fecha de Creación" VisibleIndex="3" Width="100px">
                <PropertiesDateEdit DisplayFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" NullDisplayText="-" />
                <Settings AllowAutoFilter="False" AllowSort="True" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="CheckedList" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn Name="UltimoAcceso" FieldName="UltimoAcceso" Caption="Ultimo Acceso" VisibleIndex="4" Width="100px">
                <PropertiesDateEdit DisplayFormatString="{0:dd/MM/yyyy hh:mm:ss tt}" NullDisplayText="-" />
                <Settings AllowAutoFilter="False" AllowSort="True" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="CheckedList" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewCommandColumn Caption=" " ButtonRenderMode="Image" ShowClearFilterButton="True" ShowEditButton="True" ShowDeleteButton="True"
                Width="70px" VisibleIndex="5">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn Name="Nombre" FieldName="Nombre" Caption="Nombre" Visible="False" />
            <dx:GridViewDataTextColumn Name="Apellido" FieldName="Apellido" Caption="Apellido" Visible="False" />
        </Columns>
        <Templates>
            <EmptyDataRow>
                No hay usuarios con el criterio seleccionado.
            </EmptyDataRow>
            <EditForm>
                <div style="width: 100%; min-width: 910px; max-width: 1080px;">
                    <h3>
                        <% if (DxGrVwUsuarios.IsNewRowEditing) { %>
                            Añadir Nuevo Usuario
                        <% } else { %>
                            Editar Usuario
                        <% } %>
                    </h3>
                    <table style="width: 100%; border-collapse: separate; border-spacing: 0 5px;">
                        <colgroup>
                            <col style="width: 155px;" />
                            <col style="width: auto; width: calc(100% - 155px);" />
                        </colgroup>
                        <tr>
                            <td>
                                <dx:ASPxLabel runat="server" ID="DxLblNombre" AssociatedControlID="DxTxtBxNombre"
                                    Text="Nombre:">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="DxTxtBxNombre" MaxLength="256" Width="200px"
                                    Text='<%# Eval("Nombre") %>' ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" SetFocusOnError="True"
                                        ValidateOnLeave="True">
                                        <RequiredField IsRequired="True" ErrorText="El campo Nombre es obligatorio." />
                                        <ErrorFrameStyle Wrap="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel runat="server" ID="DxLblApellido" AssociatedControlID="DxTxtBxApellido"
                                    Text="Apellido:">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="DxTxtBxApellido" MaxLength="256" Width="200px"
                                    Text='<%# Eval("Apellido") %>' ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" SetFocusOnError="True"
                                        ValidateOnLeave="True">
                                        <RequiredField IsRequired="True" ErrorText="El campo Apellido es obligatorio." />
                                        <ErrorFrameStyle Wrap="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel runat="server" ID="DxLblCorreoElectronico" AssociatedControlID="DxTxtBxCorreoElectronico"
                                    Text="Correo Electrónico:">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="DxTxtBxCorreoElectronico" MaxLength="256" Width="400px"
                                    Text='<%# Eval("CorreoElectronico") %>' ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>"
                                    OnLoad="DxTxtBxCorreoElectronico_OnLoad">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" SetFocusOnError="True"
                                        ValidateOnLeave="True">
                                        <RegularExpression ValidationExpression="\S+@\S+\.\S+" ErrorText="El campo Correo Electrónico no es correcto." />
                                        <RequiredField IsRequired="True" ErrorText="El campo Correo Electrónico es obligatorio." />
                                        <ErrorFrameStyle Wrap="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel runat="server" ID="DxLblContrasena" AssociatedControlID="DxTxtBxContrasena"
                                    Text="Contraseña:">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="DxTxtBxContrasena" ClientInstanceName="DxcTxtBxContrasena"
                                    MaxLength="100" Width="300px" Password="True" OnLoad="DxTxtBxContrasena_OnLoad"
                                    ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" SetFocusOnError="True"
                                        ValidateOnLeave="True" ErrorText="El campo Contraseña no es correcto.">
                                        <ErrorFrameStyle Wrap="True" />
                                    </ValidationSettings>
                                    <ClientSideEvents Validation="DxcTxtBxContrasena_OnClientValidation"
                                        KeyUp="function(s, e) { s.Validate(); window.DxcTxtBxConfirmarContrasena.Validate(); }" />
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel runat="server" ID="DxLblConfirmarContrasena" AssociatedControlID="DxTxtBxConfirmarContrasena"
                                    Text="Confirmar Contraseña:">
                                </dx:ASPxLabel>
                            </td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="DxTxtBxConfirmarContrasena" ClientInstanceName="DxcTxtBxConfirmarContrasena"
                                    MaxLength="50" Width="300px" Password="True"
                                    ValidationSettings-ValidationGroup="<%# Container.ValidationGroup %>">
                                    <ValidationSettings Display="Dynamic" ErrorDisplayMode="ImageWithText" SetFocusOnError="False"
                                        ValidateOnLeave="True" ErrorText="Las contraseñas no coinciden.">
                                        <ErrorFrameStyle Wrap="True" />
                                    </ValidationSettings>
                                    <ClientSideEvents Validation="function(s, e) { e.isValid = s.GetText() === window.DxcTxtBxContrasena.GetText(); }"
                                        KeyUp="function(s, e) { s.Validate(); }" />
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 100%; padding-top: 5px;">
                        <dx:ASPxButton runat="server" ID="DxBtnActualizar" ClientInstanceName="DxcBtnActualizar"
                            Text="Guardar Cambios" ToolTip="Guardar Cambios"
                            UseSubmitBehavior="False" AutoPostBack="False" CausesValidation="True"
                            ValidationGroup="<%# Container.ValidationGroup %>">
                            <ClientSideEvents Click="function (s, e) { DxcGrVwUsuarios.UpdateEdit(); }" />
                        </dx:ASPxButton>
                        <dx:ASPxButton runat="server" ID="DxBtnCancelar" ClientInstanceName="DxcBtnCancelar"
                            Text="Cancelar" ToolTip="Cancelar"
                            UseSubmitBehavior="False" AutoPostBack="False" CausesValidation="False">
                            <ClientSideEvents Click="function (s, e) { DxcGrVwUsuarios.CancelEdit(); }" />
                        </dx:ASPxButton>
                    </div>
                </div>
            </EditForm>
        </Templates>
        <Styles>
            <Header HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True"></Header>
            <Cell HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
            <AlternatingRow Enabled="True" BackColor="#F5F5F5" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
            <CommandColumn HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
            <EmptyDataRow HorizontalAlign="Center" VerticalAlign="Middle" />
        </Styles>
    </dx:ASPxGridView>
    <asp:ObjectDataSource runat="server" ID="ObjUsuariosGoogle" TypeName="GoogleApiSDKDirectoryEjemplo.Administrar"
        SelectMethod="ObtenerUsuariosComoDataTable" />
</asp:Content>