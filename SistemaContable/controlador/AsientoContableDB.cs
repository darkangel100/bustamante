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
        /// Obtiene un 
        /// </summary>
        /// <returns>un objeto de la clase asiento contable</returns>
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
       
        public void setAsientoContable(AsientoContable aconta)
        {
            this.ac = aconta;
        }
        public void limpiar()
        {
            this.ac = null;
        }
        /// <summary>
        /// Inserta un asiento Contable a la Base de datos
        /// </summary>
        /// <param name="asiento"></param>
        /// <returns>un numero que indica que se inserto correctamente a la base de datos</returns>
        
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
        //ultimo id de ASIENTOCONTABLE 
        /// <summary>
        /// Trae el ultimo ide de un asiento contable
        /// </summary>
        /// <returns>el ultimo id de asiento</returns>
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
        ///trae un asiento ontable por el nombre 
        /// </summary>
        /// <param name="nombre">nombre asiento</param>
        /// <returns>la lista de asientos con el mismo numero</returns>
        public List<AsientoContable> traeasicon(string nombre)
        {
            AsientoContableDB asicn = null;
            List<AsientoContable> ListaAsiento = new List<AsientoContable>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from asiento_contable where nombre_asiento='" + nombre + "' and estado='A'";
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
    }
}
