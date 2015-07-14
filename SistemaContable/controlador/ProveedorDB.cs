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

        /// <summary>
        /// Se obtiene un objeto de tipo Proveedor si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Proveedor</returns>
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

        /// <summary>
        /// Asignacion de un objeto de tipo Proveedor a la variable pr
        /// </summary>
        /// <param name="p">Objeto de tipo Proveedor</param>
        public void setProveedor(Proveedor p)
        {
            this.pr = p;
        }

        /// <summary>
        /// Insercion de los datos contenidos en el objeto de tipo Proveedor a la base de datos
        /// </summary>
        /// <param name="proveedor">Objeto de tipo Proveedor</param>
        /// <returns>Numero que indica si se realizo la insercion</returns>
        internal int insertaDistribuidora(Proveedor proveedor, int id)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Insert proveedor set id_distribuidora='" + id + "', nombreProveedor='default', celularProveedor='0000000000'";
                if (proveedor != null)
                    comandoSql = comandoSql = "Insert proveedor set id_distribuidora='" + proveedor.IdDistri + "', nombreProveedor='" + proveedor.Nombre + "', celularProveedor='" + proveedor.Celular + "', correoProveedor='" + proveedor.Correo + "', tiempoVisita='" + proveedor.Tiempo + "'";
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

        /// <summary>
        /// Obtiene la lista de proveedores registrados en la base de datos
        /// </summary>
        /// <returns>Lista de Proveedores</returns>
        public List<Proveedor> traeProveedores()
        {
            ProveedorDB p = null;
            List<Proveedor> lista = new List<Proveedor>();
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from proveedor";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new ProveedorDB();
                    p.getProveedor().IdDistri = int.Parse(dr[0].ToString());
                    p.getProveedor().IdProveedor = int.Parse(dr[1].ToString());
                    p.getProveedor().Nombre = dr[2].ToString();
                    p.getProveedor().Correo = dr[3].ToString();
                    p.getProveedor().Celular = dr[4].ToString();
                    p.getProveedor().Tiempo = dr[5].ToString();
                    p.getProveedor().Estado = dr[6].ToString();
                    lista.Add(p.getProveedor());
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

        /// <summary>
        /// Obtencion del Proveedor segun el criterio de busqueda seleccionado en la vista
        /// </summary>
        /// <param name="id">Id del proveedor</param>
        /// <param name="busqueda">Nombre o id del proveedor</param>
        /// <param name="c">Criterio de busqueda seleccionado</param>
        /// <returns>Objeto de tipo Proveedor</returns>
        public Proveedor traeProveedor(int id, string busqueda, int c)
        {
            ProveedorDB p = null;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try 
            {
                string comandoSql = "Select * from proveedor Where id_proveedor='" + id + "'";
                if (c == 0)
                    comandoSql = "Select * from proveedor Where nombreProveedor='" + busqueda + "'";
                if (c == 1)
                    comandoSql = "Select * from proveedor Where id_proveedor='" + int.Parse(busqueda) + "'";
                cmd = new MySqlCommand(comandoSql,cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    p = new ProveedorDB();
                    p.getProveedor().IdDistri = int.Parse(dr[0].ToString());
                    p.getProveedor().IdProveedor = int.Parse(dr[1].ToString());
                    p.getProveedor().Nombre = dr[2].ToString();
                    p.getProveedor().Correo = dr[3].ToString();
                    p.getProveedor().Celular = dr[4].ToString();
                    p.getProveedor().Tiempo = dr[5].ToString();
                    p.getProveedor().Estado = dr[6].ToString();
                }
                dr.Close();
            }
            catch(MySqlException ex)
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
            if (p == null)
            {
                p = new ProveedorDB();
            }
            return p.getProveedor();
        }

        /// <summary>
        /// Actializacion de los datos del Producto
        /// </summary>
        /// <param name="prod">Objeto de tipo Producto</param>
        /// <returns>Numero que indica si se realizo la actualizacion</returns>
        public int actualizaProveedor(Proveedor prod)
        {
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            int resp;
            try
            {
                string comandoSql = "Update proveedor set id_distribuidora='" + prod.IdDistri + "', nombreProveedor='" + prod.Nombre + "', correoProveedor='" + prod.Correo + "', celularProveedor='" + prod.Celular + "', tiempoVisita='" + prod.Tiempo +  "' WHERE id_proveedor='" + prod.IdProveedor + "'";
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
            return resp;
        }

        public int verificacion(string nombre)
        {
            int v=0;
            MySqlCommand cmd;
            MySqlConnection cn = co.getConexion();
            try
            {
                string comandoSql = "Select * from proveedor where nombreProveedor='" + nombre + "'";
                cmd = new MySqlCommand(comandoSql, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                        v = 1;
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                v=0;
                throw ex;
            }
            catch (Exception ex)
            {
                v=0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return v;  
        }
    }
}
