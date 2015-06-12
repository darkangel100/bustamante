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
                
            }
            return this.asien;
        }

        public int InsertaAsiento(Asiento asien)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert Asiento Values ('" + asien.NOMBREASIENTO + "')";
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
            asien = null;
            return resp;
        }
        
        public List<Asiento> TraeAsientos()
        {
            AsientoDB asi = null;
            List<Asiento> ListaAsiento = new List<Asiento>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from Asiento order by nombre_asiento";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    asi = new AsientoDB();
                    asi.getAsiento().NOMBREASIENTO = dr["nombre_asiento"].ToString();

                    ListaAsiento.Add(asi.getAsiento());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                asi = null;
                throw ex;
            }
            catch (Exception ex)
            {
                asi = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaAsiento;
        }
    }
}
