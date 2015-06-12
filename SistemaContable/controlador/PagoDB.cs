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
        public int InsertaPago(Pago pag)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert pago Values('"  + pag.FECHA + "','" + pag.MONTO + "')";
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
    }
}
