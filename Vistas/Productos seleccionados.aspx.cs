using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;
using System.Data.SqlClient;

namespace Vistas
{
    public partial class Productos_seleccionados : System.Web.UI.Page
    {
        VentaNegocio vtn = new VentaNegocio();
        DetalleDeVentaNegocio dvtn = new DetalleDeVentaNegocio();
        UsuarioNegocio usn = new UsuarioNegocio();
        Usuario us = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (IsPostBack == false)
            {
                if (Session["Tabla"] != null)
                {
                    grvCarrito.DataSource = Session["Tabla"];
                    grvCarrito.DataBind();
                    btnActualizar_Click(btnActualizar, null);
                }
                else
                {
                    lblCarritoVacio.Text = "No hay elementos en el carrito";
                }
            }
        }

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (Session["Tabla"] == null)
            {
                lblError.Text = "No hay elementos en el carrito";
            }
            else
            {
                btnActualizar.Visible = false;
                btnConfirmar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string cantidad, precio;
            int i;
            double total = 0, prec, subtotal;
            string cod;
            int cant;

            var items = (DataTable)Session["Tabla"];
            for (i = 0; i < grvCarrito.Rows.Count; i++)
            {
                cod = (grvCarrito.Rows[i].Cells[1].Text);
                precio = grvCarrito.Rows[i].Cells[4].Text;
                prec = Convert.ToDouble(precio);
                cantidad = ((TextBox)grvCarrito.Rows[i].Cells[6].FindControl("txtCantidad")).Text;
                cant = Convert.ToInt32(cantidad);
                subtotal = cant * prec;
                grvCarrito.Rows[i].Cells[7].Text = subtotal.ToString();
                foreach (DataRow dr in items.Rows)
                {
                    if (dr["ID Producto"].ToString() == cod.ToString())
                    {
                        dr["Cantidad"] = cant;
                        dr["Subtotal"] = subtotal;
                    }
                }
                total = total + subtotal;
            }
            if (total == 0)
            {
                lblMontoTotal.Text = "";
            }
            else
            {
                lblMontoTotal.Text = "Total: " + total.ToString("0.00");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void grvCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = (DataTable)Session["Tabla"];
            dt.Rows.RemoveAt(e.RowIndex);

            Session["Tabla"] = dt;

            grvCarrito.DataSource = dt;
            grvCarrito.DataBind();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Session["Tabla"] == null)
            {
                lblError.Text = "No hay elementos en el carrito";
            }
            else
            {

                bool StockCantidad = false;
                int k;
                for (k = 0; k < grvCarrito.Rows.Count; k++)
                {
                    if (Convert.ToInt32(grvCarrito.Rows[k].Cells[5].Text) < Convert.ToInt32(((TextBox)grvCarrito.Rows[k].Cells[6].FindControl("txtCantidad")).Text))
                    {
                        StockCantidad = true;
                    }
                }

                if (!StockCantidad)
                {
                    vtn.AgregarVenta((Session["Usuario"] as Usuario).Id_Usuario.ToString(), 0); ;

                    int id, cant, i;
                    double prec;
                    for (i = 0; i < grvCarrito.Rows.Count; i++)
                    {
                        id = Convert.ToInt32(grvCarrito.Rows[i].Cells[1].Text);
                        prec = Convert.ToDouble(grvCarrito.Rows[i].Cells[4].Text);
                        cant = Convert.ToInt32(((TextBox)grvCarrito.Rows[i].Cells[6].FindControl("txtCantidad")).Text);
                        dvtn.AgregarDetalleDeVenta(vtn.traerIdUltimaFactura(), id, prec, cant);
                    }

                    lblCompraFinalizada.Text = "Compra Finalizada";
                    Session["Tabla"] = null;
                    btnCancelar.Visible = false;
                }
                else
                {
                    lblError.Text = "Corrobore el stock disponible";
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnActualizar.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}