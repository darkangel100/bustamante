using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using SistemaContable.modelo;
using System.Xml;
using System.Xml.Linq;

namespace SistemaContable.controlador
{
    class ProductoDB
    {
        conexion co = new conexion();
        Producto pro = null;

        public Producto getProducto()
        {
            if (this.pro == null)
            {
                this.pro = new Producto();
                Producto producto = new Producto();
                pro = producto;
            }
            return this.pro;
        }
        public void setProducto(Producto prod)
        {
            this.pro = prod;
        }
        //metodo para leer el archivo y envio del objeto para la insercion a la base de datos
        public int guardar(string url)
        {
            int r = 0;
            try
            {
                XmlReader xmltr = XmlReader.Create(url);
                xmltr.MoveToContent();
                Producto p = new Producto();
                
                while (xmltr.Read())
                {
                    if (xmltr.IsStartElement())
                    {
                        switch (xmltr.Name)
                        {
                            case "nombre":
                                if (xmltr.Read())
                                {
                                    if (p == null)
                                    {
                                        p = new Producto();
                                    }
                                    p.Nombre = xmltr.Value;
                                }
                                break;
                            case "precio":
                                if (xmltr.Read())
                                {
                                    p.Precio = double.Parse(xmltr.Value);
                                }
                                break;
                            case "estado":
                                if (xmltr.Read())
                                {
                                    p.Estado = xmltr.Value;
                                }
                                break;
                            case "stock_global":
                                if (xmltr.Read())
                                {
                                    p.Stock_global = Int32.Parse(xmltr.Value);
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    else if (xmltr.Name == "Producto")
                    {
                        if (p != null)
                        {
                            int v = verificacionProducto(p);
                            if (v == 0)
                            {
                                r = insertaProducto(p);
                            }
                            if (v == 2)
                            {
                                r = modificarProducto(p);
                            }
                            if (v == 1)
                            {
                                r = -5;
                            }
                        }
                        p = null;
                    }
                }
                return r;
            }
            catch(Exception ex)
            {
                r=0;
                throw ex;
            }
        }
        //metodo para insertar un producto en la base de datos
        public int insertaProducto(Producto pr)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Insert producto set nombre='" + pr.Nombre + "', precio='" + pr.Precio + "', estado='" + pr.Estado + "', stock_global='" + pr.Stock_global + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                resp = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resp = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                resp = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            cn = null;
            return resp;
        }

        
        //listado de productos
        public List<Producto> traeProductos()
        {
            ProductoDB pro = null;
            List<Producto> lista = new List<Producto>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from producto";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro = new ProductoDB();
                    pro.getProducto().Id_producto = int.Parse(dr[0].ToString());
                    pro.getProducto().Nombre = dr[1].ToString();
                    pro.getProducto().Precio = double.Parse(dr[2].ToString());
                    pro.getProducto().Estado = dr[3].ToString();
                    pro.getProducto().Stock_global =int.Parse(dr[4].ToString());
                    lista.Add(pro.getProducto());
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                pro = null;
                throw ex;
            }
            catch (Exception ex)
            {
                pro = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return lista;
        }

        //metodo para verificar si el producto se encuentra en la base de datos y si hay alguna modificacion de los valores
        public int verificacionProducto(Producto p)
        { 
            int v=0;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from producto where nombre='" + p.Nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (p.Nombre == dr[1].ToString())
                        v = 1;
                    if (p.Nombre == dr[1].ToString() && (p.Precio != double.Parse(dr[2].ToString()) || p.Stock_global != int.Parse(dr[4].ToString())))
                        v = 2;
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                v=0;
                throw ex;
            }
            catch (Exception ex)
            {
                v=0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return v;  
        }

        //metodo para modificar valores del producto
        public int modificarProducto(Producto pro)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Update producto set precio='" + pro.Precio + "', estado='" + pro.Estado + "', stock_global='" + pro.Stock_global + "' WHERE nombre='" + pro.Nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                resp = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resp = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                resp = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return resp;
        }
        //ultimo id del producto 
        public string traenumero()
        {
            MySqlConnection cn = co.getConexion();
            MySqlCommand cmd;
            string num = "";
            try
            {
                string Sqlcad = "Select max(id_producto)as num from producto";
                cmd = new MySqlCommand(Sqlcad, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    num = dr["num"].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                num = "";
                throw ex;
            }
            catch (Exception ex)
            {
                num = "";
                throw ex;
            }
            cn.Close();
            cmd = null;
            return num;
        }

        //metodo para traer un producto en particular segun el criterio
        public Producto traeProducto(int id, string nombre, string criterio)
        {
            ProductoDB p = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from producto Where id_producto='" + id + "'";
                if (criterio == "nombre")
                    comandoSql = "Select * from producto Where nombre='" + nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new ProductoDB();
                    p.getProducto().Id_producto = int.Parse(dr[0].ToString());
                    p.getProducto().Nombre = dr[1].ToString();
                    p.getProducto().Precio = double.Parse(dr[2].ToString());
                    p.getProducto().Estado = dr[3].ToString();
                    p.getProducto().Stock_global = int.Parse(dr[4].ToString());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                p = null;
                throw ex;
            }
            catch (Exception ex)
            {
                p = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return p.getProducto();
        }
        //actualiza producto cuando se compra
        public int agregapro(string cod, int can)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;

            try
            {
                string sqlcad = "Update producto set stock_global=stock_global+" + can + " where id_producto='" + cod + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                resp = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                resp = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                resp = 0;
                throw ex;
            }
            cmd = null;
            cn.Close();
            return resp;


        }
    }
}
