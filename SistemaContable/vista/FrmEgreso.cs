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
using SistemaContable.modelo;

namespace SistemaContable.vista
{
    public partial class FrmEgreso : Form
    {
        public FrmEgreso()
        {
            InitializeComponent();
            
        }
        string tipofac = "C";
        string estado = "";
        string usuario = "usu";
        int agrega = -1;
        private void label18_Click(object sender, EventArgs e)
        {

        }

        

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            txtNomAsiento.CharacterCasing = CharacterCasing.Upper;
            estado = "N";
            llenaAsiento(cboNomAsiento);
            //llenaProveedor(cboProvedor);
        }
        //private void llenaProveedor(ComboBox cbo)
        //{
        //    ProveedorDB objPro = new ProveedorDB();
        //    objjPro.getProveedor().LISTAPROVEEDOR = objPro.traeProveedor();
            
        //    if (objPro.getProveedor().LISTAPROVEEDOR.Count == 0)
        //    {
        //        MessageBox.Show("No existen registros de Asientos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        pnlAsiento.Enabled = true;
        //        txtNomAsiento.Focus();
        //        btnGuardarAsiento.Enabled = false;
        //    }
        //    cboNomAsiento.DisplayMember = "nombre_asiento";
        //    cboNomAsiento.ValueMember = "nombre_asiento";
        //    cboNomAsiento.DataSource = objAsi.getAsiento().LISTAASIENTO;

        //}
        private void llenaAsiento(ComboBox cbo)
        {
            AsientoDB objAsi = new AsientoDB();
            objAsi.getAsiento().LISTAASIENTO = objAsi.traeAsiento();
            if (objAsi.getAsiento().LISTAASIENTO.Count == 0)
            {
                MessageBox.Show("No existen registros de Asientos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pnlAsiento.Enabled = true;
                txtNomAsiento.Focus();
                btnGuardarAsiento.Enabled = false;
            }
            cboNomAsiento.DisplayMember = "nombre_asiento";
            cboNomAsiento.ValueMember = "nombre_asiento";
            cboNomAsiento.DataSource = objAsi.getAsiento().LISTAASIENTO;
            
        }

       private void btnGuardarAsiento_Click(object sender, EventArgs e)
        {
            if (estado == "N")
            {
                AdicionaAsientoContable();
            }
        }

        private void AdicionaAsientoContable()
        {
            try
            {
                AsientoContableDB objAs = new AsientoContableDB();
                PagoDB objpa = new PagoDB();
                int resp;

                objAs.getAsientoContable().IDUSUARIO = usuario;
                objAs.getAsientoContable().NOMBRE_ASIENTO = cboNomAsiento.Text.Trim();
                objAs.getAsientoContable().DESCRIPCION = txtDescripcionAsiento.Text.Trim();
                objpa.getPago().FECHA = dtFechaAsiento.Text.Trim();
                objpa.getPago().MONTO = txtMonto.Text.Trim();

                resp = objpa.InsertaPago(objpa.getPago());
                resp = objAs.InsertaAsientoContable(objAs.getAsientoContable());
                
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos del Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estado = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardaAsi_Click(object sender, EventArgs e)
        {
            AdicionaAsiento();
            btnGuardarAsiento.Enabled = true;
            pnlAsiento.Enabled = false;
            llenaAsiento(cboNomAsiento);
        }
        private void AdicionaAsiento()
        {
            try
            {
                AsientoDB objAs = new AsientoDB();
                int resp;
                objAs.getAsiento().NOMBREASIENTO = txtNomAsiento.Text.Trim();
                resp = objAs.InsertaAsiento(objAs.getAsiento());
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos del Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estado = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= '0' && le <= '9')||(le==8)||(le==44))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros");
            }
        }

        private void txtNomAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= 'A' && le <= 'Z') || (le >= 'a' && le <= 'z') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo letras");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnlAsiento.Enabled = true;
            txtNomAsiento.Focus();
        }
        double subtotal = 0, iva, totalfactura;

        private void calculaproducto(string nombrepro,int num)
        {
            string nombre = "";
            
            
        }

        private void btnAgregaDetalle_Click(object sender, EventArgs e)
        {

            string np = "";
            int dato = 0;
            np = txtProducto.Text;

            ComboBox cbo = new ComboBox();
            ProductoDB objC = new ProductoDB();
            objC.getProducto().ListaProducto = objC.traeProductos();
            if (objC.getProducto().ListaProducto.Count != 0)
            {
                cbo.DisplayMember = "nombre";
                cbo.ValueMember = "id_producto";
                cbo.DataSource = objC.getProducto().ListaProducto;
                if (cbo.Items.Contains(np))
                {
                    dato = 1;
                }
            }

            if (dato == 1)
            {
                MessageBox.Show("El producto no existe");
            }
            else
            {
                int numcajas;
                double unidades, costocaja, totalunidades, total;



                numcajas = Convert.ToInt32(txtCantidadCajas.Text);
                unidades = Convert.ToDouble(txtCanUnidades.Text);
                costocaja = Convert.ToDouble(txtCostoCaja.Text);


                totalunidades = numcajas * unidades;
                total = costocaja * numcajas;

                subtotal = subtotal + total;
                iva = subtotal * 0.12;
                totalfactura = subtotal + iva;

                agrega++;
                dtgDetalleFactura.Rows.Add(1);
                dtgDetalleFactura.Rows[agrega].Cells[0].Value = txtCodLote.Text.Trim();
                dtgDetalleFactura.Rows[agrega].Cells[1].Value = txtProducto.Text.Trim();
                dtgDetalleFactura.Rows[agrega].Cells[2].Value = totalunidades.ToString();
                dtgDetalleFactura.Rows[agrega].Cells[3].Value = txtCostoCaja.Text.Trim();
                dtgDetalleFactura.Rows[agrega].Cells[4].Value = dtpFechaEla.Text.Trim();
                dtgDetalleFactura.Rows[agrega].Cells[5].Value = dtpFechaCadu.Text.Trim();
                dtgDetalleFactura.Rows[agrega].Cells[6].Value = total.ToString();

                txtSubTotal.Text = subtotal.ToString();
                txtIva.Text = iva.ToString();
                txtTotal.Text = totalfactura.ToString();

                //dtgDetalleFactura.Rows[agrega].Cells[0].Value = cboProvedor.Text.Trim();
                //dtgDetalleFactura.Rows[agrega].Cells[1].Value = dtpFechaFactura.Text.Trim();
                //dtgDetalleFactura.Rows[agrega].Cells[2].Value = txtTotal.Text.Trim();
                //dtgDetalleFactura.Rows[agrega].Cells[3].Value = txtSubTotal.Text.Trim();
                //dtgDetalleFactura.Rows[agrega].Cells[4].Value = txtIva.Text.Trim();
                //dtgDetalleFactura.Rows[agrega].Cells[5].Value = tipofac;
            }
            
        }

        private void dtgDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGuardaFactura_Click(object sender, EventArgs e)
        {

        }   
    }
}
