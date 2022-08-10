using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class Ventas
    {
        int num_Factura;
        string dni_Usuario;
        DateTime fecha;
        float monto_Total;

        public Ventas()
        {
        }
         public Ventas(int num_Factura, string dni_Usuario, DateTime fecha, float monto_Total)
         {
            this.Num_Factura = num_Factura;
            this.Dni_Usuario = dni_Usuario;
            this.Fecha = fecha;
            this.Monto_Total = monto_Total;
         }

        public int Num_Factura { get => num_Factura; set => num_Factura = value; }
        public string Dni_Usuario { get => dni_Usuario; set => dni_Usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Monto_Total { get => monto_Total; set => monto_Total = value; }
    }
}
