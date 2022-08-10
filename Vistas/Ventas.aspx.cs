using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Ventas : System.Web.UI.Page
    {
        VentaNegocio vtn = new VentaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                cargaTablaVentas(vtn.traerDatosVentas());
            }
        }

        public void cargaTablaVentas(DataSet dataSet)
        {
            grvVentas.DataSource = dataSet;
            grvVentas.DataBind();
        }

        protected void grvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eventoDetalle")
            {
                //Se hizo click sobre el boton detalle de ventas
                int fila = Convert.ToInt32(e.CommandArgument);
                string IDVentaParaDetalle = ((Label)grvVentas.Rows[fila].FindControl("lbl_Num_Factura_V")).Text;

                //Redireccionar a detalle de venta enviando IDVentaParaDetalle
                Response.Redirect("Detalle de ventas.aspx?ID=" + IDVentaParaDetalle);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void grvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvVentas.PageIndex = e.NewPageIndex;
            cargaTablaVentas(vtn.traerDatosVentas());
        }
    }
}