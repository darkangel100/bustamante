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

        /// <summary>
        /// Propiedad para obtener o fijar el id_factura
        /// </summary>
        public string IDFACTURA
        {
            get { return id_factura; }
            set { id_factura = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el id_producto
        /// </summary>
        public string IDPRODUCTO
        {
            get { return id_producto; }
            set { id_producto = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar ls cantidad
        /// </summary>
        public string CANTIDAD
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el nombre_producto
        /// </summary>
        public string NOMBREPRODUCTO
        {
            get { return nombre_producto; }
            set { nombre_producto = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el conto_unitario
        /// </summary>
        public string COSTOUNITARIO
        {
            get { return costo_unitario; }
            set { costo_unitario = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fija el costo_total
        /// </summary>
        public string COSTOTOTAL
        {
            get { return costo_total; }
            set { costo_total = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de DetalleFactura
        /// </summary>
        public List<DetalleFactura> LISTADETALLE
        {
            get { return listadetallefa; }
            set { listadetallefa = value; }
        }
    }
}
