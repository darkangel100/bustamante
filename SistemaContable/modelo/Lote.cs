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

        public string CODLOTE
        {
            get { return codLote; }
            set { codLote = value; }
        }
        public string IDPRODUCTO
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string STOCKUNIDADES
        {
            get { return stock_unidades; }
            set { stock_unidades = value; }
        }
        public string FECHAVENCIMINTO
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }
        public string FECHAELABORACION
        {
            get { return fechaElaboracion; }
            set { fechaElaboracion = value; }
        }
        public List<Lote> LISTALOTE
        {
            get { return listalote; }
            set { listalote = value; }
        }
    }
}
