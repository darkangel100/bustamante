using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Pago
    {
        private string idpado;
        private string fecha;
        private string monto;
        private List<Pago> listapago;

        public string IDPAGO
        {
            get { return idpado; }
            set { idpado = value; }
        }
        public string FECHA
        {
            get { return fecha; }
            set { fecha = value; }
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
