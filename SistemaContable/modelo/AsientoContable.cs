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

        /// <summary>
        /// Propiedad para obtener o fijar el id_usuario
        /// </summary>
        public string IDUSUARIO
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el id_asiento
        /// </summary>
        public string IDASIENTO
        {
            get { return id_asiento; }
            set { id_asiento = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el nombre_asiento
        /// </summary>
        public string NOMBRE_ASIENTO
        {
            get { return nombre_asiento; }
            set { nombre_asiento = value; }
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
        /// Propiedad para obtener o fijar el estado
        /// </summary>
        public string ESTADO
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de asientos
        /// </summary>
        public List<AsientoContable> LISTAASIENTO
        {
            get { return listaAsiento; }
            set { listaAsiento = value; }
        }
        
    }
}
