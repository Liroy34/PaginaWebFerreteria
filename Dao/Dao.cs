using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public abstract class Dao
    {
        private String rutaBD =
          "Data Source=localhost\\sqlexpress;Initial Catalog=TI_FERRETERIAS;Integrated Security=True";
        
        public DataSet traerDatos(String consulta, String tabla)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaBD);
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            cn.Open();
            adaptador.Fill(ds, tabla);
            cn.Close();

            return ds;
        }

        public int agregarModificarEliminar(String consulta)
        {
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();
            SqlCommand comando = new SqlCommand(consulta, cn);
            int filasAfectadas = comando.ExecuteNonQuery();
            cn.Close();
            return filasAfectadas;
        }

        public DataTable ObtenerTabla(String NombreTabla, String consulta)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaBD);
            SqlDataAdapter adp = new SqlDataAdapter(consulta, cn);
            cn.Open();
            adp.Fill(ds, NombreTabla);
            cn.Close();
            return ds.Tables[NombreTabla];
        }

        public bool existeID(String consulta, String tabla)
        {
            DataSet ds = new DataSet();
            SqlConnection cn = new SqlConnection(rutaBD);
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, cn);
            cn.Open();
            adaptador.Fill(ds, tabla);
            cn.Close();


            if (ds.Tables[tabla].Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        //NUEVO UTLIMA VERSION
        public SqlDataReader FiltrarPorCUIT(String consulta)
        {

            SqlConnection cn = new SqlConnection(rutaBD);
            SqlCommand cmd = new SqlCommand(consulta, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }

        public int EjecutarProcedimientoAlmacenado(SqlCommand comando, String NombreSP)
        {
            int filasCambiadas;
            SqlConnection cn = new SqlConnection(rutaBD);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            filasCambiadas = cmd.ExecuteNonQuery();
            cn.Close();
            return filasCambiadas;
        }
    }
}
