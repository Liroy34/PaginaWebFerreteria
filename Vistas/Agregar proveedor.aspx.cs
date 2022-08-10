using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;


namespace Vistas
{
    public partial class Agregar_proveedor : System.Web.UI.Page
    {
        ProveedorNegocio prov = new ProveedorNegocio();
        ProvinciaNegocio provNeg = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                DataSet ds = provNeg.tablaProvinciasEstado1();

                foreach (DataRow dr in ds.Tables["Provincias"].Rows)
                {
                    DdlProvincia.Items.Add(new ListItem(dr["Descripcion_Provincia_Pr"].ToString(), dr["Id_Provincia_Pr"].ToString()));
                }
            }
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Proveedor Pr = new Proveedor();
            Pr.Cuit = TxtCUITPr.Text;
            Pr.Nombre = TxtNombrePr.Text;
            Pr.Direccion = TxtDireccionPr.Text;
            Pr.Ciudad = TxtCiudadPr.Text;
            Pr.Provincia = provNeg.traerProvincia(Convert.ToInt32(DdlProvincia.SelectedValue));
            Pr.Telefono = TxtTelPr.Text;
            Pr.Mail = TxtMailPr.Text;
            Pr.Estado = true;

            DataTable TablaPr = prov.getTabla();

            if (!prov.ChequeoProveedores(TablaPr, Pr))
            {
                if (prov.AgregarProveedor(Pr) == 1)
                {
                    LblMensaje.Text = "Se agrego con exito";
                    vaciarCampos();
                }
                else
                {
                    LblMensaje.Text = "No se pudo agregar";
                }
            }
            else
            {
                LblMensaje.Text = "El Cuit ingresado ya existe";
                TxtCUITPr.Text = "";
            }
        }
        protected void vaciarCampos()
        {
            TxtCiudadPr.Text = "";
            TxtCUITPr.Text = "";
            TxtDireccionPr.Text = "";
            TxtMailPr.Text = "";
            TxtNombrePr.Text = "";
            TxtTelPr.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }
    }
}