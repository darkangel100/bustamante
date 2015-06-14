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
        //public List<Lote> traeLote()
        //{
        //    Lote lo = null;
        //    List<Lote> ListaAsi = new List<Lote>();
        //    MySqlCommand cmd;
        //    MySqlConnection cn = con.getConexion();
        //    try
        //    {
        //        string sqlcad = "Select * from Asiento";
        //        cmd = new MySqlCommand(sqlcad, cn);
        //        cmd.CommandType = CommandType.Text;
        //        cn.Open();
        //        MySqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            lo = new Lote();
        //            asie.NOMBREASIENTO = dr["nombre_asiento"].ToString();

        //            ListaAsi.Add(asie);
        //        }
        //        dr.Close();
        //    }
        //    catch (MySqlException ex)
        //    {
        //        asie = null;
        //        throw ex;
        //    }
        //    catch (Exception ex)
        //    {
        //        asie = null;
        //        throw ex;
        //    }
        //    cn.Close();
        //    cmd = null;
        //    return ListaAsi;
        //}
    }
}
