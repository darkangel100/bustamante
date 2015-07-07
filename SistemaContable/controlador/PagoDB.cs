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
    class PagoDB
    {
        conexion con = new conexion();
        Pago pag = null;

        public Pago getPago()
        {
            if (this.pag == null)
            {
                this.pag = new Pago();
                Pago p = new Pago();
                pag = p;
                
            }
            return this.pag;
        }
        public void setPago(Pago pa)
        {
            this.pag = pa;
        }
        public void limpiar()
        {
            this.pag = null;
        }

        //Insertar un Pago a la Base de datos
        /// <summary>
        /// Inserta un pago a la base de datos
        /// </summary>
        /// <param name="pag">objeto de la clase Pago</param>
        /// <returns>numero que indique que el pago se ingreso correctamente</returns>
        public int InsertaPago(Pago pag)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert pago set id_pago='" + pag.IDPAGO + "',fecha_ingreso='" + pag.FECHA + "', monto='" + pag.MONTO + "'";
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
            pag = null;
            return resp;
        }
        /// <summary>
        /// Trae un pago segun su id 
        /// </summary>
        /// <param name="id">entero id</param>
        /// <returns>lista de pago segun su id</returns>
        public List<Pago> traePAGOtid(int id)
        {
            PagoDB pag = null;
            List<Pago> listapago = new List<Pago>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from pago where id_pago='" + id + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    pag = new PagoDB();
                    pag.getPago().FECHA = dr["fecha_ingreso"].ToString();
                    pag.getPago().MONTO = Convert.ToDouble(dr["monto"].ToString());
                    listapago.Add(pag.getPago());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                pag = null;
                throw ex;
            }
            catch (Exception ex)
            {
                pag = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return listapago;
        }

        public List<Pago> traePAGOfecha(string  fecha)
        {
            PagoDB pag = null;
            List<Pago> listapago = new List<Pago>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from pago where fecha_ingreso='" + fecha + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    pag = new PagoDB();
                    pag.getPago().FECHA = dr["fecha_ingreso"].ToString();
                    pag.getPago().IDPAGO = dr["id_pago"].ToString();
                    listapago.Add(pag.getPago());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                pag = null;
                throw ex;
            }
            catch (Exception ex)
            {
                pag = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return listapago;
        }
    }
}
