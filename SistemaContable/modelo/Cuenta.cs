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

        public int IdUsuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Contrasenia
        {
            get { return contrasenia; }
            set { contrasenia = value; }
        }
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        public List<Cuenta> ListaCuentas
        {
            get { return listaCuentas; }
            set { listaCuentas = value; }
        }

    }
}
