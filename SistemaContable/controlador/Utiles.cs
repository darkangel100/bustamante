using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SistemaContable.controlador
{
    class Utiles
    {


        public static int IdUsuarioActual;
        /// <summary>
        /// Limpia los componentes de un panel
        /// </summary>
        /// <param name="cont">coleccion de componentes</param>
        public static void limpiar(Control.ControlCollection cont)
        {
            foreach (Control c in cont)
            {
                if (c is TextBox)
                    c.Text = "";
            }
        }
        public static string girafecha(String f)
        {
            String fec = "";
            fec = f.Substring(6, 4) + "-" + f.Substring(3, 2) + "-" + f.Substring(0, 2);
            return fec;
        }
        public static string codi(string cod, int nro)
        {
            string num = cod;
            nro++;
            if (nro < 10)
                num += "000" + Convert.ToString(nro);
            else if (nro < 100)
                num += "00" + Convert.ToString(nro);
            else if (nro < 1000)
                num += "0" + Convert.ToString(nro);
            else
                num += Convert.ToString(nro);
            return num;
        }

        public string girafechaVenta(String f)
        {
            String fec = "";
            fec = f.Substring(6, 4) + "-" + f.Substring(3, 2) + "-" + f.Substring(0, 2);
            return fec;
        }

        public static string fecha(DateTimePicker dtp)
        {
            int a = dtp.Value.Year;
            int m = dtp.Value.Month;
            string ms = m.ToString();
            if (m < 10)
            {
                ms = "0" + m;
            }
            int d = dtp.Value.Day;
            string ds = d.ToString();
            if (d < 10)
            {
                ds = "0" + d;
            }
            string f = a + "-" + ms + "-" + ds;
            return f;
        }
        public static string ObtenerRuta()
        {
            string directory = "";
            directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return directory;
        }
        public static void guardarReporte(string datos, string nombre)
        {
            try
            {
                StreamWriter escribir = new StreamWriter(Utiles.ObtenerRuta() + "/Panda/" + nombre + ".html");
                escribir.Write(datos);
                escribir.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
