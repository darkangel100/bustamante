using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaContable.vista;

namespace SistemaContable
{
    public partial class FrmPrincipal : Form
    {
        string tipo;
        public FrmPrincipal(string tip)
        {
            InitializeComponent();
            tipo = tip;
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor formProveedor = new FrmProveedor();
            formProveedor.ShowDialog();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto formProducto = new FrmProducto();
            formProducto.ShowDialog();
        }

        private void cuentaDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario formUsuario = new FrmUsuario();
            formUsuario.ShowDialog();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes formReportes = new FrmReportes();
            formReportes.ShowDialog();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEgreso formEgreso = new FrmEgreso();
            formEgreso.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngreso formIngreso = new FrmIngreso();
            formIngreso.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
