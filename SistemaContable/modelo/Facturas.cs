using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Facturas
    {

        private int id_proveedor;
        private int id_factura;
        private string fecha;
        private double total;
        private double subtotal;
        private double iva;
        private string tipo_fac;
        private List<Facturas> listaFacturas;

        
        public int Id_Proveedor
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }
        public int Id_Factura
        {
            get { return id_factura; }
            set { id_factura = value; }
        }
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public double SubTotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        public double Iva
        {
            get { return iva; }
            set { iva = value; }
        }
        public string Tipo_fac
        {
            get { return tipo_fac; }
            set { tipo_fac = value; }
        }
        public List<Facturas> LISTAFACTURAS
        {
            get { return listaFacturas; }
            set { listaFacturas = value; }
        }
    }
}
