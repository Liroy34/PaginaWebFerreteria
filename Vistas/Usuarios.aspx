<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Vistas.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server" class="mb-3">

        <div>
            <ul class="nav nav-tabs">
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink1" class="nav-link" runat="server" NavigateUrl="~/Pagina Principal Admin.aspx">Pagina principal</asp:HyperLink>
                </li>
                <li class="nav-item dropdown">
                    <asp:HyperLink ID="HyperLink7" class="nav-link" runat="server" NavigateUrl="~/Productos BM.aspx">Productos</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink8" class="nav-link" runat="server" NavigateUrl="~/Proveedores.aspx">Proveedores</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink9" class="nav-link" runat="server" NavigateUrl="~/Usuarios.aspx">Usuarios</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink10" class="nav-link" runat="server" NavigateUrl="~/Ventas.aspx">Ventas</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink11" class="nav-link" runat="server" NavigateUrl="~/Registrar Admin.aspx">Registrar Administrador</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink12" class="nav-link" runat="server" NavigateUrl="~/Provincias.aspx">Provincias</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink2" class="nav-link" runat="server" NavigateUrl="~/Tipos de Producto.aspx">Tipos de Producto</asp:HyperLink>
                </li>
                <li class="nav-item">
                    <asp:Label ID="lblNombre" class="nav-link" runat="server" Text=""></asp:Label>
                </li>
                <li class="nav-item">
                    <asp:LinkButton ID="LinkButton1" class="nav-link" runat="server" OnClick="LinkButton1_Click">Cerrar Session</asp:LinkButton>
                </li>

            </ul>
        </div>

        <div>
            <asp:Label ID="lblVentas" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Usuarios"></asp:Label>
            <br />
            <div class="row">
                <div class="col-2">
                    Buscar por id:
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtUsuarioId" class="form-control form-control-sm" runat="server" TextMode="Number" OnTextChanged="txtUsuarioId_TextChanged"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Button ID="txtBuscar" class="btn btn-primary" runat="server" OnClick="txtBuscar_Click" Text="Buscar" />
                </div>
                <div class="col-2">
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="btnMostrarTodos_Click" Text="Mostrar todos" />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-2">
                    Buscar por Nombre:
                </div>
                <div class="col-4">
                    <asp:TextBox ID="tbUsuarioNombre" class="form-control form-control-sm" runat="server" OnTextChanged="tbUsuarioNombre_TextChanged"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnBuscarNombre" class="btn btn-primary" runat="server" OnClick="btnBuscarNombre_Click" Text="Buscar" />
                </div>
            </div>
            <br />
            <br />
            <asp:GridView ID="grvUsuarios" class="table table-striped table-hover" runat="server" AutoGenerateEditButton="True" AutoGenerateColumns="False"  OnRowCancelingEdit="grvUsuarios_RowCancelingEdit" OnRowEditing="grvUsuarios_RowEditing" OnRowUpdating="grvUsuarios_RowUpdating" AllowPaging="True" OnPageIndexChanging="grvUsuarios_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="ID Usuario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_it_IdUsuario" runat="server" Text='<%# Bind("Id_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre de Usuario">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtNombre_Eit_Us" runat="server" Text='<%# Bind("Nombre_Usuario_U") %>' MaxLength="25"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblNombre_it_Us" runat="server" Text='<%# Bind("Nombre_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contraseña">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtContraseña_Eit_Us" runat="server" Text='<%# Bind("Contraseña_Usuario_U") %>' MaxLength="20"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblContraseña_it_Us" runat="server" Text='<%# Bind("Contraseña_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate>
                            <asp:Label ID="LblDNI_it_Us" runat="server" Text='<%# Bind("DNI_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mail">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtMail_Eit_Us" runat="server" Text='<%# Bind("Mail_Usuario_U") %>' TextMode="Email"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblMail_it_Us" runat="server" Text='<%# Bind("Mail_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtTelefono_Eit_Us" runat="server" Text='<%# Bind("Telefono_Usuario_U") %>' MaxLength="15" TextMode="Number"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblTelefono_it_Us" runat="server" Text='<%# Bind("Telefono_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtDireccion_Eit_Us" runat="server" Text='<%# Bind("Direccion_Usuario_U") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblDireccion_it_Us" runat="server" Text='<%# Bind("Direccion_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ciudad">
                        <EditItemTemplate>
                            <asp:TextBox ID="TxtCiudad_Eit_Us" runat="server" Text='<%# Bind("Ciudad_Usuario_U") %>' MaxLength="20"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblCiudad_it_Us" runat="server" Text='<%# Bind("Ciudad_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DdlProvincias_Eit_Us" runat="server" DataSourceID="SqlDataSource1" DataTextField="Descripcion_Provincia_Pr" DataValueField="Id_Provincia_Pr" Width="154px">
                            </asp:DropDownList>
                            <br />
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString5 %>" SelectCommand="SELECT [Descripcion_Provincia_Pr], [Id_Provincia_Pr] FROM [Provincias]"></asp:SqlDataSource>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblProvincia_it_Us" runat="server" Text='<%# Bind("Descripcion_Provincia_Pr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <EditItemTemplate>
                            <asp:CheckBox ID="chbEstado_Eit_Us" runat="server" Checked='<%# Bind("Estado_Usuario_U") %>' />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="LblEstado_it_Us" runat="server" Text='<%# Bind("Estado_Usuario_U") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:HyperLink ID="hlCliente" runat="server" NavigateUrl="~/Registrar Admin.aspx">Registrar Administrador</asp:HyperLink>
        </div>
        <br />
                <div>
                    <asp:Label ID="lblMensaje" class="alert alert-light" runat="server"></asp:Label>
                    <br />
                </div>
    </form>
        </div>
</body>
</html>
