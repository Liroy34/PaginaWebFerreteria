    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class DetalleVentas
    {
        string num_factura;
        string id_producto;
        double precio_producto;
        int cantidad;

        public DetalleVentas()
        {
        }
        public DetalleVentas(string num_factura, string id_producto, double precio_producto, int cantidad)
        {
            this.Num_factura = num_factura;
            this.Id_producto = id_producto;
            this.Precio_producto = precio_producto;
            this.Cantidad = cantidad;
        }

        public string Num_factura { get => num_factura; set => num_factura = value; }
        public string Id_producto { get => id_producto; set => id_producto = value; }
        public double Precio_producto { get => precio_producto; set => precio_producto = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
    }
}
