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
            try
            {
                ProductoDB pddb = new ProductoDB();
                ofdUrl.ShowDialog();
                int r = pddb.guardar(url);
                if (r == 0)
                    MessageBox.Show("No logro importar los productos", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (r == -5)
                    MessageBox.Show("No hay nuevos productos a importar", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (r > 0)
                    MessageBox.Show("Importacion de productos finalizada", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                llenaProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Archivo no seleccionado", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        public void llenaProductos(ComboBox cbo)
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
                    cbo.DisplayMember = "Nombre";
                    cbo.ValueMember = "Id_producto";
                    cbo.DataSource = objC.getProducto().ListaProducto;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ProductoDB p=new ProductoDB();
            if (cmbCriterio.Text == "Nombre")
            {
                mostrarProducto(0, "nombre");
            }
            else
                if(txtBusqueda.Text!="")
                    mostrarProducto(int.Parse(txtBusqueda.Text), "id");
            
        }
        private void mostrarProducto(int i,string c)
        {
            ProductoDB objB = new ProductoDB();
            try
            {
                
                objB.setProducto(objB.traeProducto(i, txtBusqueda.Text, c));
                txtCodB.Text = objB.getProducto().Id_producto.ToString();
                txtNomB.Text = objB.getProducto().Nombre;
                txtPrecioB.Text = objB.getProducto().Precio.ToString();
                txtStockB.Text = objB.getProducto().Stock_global.ToString();
                if (objB.getProducto().Estado == "a")
                    rdbActivo.Checked = true;
                else
                    rdbInactivo.Checked = true;
                
            }
            catch (Exception e)
            {
                MessageBox.Show("No existe producto registrado con dicho " + cmbCriterio.Text, "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar.Enabled = true;
            txtBusqueda.Text = "";
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbCriterio.Text == "Nombre")
            {
                if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar!=8) 
                {
                    e.Handled = true;
                }   
            }
            if (cmbCriterio.Text == "Codigo" && e.KeyChar != 8)
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cmbCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar==8 || char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            ProductoDB objB = new ProductoDB();
            objB.getProducto().Nombre = txtNomB.Text;
            objB.getProducto().Precio = double.Parse(txtPrecioB.Text);
            objB.getProducto().Stock_global = int.Parse(txtStockB.Text);
            if (rdbActivo.Checked)
                objB.getProducto().Estado = "i";
            else
                objB.getProducto().Estado = "a";

            int resp = objB.modificarProducto(objB.getProducto());
            if (resp == 0)
            {
                MessageBox.Show("No se modifico el estado del producto", "Sistema Contable", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Estado del producto modificado", "Sistema Contable", MessageBoxButtons.OK);
                llenaProductos();
                Utiles.limpiar(pnlProducto.Controls);
                cmbCriterio.Text = "";
                txtBusqueda.Text = "";
                tcProducto.SelectTab(0);
            }
        }
    }
}
