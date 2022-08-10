<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Vistas.Ventas" %>

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
            <asp:Label ID="lblVentas" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Ventas"></asp:Label>
            <br />
            <br />
            <br />
            <asp:GridView ID="grvVentas" class="table table-striped table-hover"  runat="server" OnRowCommand="grvVentas_RowCommand" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grvVentas_PageIndexChanging" PageSize="5">
                <Columns>
                    <asp:ButtonField Text="Detalle de Venta" CommandName="eventoDetalle" />
                    <asp:TemplateField HeaderText="Número de factura">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Num_Factura_V" runat="server" Text='<%# Bind("Num_Factura_V") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID Usuario">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Id_Usuario_V" runat="server" Text='<%# Bind("Id_Usuario_V") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Fecha_V" runat="server" Text='<%# Bind("Fecha_V") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Monto total">
                        <ItemTemplate>
                            <asp:Label ID="lbl_Monto_Total_V" runat="server" Text='<%# Bind("Monto_Total_V") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
        </div>
</body>
</html>
