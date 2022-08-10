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
    public partial class Usuarios : System.Web.UI.Page
    {
        bool Txt = true;
        static int idBuscado;
        static String nombreBusqueda;
        UsuarioNegocio usn = new UsuarioNegocio();
        ProvinciaNegocio pn = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
                CargarGrv();
            
            
        }
        public void CargarGrv()
        {
            UsuarioNegocio UsNeg = new UsuarioNegocio();
            grvUsuarios.DataSource = UsNeg.traerDatos();
            grvUsuarios.DataBind();
        }

        protected void grvUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        { 

            grvUsuarios.EditIndex = e.NewEditIndex;
            CargarGrv();
        }

        protected void grvUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            
            String idProducto = ((Label)grvUsuarios.Rows[e.RowIndex].FindControl("lbl_it_IdUsuario")).Text;
            String Nombre = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtNombre_Eit_Us")).Text;
            String Contraseña = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtContraseña_Eit_Us")).Text;
            String DNI = ((Label)grvUsuarios.Rows[e.RowIndex].FindControl("lblDNI_it_Us")).Text;
            String Mail = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtMail_Eit_Us")).Text;
            String Telefono = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtTelefono_Eit_Us")).Text;
            String Direccion = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtDireccion_Eit_Us")).Text;
            String Ciudad = ((TextBox)grvUsuarios.Rows[e.RowIndex].FindControl("TxtCiudad_Eit_Us")).Text;
            String Provincia = ((DropDownList)grvUsuarios.Rows[e.RowIndex].FindControl("DdlProvincias_Eit_Us")).SelectedValue;
            bool Estado = ((CheckBox)grvUsuarios.Rows[e.RowIndex].FindControl("chbEstado_Eit_Us")).Checked;

            
            
            Usuario Us = new Usuario();
            Us.Id_Usuario = Convert.ToInt32(idProducto);
            Us.Nombre = Nombre;
            Us.Contrasenia = Contraseña;
            Us.Dni = DNI;
            Us.Mail = Mail;
            Us.Telefono = Telefono;
            Us.Direccion = Direccion;
            Us.Ciudad = Ciudad;
            Us.Provincia = pn.traerProvincia(Convert.ToInt32(Provincia));
            Us.Estado = Estado;


            if (usn.ActualizarUsuario(Us) == 1)
            {
                lblMensaje.Text = "Usuario " + Nombre + " actualizado correctamente.";
            }
           
            grvUsuarios.EditIndex = -1;
            CargarGrv();
        }

        protected void grvUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvUsuarios.EditIndex = -1;
            CargarGrv();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void grvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvUsuarios.PageIndex = e.NewPageIndex;
            CargarGrv();
        }

        protected void txtBuscar_Click(object sender, EventArgs e)
        {
            if (txtUsuarioId.Text != "")
            {
                idBuscado = Convert.ToInt32(txtUsuarioId.Text);
                grvUsuarios.DataSource = usn.BuscarUsuario(idBuscado);
                grvUsuarios.DataBind();
                txtUsuarioId.Text = "";
            }
            else
            {
                CargarGrv();
            }
        }

        protected void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            CargarGrv();
        }

        protected void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            if (tbUsuarioNombre.Text != "")
            {
                nombreBusqueda = tbUsuarioNombre.Text;
                grvUsuarios.DataSource = usn.BuscarUsuarioXNombre(nombreBusqueda);
                grvUsuarios.DataBind();
                tbUsuarioNombre.Text = "";
            }
            else
            {
                CargarGrv();
            }
        }

        protected void txtUsuarioId_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        protected void tbUsuarioNombre_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }
    }
}