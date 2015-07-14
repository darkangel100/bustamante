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
        
        /// <summary>
        /// Obtiene un objeto de tipo Lote si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Lote</returns>
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

        /// <summary>
        /// Trae una lista de objetos de tipo Lote dado su el ID del producto
        /// </summary>
        /// <param name="id">ID del Producto</param>
        /// <returns>Lista de objetos de tipo Lote</returns>
        public List<Lote> traerLotes(int id)
        {
            LoteDB pag = null;
            List<Lote> lista = new List<Lote>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from lote where id_producto='" + id + "'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    pag = new LoteDB();
                    pag.getLote().CODLOTE = dr[0].ToString();
                    pag.getLote().IDPRODUCTO = dr[1].ToString();
                    pag.getLote().DESCRIPCION = dr[2].ToString();
                    pag.getLote().STOCKUNIDADES = dr[3].ToString();
                    pag.getLote().FECHAVENCIMINTO = dr[4].ToString();
                    pag.getLote().FECHAELABORACION = dr[5].ToString();
                    lista.Add(pag.getLote());
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                pag = null;
                throw ex;
            }
            catch (Exception ex)
            {
                pag = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return lista;
        }
    }
}
