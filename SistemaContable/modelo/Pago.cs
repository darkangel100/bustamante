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

        /// <summary>
        /// Propiedad para obtener o fijar el id_pago
        /// </summary>
        public string IDPAGO
        {
            get { return id_pago; }
            set { id_pago = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la fecha_ingreso
        /// </summary>
        public string FECHA
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el monto
        /// </summary>
        public double MONTO
        {
            get { return monto; }
            set { monto = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de pagos
        /// </summary>
        public List<Pago> LISTAPAGO
        {
            get { return listapago; }
            set { listapago = value; }
        }
    }
}
