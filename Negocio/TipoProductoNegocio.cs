using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using Entidades;

namespace Negocio
{
    public class TipoProductoNegocio
    {
        TipoProductoDao tpdao = new TipoProductoDao();
        public DataSet traerTipoProductos()
        {
            DataSet provincias = tpdao.tablaTipoProducto();

            return provincias;
        }
        public DataSet traerTipoProductosEstado1()
        {
            DataSet provincias = tpdao.tablaTipoProductoEstado1();

            return provincias;
        }
        public int AgregarTipoProducto(String tp)
        {
            int filasAfectadas = tpdao.AgregarTipoProducto(tp);
            return filasAfectadas;
        }
        
        public bool ActualizaTipoDeProducto(TipoProducto tp)
        {
            return tpdao.ActualizarTipoDeProducto(tp);
        }
        public bool ChequeoTipoDeProducto(DataTable tabla, TipoProducto tp)
        {
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Id_Tipo_Producto_T"].ToString().Trim().Equals(tp.Id_TipoProducto))
                {
                    return true;
                }

            }
            return false;
        }
        public DataTable getTabla()
        {
            TipoProductoDao dao = new TipoProductoDao();
            return dao.getTablaTipoDeProducto();
        }

        public bool existeIdTipoDeProducto(int Id)
        {
            return tpdao.existeIdTipoDeProducto(Id);

        }

        public TipoProducto traerTipoProducto(int id)
        {
            DataSet ds = tpdao.traerTipoProducto(id);
            TipoProducto tp = new TipoProducto();
            tp.Id_TipoProducto = Convert.ToInt32(ds.Tables["Tipo_Producto"].Rows[0]["Id_Tipo_Producto_T"].ToString());
            tp.Descripcion = ds.Tables["Tipo_Producto"].Rows[0]["Descripcion_Tipo_Producto_T"].ToString();
            return tp;
        }

        public int bajaTipoProducto(int id)
        {

            int filasAfectadas = tpdao.bajaTipoProducto(id);

            return filasAfectadas;
        }
    }
}
