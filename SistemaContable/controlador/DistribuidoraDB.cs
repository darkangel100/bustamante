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
    class DistribuidoraDB
    {
        conexion co = new conexion();
        Distribuidora dis = null;

        public Distribuidora getDistribuidora()
        {
            if (this.dis == null)
            {
                this.dis = new Distribuidora();
                Distribuidora distri = new Distribuidora();
                dis = distri;
            }
            return this.dis;
        }
        public void setDistribuidora(Distribuidora d)
        {
            this.dis = d;
        }
        // inserccion distribuidora
        public int insertaDistribuidora(Distribuidora d)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Insert distribuidora set nombreDistribuidora='" + d.Nombre + "', direccionDistribuidora='" + d.Direccion + "', estado='" + d.Estado + "', telefonoDistribuidora='" + d.Telefono + "'";
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
        //listado de distribuidoras
        public List<Distribuidora> traeDistribuidoras()
        {
            DistribuidoraDB d = null;
            List<Distribuidora> lista = new List<Distribuidora>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from distribuidora";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    d = new DistribuidoraDB();
                    d.getDistribuidora().Id = int.Parse(dr[0].ToString());
                    d.getDistribuidora().Nombre = dr[1].ToString();
                    d.getDistribuidora().Direccion = dr[2].ToString();
                    d.getDistribuidora().Telefono = dr[4].ToString();
                    d.getDistribuidora().Estado = dr[3].ToString();
                    lista.Add(d.getDistribuidora());
                }
                dr.Close();

            }
            catch (MySqlException ex)
            {
                d = null;
                throw ex;
            }
            catch (Exception ex)
            {
                d = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return lista;
        }

        //verificacion si la distribuidora existe
        public int verificacionDistri(Distribuidora d)
        {
            int v = 0;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from distribuidora where nombreDistribuidora='" + d.Nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (d.Nombre == dr[1].ToString())
                        v = 1;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                v = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return v;
        }
    }
}
