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

    }
}
