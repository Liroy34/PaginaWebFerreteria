<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificar Datos.aspx.cs" Inherits="Vistas.Modificar_Datos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>

    <style type="text/css">
        .auto-style1 {
            margin-left: 37;
        }
    </style>

</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="mb-3">

            <div>
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <asp:HyperLink ID="HyperLink" class="nav-link" runat="server" NavigateUrl="~/Pagina Principal Sesion Iniciada.aspx">Pagina principal</asp:HyperLink>
                    </li>
                    <li class="nav-item">
                        <asp:HyperLink ID="Editar_Perfil" class="nav-link" runat="server" NavigateUrl="~/Modificar Datos.aspx">Editar Perfil</asp:HyperLink>
                    </li>
                    <li class="nav-item align-center">
                        <asp:Label ID="lblNombre" class="alert alert-info " runat="server" Text=""></asp:Label>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="LinkButton1" class="nav-link" runat="server" OnClick="LinkButton1_Click">Cerrar Session</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div>
                <asp:Label ID="lblEditarPerfil" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Editar Perfil"></asp:Label>

                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">Nombre:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtNombre" class="form-control form-control-sm" runat="server" MaxLength="25"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfdNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Complete con el nombre</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style6">Direccion:</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="txtDireccion" class="form-control form-control-sm" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfdDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage=" " ForeColor="Red">Complete con la direccion</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Ciudad:</td>
                        <td>
                            <asp:TextBox ID="txtCiudad" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfdCiudad" runat="server" ControlToValidate="txtCiudad" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Complete con la ciudad</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Provincia:</td>
                        <td>
                            <asp:DropDownList ID="ddlProvincia" class="btn btn-outline-secondary dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">DNI:</td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtDNI" class="form-control form-control-sm" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="rgfvDNI" runat="server" ControlToValidate="txtDNI" EnableTheming="True" ForeColor="Red" ValidationExpression="^\d+$">SE ENCONTRO ALGUN CARACTER INVALIDO</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Telefono:</td>
                        <td class="auto-style16">
                            <asp:TextBox ID="txtTelefono" class="form-control form-control-sm" runat="server" MaxLength="15" TextMode="Phone"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfdTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Complete con el telefono</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">Mail:</td>
                        <td class="auto-style13">
                            <asp:TextBox ID="txtMail" class="form-control form-control-sm" runat="server" MaxLength="30" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="frdMail" runat="server" ControlToValidate="txtMail" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Complete con el mail</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style14">Contraseña:</td>
                        <td class="auto-style16">
                            <asp:TextBox ID="txtContraseña" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfdContrasenia" runat="server" ControlToValidate="txtContraseña" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Complete con la contraseña</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">Confirmar Contraseña:</td>
                        <td>
                            <asp:TextBox ID="txtConContr" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                            <asp:CompareValidator ID="cvContr" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtConContr" ForeColor="Red">LAS CONTRASEÑAS NO COINCIDEN</asp:CompareValidator>
                            <asp:RequiredFieldValidator ID="rfvConfContr" runat="server" ControlToValidate="txtConContr" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7"></td>
                        <td>
                            <asp:Button ID="btnEditar" class="btn btn-primary" runat="server"  OnClick="btnEditar_Click" Text="Editar" Width="49px"  />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnConfirmar" runat="server" CssClass="auto-style1" Enabled="False" OnClick="btnConfirmar_Click" Width="85px" Text="Confirmar" Visible="False" />
                        </td>
                    </tr>
                </table>
            </div>
            
            <p>
                <asp:Label ID="lblModifico" runat="server"></asp:Label>
            </p>
        </form>
    </div>
</body>
</html>
