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
    public partial class Registrar_Admin : System.Web.UI.Page
    {
        UsuarioNegocio usn = new UsuarioNegocio();
        
        ProvinciaNegocio pn = new ProvinciaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                String tabla = "Provincias";

                DataSet ds = pn.tablaProvinciasEstado1();
                foreach (DataRow dr in ds.Tables[tabla].Rows)
                {
                    ddlProvincias.Items.Add(new ListItem(dr["Descripcion_Provincia_Pr"].ToString(), dr["Id_Provincia_Pr"].ToString()));
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario us = new Usuario();
            us.Nombre = txtNombre.Text;
            us.Contrasenia = txtContrasenia.Text;
            us.Mail = txtMail.Text;
            us.Ciudad = txtCiudad.Text;
            us.Direccion = txtDirecc.Text;
            us.Provincia =pn.traerProvincia(Convert.ToInt32(ddlProvincias.SelectedValue));
            us.Telefono = txtTelefono.Text;
            us.Estado = true;
            us.Admin = true;
            if (!usn.ChequeoDni(txtDNI.Text))
            {
                us.Dni = txtDNI.Text;
                if (usn.AgregarUsuario(us) > 0)
                {
                    lblMensaje.Text = "Administrador registrado de manera exitosa.";
                    vaciarCampos();
                }
            }
            else
            {
                lblMensaje.Text = "Ya existe una cuenta con ese DNI.";
                txtDNI.Text = "";
                txtContrasenia.Text = "";
                TxtConfirmarContraseña.Text = "";
            }

            
        }
        protected void vaciarCampos()
        {
            txtCiudad.Text = "";
            txtContrasenia.Text = "";
            txtDirecc.Text = "";
            txtDNI.Text = "";
            txtMail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            TxtConfirmarContraseña.Text = "";
        }
        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }
    }
}