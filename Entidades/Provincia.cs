using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        int id_Provincia;
        string descripcion_Provincia;
        private bool estado;

        public Provincia()
        {
        }

        public int Id_Provincia { get => id_Provincia; set => id_Provincia = value; }
        public string Descripcion_Provincia { get => descripcion_Provincia; set => descripcion_Provincia = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
