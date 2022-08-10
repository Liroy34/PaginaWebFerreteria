<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina Principal Admin.aspx.cs" Inherits="Vistas.Pagina_Principal_Admin" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
       <title></title>
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
            <div class="row">
                <asp:Label ID="lblTituloSeleccion" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Pagina Principal"></asp:Label>
                <br />
                <br />
                <br />
                <table class="w-100">
                    <tr>
                        <td class="auto-style14">
                            &nbsp;</td>
                        <td class="auto-style8">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="DdlAño" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlAño_SelectedIndexChanged">
                                <asp:ListItem>2022</asp:ListItem>
                                <asp:ListItem>2021</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DdlMes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlMes_SelectedIndexChanged">
                                <asp:ListItem Value="31/01">Enero</asp:ListItem>
                                <asp:ListItem Value="28/02">Febrero</asp:ListItem>
                                <asp:ListItem Value="31/03">Marzo</asp:ListItem>
                                <asp:ListItem Value="30/04">Abril</asp:ListItem>
                                <asp:ListItem Value="31/05">Mayo</asp:ListItem>
                                <asp:ListItem Value="30/06">Junio</asp:ListItem>
                                <asp:ListItem Value="31/07">Julio</asp:ListItem>
                                <asp:ListItem Value="31/08">Agosto</asp:ListItem>
                                <asp:ListItem Value="30/09">Septiembre</asp:ListItem>
                                <asp:ListItem Value="31/10">Octubre</asp:ListItem>
                                <asp:ListItem Value="30/11">Noviembre</asp:ListItem>
                                <asp:ListItem Value="31/12">Diciembre</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DdlFiltro" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlFiltro_SelectedIndexChanged">
                                <asp:ListItem Value="Id_Producto_P">ID</asp:ListItem>
                                <asp:ListItem Value="Cantidad_Vendida DESC">Mas Vendido</asp:ListItem>
                                <asp:ListItem Value="Cantidad_Vendida ASC">Menos Vendido</asp:ListItem>
                                <asp:ListItem Value="Nombre_Producto_P ASC">ABC</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:GridView ID="GrvVentas" runat="server" AutoGenerateColumns="False" CellPadding="3" CssClass="auto-style16" ForeColor="#333333" GridLines="None" Width="379px" AllowPaging="True" OnPageIndexChanging="GrvVentas_PageIndexChanging" PageSize="5">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="LblID_it_Pr" runat="server" Text='<%# Bind("Id_Producto_P") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNombreProducto" runat="server" Text='<%# Bind("Nombre_Producto_P") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cantidad Vendida">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCV_it_Pr" runat="server" Text='<%# Bind("Cantidad_Vendida") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Recaudado">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTotalRecaudado" runat="server" Text='<%# Bind("TOTAL") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                            <br />
                        </td>
                        <td class="auto-style12">
                            </td>
                        <td class="auto-style13">
                            <br />
                            Ranking Clientes&nbsp;
                            <asp:DropDownList ID="DdlTop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlTop_SelectedIndexChanged">
                                <asp:ListItem Value="3">Top 3</asp:ListItem>
                                <asp:ListItem Value="5">Top 5</asp:ListItem>
                                <asp:ListItem Value="10">Top 10</asp:ListItem>
                                <asp:ListItem Value="25">Top 25</asp:ListItem>
                            </asp:DropDownList>
                            <asp:GridView ID="GrvClientes" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="1">
                                <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <Columns>
                                    <asp:TemplateField HeaderText="DNI">
                                        <ItemTemplate>
                                            <asp:Label ID="Label8" runat="server" Text='<%# Bind("DNI_Usuario_U") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre_Usuario_U") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gastos">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("GASTO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />
                            </asp:GridView>
                        </td>
                        <td class="auto-style10">
                            <br />
                            INGRESOS ANUALES<br />
                            <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1">
                                <series>
                                    <asp:Series ChartType="Line" Name="Series1" XValueMember="Column1" YValueMembers="TOTAL AÑO">
                                    </asp:Series>
                                </series>
                                <chartareas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </chartareas>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString %>" SelectCommand="SELECT sum(Precio_Unitario_DV*Cantidad_DV) AS [TOTAL AÑO],YEAR(Fecha_V)
From Detalle_De_Venta INNER JOIN Ventas ON Num_Factura_DV=Num_Factura_V
GROUP BY YEAR(Fecha_V)"></asp:SqlDataSource>
                            <br />
                        </td>
                        <td class="auto-style11">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">
                            &nbsp;</td>
                        <td class="auto-style1">
                            &nbsp;</td>
                        <td class="auto-style6">
                            &nbsp;</td>
                        <td class="auto-style5">
                            &nbsp;</td>
                        <td class="auto-style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style14">&nbsp;</td>
                        <td class="auto-style8">&nbsp;&nbsp;&nbsp;&nbsp; PRODUCTOS CON STOCK MENOR A 100<br />
                            &nbsp;&nbsp;
                            <asp:GridView ID="GrvProductosStock" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="393px" AllowPaging="True" OnPageIndexChanging="GrvProductosStock_PageIndexChanging" PageSize="5">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("Id_Producto_P") %>'></asp:Label>
                                            <br />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Nombre_Producto_P") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripcion Producto">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("Descripcion_Producto_P") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" runat="server" Text='<%# Bind("Stock_Producto_P") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                            <br />
                        </td>
                        <td class="auto-style9"></td>
                        <td class="auto-style8"></td>
                        <td class="auto-style10">PROVINCIAS DE USUARIOS<br />
                            <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
                                <series>
                                    <asp:Series Name="Series1" XValueMember="Descripcion_Provincia_Pr" YValueMembers="CANTIDAD">
                                    </asp:Series>
                                </series>
                                <chartareas>
                                    <asp:ChartArea Name="ChartArea1">
                                    </asp:ChartArea>
                                </chartareas>
                            </asp:Chart>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString %>" SelectCommand="SELECT Descripcion_Provincia_Pr,count(Descripcion_Provincia_Pr) AS CANTIDAD
FROM Usuarios INNER JOIN Provincias ON Id_Provincia_U=Id_Provincia_Pr 
GROUP BY Descripcion_Provincia_Pr"></asp:SqlDataSource>
                            <br />
                            <br />
                        </td>
                        <td class="auto-style11">
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style7">&nbsp;</td>
                        <td class="auto-style1">&nbsp;</td>
                        <td class="auto-style4">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </form>
    </div>
</body>
</html>
