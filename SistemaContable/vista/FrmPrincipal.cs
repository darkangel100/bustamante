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
using SistemaContable.controlador;

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
            formProveedor.MdiParent = this;
            formProveedor.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto formProducto = new FrmProducto();
            formProducto.MdiParent = this;
            formProducto.Show();
        }

        private void cuentaDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmUsuarios f1 = new FrmUsuarios();
            f1.MdiParent = this;
            f1.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReportes formReportes = new FrmReportes();
            formReportes.MdiParent = this;
            formReportes.Show();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tipo.Equals("B"))
            {

            }
            else
            {
                FrmEgreso formEgreso = new FrmEgreso();
                formEgreso.MdiParent = this;
                formEgreso.Show();
            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngreso formIngreso = new FrmIngreso();
            formIngreso.MdiParent = this;
            formIngreso.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            proveedorDefault();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void proveedorDefault()
        {
            try
            {
                DistribuidoraDB d = new DistribuidoraDB();
                d.setDistribuidora(d.traeDistribuidora(0,"default"));
                ProveedorDB p = new ProveedorDB();
                if (p.verificacion("default") == 0)
                    p.insertaDistribuidora(null,d.getDistribuidora().Id);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
