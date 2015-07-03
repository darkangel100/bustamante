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

        /// <summary>
        /// Se obtiene un objeto de tipo Distribuidora si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Distribuidora</returns>
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

        /// <summary>
        /// Asignacion de un objeto de tipo Distribuidora a la variable dis
        /// </summary>
        /// <param name="d">Objeto de tipo Distribuidora</param>
        public void setDistribuidora(Distribuidora d)
        {
            this.dis = d;
        }
        
        /// <summary>
        /// Insercion de los datos contenidos en el objeto de tipo Distribuidora a la base de datos
        /// </summary>
        /// <param name="d">Objeto de tipo Distribuidora</param>
        /// <returns>Numero que indica si se realizo la insercion</returns>
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
        
        /// <summary>
        /// Obtencion de las distribuidoras registradas en la base de datos
        /// </summary>
        /// <returns>Lista de distribuidoras</returns>
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

        /// <summary>
        /// Verifica si existe la distribuidora en la base de datos
        /// </summary>
        /// <param name="d">Objeto de tipo Distribuidora</param>
        /// <returns>Numero que indica si existe o no en la base de datos</returns>
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

        /// <summary>
        /// Obtiene los datos de la distribuidora
        /// </summary>
        /// <param name="p">Id de la Distribuidora</param>
        /// <returns>Objeto de tipo Distribuidora</returns>
        public Distribuidora traeDistribuidora(int p)
        {
            DistribuidoraDB d = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from distribuidora Where id_distribuidora='" + p + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    d = new DistribuidoraDB();
                    d.getDistribuidora().Id = int.Parse(dr[0].ToString());
                    d.getDistribuidora().Nombre = dr[1].ToString();
                    d.getDistribuidora().Direccion = dr[2].ToString();
                    d.getDistribuidora().Telefono = dr[3].ToString();
                    d.getDistribuidora().Estado = dr[4].ToString();
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
            return d.getDistribuidora();
        }

        /// <summary>
        /// Actualiza los datos de la Distribuidora
        /// </summary>
        /// <param name="d">Objeto de tipo Distribuidora</param>
        /// <returns>Numero que indica si se realizo la actualizacion</returns>
        public int actualizaDistribuidora(Distribuidora d)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Update distribuidora set nombreDistribuidora='" + d.Nombre + "', direccionDistribuidora='" + d.Direccion + "', telefonoDistribuidora='" + d.Telefono + "' WHERE id_distribuidora='" + d.Id + "'";
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
