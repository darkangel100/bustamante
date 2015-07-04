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
    class LoteDB
    {
        conexion con = new conexion();
        Lote lo = new Lote();

        public Lote getLote()
        {
            if (this.lo == null)
            {
                this.lo = new Lote();
                Lote lot = new Lote();
                lo = lot;

            }
            return this.lo;
        }
        /// <summary>
        /// Inserta un lote a la base de datos
        /// </summary>
        /// <param name="lo">objeto de la clase lote</param>
        /// <returns>numero que indica que el loste se ingreso correctamente</returns>
        public int InsertaLote(Lote lo)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert lote set codLote='" + lo.CODLOTE + "',id_producto='" + lo.IDPRODUCTO + "',descripcion='" + lo.DESCRIPCION + "',stock_unidades='" + lo.STOCKUNIDADES + "',fechaVencimiento='" + lo.FECHAVENCIMINTO + "',fechaElaboracion='" + lo.FECHAELABORACION + "'";
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
            lo = null;
            return resp;
        }
    }
}
