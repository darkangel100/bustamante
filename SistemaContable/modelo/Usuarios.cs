using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Usuarios
    {
        //Atributos
        private int Id_Usu;

        private int Id_Rol;

        private string Ced_Usu;
        private string Nom_Usu;
        private string Ape_Usu;

        private string Tel_Usu;
        private string Dir_Usu;

        private List<Usuarios> listaUsuarios = new List<Usuarios>();

        /// <summary>
        /// Propiedad para obtener o fijar el Id_Usu
        /// </summary>
        public int IdUsu
        {
            get { return Id_Usu; }
            set { Id_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el Id_Rol
        /// </summary>
        public int IdRol
        {
            get { return Id_Rol; }
            set { Id_Rol = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la Ced_Usu
        /// </summary>
        public string CedUsu
        {
            get { return Ced_Usu; }
            set { Ced_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el Nom_Usu
        /// </summary>
        public string NomUsu
        {
            get { return Nom_Usu; }
            set { Nom_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el Ape_Usu
        /// </summary>
        public string ApeUsu
        {
            get { return Ape_Usu; }
            set { Ape_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar el Tel_Usu
        /// </summary>
        public string TelUsu
        {
            get { return Tel_Usu; }
            set { Tel_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar la Dir_Usu
        /// </summary>
        public string DirUsu
        {
            get { return Dir_Usu; }
            set { Dir_Usu = value; }
        }

        /// <summary>
        /// Propiedad para obtener o fijar una lista de usuarios
        /// </summary>
        public List<Usuarios> ListaUsuarios
        {
            get { return listaUsuarios; }
            set { listaUsuarios = value; }
        }

    }
}
