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
    public partial class Registrar_Usuario : System.Web.UI.Page
    {
        ProvinciaNegocio Prov = new ProvinciaNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = Prov.tablaProvinciasEstado1();
            foreach(DataRow dr in ds.Tables["Provincias"].Rows)
            {
                DdlProvincias.Items.Add(new ListItem(dr["Descripcion_Provincia_Pr"].ToString(), dr["Id_Provincia_Pr"].ToString()));
            }

        }
        protected void borrarCampos()
        {
            TxtCiudad.Text = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
            TxtMail.Text = "";
            TxtDNI.Text = "";
            TxtDireccion.Text = "";
            TxtContraseña.Text = "";
            TxtConfirmarContraseña.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            UsuarioNegocio Usuario = new UsuarioNegocio();
            Usuario Us = new Usuario();
            Us.Nombre = TxtNombre.Text;
            Us.Direccion = TxtDireccion.Text;
            Us.Ciudad = TxtCiudad.Text;
            Us.Provincia = Prov.traerProvincia(Convert.ToInt32(DdlProvincias.SelectedValue));
            Us.Dni = TxtDNI.Text;
            Us.Telefono = TxtTelefono.Text;
            Us.Mail = TxtMail.Text;
            Us.Contrasenia = TxtContraseña.Text;
            Us.Estado = true;
            Us.Admin = false;

            borrarCampos();

            switch (Usuario.existeCuentaUsuario(Us.Dni, Us.Mail.ToString()))
            {
                case 0:
                    if (Usuario.AgregarUsuario(Us) == 1)
                        LblMensaje.Text = "Se Registro con exito";
                        vaciarCampos();
                    break;
                case 1:
                    LblMensaje.Text = "El Mail ingresado ya esta registrado";
                    TxtMail.Text = "";
                    break;
                case 2:
                    LblMensaje.Text = "El DNI ingresado ya tiene una cuenta";
                    TxtDNI.Text = "";
                    break;
                case 3:
                    LblMensaje.Text = "Mail y DNI existentes";
                    TxtDNI.Text = "";
                    TxtMail.Text = "";
                    break;
                default:
                    LblMensaje.Text = "No se pudo crear la cuenta";
                    break;

            }
        }
        protected void vaciarCampos()
        {
            TxtCiudad.Text = "";
            TxtConfirmarContraseña.Text = "";
            TxtContraseña.Text = "";
            TxtDireccion.Text = "";
            TxtDNI.Text = "";
            TxtMail.Text = "";
            TxtNombre.Text = "";
            TxtTelefono.Text = "";
        }
    }
}