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
    class DetalleFacturaDB
    {
        conexion con = new conexion();
        DetalleFactura defac = null;

        public DetalleFactura getDetalleFactura()
        {
            if (this.defac == null)
            {
                this.defac = new DetalleFactura();
                DetalleFactura defact = new DetalleFactura();
                defac = defact;
            }
            return this.defac;
        }

        public void setDetalleFactura(DetalleFactura defactu)
        {
            this.defac = defactu;
        }
        public void limpiar()
        {
            this.defac = null;
        }
        /// <summary>
        /// Inserta un dettalle de la factura
        /// </summary>
        /// <param name="defactur">objeto de la clase detallefactura</param>
        /// <returns>numero que indica que el detalle se ingreso correctamente</returns>
        public int InsertaDetalleFactura(DetalleFactura defactur)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert detalle_factura set id_factura='" + defactur.IDFACTURA + "', id_producto='" + defactur.IDPRODUCTO + "',cantidad='" + defactur.CANTIDAD + "',nombre_producto='" + defactur.NOMBREPRODUCTO + "',costo_unitario='" + defactur.COSTOUNITARIO + "',costo_total='" + defactur.COSTOTOTAL + "'"; ;
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
            defactur = null;
            return resp;
        }
        //trae detalle por id de factura
        /// <summary>
        /// Trar un detalle por el id de detalle
        /// </summary>
        /// <param name="id">entero</param>
        /// <returns>Lista de los detalles de la factura segun el id del detalle</returns>
        public List<DetalleFactura> traedetaid(int id)
        {
            DetalleFacturaDB det = null;
            List<DetalleFactura> ListaDetalle = new List<DetalleFactura>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from detalle_factura where id_factura='" + id + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                    det = new DetalleFacturaDB();
                    det.getDetalleFactura().CANTIDAD = dr["cantidad"].ToString();
                    det.getDetalleFactura().NOMBREPRODUCTO = dr["nombre_producto"].ToString();
                    det.getDetalleFactura().COSTOUNITARIO = dr["costo_unitario"].ToString();
                    det.getDetalleFactura().COSTOTOTAL = dr["costo_total"].ToString();
                    ListaDetalle.Add(det.getDetalleFactura());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                det = null;
                throw ex;
            }
            catch (Exception ex)
            {
                det = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return ListaDetalle;
        }
    }
}
