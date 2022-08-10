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
    public partial class Detalle_de_ventas : System.Web.UI.Page
    {
        DetalleDeVentaNegocio dvn = new DetalleDeVentaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
           Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                string ID;
                ID = Request.QueryString["ID"].ToString();
                cargaTablaDetalleVenta(dvn.traerDatosDetalleDeVenta(ID));
            }
        }

        public void cargaTablaDetalleVenta(DataSet dataSet)
        {
            grvDetalleVentas.DataSource = dataSet;
            grvDetalleVentas.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void grvDetalleVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string ID;
            ID = Request.QueryString["ID"].ToString();
            grvDetalleVentas.PageIndex = e.NewPageIndex;
            cargaTablaDetalleVenta(dvn.traerDatosDetalleDeVenta(ID));
        }
    }
}