using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Cuenta
    {
        private int id_usuario;
        private string usuario;
        private string contrasenia;
        private string estado;

        private List<Cuenta> listaCuentas = new List<Cuenta>();

        /// <summary>
        /// Propiedad para obtener o fijar el id_usuario
        /// </summary>
        public int IdUsuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el usuario
        /// </summary>
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la contrasenia
        /// </summary>
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el estado
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de cuentas de usuario
        /// </summary>
        public List<Cuenta> ListaCuentas
        {
            get { return listaCuentas; }
            set { listaCuentas = value; }
        }

    }
}
