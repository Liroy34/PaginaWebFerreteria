using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int id_Usuario;
        private String dni;
        private String telefono;
        private String nombre;
        private String contrasenia;
        private String mail;
        private String direccion;
        private String ciudad;
        private Provincia provincia;
        private bool estado;
        private bool admin;

        public Usuario()
        {
        }

        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public Provincia Provincia { get => provincia; set => provincia = value; }
        public bool Estado { get => estado; set => estado = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}