using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class DetalleFactura
    {
        private string id_factura;
        private string id_producto;
        private string cantidad;
        private string nombre_producto;
        private string costo_unitario;
        private string costo_total;
        private List<DetalleFactura> listadetallefa;

        public string IDFACTURA
        {
            get { return id_factura; }
            set { id_factura = value; }
        }
        public string IDPRODUCTO
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        public string CANTIDAD
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string NOMBREPRODUCTO
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }
        public string COSTOUNITARIO
        {
            get { return costo_unitario; }
            set { costo_unitario = value; }
        }
        public string COSTOTOTAL
        {
            get { return costo_total; }
            set { costo_total = value; }
        }
        public List<DetalleFactura> LISTADETALLE
        {
            get { return listadetallefa; }
            set { listadetallefa = value; }
        }
    }
}
