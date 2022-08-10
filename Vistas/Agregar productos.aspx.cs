using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Agregar_productos : System.Web.UI.Page
    {
        ProductoNegocio pn = new ProductoNegocio();
        TipoProductoNegocio tpn = new TipoProductoNegocio();
        ProveedorNegocio provn = new ProveedorNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                DataSet ds = tpn.traerTipoProductosEstado1();
                foreach (DataRow dr in ds.Tables["Tipo_Producto"].Rows)
                {
                    ddlTipoProducto.Items.Add(new ListItem(dr["Descripcion_Tipo_Producto_T"].ToString(), dr["Id_Tipo_Producto_T"].ToString()));
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Nombre = tbNombre.Text;
            p.Descipcion = tbDescripcion.Text;
            p.Proveedor = provn.traerProveedor(Convert.ToInt32(ddlProveedor.SelectedValue));
            p.Precio_Unitario = Convert.ToDouble(tbPrecio.Text);
            p.TipoProducto = tpn.traerTipoProducto(Convert.ToInt32(ddlTipoProducto.SelectedValue));
            p.Stock = Convert.ToInt32(tbStock.Text);
            p.Estado = true;

            if (fuImagen.HasFile)
            {
                String ext = System.IO.Path.GetExtension(fuImagen.FileName).ToLower();
                if (ext == ".png" || ext == ".jpg")
                {
                    p.Url_imagen = "~/Imagen/" + p.Id_Producto + ext;
                    fuImagen.SaveAs(Server.MapPath(p.Url_imagen));
                }
                else
                {
                    fuImagen.FileContent.Dispose();
                    p.Url_imagen = "~/Imagen/sinImagen.png";
                }
            }
            else
            {
                p.Url_imagen = "~/Imagen/sinImagen.png";
            }

            if (pn.AgregarProducto(p) > 0)
              {
                lblMensaje.Text = "Se agrego el producto correctamente";
                vaciarCampos();
              }
            else
            {
                lblMensaje.Text = "Error al tratar de agragar el producto";
            }
        }
        protected void vaciarCampos()
        {
            tbNombre.Text = "";
            tbPrecio.Text = "";
            tbStock.Text = "";
            tbDescripcion.Text = "";
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void tbNombre_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}