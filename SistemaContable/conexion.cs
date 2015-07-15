using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SistemaContable
{
    class conexion
    {
       string coneccion = "Database=panda; Data Source=localhost; User Id=Panda; Password=pandita";
        public MySqlConnection getConexion()
        {
            MySqlConnection obj = new MySqlConnection(coneccion);
            return obj;
        }
    }
}
