<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar productos.aspx.cs" Inherits="Vistas.Agregar_productos" %>

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
            <div class="col-auto">
                <asp:Label ID="lblAgregarProductos" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Agregar Producto"></asp:Label>
                <br />
                <br />
                <br />
                <table class="auto-style1">
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Nombre producto:</td>
                        <td>
                            <asp:TextBox ID="tbNombre" class="form-control form-control-sm" runat="server" OnTextChanged="tbNombre_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese un nombre" ControlToValidate="tbNombre" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Descripción producto:</td>
                        <td class="auto-style2">
                            <asp:TextBox ID="tbDescripcion" class="form-control form-control-sm" runat="server"></asp:TextBox>
                        </td>
                        <td class="auto-style2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese una descripcion" ControlToValidate="tbDescripcion" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">Cuit proveedor:</td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="ddlProveedor" runat="server" DataSourceID="SqlDataSource1" DataTextField="CUIT_Proveedor_Prov" DataValueField="Id_Proveedor_Prov">
                                <asp:ListItem Value="0">-----Seleccione un CUIT-----</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="auto-style2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>Precio unitario:</td>
                        <td>
                            <asp:TextBox ID="tbPrecio" class="form-control form-control-sm" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Ingrese un precio" ControlToValidate="tbPrecio" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbPrecio" ErrorMessage="Ingrese un numero valido" ValidationExpression="(?&lt;=^| )\d+(\.\d+)?(?=$| )" ValidationGroup="Grupo1"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>Tipo Producto:</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoProducto" class="btn btn-outline-secondary dropdown-toggle" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Seleccione un tipo de Producto" ControlToValidate="ddlTipoProducto" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Stock producto:</td>
                        <td>
                            <asp:TextBox ID="tbStock" class="form-control form-control-sm" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ingrese una cantidad" ControlToValidate="tbStock" ValidationGroup="Grupo1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Dirección de imagen producto:</td>
                        <td>
                            <asp:FileUpload ID="fuImagen" class="btn btn-outline-secondary" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString %>" SelectCommand="SELECT [CUIT_Proveedor_Prov], [Id_Proveedor_Prov], [Estado_Proveedor_Prov] FROM [Proveedores] WHERE ([Estado_Proveedor_Prov] = @Estado_Proveedor_Prov)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="true" Name="Estado_Proveedor_Prov" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregar" class="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ValidationGroup="Grupo1" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </div>
            <br />
            <div>
                <asp:Label ID="lblMensaje"  role="alert" runat="server"  ></asp:Label>
                <br />
            </div>

        </form>
    </div>

</body>
</html>
