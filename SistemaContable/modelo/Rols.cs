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

        public int IdRol
        {
            get { return id_rol; }
            set { id_rol = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public List<Rols> ListaRoles
        {
            get { return listaRoles; }
            set { listaRoles = value; }
        }



    }
}
