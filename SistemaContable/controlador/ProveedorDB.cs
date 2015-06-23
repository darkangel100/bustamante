using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaContable.modelo;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaContable.controlador
{
    class ProveedorDB
    {
        conexion co = new conexion();
        Proveedor pr = null;
        public Proveedor getProveedor()
        {
            if (this.pr == null)
            {
                this.pr = new Proveedor();
                Proveedor p = new Proveedor();
                pr = p;
            }
            return this.pr;
        }
        public void setProveedor(Proveedor p)
        {
            this.pr = p;
        }

        internal int insertaDistribuidora(Proveedor proveedor)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Insert proveedor set id_distribuidora='" + proveedor.IdDistri + "', nombreProveedor='" + proveedor.Nombre + "', celularProveedor='" + proveedor.Celular + "', correoProveedor='" + proveedor.Correo + "', tiempoVisita='" + proveedor.Tiempo + "'";
                cmd = new MySqlCommand(comandoSql, cn);
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
            cn = null;
            return resp;
        }
    }
}
