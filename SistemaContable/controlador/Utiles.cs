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
        
        /// <summary>
        /// Convierte la fecha ingresada en el DateTimePicker en una cadena con formato aa-mm-dd para insertar en la base de datos
        /// </summary>
        /// <param name="dtp">Objeto de tipo DateTimePicker</param>
        /// <returns>Cadena que contiene la fecha</returns>
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

        /// <summary>
        /// Devuelve la ruta de donde se encuentra ubicada la Carpeta "Mis Documentos"
        /// </summary>
        /// <returns>Cadena con la ruta de la carpeta</returns>
        public static string ObtenerRuta()
        {
            string directory = "";
            directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return directory;
        }

        /// <summary>
        /// Guarda la cadena de texto en unarchivo .html con el nombre especificado
        /// </summary>
        /// <param name="datos">Cadena de texto</param>
        /// <param name="nombre">Cadena con el nombre del documento</param>
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
