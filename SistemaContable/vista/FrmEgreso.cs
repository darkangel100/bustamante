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
        
        string usuario = "usu";
        int agrega = -1;
        string num = "", idpro = "";
        int id_factura, id_producto;

        private void label18_Click(object sender, EventArgs e)
        {

        }

        

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
           
            FacturaDB objfac = new FacturaDB();
            ProductoDB objproducto = new ProductoDB();
            
            num = objfac.traenumero();
            if (num.Equals(""))
            {
                id_factura = 1;
            }
            else
            {
                id_factura = Convert.ToInt32(num);
                id_factura++;
            }

            idpro = objproducto.traenumero();
            if (idpro.Equals(""))
            {
                id_producto = 1;
            }
            else
            {
                id_producto = Convert.ToInt32(idpro);
                id_producto++;
            }
            txtNomAsiento.CharacterCasing = CharacterCasing.Upper;
            
            llenaAsiento(cboNomAsiento);
        }
  
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
            cbo.DisplayMember = "NOMBREASIENTO";
            cbo.ValueMember = "NOMBREASIENTO";
            cbo.DataSource = objAsi.getAsiento().LISTAASIENTO;
            
        }

       private void btnGuardarAsiento_Click(object sender, EventArgs e)
        {
            
                AdicionaAsientoContable();
                Utiles.limpiar(panelAsiento.Controls);
           // Util.limpiar(tabPage1.Controls);
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
                objpa.getPago().FECHA = Convert.ToString(dtFechaAsiento);
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
            //Util.limpiar(pnlAsiento.Controls);
            Utiles.limpiar(panelAsiento.Controls);
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
        int numcajas, unidades, totalunidades;
        double  costocaja, total;

        private void btnAgregaDetalle_Click(object sender, EventArgs e)
        {

                numcajas = Convert.ToInt32(txtCantidadCajas.Text);
                unidades = Convert.ToInt32(txtCanUnidades.Text);
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

        }

        private void dtgDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtGuardaFactura_Click(object sender, EventArgs e)
        {
            
                AdicionaFactura();
                Utiles.limpiar(panelFactura.Controls);
            //Util.limpiar(tbpRegistroFactura.Controls);
                dtgDetalleFactura.Rows.Clear();
                dtgDetalleFactura.Columns.Clear();
        }

        public void AdicionaFactura()
        {
           
            try
            {

                FacturaDB objfac = new FacturaDB();
                DetalleFacturaDB objdefac = new DetalleFacturaDB();
                ProductoDB objproducto = new ProductoDB();
                LoteDB objLote = new LoteDB();

                int resp;
                
                objfac.getFactura().IDPROVEEDOR = usuario;
                objfac.getFactura().FECHA = dtpFechaFactura.Value.Date.ToShortDateString();
                objfac.getFactura().TOTAL = txtTotal.Text.Trim();
                objfac.getFactura().SUBTOTAL = txtSubTotal.Text.Trim();
                objfac.getFactura().IVA = txtIva.Text.Trim();
                objfac.getFactura().TIPOFACTURA = tipofac;

                objdefac.getDetalleFactura().IDFACTURA = Convert.ToString(id_factura);
                objdefac.getDetalleFactura().IDPRODUCTO = Convert.ToString(id_producto);
                objdefac.getDetalleFactura().CANTIDAD = totalunidades.ToString().Trim();
                objdefac.getDetalleFactura().NOMBREPRODUCTO = txtProducto.Text.Trim();
                objdefac.getDetalleFactura().COSTOUNITARIO = txtCostoUnidad.Text.Trim();
                objdefac.getDetalleFactura().COSTOTOTAL = total.ToString();

                objproducto.getProducto().Nombre = txtProducto.Text.Trim();
                objproducto.getProducto().Precio = Convert.ToDouble(txtCostoUnidad.Text);
                objproducto.getProducto().Estado = "A";
                objproducto.getProducto().Stock_global = totalunidades;

                objLote.getLote().CODLOTE = txtCodLote.Text.Trim();
                objLote.getLote().IDPRODUCTO = Convert.ToString(id_producto);
                objLote.getLote().DESCRIPCION = txtDescripcionAsiento.Text.Trim();
                objLote.getLote().STOCKUNIDADES = Convert.ToString(totalunidades);
                objLote.getLote().FECHAVENCIMINTO = dtpFechaCadu.Value.Date.ToShortDateString();
                objLote.getLote().FECHAELABORACION = dtpFechaEla.Value.Date.ToShortDateString();

                resp = objfac.InsertaFactura(objfac.getFactura());
                resp = objdefac.InsertaDetalleFactura(objdefac.getDetalleFactura());
                resp = objproducto.insertaProducto(objproducto.getProducto());
                resp = objLote.InsertaLote(objLote.getLote());

                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (cboCriterio.Items.Contains("NOMBRE"))
            {

            }
        }

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriterio.Items.Equals("NOMBRE"))
            {
                txtBuscaAsiento.Enabled = true;
                dtpBuscaAsiento.Enabled = false;
            }
            else
            {
             
                    txtBuscaAsiento.Enabled = false;
                    dtpBuscaAsiento.Enabled = true;
                
            }
            
        }

       
      

       
    }
}
