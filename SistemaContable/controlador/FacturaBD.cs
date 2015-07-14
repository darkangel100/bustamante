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

        /// <summary>
        /// Obtiene un objeto de tipo Factura si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Factura</returns>
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
        
        /// <summary>
        /// Obtiene una lista de objetos de tipo Factura dado un intervalo de fecha y el tipo de factura
        /// </summary>
        /// <param name="fi">Fecha inicial</param>
        /// <param name="ff">Fecha final</param>
        /// <param name="tipo">Tipo factura</param>
        /// <returns>Lista de tipo Factura</returns>
        public List<Factura> libros(string fi, string ff, string tipo)
        {
            FacturaBD p = null;
            List<Factura> lista = new List<Factura>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string comandoSql = "Select * from factura Where fecha BETWEEN '" + fi + "' AND '" + ff + "'";
                if (tipo != "")
                    comandoSql = "Select * from factura Where fecha BETWEEN '" + fi + "' AND '" + ff + "'AND tipo_fac='" + tipo + "'";
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
