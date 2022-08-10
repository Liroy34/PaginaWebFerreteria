using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class TipoProducto
    {
        int id_TipoProducto;
        string descripcion;
        private bool estado;

        public TipoProducto()
        {
        }

        public int Id_TipoProducto { get => id_TipoProducto; set => id_TipoProducto = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
