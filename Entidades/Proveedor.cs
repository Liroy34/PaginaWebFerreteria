using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedor
    {
        private int id_Proveedor;
        private String cuit;
        private String nombre;
        private String mail;
        private String direccion;
        private String ciudad;
        private Provincia provincia;
        private String telefono;
        private bool estado;

        public Proveedor()
        {
        }

        public int Id_Proveedor { get => id_Proveedor; set => id_Proveedor = value; }
        public string Cuit { get => cuit; set => cuit = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
