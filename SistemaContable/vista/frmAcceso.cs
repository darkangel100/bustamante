using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaContable.vista
{
    public partial class frmAcceso : Form
    {
        public frmAcceso()
        {
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {
            llenausuario();
        }
        public void llenausuario()
        {
            try
            {
                datosUsuario objU = new datosUsuario();
                objU.getUsuarios().ListaUsuarios = objU.Traeusuarios();
                if (objU.getUsuarios().ListaUsuarios.Count == 0)
                {
                    MessageBox.Show("No existen registros de usuarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cmbUSU.DisplayMember = "NomUsu";
                cmbUSU.ValueMember = "IdUsu";
                cmbUSU.DataSource = objU.getUsuarios().ListaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
