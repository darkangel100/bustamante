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


        public int IDPROVEEDOR
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }
        public int IDFACTURA
        {
            get { return id_factura; }
            set { id_factura = value; }
        }
        public string FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public double TOTAL
        {
            get { return total; }
            set { total = value; }
        }
        public double SUBTOTAL
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
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
        public List<Factura> LISTAFACTURA
        {
            get { return listaFactura; }
            set { listaFactura = value; }
        }
    }
}
