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
        
        /// <summary>
        /// Obtiene un objeto de tipo DetalleFactura si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo DetalleFactura</returns>
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

        /// <summary>
        /// Inserta los datos contenidos en el objeto  DetalleFactura a la base de datos
        /// </summary>
        /// <param name="defactur">Objeto de tipo DetalleFactura</param>
        /// <returns>Numero que indica que el detalle se ingreso correctamente</returns>
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


        /// <summary>
        /// Trar una lista de DetalleFactura dado el id de la Factura
        /// </summary>
        /// <param name="id">Numero con el Id de la factura</param>
        /// <returns>Lista de objetos de tipo DetalleFactura</returns>
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
