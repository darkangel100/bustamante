using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using SistemaContable.modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaContable.controlador
{
    class FacturaBD
    {
        conexion con = new conexion();
        Facturas fac = null;

        public Facturas getFacturas()
        {
            if (this.fac == null)
            {
                this.fac = new Facturas();
            }
            return this.fac;
        }
        public void setFacturas(Facturas f)
        {
            this.fac = f;
        }
        public void limpiar()
        {
            this.fac = null;
        }


        public int TraeCodigo()
        {
            int nro = 0; ;
            MySqlConnection cn = con.getConexion();
            MySqlCommand cmd;
            try
            {
                string sqlcad = "Select max(id_factura) as nro from factura ";
                cmd = new MySqlCommand(sqlcad, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (DBNull.Value == dr["nro"])
                        nro = 0;
                    else
                        nro = Convert.ToInt32(dr["nro"]);
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                nro = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                nro = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return nro;
        }
        public int InsertaFacturas(Facturas c)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp = 0;
            try
            {
              //  string sqlcad = "Insert factura Values (" + c.idfac + ",'" + c.numfac + "','" + c.cedper + "','" + c.fecfac + "'," + c.iva0 + "," + c.iva12 + "," + c.ivafac + "," + c.totfac + ",'" + c.estfac + "')";
                string sqlcad = "Insert factura Values (null," + c.Id_Factura + ",'" + c.Fecha + "'," + c.Total + "," + c.SubTotal + "," + c.Iva + ",'" + c.Tipo_fac + "')";
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
