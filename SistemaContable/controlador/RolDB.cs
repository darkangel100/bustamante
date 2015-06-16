using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaContable.modelo;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaContable.controlador
{
    class RolDB
    {
        //Conexion nuevo
        conexion con = new conexion();
        //
        Rols usu = null;

        public Rols getRol()
        {
            if (this.usu == null)
            {
                this.usu = new Rols();
            }
            return this.usu;
        }
        public void setRol(Rols usua)
        {
            this.usu = usua;
        }
        public void limpiar()
        {
            this.usu = null;
        }
        public List<Rols> TraeRoles()
        {
            Rols usu = null;
            List<Rols> ListaUsu = new List<Rols>();
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from rol order by id_rol";
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //BD
                    usu = new Rols();
                    usu.IdRol = Convert.ToInt32(dr["id_rol"]);

                    usu.Tipo = dr["tipo"].ToString();
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
        public Rols TraeRol(int id)
        {
            Rols usu = null;
            MySqlCommand cmd;
            MySqlConnection cn = con.getConexion();
            try
            {
                string sqlcad = "Select * from rol Where id_rol=" + id;
                cmd = new MySqlCommand(sqlcad, cn);
                cmd.CommandType = CommandType.Text;
                cn.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usu = new Rols();

                    usu.IdRol = Convert.ToInt32(dr["id_rol"]);
                    //Nuevo
                    usu.Tipo = dr["tipo"].ToString();
                    //    usu.Contrasenia = dr["contrasenia"].ToString();
                    //   usu.Estado = dr["estado"].ToString();
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
        

        
    }
}
