using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaContable.controlador;

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
            //Inicio
            try
            {
                UsuariosBD objU = new UsuariosBD();
                objU.getUsuarios().ListaUsuarios = objU.Traeusuarios();
                if (objU.getUsuarios().ListaUsuarios.Count == 0)
                {
                    MessageBox.Show("No existen registros de usuarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                comboBoxNomUsu.DisplayMember = "NomUsu";
                comboBoxNomUsu.ValueMember = "IdUsu";
                comboBoxNomUsu.DataSource = objU.getUsuarios().ListaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {

        }

    }
}
