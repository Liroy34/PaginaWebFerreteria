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
    public partial class Iniciar_Sesion : System.Web.UI.Page
    {
        Usuario us = new Usuario();
        UsuarioNegocio usn = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int estado = usn.existeCuentaUsuario(tbUsuario.Text, tbContrasenia.Text);

            if (estado == 1)
            {
                
                Session["Usuario"] = usn.traerUsuario(Convert.ToInt32(tbUsuario.Text));
                Response.Redirect("~/Pagina Principal Admin.aspx");
                vaciarCampos();
            }
            if (estado == 2)
            {
             
                Session["Usuario"] = usn.traerUsuario(Convert.ToInt32(tbUsuario.Text));
                Response.Redirect("~/Pagina Principal Sesion Iniciada.aspx");
                vaciarCampos();
            }
            else
            {
                lblMensaje.Text = "El usuario o la contraseña son incorrectos.";
            }
        }
        protected void vaciarCampos()
        {
            tbUsuario.Text = "";
            tbContrasenia.Text = "";
        }
    }
}