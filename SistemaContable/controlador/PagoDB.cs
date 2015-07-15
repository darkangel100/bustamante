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

        /// <summary>
        /// Obtiene un objeto de tipo Pago
        /// </summary>
        /// <returns>Objeto de tipo Pago</returns>
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
        /// <returns>lista de objetos de tipo Pago</returns>
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

        /// <summary>
        /// Listo de objetos de tipo pago dado un periodo de tiempo y id de pago
        /// </summary>
        /// <param name="p1">Cadena con la fecha incial</param>
        /// <param name="p2">Cadena con la fecha final</param>
        /// <param name="id">Numero del Id del pago</param>
        /// <returns>Lista de objetos de tipo Pago</returns>
        internal List<Pago> rptLibros(string p1, string p2, int id)
        {
            PagoDB p = null;
            List<Pago> lista = new List<Pago>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string comandoSql = "Select * from pago Where fecha_ingreso BETWEEN '" + p1 + "' AND '" + p2 + "'";
                if (id != 0)
                    comandoSql = "Select * from pago Where fecha_ingreso BETWEEN '" + p1 + "' AND '" + p2 + "'AND id_pago='" + id + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new PagoDB();
                    p.getPago().IDPAGO = dr[0].ToString();
                    p.getPago().FECHA = dr[1].ToString();
                    p.getPago().MONTO = double.Parse(dr[2].ToString());
                    lista.Add(p.getPago());
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
        public List<Pago> traePAGOfecha(string fecha)
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
