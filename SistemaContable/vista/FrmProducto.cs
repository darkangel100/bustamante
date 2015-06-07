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
        private void btnModificar_Click(object sender, EventArgs e)
        {
            pnlProducto.Enabled = true;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ProductoDB pddb = new ProductoDB();
            int b = pddb.eliminarProductos();
            if (b != 0)
            {
                int r = pddb.guardar();
                if (r == 0)
                {
                    MessageBox.Show("No logro importar los productos", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Importacion de productos finalizada", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se logro limpiar la base de datos para iniciar la importacion", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

    }
}
