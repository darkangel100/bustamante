using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Distribuidora
    {
        private int id;

        /// <summary>
        /// Propiedad del atributo Id ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nombre;

        /// <summary>
        /// Propiedad del atributo Nombre ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string direccion;

        /// <summary>
        /// Propiedad de la atributo Direccion ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        private string telefono;

        /// <summary>
        /// Propiedad del atributo Telefono ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string estado;

        /// <summary>
        /// Propiedad del atributo Estado ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private List<Distribuidora> listaDistribuidora;

        /// <summary>
        ///  Propiedad del atributo listaDistribuidora ya sea para la obtencion del listado o asignacion de una lista de tipo Distribuidora
        /// </summary>
        public List<Distribuidora> ListaDistribuidora
        {
            get { return listaDistribuidora; }
            set { listaDistribuidora = value; }
        }
    }
}
