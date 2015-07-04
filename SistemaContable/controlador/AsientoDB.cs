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
    class AsientoDB
    {
        conexion con = new conexion();
        Asiento asien = null;

        public Asiento getAsiento()
        {
            if (this.asien == null)
            {
                this.asien = new Asiento();
                Asiento asient = new Asiento();
                asien = asient;
                
            }
            return this.asien;
        }
        /// <summary>
        /// Inserta un asiento en la base de datos
        /// </summary>
        /// <param name="asi">objeto de la clase asiento</param>
        /// <returns>numero que indica  que se ingreso correctamente el asiento</returns>
        public int InsertaAsiento(Asiento asi)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert asiento set nombre_asiento='" + asi.NOMBREASIENTO + "'";
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
            asi = null;
            return resp;
        }
        /// <summary>
        /// Trae los nombres de los asientos
        /// </summary>
        /// <returns>lista de asientos </returns>
        public List<Asiento> traeAsiento()
        {
            Asiento asie = null;
            List<Asiento> ListaAsi = new List<Asiento>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from Asiento";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asie = new Asiento();
                    asie.NOMBREASIENTO = dr["nombre_asiento"].ToString();

                    ListaAsi.Add(asie);
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                asie = null;
                throw ex;
            }
            catch (Exception ex)
            {
                asie = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaAsi;
        }
    }
}
