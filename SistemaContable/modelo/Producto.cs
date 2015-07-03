using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaContable.modelo
{
    class Producto
    {
        private int id_producto;

        /// <summary>
        ///  Propiedad del atributo id_producto ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public int Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        private string nombre;

        /// <summary>
        ///  Propiedad del atributo nombre ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private double precio;

        /// <summary>
        ///  Propiedad del atributo Precio ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
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
        private int stock_global;

        /// <summary>
        ///  Propiedad del atributo stock_global ya sea para la obtencion de su valor o asignacion de un valor
        /// </summary>
        public int Stock_global
        {
            get { return stock_global; }
            set { stock_global = value; }
        }
        private List<Producto> listaProducto;

        /// <summary>
        /// Propiedad del atributo listaProducto ya sea para la obtencion del listado o asignacion de una lista de tipo Producto
        /// </summary>
        public List<Producto> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }
    }
}
