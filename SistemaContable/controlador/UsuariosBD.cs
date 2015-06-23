using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaContable.modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaContable.controlador
{
    class UsuariosBD
    {
        //Conexion nuevo
        conexion con = new conexion();
        //
        Usuarios usu = null;

        public Usuarios getUsuarios()
        {
            if (this.usu == null)
            {
                this.usu = new Usuarios();
            }
            return this.usu;
        }
        public void setUsuarios(Usuarios usua)
        {
            this.usu = usua;
        }
        public void limpiar()
        {
            this.usu = null;
        }
        public Usuarios TraeUsuario(int id)
        {
            Usuarios usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from usuario Where id_usuario=" + id;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Usuarios();

                    //   usu.IdRol = Convert.ToInt32(dr["id_rol"]);
                    //Nuevo
                    //  usu.Tipo = dr["tipo"].ToString();
                    //    usu.Contrasenia = dr["contrasenia"].ToString();
                    //   usu.Estado = dr["estado"].ToString();

                    //  usu = new Usuarios();
                    usu.IdUsu = Convert.ToInt32(dr["id_usuario"]);
                    //Nuevo
                    usu.IdRol = Convert.ToInt32(dr["id_rol"]);
                    //
                    usu.CedUsu = dr["cedula"].ToString();
                    usu.NomUsu = dr["nombre"].ToString();
                    usu.ApeUsu = dr["apellido"].ToString();
                    usu.TelUsu = dr["telefono"].ToString();
                    usu.DirUsu = dr["direccion"].ToString();

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

        public List<Usuarios> Traeusuarios()
        {
            Usuarios usu = null;
            List<Usuarios> ListaUsu = new List<Usuarios>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from usuario order by id_usuario";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //BD
                    usu = new Usuarios();
                    usu.IdUsu = Convert.ToInt32(dr["id_usuario"]);
                    //Nuevo
                    usu.IdRol = Convert.ToInt32(dr["id_rol"]);
                    //
                    usu.CedUsu = dr["cedula"].ToString();
                    usu.NomUsu = dr["nombre"].ToString();
                    usu.ApeUsu = dr["apellido"].ToString();
                    usu.TelUsu = dr["telefono"].ToString();
                    usu.DirUsu = dr["direccion"].ToString();
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

        public int Insertausuario(Usuarios usu)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {
                string sqlcad = "Insert usuario Values (" + usu.IdUsu + "," + usu.IdRol + ",'" + usu.CedUsu + "','" + usu.NomUsu + "','" + usu.ApeUsu + "','" + usu.TelUsu + "','" + usu.DirUsu + "')";
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
        public int TraeCodigo()
        {
            int nro = 0; ;
            MySqlConnection cn = con.getConexion();
            MySqlCommand cmd;
            try
            {
                string sqlcad = "Select max(id_usuario) as nro from usuario ";
                cmd = new MySqlCommand(sqlcad, cn);
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (DBNull.Value == dr["nro"])
                        nro = 0;
                    else
                        nro = Convert.ToInt32(dr["nro"]);
                }
                dr.Close();
            }
            catch (MySqlException ex)
            {
                nro = 0;
                throw ex;
            }
            catch (Exception ex)
            {
                nro = 0;
                throw ex;
            }
            cn.Close();
            cmd = null;
            return nro;
        }
        public int ActualizaUsuario(Usuarios per)
        {
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            int resp;
            try
            {

                string sqlcad = "Update usuario set id_rol=" + per.IdRol + ",cedula='" + per.CedUsu + "',nombre='" + per.NomUsu + "',apellido='" + per.ApeUsu + "',telefono='" + per.TelUsu + "',direccion='" + per.DirUsu + "' WHERE id_usuario=" + per.IdUsu + "";
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
