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
    class FacturaDB
    {
        conexion con = new conexion();
        Factura fac = null;

        public Factura getFactura()
        {
            if (this.fac == null)
            {
                this.fac = new Factura();
                Factura fact = new Factura();
                fac = fact;
            }
            return this.fac;
        }

        public void setFactura(Factura factu)
        {
            this.fac = factu;
        }
        public void limpiar()
        {
            this.fac = null;
        }
        //id de la factura
        public string traenumero()
        {
            MySqlConnection cn = con.getConexion();
            MySqlCommand cmd;
            string num = "";
            try
            {
                string Sqlcad = "Select max(id_factura)as num from factura";
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

        //Insertar una factue=ra a la Base de datos
        public int InsertaFactura(Factura factur)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert factura set id_factura='"+factur.IDFACTURA+"',fecha='" + factur.FECHA + "', total='" + factur.TOTAL + "',subtotal='" + factur.SUBTOTAL + "',iva='" + factur.IVA + "',tipo_fac='" + factur.TIPOFACTURA + "'";
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
            factur = null;
            return resp;
        }
    }
}
