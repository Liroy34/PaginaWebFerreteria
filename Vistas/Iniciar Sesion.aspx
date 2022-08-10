<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Iniciar Sesion.aspx.cs" Inherits="Vistas.Iniciar_Sesion" %>

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
          <div>

           <ul class="nav nav-tabs">
                <li class="nav-item">
                    <asp:HyperLink ID="HyperLink1" class="nav-link" runat="server" NavigateUrl="~/Pagina Principal.aspx">Pagina principal</asp:HyperLink>
                </li>                
            </ul>
        </div>
    <form id="form1" runat="server" class="mb-3">
        <asp:Label ID="lblIniciarSesion" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Iniciar Sesion"></asp:Label>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Usuario: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Contraseña: "></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="tbContrasenia" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div>
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Ingresar" />
                    <br />
                    <asp:RequiredFieldValidator ID="rfdUsuario" runat="server" ControlToValidate="tbUsuario" ErrorMessage="RequiredFieldValidator">Complete el nombre de usuario</asp:RequiredFieldValidator>
                    <br />
                    <asp:RequiredFieldValidator ID="rfdContrasenia" runat="server" ControlToValidate="tbContrasenia" ErrorMessage="RequiredFieldValidator">Complete la contraseña</asp:RequiredFieldValidator>
                <table class="auto-style1">
                    <tr>
                        <td>
                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Registrar Usuario.aspx">Registrarse</asp:HyperLink>
                        </td>
                    </tr>
            </table>
        </div>
    </form>
         </div>
     <p>
         <asp:Label ID="lblMensaje" runat="server"></asp:Label>
     </p>
</body>
</html>
