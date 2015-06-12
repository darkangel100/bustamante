using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class AsientoContable
    {
        private string id_usuario;
        private string id_asiento;
        private string nombre_asiento;
        private string descripcion;
        private List<AsientoContable> listaAsiento;

        //public string IDUSUARIO
        //{
        //    get { return idusuario; }
        //    set { idusuario = value; }
        //}
        //public string IDASIENTO
        //{
        //    get { return idasiento; }
        //    set { idasiento = value; }
        //}
        public string NOMBRE_ASIENTO
        {
            get { return nombre_asiento; }
            set { nombre_asiento = value; }
        }
        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        public List<AsientoContable> LISTAASIENTO
        {
            get { return listaAsiento; }
            set { listaAsiento = value; }
        }
        
    }
}
