using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaContable.controlador
{
    class Util
    {
        public static void limpiar(Control.ControlCollection cont)
        {
            foreach (Control c in cont)
            {
                if (c is TextBox)
                    c.Text = "";
            }
        }
    }
}
