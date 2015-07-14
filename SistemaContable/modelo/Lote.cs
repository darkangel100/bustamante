using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Lote
    {
        private string codLote;
        private string id_producto;
        private string descripcion;
        private string stock_unidades;
        private string fechaVencimiento;
        private string fechaElaboracion;
        private List<Lote> listalote;

        /// <summary>
        /// Propiedad para obtener o fijar el codLote
        /// </summary>
        public string CODLOTE
        {
            get { return codLote; }
            set { codLote = value; }
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
        /// Propiedad para obtener o fijar la descripcion
        /// </summary>
        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el stock_unidades
        /// </summary>
        public string STOCKUNIDADES
        {
            get { return stock_unidades; }
            set { stock_unidades = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la fechaVencimiento
        /// </summary>
        public string FECHAVENCIMINTO
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar l fechaElaboracion
        /// </summary>
        public string FECHAELABORACION
        {
            get { return fechaElaboracion; }
            set { fechaElaboracion = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de lotes
        /// </summary>
        public List<Lote> LISTALOTE
        {
            get { return listalote; }
            set { listalote = value; }
        }
    }
}
