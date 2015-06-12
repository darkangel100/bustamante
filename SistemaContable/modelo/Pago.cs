using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Pago
    {
      
        private string fecha_ingreso;
        private string monto;
        private List<Pago> listapago;

      
        public string FECHA
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }
        public string MONTO
        {
            get { return monto; }
            set { monto = value; }
        }
        public List<Pago> LISTAPAGO
        {
            get { return listapago; }
            set { listapago = value; }
        }
    }
}
