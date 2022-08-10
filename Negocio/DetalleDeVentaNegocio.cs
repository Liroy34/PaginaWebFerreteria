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
    public class DetalleDeVentaNegocio
    {
        DetallesDeVentaDao DVDao = new DetallesDeVentaDao();
        public DataSet traerDatosDetalleDeVenta(string id)
        {
            DataSet ds = DVDao.traerDatos(id);
            return ds;
        }

        public DataSet traerDatosDetalleDeVentaFiltrado(String consulta, String Tabla)
        {
            DataSet ds = DVDao.traerDatosFiltrados(consulta, Tabla);
            return ds;
        }

        public int AgregarDetalleDeVenta(int NumFac, int IdProd, double Precio, int Cant)
        {

            int filasAfectadas = DVDao.AgregarDetalleDeVenta(NumFac,IdProd,Precio,Cant);

            return filasAfectadas;
        }
    }
}
