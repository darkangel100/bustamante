using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SistemaContable.modelo
{
    class Producto
    {
        private int id_producto;

        public int Id_producto
        {
            get { return id_producto; }
            set { id_producto = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private int stock_global;

        public int Stock_global
        {
            get { return stock_global; }
            set { stock_global = value; }
        }
        private List<Producto> listaProducto;

        public List<Producto> ListaProducto
        {
            get { return listaProducto; }
            set { listaProducto = value; }
        }
        private string codLote;

        public string CodLote
        {
            get { return codLote; }
            set { codLote = value; }
        }
    }
}
