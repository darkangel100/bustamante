using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaContable.modelo
{
    class Proveedor
    {
        private int idDistri;

        /// <summary>
        ///  Propiedad del atributo idDistri ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public int IdDistri
        {
            get { return idDistri; }
            set { idDistri = value; }
        }
        private int idProveedor;

        /// <summary>
        ///  Propiedad del atributo idProveedor ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public int IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }
        private string nombre;

        /// <summary>
        ///  Propiedad del atributo Nombre ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string correo;

        /// <summary>
        ///  Propiedad del atributo Correo ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        private string celular;

        /// <summary>
        ///  Propiedad del atributo Celular ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string tiempo;

        /// <summary>
        ///  Propiedad del atributo Tiempo ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Tiempo
        {
            get { return tiempo; }
            set { tiempo = value; }
        }
        private string estado;

        /// <summary>
        ///  Propiedad del atributo Estado ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private List<Proveedor> listaProveedor;

        /// <summary>
        ///  Propiedad del atributo listaProveedor ya sea para la obtencion del listado de proveedores o asignacion de una lista de proveedores
        /// </summary>
        public List<Proveedor> ListaProveedor
        {
            get { return listaProveedor; }
            set { listaProveedor = value; }
        }
    }
}
