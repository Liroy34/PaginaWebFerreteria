using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;
using System.Data;

namespace Negocio
{
    public class UsuarioNegocio
    {
        UsuarioDao UsuDao = new UsuarioDao();
        ProvinciaNegocio prn = new ProvinciaNegocio();
        public int AgregarUsuario(Usuario usuario)
        {
            int filasAfectadas = UsuDao.AgregarUsuario(usuario);
            return filasAfectadas;
        }

        public int ActualizarUsuario(Usuario usuario)
        {
            int filasAfectadas = UsuDao.ActualizarUsuario(usuario);
            return filasAfectadas;
        }

        public int existeCuentaUsuario(String DNI, String contrasenia)
        {
            return UsuDao.ChequeoUsuario(DNI, contrasenia);

        }
        public DataSet BuscarUsuario(int id)
        {
            return UsuDao.BuscarUsuario(id);
        }
        public DataSet BuscarUsuarioXNombre(String nombre)
        {
            return UsuDao.BuscarUsuarioXNombre(nombre);
        }
        public Usuario traerUsuario(int id)
        {
            DataSet ds = UsuDao.traerUsuario(id);
            Usuario us = new Usuario();
            us.Id_Usuario = Convert.ToInt32(ds.Tables["Usuarios"].Rows[0]["Id_Usuario_U"].ToString());
            us.Dni = ds.Tables["Usuarios"].Rows[0]["DNI_Usuario_U"].ToString();
            us.Telefono = ds.Tables["Usuarios"].Rows[0]["Telefono_Usuario_U"].ToString();
            us.Nombre = ds.Tables["Usuarios"].Rows[0]["Nombre_Usuario_U"].ToString();
            us.Contrasenia = ds.Tables["Usuarios"].Rows[0]["Contraseña_Usuario_U"].ToString();
            us.Mail = ds.Tables["Usuarios"].Rows[0]["Mail_Usuario_U"].ToString();
            us.Direccion = ds.Tables["Usuarios"].Rows[0]["Direccion_Usuario_U"].ToString();
            us.Ciudad = ds.Tables["Usuarios"].Rows[0]["Ciudad_Usuario_U"].ToString();
            us.Provincia = prn.traerProvincia(Convert.ToInt32(ds.Tables["Usuarios"].Rows[0]["Id_Provincia_U"].ToString()));
            us.Estado = Convert.ToBoolean(ds.Tables["Usuarios"].Rows[0]["Estado_Usuario_U"].ToString());
            us.Admin = Convert.ToBoolean(ds.Tables["Usuarios"].Rows[0]["Admin_Usuario_U"].ToString());

            return us;
        }
        public DataSet traerDatos()
        {
            DataSet ds = UsuDao.traerDatos();

            return ds;
        }

        public bool ChequeoDni(String DNI)
        {
            return UsuDao.ChequeoDni(DNI);
        }

    }
}
