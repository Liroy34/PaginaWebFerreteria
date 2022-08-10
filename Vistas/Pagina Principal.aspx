<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagina Principal.aspx.cs" Inherits="Vistas.Pagina_Principal" %>

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
        <form id="form1" class="mb-3" runat="server">
            <div>
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <asp:HyperLink ID="IniciarSesionPP" class="nav-link" runat="server" NavigateUrl="~/Iniciar Sesion.aspx">Iniciar Sesion</asp:HyperLink>
                    </li>
                    <li class="nav-item dropdown">
                        <asp:HyperLink ID="HyperLink2" class="nav-link" runat="server" NavigateUrl="~/Registrar Usuario.aspx">Registrarse</asp:HyperLink>
                    </li>
                </ul>
            </div>


            <div>
                <table class="col-12">
                    <tr>
                        <td class="auto-style4">
                            <asp:Label ID="lblTituloSeleccion" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Pagina Principal"></asp:Label>
                        </td>
                        <td class="auto-style5"></td>
                    </tr>
                    <tr>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style9"></td>
                        <td>
                            <div class="row">
                                <div class="col-3">
                                    <asp:TextBox ID="txtFiltrar" class="form-control form-control-sm" runat="server" OnTextChanged="txtFiltrar_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-2">
                                    <asp:Button ID="btnFiltrar" class="btn btn-primary" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                                </div>

                                <div class="col-2">
                                    Ordenar por precio
                                </div>
                                <div class="col-4">
                                    <asp:Button ID="btnAscendente" class="btn btn-primary" runat="server" OnClick="btnAscendente_Click" Text="Ascendente" />

                                    <asp:Button ID="btnDescendente" runat="server" class="btn btn-primary" OnClick="btnDescendente_Click" Text="Descendente" />
                                </div>

                            </div>
                            <asp:Label ID="lblFiltrado" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
                <br />
                <table>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style3 align-text-top">
                        <div class="list-group">
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString %>" SelectCommand="SELECT * FROM [Tipo_Producto] WHERE ([Estado_Tipo_Producto_T] = @Estado_Tipo_Producto_T)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="true" Name="Estado_Tipo_Producto_T" Type="Boolean" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <asp:DataList ID="dlFiltroXTipo" runat="server" DataKeyField="Id_Tipo_Producto_T" DataSourceID="SqlDataSource2" CssClass="auto-style6" Width="284px">
                                <ItemTemplate>
                                    <asp:Button ID="btnFiltroXTipo" class="list-group-item list-group-item-action text-center" runat="server" Height="50px" Text='<%# Eval("Descripcion_Tipo_Producto_T") %>' Width="200px" CommandName="eventoFiltrar" CommandArgument='<%# Eval("Id_Tipo_Producto_T") %>' OnCommand="btnFiltroXTipo_Command" />
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                    <td class="auto-style7">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TI_FERRETERIASConnectionString %>" SelectCommand="SELECT * FROM [Productos] WHERE (([Stock_Producto_P] &gt; @Stock_Producto_P) AND ([Estado_P] = @Estado_P))">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="Stock_Producto_P" Type="Int32" />
                                <asp:Parameter DefaultValue="true" Name="Estado_P" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:ListView ID="lvProductos" runat="server" DataKeyNames="Id_Producto_P" DataSourceID="SqlDataSource1" GroupItemCount="4">
                            <%--                            <AlternatingItemTemplate>
                               <td runat="server" style="background-color:#FFF8DC;">Id_Producto_P:
                                    <asp:Label ID="Id_Producto_PLabel" runat="server" Text='<%# Eval("Id_Producto_P") %>' />
                                    <br />Descripcion_Producto_P:
                                    <asp:Label ID="Descripcion_Producto_PLabel" runat="server" Text='<%# Eval("Descripcion_Producto_P") %>' />
                                    <br />Precio_Unitario_P:
                                    <asp:Label ID="Precio_Unitario_PLabel" runat="server" Text='<%# Eval("Precio_Unitario_P") %>' />
                                    <br />Nombre_Producto_P:
                                    <asp:Label ID="Nombre_Producto_PLabel" runat="server" Text='<%# Eval("Nombre_Producto_P") %>' />
                                    <br />Imagen_Producto_P:
                                    <asp:Label ID="Imagen_Producto_PLabel" runat="server" Text='<%# Eval("Imagen_Producto_P") %>' />
                                    <br />Stock_Producto_P:
                                    <asp:Label ID="Stock_Producto_PLabel" runat="server" Text='<%# Eval("Stock_Producto_P") %>' />
                                    <br /></td>
                            </AlternatingItemTemplate>--%>
                            <EditItemTemplate>
                                <td runat="server" style="background-color: #008A8C; color: #FFFFFF;">Id_Producto_P:
                                    <asp:Label ID="Id_Producto_PLabel1" runat="server" Text='<%# Eval("Id_Producto_P") %>' />
                                    <br />
                                    Descripcion_Producto_P:
                                    <asp:TextBox ID="Descripcion_Producto_PTextBox" runat="server" Text='<%# Bind("Descripcion_Producto_P") %>' />
                                    <br />
                                    Precio_Unitario_P:
                                    <asp:TextBox ID="Precio_Unitario_PTextBox" runat="server" Text='<%# Bind("Precio_Unitario_P") %>' />
                                    <br />
                                    Nombre_Producto_P:
                                    <asp:TextBox ID="Nombre_Producto_PTextBox" runat="server" Text='<%# Bind("Nombre_Producto_P") %>' />
                                    <br />
                                    Imagen_Producto_P:
                                    <asp:TextBox ID="Imagen_Producto_PTextBox" runat="server" Text='<%# Bind("Imagen_Producto_P") %>' />
                                    <br />
                                    Stock_Producto_P:
                                    <asp:TextBox ID="Stock_Producto_PTextBox" runat="server" Text='<%# Bind("Stock_Producto_P") %>' />
                                    <br />
                                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                                    <br />
                                </td>
                            </EditItemTemplate>
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>
                            <InsertItemTemplate>
                                <td runat="server" style="">Descripcion_Producto_P:
                                    <asp:TextBox ID="Descripcion_Producto_PTextBox" runat="server" Text='<%# Bind("Descripcion_Producto_P") %>' />
                                    <br />
                                    Precio_Unitario_P:
                                    <asp:TextBox ID="Precio_Unitario_PTextBox" runat="server" Text='<%# Bind("Precio_Unitario_P") %>' />
                                    <br />
                                    Nombre_Producto_P:
                                    <asp:TextBox ID="Nombre_Producto_PTextBox" runat="server" Text='<%# Bind("Nombre_Producto_P") %>' />
                                    <br />
                                    Imagen_Producto_P:
                                    <asp:TextBox ID="Imagen_Producto_PTextBox" runat="server" Text='<%# Bind("Imagen_Producto_P") %>' />
                                    <br />
                                    Stock_Producto_P:
                                    <asp:TextBox ID="Stock_Producto_PTextBox" runat="server" Text='<%# Bind("Stock_Producto_P") %>' />
                                    <br />
                                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                                    <br />
                                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                                    <br />
                                </td>
                            </InsertItemTemplate>
                            <ItemTemplate>

                                <td runat="server">
                                    <div class="card bg-light mb-3 " style="max-width: 18rem;">

                                        <div class="card-body ">
                                            <h5>
                                                <asp:Label ID="Nombre_Producto_PLabel" class="card-title" runat="server" Text='<%# Eval("Nombre_Producto_P") %>' />
                                            </h5>
                                            <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageUrl='<%# Eval("Imagen_Producto_P") %>' Width="200px" />
                                            <br />
                                            <p class="card-text">
                                                <asp:Label ID="Descripcion_Producto_PLabel" runat="server" Text='<%# Eval("Descripcion_Producto_P") %>' Height="75px" Width="200px" />
                                            </p>
                                            <br />
                                            Precio: $<asp:Label ID="Precio_Unitario_PLabel" runat="server" Text='<%# Eval("Precio_Unitario_P") %>' />
                                            <br />
                                            <br />

                                        </div>
                                    </div>
                                </td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server">
                                            <asp:DataPager ID="DataPager1" class="pagination" runat="server" PageSize="6">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td runat="server" style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">Id_Producto_P:
                                    <asp:Label ID="Id_Producto_PLabel" runat="server" Text='<%# Eval("Id_Producto_P") %>' />
                                    <br />
                                    Descripcion_Producto_P:
                                    <asp:Label ID="Descripcion_Producto_PLabel" runat="server" Text='<%# Eval("Descripcion_Producto_P") %>' />
                                    <br />
                                    Precio_Unitario_P:
                                    <asp:Label ID="Precio_Unitario_PLabel" runat="server" Text='<%# Eval("Precio_Unitario_P") %>' />
                                    <br />
                                    Nombre_Producto_P:
                                    <asp:Label ID="Nombre_Producto_PLabel" runat="server" Text='<%# Eval("Nombre_Producto_P") %>' />
                                    <br />
                                    Imagen_Producto_P:
                                    <asp:Label ID="Imagen_Producto_PLabel" runat="server" Text='<%# Eval("Imagen_Producto_P") %>' />
                                    <br />
                                    Stock_Producto_P:
                                    <asp:Label ID="Stock_Producto_PLabel" runat="server" Text='<%# Eval("Stock_Producto_P") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                        <br />
                        
                    </td>

                    
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </table>
            </div>
        </form>
        </div>
</body>
</html>