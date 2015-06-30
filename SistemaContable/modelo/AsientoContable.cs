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
        private string estado;
        private List<AsientoContable> listaAsiento;


        public string IDUSUARIO
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public string IDASIENTO
        {
            get { return id_asiento; }
            set { id_asiento = value; }
        }
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
