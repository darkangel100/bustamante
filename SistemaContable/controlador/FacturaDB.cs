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

        /// <summary>
        /// Obtiene un objeto de tipo Factura si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Factura</returns>
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

        /// <summary>
        /// Fija un objeto de tipo Factura a la variable global
        /// </summary>
        /// <param name="factu">Objeto tipo Factura</param>
        public void setFactura(Factura factu)
        {
            this.fac = factu;
        }
        public void limpiar()
        {
            this.fac = null;
        }
        //id de la factura
        /// <summary>
        /// Trae el ultimo id de la factura
        /// </summary>
        /// <returns>Cadena con el id de la factura</returns>
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

        //Insertar una factura a la Base de datos
        /// <summary>
        /// Inserta los datos contenidos en el objeto de tipo Factura a la base de datos
        /// </summary>
        /// <param name="factur">objeto de tipo Factura</param>
        /// <returns>numero que indica que la factura se ingreso correctamente</returns>
        public int InsertaFactura(Factura factur)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert factura set id_proveedor='" + factur.IDPROVEEDOR + "',id_factura='" + factur.IDFACTURA + "',fecha='" + factur.FECHA + "', total='" + factur.TOTAL + "',subtotal='" + factur.SUBTOTAL + "',iva='" + factur.IVA + "',tipo_fac='" + factur.TIPOFACTURA + "'";
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
        
        /// <summary>
        /// Inserta los datos contenidos en el objeto de tipo Factura
        /// </summary>
        /// <param name="factur">Objeto de tipo Factura</param>
        /// <returns>Numero que indica si se realizo la operacion de insercion</returns>
        public int InsertaFacturasV(Factura factur)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp = 0;
            try
            {
                String sqlcad = "Insert factura Values ('" + factur.IDPROVEEDOR + "','" + factur.IDFACTURA + "','" + factur.FECHA + "','" + factur.TOTAL + "','" + factur.SUBTOTAL + "','" + factur.IVA + "','" + factur.TIPOFACTURA + "')";                
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

        /// <summary>
        /// Trae una lista de facturas segun el id 
        /// </summary>
        /// <param name="id">Id de la factura</param>
        /// <returns>lista de objetos de tipo Factura</returns>
        public List<Factura> traefacid(int id)
        {
            FacturaDB fac = null;
            List<Factura> ListaFac = new List<Factura>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from factura where id_fac='" + id + "' and tipo='C'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fac = new FacturaDB();

                    fac.getFactura().FECHA = dr["fecha"].ToString();
                    ListaFac.Add(fac.getFactura());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                fac = null;
                throw ex;
            }
            catch (Exception ex)
            {
                fac = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaFac;
        }
        
        /// <summary>
        /// Obtiene un objeto de tipo Factura dado el Id de la factura
        /// </summary>
        /// <param name="id">Numero del Id de la Factura</param>
        /// <returns>Objeto de tipo Factura</returns>
        public Factura Traefactura(int id)
        {
            FacturaDB per = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                // string sqlcad = "Select * from Factura Where id_fac='" + id + "'";
                string sqlcad = "Select * from factura  Where id_factura=" + id;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Destino Vista
                    per = new FacturaDB();
                    //
                    per.getFactura().IDFACTURA = Convert.ToInt32(dr[1].ToString());
                    per.getFactura().FECHA = dr[2].ToString();
                    //
                    per.getFactura().TOTAL =Convert.ToDouble(dr[3].ToString());
                    //per.getFacturas().cedper = dr[2].ToString();
                    //per.getFactura().FECHA = dr[2].ToString();
                    per.getFactura().SUBTOTAL = Convert.ToDouble(dr[4].ToString());//este es subtotal
                    per.getFactura().IVA = Convert.ToDouble(dr[5].ToString());//este es subtotal             
                    per.getFactura().TIPOFACTURA = dr[6].ToString();
                    //per.getFacturas().Usuario.tipusu = dr[7].ToString();
                    //
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                per = null;
                throw ex;
            }
            catch (Exception ex)
            {
                per = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return per.getFactura();
        }
        
        /// <summary>
        /// Obtiene una lista de Facturas dado su tipo
        /// </summary>
        /// <param name="cat">String con el tipo de Factura</param>
        /// <returns>Lista de objetos de tipo Factura</returns>
        public List<Factura> TraeFacts(string cat)
        {
            Factura fac = null;
            List<Factura> ListaFs = new List<Factura>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from factura where tipo_fac='" + cat + "' order by id_factura";

                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fac = new Factura();
                    fac.IDFACTURA = Convert.ToInt32(dr[1].ToString());
                    fac.FECHA = dr[2].ToString();
                    fac.TOTAL = Convert.ToDouble(dr[3].ToString());//este es subtotal
                    fac.SUBTOTAL = Convert.ToDouble(dr[4].ToString());//este es subtotal
                    fac.IVA = Convert.ToDouble(dr[5].ToString());
                    fac.TIPOFACTURA = dr[6].ToString();
                    ListaFs.Add(fac);
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                fac = null;
                throw ex;
            }
            catch (Exception ex)
            {
                fac = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaFs;
        }
    }
}
