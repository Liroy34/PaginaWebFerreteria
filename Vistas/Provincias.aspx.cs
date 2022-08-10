using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class Provincias : System.Web.UI.Page
    {
        Provincia p = new Provincia();
        ProvinciaNegocio pn = new ProvinciaNegocio();
        ProvinciaNegocio provNeg = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario; // comentar para no ingresar con un usuario
            lblNombre.Text = us.Nombre; // comentar para no ingresar con un usuario
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }
        protected void CargarTabla()
        {
            ProvinciaNegocio pn = new ProvinciaNegocio();
            grdProvincias.DataSource = pn.getTabla();
            grdProvincias.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtProvincia.Text.Length != 0)
            {
                if (pn.AgregarProvincia(txtProvincia.Text) > 0)
                {
                    lblMensaje.Text = "Provincia agregada con exito.";
                    txtProvincia.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Error al tratar de agregar provincia.";
                }
            }
            else
            {
                lblMensaje.Text = "Debe completar el campo para agregar una provincia.";
            }


            CargarTabla();
        }
        protected void grdProvincia_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s_Id = Convert.ToInt32(((Label)grdProvincias.Rows[e.RowIndex].FindControl("lbl_it_IdProvincia")).Text);

            if (provNeg.bajaProvincia(s_Id)>0)
            {
                lblMensaje.Text = "La provincia fue dada de baja y quedara eliminada para la carga de usuarios y proveedores";
            }
            else
            {
                lblMensaje.Text = "Error al tratar de eliminar la provincia.";
            }

            CargarTabla();
        }

        protected void grdProvincias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            lblMensaje.Text = "";
            grdProvincias.EditIndex = e.NewEditIndex;
            CargarTabla();
        }

        protected void grdProvincias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int s_Id = Convert.ToInt32(((Label)grdProvincias.Rows[e.RowIndex].FindControl("lbl_it_IdProvincia")).Text);
            String s_Provincia = ((TextBox)grdProvincias.Rows[e.RowIndex].FindControl("txt_ed_Provincia")).Text;
            bool s_Estado = ((CheckBox)grdProvincias.Rows[e.RowIndex].FindControl("chb_Eit_Estado")).Checked;

            Provincia p = new Provincia();

            p.Id_Provincia = s_Id;
            p.Descripcion_Provincia = s_Provincia;
            p.Estado = s_Estado;

            if (pn.ActualizaProvincia(p))
            {
                lblMensaje.Text = "Provincia " + s_Id + " actualizada correctamente";
            }
            else
            {
                lblMensaje.Text = "Erorr al tratar de actulizar la provincia " + s_Provincia;
            }

            grdProvincias.EditIndex = -1;
            CargarTabla();
        }

        protected void grdProvincias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProvincias.EditIndex = -1;
            CargarTabla();
        }

        protected void grdProvincias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblMensaje.Text = "";
            grdProvincias.PageIndex = e.NewPageIndex;
            CargarTabla();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void txtProvincia_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }
    }
}