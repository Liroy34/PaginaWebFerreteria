using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;

namespace Vistas
{
    public partial class Tipos_de_Producto : System.Web.UI.Page
    {
        TipoProductoNegocio tpn = new TipoProductoNegocio();
        TipoProducto tp = new TipoProducto();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                CargarTabla();
            }
        }
        protected void CargarTabla()
        {
            grdTipoProducto.DataSource = tpn.traerTipoProductos();
            grdTipoProducto.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tpn.AgregarTipoProducto(txtTipoDeProducto.Text) > 0)
            {
                lblAgregado.Text = "Tipo de Producto agregado exitosamente.";
                txtTipoDeProducto.Text = "";
            }
            else
            {
                lblAgregado.Text = "Error al tratar de agregar el tipo de producto.";
            }

            CargarTabla();
        }

        protected void grdTipoProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int s_IdTipoPRoducto = Convert.ToInt32(((Label)grdTipoProducto.Rows[e.RowIndex].FindControl("lbl_it_IdTipo")).Text);

            if (tpn.bajaTipoProducto(s_IdTipoPRoducto) == 1)
            {
                lblMensaje.Text = "El tipo de producto fue dada de baja y quedara eliminado para la carga de productos";
            }
            else
            {
                lblMensaje.Text = "Error al tratar de eliminar el tipo de producto " + s_IdTipoPRoducto;
            }
            CargarTabla();
        }

        protected void grdTipoProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdTipoProducto.PageIndex = e.NewPageIndex;
            CargarTabla();
            lblMensaje.Text = "";
        }

        protected void grdTipoProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            int s_Id = Convert.ToInt32(((Label)grdTipoProducto.Rows[e.RowIndex].FindControl("lbl_it_IdTipo")).Text);
            String s_Tipo = ((TextBox)grdTipoProducto.Rows[e.RowIndex].FindControl("txt_ed_TipoProducto")).Text;
            bool s_Estado = ((CheckBox)grdTipoProducto.Rows[e.RowIndex].FindControl("chb_Eit_Estado")).Checked;

            tp.Id_TipoProducto = s_Id;
            tp.Descripcion = s_Tipo;
            tp.Estado = s_Estado;

            if (tpn.ActualizaTipoDeProducto(tp))
            {
                lblMensaje.Text = "Tipo de producto " + s_Id + " actualizado.";
            }
            else
            {
                lblMensaje.Text = "Error al tratar de actualizar el tipo de producto " + s_Id + ".";
            }

            grdTipoProducto.EditIndex = -1;
            CargarTabla();
        }

        protected void grdTipoProducto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdTipoProducto.EditIndex = e.NewEditIndex;
            CargarTabla();
            lblMensaje.Text = "";
        }

        protected void grdTipoProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdTipoProducto.EditIndex = -1;
            CargarTabla();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void txtTipoDeProducto_TextChanged(object sender, EventArgs e)
        {
            lblAgregado.Text = "";
            lblMensaje.Text = "";
        }
    }
}