using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using System.Data.SqlClient;

namespace Dao
{
    public class ProvinciaDao : Dao
    {
        public DataSet tablaProvincias()
         {
            String consulta = "SELECT * FROM Provincias";
            String tabla = "Provincias";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
         }

        public DataSet tablaProvinciasEstado1()
        {
            String consulta = "SELECT * FROM Provincias WHERE Estado_Provincia_Pr = 1";
            String tabla = "Provincias";

            DataSet ds = traerDatos(consulta, tabla);

            return ds;
        }

        public int AgregarProvincia(String provincia)
        {
            try
            {
                String consulta =
               "INSERT INTO Provincias(Descripcion_Provincia_Pr)" +
               " values('" + provincia + "')";

                int filasAfectadas = agregarModificarEliminar(consulta);
                return filasAfectadas;
            }
            catch
            {
                return 0;
            }
            

           
        }

        public DataTable getTablaProvincias()
        {
            DataTable Tabla = ObtenerTabla("Provincias", "Select * FROM Provincias");
            return Tabla;
        }
        public void ArmarParametrosProvinciaEliminar(ref SqlCommand comando, Provincia prov)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_PROVINCIA_PR", SqlDbType.Int);
            SqlParametros.Value = prov.Id_Provincia;
        }
        public bool EliminarProvincia(Provincia prov)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProvinciaEliminar(ref cmd, prov);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarProvincia");
            if (filasModificadas == 1)
            {
                return true;
            }
            return false;
        }

        public int bajaProvincia(int id)
        {
            String consulta = "Update Provincias set Estado_Provincia_Pr = 0 WHERE Id_Provincia_Pr = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public void ArmarParametrosProvincia(ref SqlCommand comando, Provincia prov)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@ID_PROVINCIA_PR", SqlDbType.Int);
            parametros.Value = prov.Id_Provincia;
            parametros = comando.Parameters.Add("@DESCRIPCION_PROVINCIA_PR", SqlDbType.Char);
            parametros.Value = prov.Descripcion_Provincia;
            parametros = comando.Parameters.Add("@Estado_Provincia_Pr", SqlDbType.Char);
            parametros.Value = prov.Estado;
        }

        public bool ActualizarProvincia(Provincia prov)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosProvincia(ref cmd, prov);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_ActualizarProvincia");
            if (filasModificadas == 1)
                return true;
            else
                return false;
        }
        public bool existeIdProvincia(int ID)
        {
            String consulta = "SELECT * FROM Provincias WHERE Id_Provincia_Pr = " + ID + "";
            String tabla = "Provincias";
            return existeID(consulta, tabla);
        }

        public DataSet traerProvincia(int ID)
        {
            String consulta = "SELECT * FROM Provincias WHERE Id_Provincia_Pr = " + ID + "";
            String tabla = "Provincia";
            return traerDatos(consulta, tabla);
        }

        public DataSet traerProvincia(String n)
        {
            String consulta = "SELECT * FROM Provincias WHERE Descripcion_Provincia_Pr = " + n + "";
            String tabla = "Provincia";
            return traerDatos(consulta, tabla);
        }
    }
}
