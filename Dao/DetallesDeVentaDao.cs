using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Dao
{
    public class DetallesDeVentaDao : Dao
    {
        String tabla = "Detalle_De_Venta";

        public DataSet traerDatos(String id)
        {
            String consulta = "SELECT * FROM Detalle_De_Venta WHERE Num_Factura_DV = '" + id + "'";
            DataSet ds = traerDatos(consulta, tabla);
            return ds;
        }

        public DataSet traerDatosFiltrados(String consulta, String Tabla)
        {
            DataSet ds = traerDatos(consulta, Tabla);
            return ds;
        }
        public int AgregarDetalleDeVenta(int NumFac, int IdProd, double Precio, int Cant)
        {
            String consulta =
               "EXEC SP_agregarDetalleDeVentas '" + NumFac + "', '" + IdProd + "', '" + Precio.ToString().Replace(",", ".") + "', '" + Cant + "'"; ;

            int filasAfectadas = agregarModificarEliminar(consulta);

            return filasAfectadas;
        }
    }
}
