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
    public class ProveedorNegocio
    {
        ProveedorDao ProvDao = new ProveedorDao();
        ProvinciaNegocio prDao = new ProvinciaNegocio();
        public int AgregarProveedor(Proveedor proveedor)
        {
            int filasAfectadas = ProvDao.AgregarProveedor(proveedor);
            return filasAfectadas;
        }

        public DataTable getTabla()
        {
            ProveedorDao dao = new ProveedorDao();
            return dao.getTablaProveedores();
        }

        public bool ChequeoProveedores(DataTable tabla, Proveedor pr)
        {
            foreach (DataRow dr in tabla.Rows)
            {
                if (dr["CUIT_Proveedor_Prov"].ToString().Trim().Equals(pr.Cuit))
                {
                    return true;
                }

            }
            return false;
        }

        public bool existeIdProveedor(int id)
        {
            return ProvDao.existeIdProveedor(id);

        }

        //NUEVO ULTIMA VERSION
        public DataSet BuscarProveedor(int id)
        {
            return ProvDao.BuscarProveedor(id);
        }
        public DataSet BuscarProveedoresXNombre(String nombre)
        {
            return ProvDao.BuscarProveedoresXNombre(nombre);
        }
        
        public Proveedor traerProveedor(int id)
        {
            DataSet ds = ProvDao.BuscarProveedor(id);
            Proveedor pr = new Proveedor();
            pr.Id_Proveedor = Convert.ToInt32(ds.Tables["Proveedor"].Rows[0]["Id_Proveedor_Prov"].ToString());
            pr.Cuit = ds.Tables["Proveedor"].Rows[0]["CUIT_Proveedor_Prov"].ToString();
            pr.Nombre = ds.Tables["Proveedor"].Rows[0]["Nombre_Proveedor_Prov"].ToString();
            pr.Mail = ds.Tables["Proveedor"].Rows[0]["Mail_Proveedor_Prov"].ToString();
            pr.Direccion = ds.Tables["Proveedor"].Rows[0]["Direccion_Proveedor_Prov"].ToString();
            pr.Ciudad = ds.Tables["Proveedor"].Rows[0]["Ciudad_Proveedor_Prov"].ToString();
            pr.Provincia = prDao.traerProvincia(Convert.ToInt32(ds.Tables["Proveedor"].Rows[0]["Id_Provincia_Prov"].ToString()));
            pr.Telefono = ds.Tables["Proveedor"].Rows[0]["Telefono_Proveedor_Prov"].ToString();
            pr.Estado = Convert.ToBoolean(ds.Tables["Proveedor"].Rows[0]["Estado_Proveedor_Prov"].ToString());

            return pr;
        }

        public bool EliminarProveedor(Proveedor prov)
        {
            return ProvDao.EliminarProveedor(prov);
        }

        public int bajaProveedor(int id)
        {
            int filasAfectadas = ProvDao.bajaProveedor(id);

            return filasAfectadas;
        }

        public bool ActualizaProveedor(Proveedor prov)
        {
            return ProvDao.ActualizarProveedor(prov);
        }

    }
}
