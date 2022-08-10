using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Vistas
{
    public partial class Pagina_Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        Producto pr = new Producto();
        public bool CorroborarProductoAgregado(DataTable dt, Producto pr)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID Producto"].ToString().ToLower().Equals((pr.Id_Producto).ToString().ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (txtFiltrar.Text.Length == 0)
            {
                lblFiltrado.Text = "Debe completar el campo de filtrado.";
            }
            else
            {
                SqlDataSource1.SelectCommand =
                    "SELECT [Id_Producto_P], [Descripcion_Producto_P], [Precio_Unitario_P], [Nombre_Producto_P], [Imagen_Producto_P], [Stock_Producto_P], [Estado_P] FROM [Productos] WHERE Stock_Producto_P > 0 AND Estado_P = 1 AND Nombre_Producto_P LIKE '%" + txtFiltrar.Text + "%'";
            }
            txtFiltrar.Text = "";

        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            lblFiltrado.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }


        protected void btnFiltroXTipo_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoFiltrar")
            {
                SqlDataSource1.SelectCommand =
                    "SELECT [Id_Producto_P], [Descripcion_Producto_P], [Precio_Unitario_P], [Nombre_Producto_P], [Imagen_Producto_P], [Stock_Producto_P], [Estado_P] FROM [Productos] WHERE Stock_Producto_P > 0 AND Estado_P = 1 AND Id_Tipo_Producto_P = '" + e.CommandArgument.ToString() + "'";
            }
        }

        protected void btnAscendente_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand =
                    "SELECT [Id_Producto_P], [Descripcion_Producto_P], [Precio_Unitario_P], [Nombre_Producto_P], [Imagen_Producto_P], [Stock_Producto_P], [Estado_P] FROM [Productos] WHERE Stock_Producto_P > 0 AND Estado_P = 1 ORDER BY Precio_Unitario_P ASC";
        }

        protected void btnDescendente_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand =
                    "SELECT [Id_Producto_P], [Descripcion_Producto_P], [Precio_Unitario_P], [Nombre_Producto_P], [Imagen_Producto_P], [Stock_Producto_P], [Estado_P] FROM [Productos] WHERE Stock_Producto_P > 0 AND Estado_P = 1 ORDER BY Precio_Unitario_P DESC";
        }
    }
}