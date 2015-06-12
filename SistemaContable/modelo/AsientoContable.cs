using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class AsientoContable
    {
        private string idusuario;
        private string idasiento;
        private string nombreasiento;
        private string descripcion;
        private string tipo;
        private string estado;
        private List<AsientoContable> listaAsiento;

        public string IDUSUARIO
        {
            get { return idusuario; }
            set { idusuario = value; }
        }
        public string IDASIENTO
        {
            get { return idasiento; }
            set { idasiento = value; }
        }
        public string NOMBREASIENTO
        {
            get { return nombreasiento; }
            set { nombreasiento = value; }
        }
        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public string TIPO
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string ESTADO
        {
            get { return estado; }
            set { estado = value; }
        }
        public List<AsientoContable> LISTAASIENTO
        {
            get { return listaAsiento; }
            set { listaAsiento = value; }
        }
        
    }
}
