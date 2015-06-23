using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaContable.modelo;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaContable.controlador
{
    class ProveedorDB
    {
        conexion co = new conexion();
        Proveedor pr = null;
        public Proveedor getProveedor()
        {
            if (this.pr == null)
            {
                this.pr = new Proveedor();
                Proveedor p = new Proveedor();
                pr = p;
            }
            return this.pr;
        }
        public void setProveedor(Proveedor p)
        {
            this.pr = p;
        }

        internal int insertaDistribuidora(Proveedor proveedor)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Insert proveedor set id_distribuidora='" + proveedor.IdDistri + "', nombreProveedor='" + proveedor.Nombre + "', celularProveedor='" + proveedor.Celular + "', correoProveedor='" + proveedor.Correo + "', tiempoVisita='" + proveedor.Tiempo + "'";
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

        internal List<Proveedor> traeProveedores()
        {
            ProveedorDB p = null;
            List<Proveedor> lista = new List<Proveedor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from proveedor";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new ProveedorDB();
                    p.getProveedor().IdDistri = int.Parse(dr[0].ToString());
                    p.getProveedor().IdProveedor = int.Parse(dr[1].ToString());
                    p.getProveedor().Nombre = dr[2].ToString();
                    p.getProveedor().Correo = dr[3].ToString();
                    p.getProveedor().Celular = dr[4].ToString();
                    p.getProveedor().Tiempo = dr[5].ToString();
                    p.getProveedor().Estado = dr[6].ToString();
                    lista.Add(p.getProveedor());
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
            return lista;
        }


        public Proveedor traeProveedor(int id)
        {
            ProveedorDB p = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try 
            {
                string comandoSql = "Select * from proveedor Where id_proveedor='" + id + "'";
                cmd = new MySqlCommand(comandoSql,cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    p = new ProveedorDB();
                    p.getProveedor().IdDistri = int.Parse(dr[0].ToString());
                    p.getProveedor().IdProveedor = int.Parse(dr[1].ToString());
                    p.getProveedor().Nombre = dr[2].ToString();
                    p.getProveedor().Correo = dr[3].ToString();
                    p.getProveedor().Celular = dr[4].ToString();
                    p.getProveedor().Tiempo = dr[5].ToString();
                    p.getProveedor().Estado = dr[6].ToString();
                }
                dr.Close();
            }
            catch(MySqlException ex)
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
            return p.getProveedor();
        }
        public int actualizaProveedor(Proveedor per)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Update proveedor set id_distribuidora='" + per.IdDistri + "', nombreProveedor='" + per.Nombre + "', correoProveedor='" + per.Correo + "', celularProveedor='" + per.Celular + "', tiempoVisita='" + per.Tiempo +  "' WHERE id_proveedor='" + per.IdProveedor + "'";
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
    }
}
