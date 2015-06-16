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
        //Conexion nuevo
        conexion con = new conexion();
        //
        Cuenta usu = null;

        public Cuenta getCuenta()
        {
            if (this.usu == null)
            {
                this.usu = new Cuenta();
            }
            return this.usu;
        }
        public void setCuenta(Cuenta usua)
        {
            this.usu = usua;
        }
        public void limpiar()
        {
            this.usu = null;
        }
        public List<Cuenta> Traecuentas()
        {
            Cuenta usu = null;
            List<Cuenta> ListaUsu = new List<Cuenta>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from cuenta order by id_usuario";
                // string sqlcad = "Select * from cuenta Where id_usuario=" + id;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //BD
                    usu = new Cuenta();
                    usu.IdUsuario = Convert.ToInt32(dr["id_usuario"]);
                    //Nuevo
                    usu.Usuario = dr["usuario"].ToString();
                    usu.Contrasenia = dr["contrasenia"].ToString();
                    usu.Estado = dr["estado"].ToString();
                    ListaUsu.Add(usu);
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
            return ListaUsu;
        }
        public Cuenta TraeCuenta(int id)
        {
            Cuenta usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from cuenta Where id_usuario=" + id;
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

    }
}
