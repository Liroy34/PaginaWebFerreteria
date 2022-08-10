using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        private int id_Producto;
        private String descipcion;
        private Proveedor proveedor;
        private double precio_Unitario;
        private String nombre;
        private TipoProducto tipoProducto;
        private String url_imagen;
        private int stock;
        private bool estado;

        public Producto()
        {
        }

        public int Id_Producto { get => id_Producto; set => id_Producto = value; }
        public string Descipcion { get => descipcion; set => descipcion = value; }
        public Proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public double Precio_Unitario { get => precio_Unitario; set => precio_Unitario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public TipoProducto TipoProducto { get => tipoProducto; set => tipoProducto = value; }
        public string Url_imagen { get => url_imagen; set => url_imagen = value; }
        public int Stock { get => stock; set => stock = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
