using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Proveedor
    {
        private int idDistri;

        public int IdDistri
        {
            get { return idDistri; }
            set { idDistri = value; }
        }
        private int idProveedor;

        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string tiempo;

        public string Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private List<Proveedor> listaProveedor;

        public List<Proveedor> ListaProveedor
        {
            get { return listaProveedor; }
            set { listaProveedor = value; }
        }
    }
}
