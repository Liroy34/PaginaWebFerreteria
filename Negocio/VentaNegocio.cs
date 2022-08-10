using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using Dao;

namespace Negocio
{
    public class VentaNegocio
    {
        VentasDao VDao = new VentasDao();

        public DataSet traerDatosVentas()
        {
            DataSet ds = VDao.traerDatos();
            return ds;
        }

        public DataSet traerDatosVentas(string id)
        {
            DataSet ds = VDao.traerDatos(id);
            return ds;
        }

        public int AgregarVenta(string DNI, double Monto)
        {

            int filasAfectadas = VDao.AgregarVenta(DNI, Monto);

            return filasAfectadas;
        }

        public int traerIdUltimaFactura()
        {
            DataSet ds = VDao.traerIdUltimaFactura();
            int id = Convert.ToInt32(ds.Tables["Ventas"].Rows[0]["Num_Factura_V"].ToString());
            return id;
        }
    }
}