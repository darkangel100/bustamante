using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Factura
    {
        private int id_proveedor;
        private int id_factura;
        private string fecha;
        private double total;
        private double subtotal;
        private double iva;
        private string tipo_fac;
        private List<Factura> listaFactura;

        /// <summary>
        /// Propiedad para obtener o fijar el id_proveedor
        /// </summary>
        public int IDPROVEEDOR
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el id_factura
        /// </summary>
        public int IDFACTURA
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la fecha
        /// </summary>
        public string FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el total
        /// </summary>
        public double TOTAL
        {
            get { return total; }
            set { total = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el subtotal
        /// </summary>
        public double SUBTOTAL
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el iva
        /// </summary>
        public double IVA
        {
            get { return iva; }
            set { iva = value; }
        }
        public string TIPOFACTURA
        {
            get { return tipo_fac; }
            set { tipo_fac = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de Facturas
        /// </summary>
        public List<Factura> LISTAFACTURA
        {
            get { return listaFactura; }
            set { listaFactura = value; }
        }
    }
}
