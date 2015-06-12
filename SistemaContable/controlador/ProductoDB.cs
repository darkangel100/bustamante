﻿using System;
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
        public int guardar()
        {
            // aqui se ubica la direccion del archivo.xml
            XmlReader xmltr = XmlReader.Create("C:\\Users\\Luis\\Documents\\Visual Studio 2012\\Projects\\SistemaContable\\SistemaContable\\productos.xml");
            xmltr.MoveToContent();
            Producto p = new Producto();
            int r = 0;
            while (xmltr.Read())
            {
                if (xmltr.IsStartElement())
                {
                    switch (xmltr.Name)
                    {
                        case "id_producto":
                            if (xmltr.Read())
                            {
                                p.Id_producto = Int32.Parse(xmltr.Value);
                            }
                            break;
                        case "nombre":
                            if (xmltr.Read())
                            {
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
                        if(verificacionProducto(p.Nombre)==0)
                        {
                            r= insertaProducto(p);
                            p = null;
                        }
                    }
                }
            }
            return r;
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

        //metodo para verificar si el producto se encuentra en la base de datos
        public int verificacionProducto(string nombre)
        { 
            int v=0;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from producto where nombre='" + nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if(nombre == dr[1].ToString())
                    {
                        v=1;
                    }
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
    }
}
