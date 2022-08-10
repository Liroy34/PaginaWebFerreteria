using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI.WebControls;



namespace Vistas
{
    public partial class Modificar_Datos : System.Web.UI.Page
    {
        ProvinciaNegocio Prov = new ProvinciaNegocio();
        UsuarioNegocio usn = new UsuarioNegocio();
        Usuario us = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            us = (Usuario)Session["Usuario"];
            lblNombre.Text = us.Nombre;

            if (!IsPostBack)
            {
                DataSet ds = Prov.traerProvincias();
                foreach (DataRow dr in ds.Tables["Provincias"].Rows)
                {
                    ddlProvincia.Items.Add(new ListItem(dr["Descripcion_Provincia_Pr"].ToString(), dr["Id_Provincia_Pr"].ToString()));
                }

                txtNombre.Text = us.Nombre.Trim();
                txtCiudad.Text = us.Ciudad.Trim();
                txtDireccion.Text = us.Direccion.Trim();
                ddlProvincia.SelectedValue = us.Provincia.Id_Provincia.ToString();
                txtTelefono.Text = us.Telefono.Trim();
                txtMail.Text = us.Mail.Trim();
                txtContraseña.Text = us.Contrasenia.Trim();
                txtDNI.Text = us.Dni.Trim();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;         
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            us.Nombre = txtNombre.Text;
            us.Direccion = txtDireccion.Text;
            us.Ciudad = txtCiudad.Text;
            us.Provincia = Prov.traerProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            us.Telefono = txtTelefono.Text;
            us.Mail = txtMail.Text;
            us.Dni = txtDNI.Text;
            us.Contrasenia = txtContraseña.Text;

            if (usn.ActualizarUsuario(us) > 0)
            {
                lblModifico.Text = "LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE";

            }

            else
            {
                lblModifico.Text = "LOS DATOS NO HAN PODIDO SER MODIFICADOS";
                lblModifico.Style.Add("color", "red");
            }
        }
    }
}