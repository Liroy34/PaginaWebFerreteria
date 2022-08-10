using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Dao
{
    public class ProductoDao : Dao
    {
        
        String tabla = "Productos";
        public int AgregarProducto(Producto producto)
        {
            String consulta =
               "insert into Productos(Descripcion_Producto_P,Id_Proveedor_P,Precio_Unitario_P,Nombre_Producto_P,Id_Tipo_Producto_P,Imagen_Producto_P,Stock_Producto_P,Estado_P)" +
               " values('" + producto.Descipcion + "'," + producto.Proveedor.Id_Proveedor + "," +
               producto.Precio_Unitario + ",'" + producto.Nombre + "','" +
               producto.TipoProducto.Id_TipoProducto + "','" + producto.Url_imagen + "'," +
               producto.Stock + "," + Convert.ToByte(producto.Estado) + ");";

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public int eliminarProducto(int id)
        {
            String consulta = "DELETE FROM Productos WHERE Id_Producto_P = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public int bajaProducto(int id)
        {
            String consulta = "Update Productos set Estado_P = 0 WHERE Id_Producto_P = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public int altaProducto(int id)
        {
            String consulta = "Update Productos set Estado = true WHERE Id_Producto_P = " + id;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }

        public bool existeIdProducto(int id)
        {
            String consulta = "SELECT * FROM Productos WHERE Id_Producto_P = " + id + "";

            return existeID(consulta, tabla);

        }

        public DataSet traerDatos()
        {
            String consulta = "SELECT * FROM Productos";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }

        public DataSet traerDatos(int id)
        {
            String consulta = "SELECT * FROM Productos WHERE Id_Producto_P = " + id + "";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }
        public DataSet traerDatos(String nombre)
        {
            String consulta = "SELECT * FROM Productos WHERE Nombre_Producto_P LIKE '%" + nombre + "%'";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }

        public int actualizarProducto(Producto p)
        {
            String consulta = "UPDATE Productos SET Descripcion_Producto_P = '" + p.Descipcion
                + "',Id_Proveedor_P = " + p.Proveedor.Id_Proveedor + ", Precio_Unitario_P = "
                + p.Precio_Unitario.ToString().Replace(",", ".") + ",Nombre_Producto_P = '" + p.Nombre +
                "',Id_Tipo_Producto_P  = '" + p.TipoProducto.Id_TipoProducto + "', Imagen_Producto_P = '" +
                p.Url_imagen + "', Stock_Producto_P  = " + p.Stock +
                ", Estado_P   = " + Convert.ToByte(p.Estado) + " WHERE Id_Producto_P = " + p.Id_Producto;

            int filasAfectadas = agregarModificarEliminar(consulta);
            return filasAfectadas;
        }

    }
}
