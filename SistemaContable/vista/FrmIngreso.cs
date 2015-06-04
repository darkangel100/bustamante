using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaContable.vista
{
    public partial class FrmIngreso : Form
    {
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlFactura.Enabled = true;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
