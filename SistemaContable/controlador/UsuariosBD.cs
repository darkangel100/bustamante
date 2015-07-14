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
        
        conexion con = new conexion();
        Usuarios usu = null;

        /// <summary>
        /// Obtencion de un objeto de tipo Usuarios
        /// </summary>
        /// <returns>Objeto de tipo Usuarios</returns>
        public Usuarios getUsuarios()
        {
            if (this.usu == null)
            {
                this.usu = new Usuarios();
            }
            return this.usu;
        }

        /// <summary>
        /// Fija un objeto de tipo Usuarios
        /// </summary>
        /// <param name="usua">Objeto tipo Usuarios</param>
        public void setUsuarios(Usuarios usua)
        {
            this.usu = usua;
        }
        
        /// <summary>
        /// Obtiene un objeto de tipo Usuarios dado su ID
        /// </summary>
        /// <param name="id">Numero con el ID del Usuario</param>
        /// <returns>Objeto de tipo Usuarios</returns>
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
                    usu.IdUsu = Convert.ToInt32(dr["id_usuario"]);
                    usu.IdRol = Convert.ToInt32(dr["id_rol"]);
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

        /// <summary>
        /// Devuelve una lista de objetos de tipo Usuarios
        /// </summary>
        /// <returns>Lista de tipo Usuarios</returns>
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

        /// <summary>
        /// Inserta los datos que contiene el objeto de tipo Usuarios a la base de datos
        /// </summary>
        /// <param name="usu">Objeto de tipo Usuario</param>
        /// <returns>Numero que indica si se realizo la operacion</returns>
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

        /// <summary>
        /// Trae el ultimo ID de usuario registrado
        /// </summary>
        /// <returns>Numero con el ID del Usuario</returns>
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

        /// <summary>
        /// Actuliza los datos del usuario dado su id
        /// </summary>
        /// <param name="per">Objeto de tipo Usuarios</param>
        /// <returns>Numero que indica si se realizo la operacion</returns>
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
