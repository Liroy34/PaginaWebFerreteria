<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar Admin.aspx.cs" Inherits="Vistas.Registrar_Admin" %>

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

                <asp:Label ID="lblRegistrarAdmin" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Registrar Administrador"></asp:Label>
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td>Nombre:</td>
                        <td>
                            <asp:TextBox ID="txtNombre" class="form-control form-control-sm" runat="server" MaxLength="20" ValidationGroup="Grupo1"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ValidationGroup="Grupo1">Ingrese un nombre</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Dirección</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtDirecc" class="form-control form-control-sm" runat="server" ValidationGroup="Grupo1"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDirecc" ValidationGroup="Grupo1">Ingrese una Direccion</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">Ciudad:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtCiudad" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                        <td class="auto-style5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCiudad" ValidationGroup="Grupo1">ingrese una ciudad</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Provincia:</td>
                        <td>
                            <asp:DropDownList ID="ddlProvincias" class="btn btn-outline-secondary dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProvincias" ValidationGroup="Grupo1">seleccione una provincia</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">DNI:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="txtDNI" class="form-control form-control-sm" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </td>
                        <td class="auto-style5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDNI" ValidationGroup="Grupo1">ingrese su dni</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style4">Telefono:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtTelefono" class="form-control form-control-sm" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtTelefono" ValidationGroup="Grupo1">ingrese su telefono</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Mail:</td>
                        <td>
                            <asp:TextBox ID="txtMail" class="form-control form-control-sm" runat="server" TextMode="Email" MaxLength="30"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtMail" ValidationGroup="Grupo1">ingrese su email</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Contraseña:</td>
                        <td>
                            <asp:TextBox ID="txtContrasenia" class="form-control form-control-sm" runat="server" OnTextChanged="TextBox8_TextChanged" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtContrasenia" ValidationGroup="Grupo1">ingrese contraseña</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Confitmar contraseña: </td>
                        <td>
                        <asp:TextBox ID="TxtConfirmarContraseña" class="form-control form-control-sm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                        <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContrasenia" ControlToValidate="TxtConfirmarContraseña" ErrorMessage="CompareValidator" ValidationGroup="Grupo1">Debe ingresar la misma contraseña</asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtConfirmarContraseña" ValidationGroup="Grupo1">Complete con la contraseña</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td class="auto-style1">
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="Grupo1" />
                        </td>
                        <td class="auto-style1"></td>
                    </tr>

                </table>
                <br />
                <div>
                    <asp:Label ID="lblMensaje" class="alert alert-light" runat="server"></asp:Label>
                    <br />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
