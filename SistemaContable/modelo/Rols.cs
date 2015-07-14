using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Rols
    {
        private int id_rol;
        private string tipo;
        private List<Rols> listaRoles = new List<Rols>();

        /// <summary>
        /// Propiedad para obtener o fijar el id_rol
        /// </summary>
        public int IdRol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el tipo
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar un listado de Rols
        /// </summary>
        public List<Rols> ListaRoles
        {
            get { return listaRoles; }
            set { listaRoles = value; }
        }



    }
}
