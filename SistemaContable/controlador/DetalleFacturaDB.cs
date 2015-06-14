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
        


        //Insertar una factue=ra a la Base de datos
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
    }
}
