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

        //Insertar un asiento Contable a la Base de datos
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

    }
}
