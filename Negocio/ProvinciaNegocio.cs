using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao;
using System.Data;
using Entidades;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        ProvinciaDao pDao = new ProvinciaDao();
        public DataSet traerProvincias()
        {
            DataSet provincias = pDao.tablaProvincias();

            return provincias;
        }

        public DataSet tablaProvinciasEstado1()
        {

            DataSet ds = pDao.tablaProvinciasEstado1();

            return ds;
        }
        public int AgregarProvincia(String provincia)
        {
            int filasAfectadas = pDao.AgregarProvincia(provincia);
            return filasAfectadas;
        }
        public DataTable getTabla()
        {
            return pDao.getTablaProvincias();
        }

        public bool EliminarProvincia(Provincia prov)
        {
            return pDao.EliminarProvincia(prov);
        }

        public int bajaProvincia(int id)
        {

            int filasAfectadas = pDao.bajaProvincia(id);

            return filasAfectadas;
        }

        public bool ActualizaProvincia(Provincia prov)
        {
            return pDao.ActualizarProvincia(prov);
        }
        public bool ChequeoProvincias(DataTable tabla, Provincia pr)
        {
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["Id_Provincia_Pr"].ToString().Trim().Equals(pr.Id_Provincia))
                {
                    return true;
                }

            }
            return false;
        }

        public bool existeIdProvincia(int id)
        {
            return pDao.existeIdProvincia(id);

        }

        public Provincia traerProvincia(int id)
        {
            DataSet ds = pDao.traerProvincia(id);
            Provincia p = new Provincia();
            try
            {
                p.Id_Provincia = Convert.ToInt32(ds.Tables["Provincia"].Rows[0]["Id_Provincia_Pr"].ToString());
                p.Descripcion_Provincia = ds.Tables["Provincia"].Rows[0]["Descripcion_Provincia_Pr"].ToString();
            }
            catch
            {
                return null;
            }
            
            return p;
        }

        public Provincia traerProvincia(String id)
        {
            DataSet ds = pDao.traerProvincia(id);
            Provincia p = new Provincia();
            p.Id_Provincia = Convert.ToInt32(ds.Tables["Provincia"].Rows[0]["Id_Provincia_Pr"].ToString());
            p.Descripcion_Provincia = ds.Tables["Provincia"].Rows[0]["Descripcion_Provincia_Pr"].ToString();
            return p;
        }
    }
}
