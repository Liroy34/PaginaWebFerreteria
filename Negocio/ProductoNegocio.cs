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
    public class ProductoNegocio
    {
        ProductoDao pDao = new ProductoDao();
        public int AgregarProducto(Producto producto)
        {

            int filasAfectadas = pDao.AgregarProducto(producto);

            return filasAfectadas;
        }

        public bool existeIdProducto(int id)
        {
            return pDao.existeIdProducto(id);
        }

        public DataSet traerDatosProductos()
        {
            DataSet ds = pDao.traerDatos();
            return ds;
        }

        public DataSet traerDatosProductos(int id)
        {
            DataSet ds = pDao.traerDatos(id);
            return ds;
        }
        public DataSet traerDatosProductos(String nombre)
        {
            DataSet ds = pDao.traerDatos(nombre);
            return ds;
        }

        public int bajaProducto(int id)
        {
            int filasAfectadas = pDao.bajaProducto(id);

            return filasAfectadas;
        }

        public int actualizarProducto(Producto p)
        {
            int filasAfectadas = pDao.actualizarProducto(p);
            return filasAfectadas;
        }



    }
}
