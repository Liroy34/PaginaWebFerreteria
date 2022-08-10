<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar Usuario.aspx.cs" Inherits="Vistas.Registrar_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</head>
<body>
    <div class="container">
    <form id="form1" runat="server" class="mb-3">
         <div>

           <ul class="nav nav-tabs">
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink1" class="nav-link" runat="server" NavigateUrl="~/Pagina Principal.aspx">Pagina principal</asp:HyperLink>
                </li>                
            </ul>
        </div>
        <div>
            <asp:Label ID="lblRegistrarUser" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Registrarse"></asp:Label>
              
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">Nombre:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TxtNombre" class="form-control form-control-sm" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="rfdNombre" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtNombre" ValidationGroup="Grupo1">Complete con el nombre</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Dirección</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TxtDireccion" class="form-control form-control-sm" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtDireccion" ValidationGroup="Grupo1">Complete con la direccion</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad:</td>
                    <td>
                        <asp:TextBox ID="TxtCiudad" class="form-control form-control-sm" runat="server" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtCiudad" ValidationGroup="Grupo1">Complete con la ciudad</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Provincia:</td>
                    <td>
                        <asp:DropDownList ID="DdlProvincias" class="btn btn-outline-secondary dropdown-toggle" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlProvincias" ValidationGroup="Grupo1">Debe seleccionar una provincia</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">DNI:</td>
                    <td class="auto-style4">
                        <asp:TextBox ID="TxtDNI" class="form-control form-control-sm" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                    </td>
                    <td class="auto-style4">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtDNI" ValidationGroup="Grupo1">Complete con el DNI</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Telefono:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TxtTelefono" class="form-control form-control-sm" runat="server" MaxLength="15"></asp:TextBox>
                    </td>
                    <td class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtTelefono" ValidationGroup="Grupo1">Complete con el telefono</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Mail:</td>
                    <td>
                        <asp:TextBox ID="TxtMail" class="form-control form-control-sm" runat="server" MaxLength="30" TextMode="Email"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TxtMail" ValidationGroup="Grupo1">Ingrese un mail valido</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="TxtContraseña" class="form-control form-control-sm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtContraseña" ValidationGroup="Grupo1">Complete con la contraseña</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Confirmar Contraseña</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TxtConfirmarContraseña" class="form-control form-control-sm" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
                        </td>
                    <td class="auto-style2">
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtContraseña" ControlToValidate="TxtConfirmarContraseña" ErrorMessage="CompareValidator" ValidationGroup="Grupo1">Debe ingresar la misma contraseña</asp:CompareValidator>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TxtConfirmarContraseña" ErrorMessage="RequiredFieldValidator" ValidationGroup="Grupo1">Complete con la contraseña</asp:RequiredFieldValidator>
                        </td>
                </tr>
           
                <tr>
                    <td class="auto-style1"></td>
                    <td>
                        <asp:Button ID="BtnRegistrarse" class="btn btn-primary" runat="server" Text="Registrarse" OnClick="Button1_Click" ValidationGroup="Grupo1" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                        
                    </td>
                </tr>

            </table>
            <asp:Label ID="LblMensaje" class="alert alert-light" runat="server" Text=""></asp:Label>
        </div>
    </form>
        </div>
</body>
</html>
