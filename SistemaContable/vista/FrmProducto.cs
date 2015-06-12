using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaContable.controlador;

namespace SistemaContable.vista
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        string url;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            pnlProducto.Enabled = true;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
           //revisar metodo
            ProductoDB pddb = new ProductoDB();
            ofdUrl.ShowDialog();
            int r = pddb.guardar(url);
            if (r == 0)
                MessageBox.Show("No logro importar los productos", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (r == -5)
                MessageBox.Show("No hay nuevos productos a importar", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            if(r>0)
                MessageBox.Show("Importacion de productos finalizada", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);  
            llenaProductos();
        }


        //metodo para presentar los datos en la tabla
        public void llenaProductos()
        {
            try
            {
                dgvProductos.Rows.Clear();
                ProductoDB objC = new ProductoDB();
                objC.getProducto().ListaProducto = objC.traeProductos();
                if (objC.getProducto().ListaProducto.Count == 0)
                {
                    MessageBox.Show("No existen productos registrados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int i = 0; i < objC.getProducto().ListaProducto.Count; i++)
                    {
                        dgvProductos.Rows.Add(1); //añade una fila a la tabla
                        dgvProductos.Rows[i].Cells[0].Value = objC.getProducto().ListaProducto[i].Id_producto;
                        dgvProductos.Rows[i].Cells[1].Value = objC.getProducto().ListaProducto[i].Nombre;
                        dgvProductos.Rows[i].Cells[2].Value = objC.getProducto().ListaProducto[i].Stock_global;
                        dgvProductos.Rows[i].Cells[3].Value = objC.getProducto().ListaProducto[i].Precio;
                        dgvProductos.Rows[i].Cells[4].Value = objC.getProducto().ListaProducto[i].Estado;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos, " + ex.Message, "Tienda", MessageBoxButtons.OK);
            }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            llenaProductos();
        }

        private void ofdUrl_FileOk(object sender, CancelEventArgs e)
        {
            url = ofdUrl.FileName;
        }

        private void btnAtras1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
