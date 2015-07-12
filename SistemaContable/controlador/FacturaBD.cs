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
        Factura fac = null;

        public Factura getFacturas()
        {
            if (this.fac == null)
            {
                //this.fac = new Factura();
                this.fac = new Factura();
                Factura p = new Factura();
                fac = p;
            }
            return this.fac;
        }
        public void setFacturas(Factura f)
        {
            this.fac = f;
        }
        public void limpiar()
        {
            this.fac = null;
        }

        /// <summary>
        /// descpr
        /// </summary>
        /// <returns>lo q retorna</returns>
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
        //Este metodo debe copiarse en DB
       /// <summary>
       /// 
       /// </summary>
       /// <param name="factur">Nombre del objeto</param>
       /// <param name="tipo">Numero que indica que la factura se ingresó correctamente</param>
       /// <returns></returns>
        public int InsertaFacturasVC(Factura factur, string tipo)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp = 0;
            try
            {
                string sqlcad = "";
                if (tipo.Equals("C"))
                {
                    sqlcad = "Insert factura set id_proveedor='" + factur.IDPROVEEDOR + "',id_factura='" + factur.IDFACTURA + "',fecha='" + factur.FECHA + "', total='" + factur.TOTAL + "',subtotal='" + factur.SUBTOTAL + "',iva='" + factur.IVA + "',tipo_fac='" + factur.TIPOFACTURA + "'";
                }
                else
                {
                    //  string sqlcad = "Insert factura Values (" + c.idfac + ",'" + c.numfac + "','" + c.cedper + "','" + c.fecfac + "'," + c.iva0 + "," + c.iva12 + "," + c.ivafac + "," + c.totfac + ",'" + c.estfac + "')";

                    sqlcad = "Insert factura Values (null," + factur.IDFACTURA + ",'" + factur.FECHA + "'," + factur.TOTAL + "," + factur.SUBTOTAL + "," + factur.IVA + ",'" + factur.TIPOFACTURA + "')";
                }
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
        
        public List<Factura> libroDiario(string fi, string ff)
        {
            FacturaBD p = null;
            List<Factura> lista = new List<Factura>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string comandoSql = "Select * from factura Where fecha BETWEEN '" + fi + "' AND '" + ff + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new FacturaBD();
                    p.getFacturas().IDPROVEEDOR = int.Parse(dr[0].ToString());
                    p.getFacturas().IDFACTURA = int.Parse(dr[1].ToString());
                    p.getFacturas().FECHA = dr[2].ToString();
                    p.getFacturas().TOTAL = double.Parse(dr[3].ToString());
                    p.getFacturas().SUBTOTAL = double.Parse(dr[4].ToString());
                    p.getFacturas().IVA = double.Parse(dr[5].ToString());
                    p.getFacturas().TIPOFACTURA = dr[6].ToString();
                    lista.Add(p.getFacturas());
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

    }
}
