<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar proveedor.aspx.cs" Inherits="Vistas.Agregar_proveedor" %>

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
                <asp:Label ID="lblAgregarProveedor" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Agregar Proveedor"></asp:Label>
                <br />
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style4">Nombre Proveedor:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="TxtNombrePr" class="form-control form-control-sm" runat="server" MaxLength="25"></asp:TextBox>
                        </td>
                        <td class="auto-style4">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombrePr">Complete el campo Nombre Proveedor</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Dirección Proveedor:</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="TxtDireccionPr" class="form-control form-control-sm" runat="server" MaxLength="11"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDireccionPr">Complete el campo Direccion Proveedor</asp:RequiredFieldValidator>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Ciudad Proveedor:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TxtCiudadPr" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtCiudadPr">Complete el campo Ciudad Proveedor</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Provincia Proveedor:</td>
                        <td class="auto-style3">
                            <asp:DropDownList ID="DdlProvincia" class="btn btn-outline-secondary dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DdlProvincia">Complete el campo</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">CUIT Proveedor:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TxtCUITPr" class="form-control form-control-sm" runat="server" MaxLength="11" TextMode="Number"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtCUITPr">Complete el campo CUIT Proveedor</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Telefono Proveedor:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TxtTelPr" class="form-control form-control-sm" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtTelPr">Complete el campo Telefono Proveedor</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Mail Proveedor:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="TxtMailPr" class="form-control form-control-sm" runat="server" TextMode="Email" MaxLength="30"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtTelPr">Complete el campo Mail Proveedor</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Agregar" OnClick="Button1_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <div>
                    <asp:Label ID="LblMensaje" class="alert alert-light" role="alert" runat="server"></asp:Label>
                    <br />
                </div>
            </div>
        </form>
        </div>
</body>
</html>
