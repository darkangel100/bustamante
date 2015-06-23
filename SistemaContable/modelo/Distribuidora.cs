using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Distribuidora
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private List<Distribuidora> listaDistribuidora;

        public List<Distribuidora> ListaDistribuidora
        {
            get { return listaDistribuidora; }
            set { listaDistribuidora = value; }
        }
    }
}
