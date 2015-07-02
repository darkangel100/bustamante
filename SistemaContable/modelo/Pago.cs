using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Pago
    {
        private string id_pago;
        private string fecha_ingreso;
        private double monto;
        private List<Pago> listapago;

        public string IDPAGO
        {
            get { return id_pago; }
            set { id_pago = value; }
        }
        public string FECHA
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }
        public double MONTO
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
