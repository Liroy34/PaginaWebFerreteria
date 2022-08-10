using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Dao;
using System.Data;
namespace Dao
{
   public class UsuarioDao : Dao
    {
        String tabla = "Usuarios";
        public int AgregarUsuario(Usuario usuario)
        {
            String consulta =
               "insert into Usuarios(DNI_Usuario_U,Nombre_Usuario_U,Mail_Usuario_U,Ciudad_Usuario_U,Id_Provincia_U,Direccion_Usuario_U,Telefono_Usuario_U,Estado_Usuario_U,Contraseña_Usuario_U,Admin_Usuario_U)" +
               " values('" + usuario.Dni + "','" + usuario.Nombre + "','" + usuario.Mail + "','" + usuario.Ciudad + "','" + usuario.Provincia.Id_Provincia + "','" +
                usuario.Direccion + "','" + usuario.Telefono + "','" + usuario.Estado + "','" + usuario.Contrasenia + "','" + usuario.Admin + "');";

            int filasAfectadas = agregarModificarEliminar(consulta);
            return filasAfectadas;
        }

        public int ActualizarUsuario(Usuario Us)
        {
            String consulta1 = "UPDATE Usuarios SET DNI_Usuario_U=" + Us.Dni + ",Telefono_Usuario_U='" + Us.Telefono + "',Nombre_Usuario_U='" + Us.Nombre + "',Contraseña_Usuario_U='" + Us.Contrasenia + "',Mail_Usuario_U='" + Us.Mail + "',Direccion_Usuario_U='" + Us.Direccion + "',Ciudad_Usuario_U='" + Us.Ciudad + "',Id_Provincia_U=" + Us.Provincia.Id_Provincia + ",Estado_Usuario_U='" + Us.Estado + "' WHERE Id_Usuario_U="+ Us.Id_Usuario;
            int filasAfectadas = agregarModificarEliminar(consulta1);
            return filasAfectadas;
        }

        public int ChequeoUsuario(String DNI, String contrasenia)
        {
            String consulta1 = "SELECT * FROM Usuarios WHERE DNI_Usuario_U = '" + DNI + "' and Contraseña_Usuario_U ='"+contrasenia + "' and Estado_Usuario_U = 1 and Admin_Usuario_U = 1";
            String consulta2 = "SELECT * FROM Usuarios WHERE DNI_Usuario_U = '" + DNI + "' and Contraseña_Usuario_U ='" + contrasenia + "' and Estado_Usuario_U = 1 and Admin_Usuario_U = 0";
            if (existeID(consulta1, tabla))
            {
                return 1;
            }
            else if(existeID(consulta2, tabla))
            {
                return 2;
            }
            return 0;
        }
        public DataSet BuscarUsuario(int id)
        {
            String consulta = "SELECT * FROM Usuarios INNER JOIN Provincias ON Id_Provincia_U  = Id_Provincia_Pr WHERE Id_Usuario_U  = " + id;
            String tabla = "Usuarios";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }

        public DataSet BuscarUsuarioXNombre(String nombre)
        {
            String consulta = "SELECT * FROM Usuarios INNER JOIN Provincias ON Id_Provincia_U  = Id_Provincia_Pr WHERE Nombre_Usuario_U  LIKE '%" + nombre + "%'";
            String tabla = "Usuarios";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }
        public bool ChequeoDni(String DNI)
        {
            String consulta = "SELECT * FROM Usuarios WHERE DNI_Usuario_U = '" + DNI + "'";
       
            return existeID(consulta,tabla);
        }
        public DataSet traerUsuario(int ID)
        {
            String consulta = "SELECT * FROM Usuarios WHERE DNI_Usuario_U =" + ID + "";
            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }

        public DataSet traerDatos()
        {
            String consulta = "Select * FROM Usuarios INNER JOIN Provincias ON Id_Provincia_U = Id_Provincia_Pr";
            DataSet ds = traerDatos(consulta,tabla);

            return ds;
        }
    }
}
