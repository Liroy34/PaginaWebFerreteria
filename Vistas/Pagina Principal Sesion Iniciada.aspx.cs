using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Vistas
{
    public partial class Pagina_Principal_Sesion_Iniciada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;

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

        public string AgregarProductoSeleccionado(DataTable dt, Producto pr)
        {
            string Mensaje;
            bool sigue = CorroborarProductoAgregado(dt, pr);
            if (!sigue)
            {
                int cant = 1;
                DataRow dr = dt.NewRow();
                dr["ID Producto"] = pr.Id_Producto;
                dr["Nombre Producto"] = pr.Nombre;
                dr["Descripcion Producto"] = pr.Descipcion;
                dr["Precio Unitario"] = pr.Precio_Unitario;
                dr["Stock"] = pr.Stock;
                dr["Cantidad"] = cant.ToString();
                dr["Subtotal"] = pr.Precio_Unitario * cant;

                dt.Rows.Add(dr);
                Mensaje = "Producto agregado";
                return Mensaje;
            }
            else
            {
                Mensaje = "Producto agregado con anterioridad";
                return Mensaje;
            }
        }

        public DataTable CrearTable()
        {
            DataTable tabla = new DataTable();

            DataColumn columna = new DataColumn("ID Producto", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Nombre Producto", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Descripcion Producto", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Precio unitario", System.Type.GetType("System.String"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Stock", System.Type.GetType("System.Int32"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Cantidad", System.Type.GetType("System.Int32"));
            tabla.Columns.Add(columna);

            columna = new DataColumn("Subtotal", System.Type.GetType("System.Double"));
            tabla.Columns.Add(columna);

            return tabla;
        }

        public void copiarPropiedades(string st, Producto pr)
        {
            double subtotal;
            int cantidad = 1;
            string[] propiedades = st.Split('.');
            pr.Id_Producto = Convert.ToInt32(propiedades[0]);
            pr.Nombre = propiedades[1];
            pr.Descipcion = propiedades[2];
            pr.Precio_Unitario = Convert.ToDouble(propiedades[3]);
            pr.Stock = Convert.ToInt32(propiedades[4]);
            subtotal = pr.Precio_Unitario * cantidad;
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

        protected void btnAgregar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoAgregar")
            {
                if (Session["Tabla"] == null)
                {
                    Session["Tabla"] = CrearTable();
                }

                copiarPropiedades(e.CommandArgument.ToString(), pr);
                string mensaje = AgregarProductoSeleccionado((DataTable)Session["Tabla"], pr);
                lblMensaje.Text = mensaje;
            }
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