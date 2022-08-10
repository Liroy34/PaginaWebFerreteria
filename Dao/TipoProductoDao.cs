using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Dao
{
    public class TipoProductoDao : Dao
    {
        public DataSet tablaTipoProducto()
        {
            String consulta = "SELECT * FROM Tipo_Producto";
            String tabla = "Tipo_Producto";
            DataSet resultado = traerDatos(consulta, tabla);

            return resultado;
        }
        public DataSet tablaTipoProductoEstado1()
        {
            String consulta = "SELECT * FROM Tipo_Producto WHERE Estado_Tipo_Producto_T = 1";
            String tabla = "Tipo_Producto";
            DataSet resultado = traerDatos(consulta, tabla);

            return resultado;
        }
        public int AgregarTipoProducto(String tp)
        {
            String consulta =
               "INSERT INTO Tipo_Producto(Descripcion_Tipo_Producto_T)" +
               " values('" + tp + "')";

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }
        
        public void ArmarParametrosTipoDeProductoEliminar(ref SqlCommand comando, TipoProducto tp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@ID_TIPO_PRODUCTO_T", SqlDbType.Int);
            SqlParametros.Value = tp.Id_TipoProducto;
        }
        public bool EliminarTipoDeProducto(TipoProducto tp)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosTipoDeProductoEliminar(ref cmd, tp);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_EliminarTipoDePoducto");
            if (filasModificadas == 1)
            {
                return true;
            }
            return false;
        }
        public void ArmarParametrosTipoDeProducto(ref SqlCommand comando, TipoProducto tp)
        {
            SqlParameter parametros = new SqlParameter();
            parametros = comando.Parameters.Add("@ID_TIPO_PRODUCTO_T", SqlDbType.Int);
            parametros.Value = tp.Id_TipoProducto;
            parametros = comando.Parameters.Add("@DESCRIPCION_TIPO_PRODUCTO_T", SqlDbType.Text);
            parametros.Value = tp.Descripcion;
            parametros = comando.Parameters.Add("@Estado_Tipo_Producto_T", SqlDbType.Bit);
            parametros.Value = tp.Estado;
        }

        public bool ActualizarTipoDeProducto(TipoProducto tp)
        {
            SqlCommand cmd = new SqlCommand();
            ArmarParametrosTipoDeProducto(ref cmd, tp);
            int filasModificadas = EjecutarProcedimientoAlmacenado(cmd, "SP_ActualizarTipoDeProducto");
            if (filasModificadas == 1)
                return true;
            else
                return false;
        }
        public bool existeIdTipoDeProducto(int ID)
        {
            String consulta = "SELECT * FROM Tipo_Producto WHERE Id_Tipo_Producto_T = " + ID + "";
            String tabla = "Tipo_Producto";
            return existeID(consulta, tabla);
        }
        public DataTable getTablaTipoDeProducto()
        {
            DataTable Tabla = ObtenerTabla("Tipo_Producto", "Select * FROM Tipo_Producto");
            return Tabla;
        }

        public DataSet traerTipoProducto(int ID)
        {
            String consulta = "SELECT * FROM Tipo_Producto WHERE Id_Tipo_Producto_T = " + ID + "";
            String tabla = "Tipo_Producto";
            return traerDatos(consulta, tabla);
        }

        public int bajaTipoProducto(int id)
        {
            String consulta = "Update Tipo_Producto set Estado_Tipo_Producto_T = 0 WHERE Id_Tipo_Producto_T  = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }
    }
}
