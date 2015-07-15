using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaContable.modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaContable.controlador
{
    class CuentaBD
    {
 
        conexion con = new conexion();
        
        Cuenta usu = null;

        /// <summary>
        /// Obtiene un objeto de tipo Cuenta si es nulo lo crea
        /// </summary>
        /// <returns>Objeto de tipo Cuenta</returns>
        public Cuenta getCuenta()
        {
            if (this.usu == null)
            {
                this.usu = new Cuenta();
            }
            return this.usu;
        }

        /// <summary>
        /// Fija un objeto de tipo Cuenta a la variable global
        /// </summary>
        /// <param name="usua">Objeto de tipo Cuenta</param>
        public void setCuenta(Cuenta usua)
        {
            this.usu = usua;
        }
        public void limpiar()
        {
            this.usu = null;
        }
        
        /// <summary>
        /// Obtiene un objeto de tipo Cuenta dado el nombre de la cuenta
        /// </summary>
        /// <param name="nombreCuenta">String que contiene el nombre de la cuenta</param>
        /// <returns></returns>
        public Cuenta TraeCuenta(string nombreCuenta)
        {
            Cuenta usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from cuenta Where usuario='" + nombreCuenta +"'";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Cuenta();

                    usu.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                    //Nuevo
                    usu.Usuario = dr["usuario"].ToString();
                    usu.Contrasenia = dr["contrasenia"].ToString();
                    usu.Estado = dr["estado"].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                usu = null;
                throw ex;
            }
            catch (Exception ex)
            {
                usu = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            if(usu==null)
            {
                usu = new Cuenta();
            }
            return usu;
        }

        /// <summary>
        /// Obtiene un objeto de tipo Cuenta dado un Id de usuario
        /// </summary>
        /// <param name="numCuenta">Numero del ID del usuario</param>
        /// <returns>Objeto de tipo Cuenta</returns>
        public Cuenta TraeCuentaPorId(int numCuenta)
        {
            Cuenta usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
              //  string sqlcad = "Select * from cuenta Where id_usuario='" ;
                string sqlcad = "Select * from cuenta Where id_usuario=" + numCuenta;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Cuenta();

                    usu.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                    //Nuevo
                    usu.Usuario = dr["usuario"].ToString();
                    usu.Contrasenia = dr["contrasenia"].ToString();
                    usu.Estado = dr["estado"].ToString();
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                usu = null;
                throw ex;
            }
            catch (Exception ex)
            {
                usu = null;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return usu;
        }

        /// <summary>
        /// Inserta los datos que contiene el objeto Cuenta a la base de datos
        /// </summary>
        /// <param name="usu">Objeto de tipo Cuenta</param>
        /// <returns>Numero que indica si se realizo la operacion de insercion</returns>
        public int Insertacuenta(Cuenta usu)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert cuenta Values (" + usu.IdUsuario + ",'" + usu.Usuario + "','" + usu.Contrasenia + "','" + usu.Estado + "')";
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
            usu = null;
            return resp;
        }

        /// <summary>
        /// Actualiza los datos de la cuenta del usuario
        /// </summary>
        /// <param name="per">Objeto de tipo Cuenta</param>
        /// <returns>Numero que indica si se realizo la operacion</returns>
        public int ActualizaCuenta(Cuenta per)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {

                string sqlcad = "Update cuenta set usuario='" + per.Usuario + "',contrasenia='" + per.Contrasenia + "',estado='" + per.Estado + "' WHERE id_usuario=" + per.IdUsuario + "";
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
    }
}
