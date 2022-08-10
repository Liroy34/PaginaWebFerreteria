using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Dao
{
    public class VentasDao : Dao
    {
        String tabla = "Ventas";

        public DataSet traerDatos()
        {
            String consulta = "SELECT * FROM Ventas";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }

        public DataSet traerDatos(String id)
        {
            String consulta = "SELECT * FROM Ventas WHERE DNI_Usuario_V = '" + id + "'";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }


        public int AgregarVenta(string ID, double Monto)
        {
            String consulta =
               "EXEC SP_agregarVentas '" + ID + "', '" + Monto.ToString().Replace(",",".") + "'";

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }
        public DataSet traerIdUltimaFactura()
        {
            String consulta = "SELECT TOP 1 Num_Factura_V  FROM Ventas ORDER BY Num_Factura_V DESC";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }
    }
}