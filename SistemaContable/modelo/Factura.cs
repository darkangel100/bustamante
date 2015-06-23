using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Factura
    {
        private string id_proveedor;
        private string id_factura;
        private string fecha;
        private string total;
        private string subtotal;
        private string iva;
        private string tipo_fac;
        private List<Factura> listaFactura;


        public string IDPROVEEDOR
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }
        public string IDFACTURA
        {
            get { return id_factura; }
            set { id_factura = value; }
        }
        public string FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public string TOTAL
        {
            get { return total; }
            set { total = value; }
        }
        public string SUBTOTAL
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        public string IVA
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
