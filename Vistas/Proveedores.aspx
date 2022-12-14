<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="Vistas.Proveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" />
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
                <asp:Label ID="lblProveedores" runat="server" Font-Bold="True" Font-Size="XX-Large" Font-Underline="True" Text="Proveedores"></asp:Label>
            </div>
            <br />
            <div class="row">
                <div class="col-2">
                    Buscar por id:
                </div>
                <div class="col-4">
                    <asp:TextBox ID="txtProveedor" class="form-control form-control-sm" runat="server" OnTextChanged="txtProveedor_TextChanged" TextMode="Number"></asp:TextBox>
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
                    <asp:TextBox ID="tbBuscarNombre" class="form-control form-control-sm" runat="server" OnTextChanged="txtProveedor_TextChanged"></asp:TextBox>
                </div>
                <div class="col-2">
                    <asp:Button ID="btnBuscarNombre" class="btn btn-primary" runat="server" OnClick="btnBuscarNombre_Click" Text="Buscar" />
                </div>
            </div>
            <br />
            <div>

                <br />
                <asp:GridView ID="grvProveedores" class="table table-striped table-hover" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" OnRowCancelingEdit="grvProveedores_RowCancelingEdit" OnRowDeleting="grvProveedores_RowDeleting" OnRowEditing="grvProveedores_RowEditing" OnRowUpdating="grvProveedores_RowUpdating" AllowPaging="True" OnPageIndexChanging="grvProveedores_PageIndexChanging" PageSize="5">
                    <Columns>
                        <asp:TemplateField HeaderText="Id Proveedor">
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_IdProveedor" runat="server" Text='<%# Bind("Id_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CUIT ">
                            <EditItemTemplate>
                                <asp:Label ID="lbl_edt_CUIT" runat="server" Text='<%# Bind("CUIT_Proveedor_Prov") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_CUITProveedor" runat="server" Text='<%# Bind("CUIT_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_NombreProveedor" runat="server" Text='<%# Bind("Nombre_Proveedor_Prov") %>' MaxLength="25"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_NombreProveedor" runat="server" Text='<%# Bind("Nombre_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mail">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_MailProveedor" runat="server" Text='<%# Bind("Mail_Proveedor_Prov") %>' MaxLength="30" TextMode="Email"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_MailProveedor" runat="server" Text='<%# Bind("Mail_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Direccion">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_DireccionProveedor" runat="server" Text='<%# Bind("Direccion_Proveedor_Prov") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_DireccionProveedor" runat="server" Text='<%# Bind("Direccion_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ciudad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_CiudadProveedor" runat="server" Text='<%# Bind("Ciudad_Proveedor_Prov") %>' MaxLength="20"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_CiudadProveedor" runat="server" Text='<%# Bind("Ciudad_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Id Provincia">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_ProvinciaProveedor" runat="server" Text='<%# Bind("Id_Provincia_Prov") %>' TextMode="Number"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_IdProvinciaProveedor" runat="server" Text='<%# Bind("Id_Provincia_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Telefono">
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_TelefonoProveedor" runat="server" Text='<%# Bind("Telefono_Proveedor_Prov") %>' MaxLength="15" TextMode="Phone"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_TelefonoProveedor" runat="server" Text='<%# Bind("Telefono_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estado">
                            <EditItemTemplate>
                                <asp:CheckBox ID="chb_Eit_Estado" runat="server" Checked='<%# Bind("Estado_Proveedor_Prov") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_it_EstadoProveedor" runat="server" Text='<%# Bind("Estado_Proveedor_Prov") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <div>
                <asp:HyperLink ID="hlProveedor" runat="server" NavigateUrl="~/Agregar proveedor.aspx">Agregar proveedor</asp:HyperLink>
                &nbsp;<br />
            </div>
        </form>
         <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <br />
    </div>
</body>
</html>
