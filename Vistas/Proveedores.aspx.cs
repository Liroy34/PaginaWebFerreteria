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
    
    public partial class Proveedores : System.Web.UI.Page
    {
        static int idBuscado;
        static String nombreBusqueda;
        ProveedorNegocio pn = new ProveedorNegocio();
        ProvinciaNegocio prn = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
                CargarTabla();
            
        }
        protected void CargarTabla()
        {
            grvProveedores.DataSource = pn.getTabla();
            grvProveedores.DataBind();
        }

        protected void grvProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s_ID = Convert.ToInt32(((Label)grvProveedores.Rows[e.RowIndex].FindControl("lbl_it_IdProveedor")).Text);


            if (pn.bajaProveedor(s_ID)>0)
            {
                lblMensaje.Text = "El proveedor fue dado de baja y fue eliminado para futuros productos";
            }

            CargarTabla();
        }

        protected void txtBuscar_Click(object sender, EventArgs e)
        {
            if (txtProveedor.Text != "")
            {
                idBuscado = Convert.ToInt32(txtProveedor.Text);
                grvProveedores.DataSource = pn.BuscarProveedor(idBuscado);
                grvProveedores.DataBind();
                txtProveedor.Text = "";
            }
            else
            {
                CargarTabla();
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarTabla();
            txtProveedor.Text = "";
            txtProveedor.Text = "";
        }

        protected void grvProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvProveedores.EditIndex = e.NewEditIndex;
            if (idBuscado != 0)
            {
                grvProveedores.DataSource = pn.BuscarProveedor(idBuscado);
                grvProveedores.DataBind();
                idBuscado = 0;
            }
            else if (nombreBusqueda != "")
            {
                grvProveedores.DataSource = pn.BuscarProveedoresXNombre(nombreBusqueda);
                grvProveedores.DataBind();
                nombreBusqueda = "";
            }
            else
            {
                CargarTabla();
            }
        }

        protected void grvProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            lblMensaje.Text = "";
            grvProveedores.EditIndex = -1;
            txtProveedor.Text = "";
            CargarTabla();
            
        }

        protected void grvProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            txtProveedor.Text = "";
            lblMensaje.Text = "";
            String s_IdProveedor = ((Label)grvProveedores.Rows[e.RowIndex].FindControl("lbl_it_IdProveedor")).Text;
            String s_Cuit = ((Label)grvProveedores.Rows[e.RowIndex].FindControl("lbl_edt_CUIT")).Text;
            String s_Nombre = ((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_NombreProveedor")).Text;
            String s_Mail = ((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_MailProveedor")).Text;
            String s_Direccion = ((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_DireccionProveedor")).Text;
            String s_Ciudad = ((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_CiudadProveedor")).Text;
            int s_Provincia = Convert.ToInt32(((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_ProvinciaProveedor")).Text);
            String s_Telefono = ((TextBox)grvProveedores.Rows[e.RowIndex].FindControl("txt_TelefonoProveedor")).Text;
            bool s_Estado = ((CheckBox)grvProveedores.Rows[e.RowIndex].FindControl("chb_Eit_Estado")).Checked;

            Proveedor prov = new Proveedor();
            prov.Id_Proveedor = Convert.ToInt32(s_IdProveedor);
            prov.Cuit = s_Cuit;
            prov.Nombre = s_Nombre;
            prov.Mail = s_Mail;
            prov.Direccion = s_Direccion;
            prov.Ciudad = s_Ciudad;
            prov.Provincia = prn.traerProvincia(Convert.ToInt32(s_Provincia));
            prov.Telefono = s_Telefono;
            prov.Estado = s_Estado;

            if(prov.Provincia != null)
            {
                pn.ActualizaProveedor(prov);
                grvProveedores.EditIndex = -1;
                CargarTabla();
                lblMensaje.Text = "Se actualizo correctamente";
            }
            else
            {
                lblMensaje.Text = "Ingrese un id de provincia existente";
            }
            
        }

        protected void txtProveedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void txtProv_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProveedores.EditIndex = -1;
            grvProveedores.PageIndex = e.NewPageIndex;
            if (idBuscado != 0)
            {
                grvProveedores.DataSource = pn.BuscarProveedor(idBuscado);
                grvProveedores.DataBind();
                idBuscado = 0;
            }
            else if (nombreBusqueda != "")
            {
                grvProveedores.DataSource = pn.BuscarProveedoresXNombre(nombreBusqueda);
                grvProveedores.DataBind();
                nombreBusqueda = "";
            }
            else
            {
                CargarTabla();
            }
        }

        protected void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            if (tbBuscarNombre.Text != "")
            {
                nombreBusqueda = tbBuscarNombre.Text;
                grvProveedores.DataSource = pn.BuscarProveedoresXNombre(nombreBusqueda);
                grvProveedores.DataBind();
                tbBuscarNombre.Text = "";
            }
            else
            {
                CargarTabla();
            }
        }
    }
}