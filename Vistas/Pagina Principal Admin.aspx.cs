using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using System.Data;
using Negocio;

namespace Vistas
{
    public partial class Pagina_Principal_Admin : System.Web.UI.Page
    {
        DetalleDeVentaNegocio DVDNeg = new DetalleDeVentaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                RankingCliente();
                EstadisticasProducto();
                StockProducto();
            }
        }

        public void EstadisticasProducto()
        {   
            String consulta = "SELECT Id_Producto_P,Nombre_Producto_P,Sum(Cantidad_DV) AS Cantidad_Vendida,sum(Precio_Unitario_DV*Cantidad_DV) AS TOTAL FROM Productos INNER JOIN Detalle_De_Venta ON Id_Producto_P = Id_Producto_DV  INNER JOIN Ventas ON Num_Factura_V = Num_Factura_DV WHERE Fecha_V <= cast('" + DdlMes.SelectedValue + "/" + DdlAño.SelectedValue + "'AS datetime) GROUP BY Id_Producto_P,Nombre_Producto_P,Stock_Producto_P ORDER BY " + DdlFiltro.SelectedValue;
            DataSet ds = DVDNeg.traerDatosDetalleDeVentaFiltrado(consulta, "Productos");
            GrvVentas.DataSource = ds.Tables["Productos"];
            DataBind();

        }

        public void StockProducto()
        {
            ///int i = 0;
            String consulta = "SELECT Id_Producto_P,Nombre_Producto_P,Descripcion_Producto_P,Stock_Producto_P From Productos WHERE Stock_Producto_P<100 ORDER BY Stock_Producto_P ASC";
            DataSet ds = DVDNeg.traerDatosDetalleDeVentaFiltrado(consulta, "StockProductos");
            GrvProductosStock.DataSource = ds.Tables["StockProductos"];
            DataBind();


           /* foreach (DataRow dr in ds.Tables["StockProductos"].Rows)
            {

                if (Convert.ToInt32(dr["Stock_Producto_P"]) <= 10)
                    ///GrvProductosStock.Rows[i].ForeColor = System.Drawing.Color.Red;
                    GrvProductosStock.SelectedRow.ForeColor = System.Drawing.Color.Red;
                i += 1;
            }*/

        }

        public void RankingCliente()
        {
            String consulta = "SELECT TOP " + DdlTop.SelectedValue + "DNI_Usuario_U,Nombre_Usuario_U,sum(Precio_Unitario_DV*Cantidad_DV) AS GASTO  FROM Detalle_De_Venta INNER JOIN Ventas ON Num_Factura_DV=Num_Factura_V  INNER JOIN Usuarios ON Id_Usuario_U=Id_Usuario_V GROUP BY DNI_Usuario_U,Nombre_Usuario_U ORDER BY GASTO DESC";
            DataSet ds = DVDNeg.traerDatosDetalleDeVentaFiltrado(consulta, "Clientes");
            GrvClientes.DataSource = ds.Tables["Clientes"];
            DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void GrvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvVentas.PageIndex = e.NewPageIndex;
            RankingCliente();
            EstadisticasProducto();
            StockProducto();

        }

        protected void GrvProductosStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrvProductosStock.PageIndex = e.NewPageIndex;
            RankingCliente();
            EstadisticasProducto();
            StockProducto();
        }

        protected void DdlAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankingCliente();
            EstadisticasProducto();
            StockProducto();
        }

        protected void DdlMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankingCliente();
            EstadisticasProducto();
            StockProducto();
        }

        protected void DdlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankingCliente();
            EstadisticasProducto();
            StockProducto();
        }

        protected void DdlTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            RankingCliente();
            EstadisticasProducto();
            StockProducto();
        }
    }
}