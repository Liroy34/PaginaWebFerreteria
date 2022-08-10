using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
   public class ProveedorDao : Dao
    {
        public int AgregarProveedor(Proveedor proveedor)
        {
            String consulta =
               "insert into Proveedores(CUIT_Proveedor_Prov,Nombre_Proveedor_Prov,Mail_Proveedor_Prov,Ciudad_Proveedor_Prov,Id_Provincia_Prov,Direccion_Proveedor_Prov,Telefono_Proveedor_Prov,Estado_Proveedor_Prov)" +
               " values('" + proveedor.Cuit + "','" + proveedor.Nombre + "','" +proveedor.Mail + "','" +proveedor.Ciudad+"','"+proveedor.Provincia.Id_Provincia+ "','" +
                proveedor.Direccion + "','" + proveedor.Telefono + "','" + proveedor.Estado  + "');";

            int filasAfectadas = agregarModificarEliminar(consulta);
            return filasAfectadas;
        }

        public int eliminarProveedor(int id)
        {
            String consulta = "DELETE FROM Proveedores WHERE Id_Proveedor_Prov = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public int bajaProveedor(int id)
        {
            String consulta = "Update Proveedores set Estado_Proveedor_Prov = 0 WHERE Id_Proveedor_Prov = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public int altaProveedor(int id)
        {
            String consulta = "Update Proveedores set Estado_Proveedor_Prov = 1 WHERE Id_Proveedor_Prov = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }


        public DataTable getTablaProveedores()
        {
            DataTable Tabla = ObtenerTabla("Proveedores", "Select * FROM Proveedores");
            return Tabla;
        }

        public bool existeIdProveedor(int id)
        {
            String consulta = "SELECT * FROM Proveedores WHERE Id_Proveedor_Prov = " + id + "";
            String tabla = "Proveedores";
            return existeID(consulta, tabla);

        }



        //NUEVO UTLIMA VERSION
        public DataSet BuscarProveedor(int id)
        {
            String consulta = "SELECT * FROM Proveedores WHERE Id_Proveedor_Prov = " + id;
            String tabla = "Proveedor";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }

        public DataSet BuscarProveedoresXNombre(String nombre)
        {
            String consulta = "SELECT * FROM Proveedores WHERE Nombre_Proveedor_Prov LIKE '%"+nombre+"%'";
            String tabla = "Proveedor";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }

        public void ArmarParametrosProveedoresEliminar(ref SqlCommand comando, Proveedor proveedor)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_PROVEEDOR_PROV", SqlDbType.Int);
            SqlParametros.Value = proveedor.Id_Proveedor;
        }

        public void ArmarParametrosProveedor(ref SqlCommand comando, Proveedor prov)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@ID_PROVEEDOR_PROV", SqlDbType.Int);
            parametros.Value = prov.Id_Proveedor;
            parametros = comando.Parameters.Add("@CUIT_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Cuit;
            parametros = comando.Parameters.Add("@Nombre_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Nombre;
            parametros = comando.Parameters.Add("@Mail_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Mail;
            parametros = comando.Parameters.Add("@Direccion_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Ciudad;
            parametros = comando.Parameters.Add("@Ciudad_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Ciudad;
            parametros = comando.Parameters.Add("@Id_Provincia_Prov", SqlDbType.Char);
            parametros.Value = prov.Provincia.Id_Provincia;
            parametros = comando.Parameters.Add("@Telefono_Proveedor_Prov", SqlDbType.Char);
            parametros.Value = prov.Telefono;
            parametros = comando.Parameters.Add("@Estado_Proveedor_Prov", SqlDbType.Bit);
            parametros.Value = prov.Estado;

        }

        public bool EliminarProveedor(Proveedor proveedor)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProveedoresEliminar(ref cmd, proveedor);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarProveedor");
            if (filasModificadas == 1)
            {
                return true;
            }
            return false;
        }

        public bool ActualizarProveedor(Proveedor prov)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProveedor(ref cmd, prov);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_ActualizarProveedor");
            if (filasModificadas == 1)
            {
                return true;
            }
            return false;
        }
    }
}
