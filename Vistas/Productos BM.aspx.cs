using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Productos : System.Web.UI.Page
    {
        static int idBuscado;
        static String nombreBusqueda;
        ProductoNegocio prn = new ProductoNegocio();
        TipoProductoNegocio tpn = new TipoProductoNegocio();
        ProveedorNegocio provn = new ProveedorNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario us = Session["Usuario"] as Usuario;
            lblNombre.Text = us.Nombre;
            if (!IsPostBack)
            {
                cargaTablaProductos(prn.traerDatosProductos());
            }
        }

        public void cargaTablaProductos(DataSet dataSet)
        {
            grvProductos.DataSource = dataSet;
            grvProductos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (tbIdProducto.Text != "")
            {
                idBuscado = Convert.ToInt32(tbIdProducto.Text);
                cargaTablaProductos(prn.traerDatosProductos(idBuscado));
                tbIdProducto.Text = "";
            }
            else
            {
                cargaTablaProductos(prn.traerDatosProductos());
            }

        }

        protected void grvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvProductos.EditIndex = -1;
            grvProductos.PageIndex = e.NewPageIndex;
            if (idBuscado != 0)
            {
                cargaTablaProductos(prn.traerDatosProductos(idBuscado));
                idBuscado = 0;
            }
            else if (nombreBusqueda != "")
            {
                cargaTablaProductos(prn.traerDatosProductos(nombreBusqueda));
                nombreBusqueda = "";
            }
            else
            {
                cargaTablaProductos(prn.traerDatosProductos());
            }
        }

        protected void grvProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvProductos.EditIndex = e.NewEditIndex;
            if (idBuscado != 0)
            {
                cargaTablaProductos(prn.traerDatosProductos(idBuscado));
                idBuscado = 0;
            }
            else if(nombreBusqueda!="")
            {
                cargaTablaProductos(prn.traerDatosProductos(nombreBusqueda));
                nombreBusqueda = "";
            }
            else
            {
                cargaTablaProductos(prn.traerDatosProductos());
            }
            
        }

        protected void grvProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String itemSeleccionado = ((Label)grvProductos.Rows[e.RowIndex].FindControl("lbl_It_IdProducto")).Text;
            if (prn.bajaProducto(Convert.ToInt32(itemSeleccionado)) == 1)
            {
                lblMensaje.Text = "El producto fue dado de baja y quedara eliminado para el usuario";
            }
            cargaTablaProductos(prn.traerDatosProductos());
        }

        protected void grvProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvProductos.EditIndex = -1;
            cargaTablaProductos(prn.traerDatosProductos());
            lblMensaje.Text = "";
            tbIdProducto.Text = "";
        }

        protected bool esFormatoNumero(String num)
        {
            try
            {
                Convert.ToDecimal(num);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void grvProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            tbIdProducto.Text = "";
            int idProducto = Convert.ToInt32(((Label)grvProductos.Rows[e.RowIndex].FindControl("lbl_It_IdProducto")).Text);
            String descripcion = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_Descripcion")).Text;
            int idProveedor = Convert.ToInt32(((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_IdProveedor")).Text);
            String precio = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_PrecioUnitario")).Text;
            String nombreProducto = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_NombreProducto")).Text;
            String idTipoProducto = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_IdTipoProducto")).Text;
            String urlImagen = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_UrlImagen")).Text;
            String stock = ((TextBox)grvProductos.Rows[e.RowIndex].FindControl("tb_Eit_Stock")).Text;
            bool estado = ((CheckBox)grvProductos.Rows[e.RowIndex].FindControl("chb_Eit_Estado")).Checked;

            if (esFormatoNumero(precio))
            {
                Producto p = new Producto();
                p.Id_Producto = Convert.ToInt32(idProducto);
                p.Descipcion = descripcion;
                p.Precio_Unitario = Convert.ToDouble(precio);
                p.Nombre = nombreProducto;
                p.TipoProducto = tpn.traerTipoProducto(Convert.ToInt32(idTipoProducto));
                p.Url_imagen = urlImagen;
                p.Stock = Convert.ToInt32(stock);
                p.Estado = estado;

                lblMensaje.Text = "";

                if (provn.existeIdProveedor(Convert.ToInt32(idProveedor)))
                {
                    p.Proveedor = provn.traerProveedor(Convert.ToInt32(idProveedor));
                    if (prn.actualizarProducto(p) == 1)
                    {
                        lblMensaje.Text = "Se a actualizado el IdProducto " + idProducto;
                    }
                    grvProductos.EditIndex = -1;
                    cargaTablaProductos(prn.traerDatosProductos());
                }
                else
                {
                    lblMensaje.Text = "El ID de proveedor no existe.";
                }
            }
            else
            {
                lblMensaje.Text = "El precio ingresado no es valido";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("~/Pagina Principal.aspx");
        }

        protected void tbIdProducto_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
        }

        protected void btnBuscar2_Click(object sender, EventArgs e)
        {
            if (tbBuscarNombre.Text != "")
            {
                nombreBusqueda = tbBuscarNombre.Text;
                cargaTablaProductos(prn.traerDatosProductos(nombreBusqueda));
                tbBuscarNombre.Text = "";
            }
            else
            {
                cargaTablaProductos(prn.traerDatosProductos());
            }
        }
    }
}