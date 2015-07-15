using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SistemaContable.modelo;

namespace SistemaContable.controlador
{
    class AsientoContableDB
    {
        conexion con = new conexion();
        AsientoContable ac = null;

        /// <summary>
        /// Se obtiene un objeto de tipo AsientoContable si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo AsientoContable</returns>
        public AsientoContable getAsientoContable()
        {
            if (this.ac == null)
            {
                this.ac = new AsientoContable();
                AsientoContable asiencon = new AsientoContable();
                ac = asiencon;
            }
            return this.ac;
        }
       
        /// <summary>
        /// Fija un objeto de tipo AsientoContable a la variable global
        /// </summary>
        /// <param name="aconta">Objeto de tipo AsientoContable</param>
        public void setAsientoContable(AsientoContable aconta)
        {
            this.ac = aconta;
        }
        
        /// <summary>
        /// Inserta de los datos que se encuentran en el objeto asiento Contable a la Base de datos
        /// </summary>
        /// <param name="asiento">Objeto de tipo AsientoContable</param>
        /// <returns>Numero que indica si se realiza la operacion</returns>
        public int InsertaAsientoContable(AsientoContable asiento)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert asiento_contable set nombre_asiento='" + asiento.NOMBRE_ASIENTO + "', descripcion='" + asiento.DESCRIPCION + "'";
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
            cn.Close();
            cmd = null;
            asiento = null;
            return resp;
        }
 
        /// <summary>
        /// Trae el ultimo "id" de un asiento contable
        /// </summary>
        /// <returns>String que contiene el Id</returns>
        public string traenumero()
        {
            MySqlConnection cn = con.getConexion();
            MySqlCommand cmd;
            string num = "";
            try
            {
                string Sqlcad = "Select max(id_asiento)as num from asiento_contable";
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
        
        /// <summary>
        ///trae una lista de asientos contables  dado un nombre de asiento
        /// </summary>
        /// <param name="nombre">String con el nombre del asiento</param>
        /// <returns>Lista de tipo AsientoContable</returns>
        public List<AsientoContable> traeasicon(string nombre)
        {
            AsientoContableDB asicn = null;
            List<AsientoContable> ListaAsiento = new List<AsientoContable>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from asiento_contable where nombre_asiento='" + nombre + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asicn = new AsientoContableDB();
                    asicn.getAsientoContable().IDASIENTO = dr["id_asiento"].ToString();
                    asicn.getAsientoContable().NOMBRE_ASIENTO = dr["nombre_asiento"].ToString();
                    asicn.getAsientoContable().DESCRIPCION = dr["descripcion"].ToString();
                    asicn.getAsientoContable().ESTADO = dr["estado"].ToString();
                    ListaAsiento.Add(asicn.getAsientoContable());
                   
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                asicn = null;
                throw ex;
            }
            catch (Exception ex)
            {
                asicn = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaAsiento;
        }

        /// <summary>
        /// Obtiene todos los asientos contables registrados
        /// </summary>
        /// <returns>Lista de tipo AsientoContable</returns>
        public List<AsientoContable> traeasicon()
        {
            AsientoContableDB asicn = null;
            List<AsientoContable> ListaAsiento = new List<AsientoContable>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from asiento_contable";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asicn = new AsientoContableDB();
                    asicn.getAsientoContable().IDASIENTO = dr["id_asiento"].ToString();
                    asicn.getAsientoContable().NOMBRE_ASIENTO = dr["nombre_asiento"].ToString();
                    asicn.getAsientoContable().DESCRIPCION = dr["descripcion"].ToString();
                    asicn.getAsientoContable().ESTADO = dr["estado"].ToString();
                    ListaAsiento.Add(asicn.getAsientoContable());

                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                asicn = null;
                throw ex;
            }
            catch (Exception ex)
            {
                asicn = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaAsiento;
        }

        /// <summary>
        /// Lista de Asientos contables dado un id
        /// </summary>
        /// <param name="id">id del AsientoContable</param>
        /// <returns>Objeto de tipo AsientoContable</returns>
        public AsientoContable cuentasLibros(int id)
        {
            AsientoContableDB per = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string comandoSql = "Select * from asiento_contable Where id_asiento='" + id + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    per = new AsientoContableDB();
                    per.getAsientoContable().IDUSUARIO = dr[0].ToString();
                    per.getAsientoContable().IDASIENTO = dr[1].ToString();
                    per.getAsientoContable().NOMBRE_ASIENTO = dr[2].ToString();
                    per.getAsientoContable().DESCRIPCION = dr[3].ToString();
                    per.getAsientoContable().ESTADO = dr[4].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                per = null;
                throw ex;
            }
            catch (Exception ex)
            {
                per = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return per.getAsientoContable();
        }
        //15
        public AsientoContable TraeAsientoPorId(int idAsiento)
        {
            AsientoContableDB per = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                // string sqlcad = "Select * from Factura Where id_fac='" + id + "'";
                string sqlcad = "Select * from asiento_contable  Where id_asiento=" + idAsiento;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    per = new AsientoContableDB();
                    /*
                    //per.getAsientoContable().IDUSUARIO = Convert.ToString(dr[0].ToString());
                    per.getAsientoContable().IDASIENTO = Convert.ToString(dr[1].ToString());
                    per.getAsientoContable().NOMBRE_ASIENTO = Convert.ToString(dr[2].ToString());
                    per.getAsientoContable().DESCRIPCION = Convert.ToString(dr[3].ToString());
                    per.getAsientoContable().ESTADO = Convert.ToString(dr[4].ToString());

                    */
                    per.getAsientoContable().IDUSUARIO = dr[0].ToString();
                    per.getAsientoContable().IDASIENTO = dr[1].ToString();
                    per.getAsientoContable().NOMBRE_ASIENTO = dr[2].ToString();
                    per.getAsientoContable().DESCRIPCION = dr[3].ToString();
                    per.getAsientoContable().ESTADO = dr[4].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                per = null;
                throw ex;
            }
            catch (Exception ex)
            {
                per = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return per.getAsientoContable();
        }
      
        public int ActualizaASientoContable(AsientoContable asi)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {

                string sqlcad = "Update asiento_contable set estado='" + asi.ESTADO + "' WHERE id_asiento=" + asi.IDASIENTO + "";
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
            cn.Close();
            cmd = null;
            return resp;
        }
        }
    }