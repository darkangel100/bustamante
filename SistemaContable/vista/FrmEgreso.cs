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
       //VARIABLES
        string tipofac = "C";
        string usuario = "usu";
        int agrega = -1;
        string num = "", idpro = "", idasiento = "";
        int id_factura, id_producto, id_asien;

        //TRAE EL ID DE ASIENTO
        private void IDEASIENTO()
        {
            AsientoContableDB objasicon = new AsientoContableDB();
            idasiento = objasicon.traenumero();
            if (idasiento.Equals(""))
            {
                id_asien = 1;
            }
            else
            {
                id_asien = Convert.ToInt32(idasiento);
                id_asien++;
            }
        }

        //TRAE EL ID DE LA FACTURA
        private void IDFACTURA()
        {
            FacturaDB objfac = new FacturaDB();
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
       }
        //TRAE EL ULTIMO ID DE PRODUCTO
        private void IDPRODUCTO()
        {
            ProductoDB objproducto = new ProductoDB();
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
        }

        //CARGA DATOS DE INICIALIZACION DEL FRM EGRESO
        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            txtNomAsiento.CharacterCasing = CharacterCasing.Upper;
            llenaAsiento(cboNomAsiento);
        }
  //CARGA LOS ASIENTOS_CONTABLES AL COMBOBOX
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
        //ASIENTO CONTABLE
       private void btnGuardarAsiento_Click(object sender, EventArgs e)
        {
            IDEASIENTO();
            AdicionaAsientoContable();
            Utiles.limpiar(tbAsientoContable.Controls);
        }
        //INGRESA ASIENTO_CONTABLE A LA BASE DE DATOS
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
                
                
                objpa.getPago().IDPAGO = id_asien.ToString();
                objpa.getPago().FECHA = Utiles.girafecha(dtFechaAsiento.Value.ToShortDateString());
                objpa.getPago().MONTO = txtMonto.Text.Trim();

                resp = objAs.InsertaAsientoContable(objAs.getAsientoContable());
                resp = objpa.InsertaPago(objpa.getPago());
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
            Utiles.limpiar(pnlAsiento.Controls);
            Utiles.limpiar(panelAsiento.Controls);
        }
        //ASIENTO
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
        double costocaja, total, costounidad;

        private void btnAgregaDetalle_Click(object sender, EventArgs e)
        {
            Agrega();
        }

        private void Agrega()
        {
            numcajas = Convert.ToInt32(txtCantidadCajas.Text);
            unidades = Convert.ToInt32(txtCanUnidades.Text);
            costocaja = Convert.ToDouble(txtCostoCaja.Text);
            costounidad = Convert.ToDouble(txtCostoUnidad.Text);

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
            Utiles.limpiar(paneldatosfactura.Controls);
        }
        private void txtGuardaFactura_Click(object sender, EventArgs e)
        {
            IDFACTURA();
            IDEASIENTO();
            IDPRODUCTO();
            AdicionaFactura();
            Utiles.limpiar(tbpRegistroFactura.Controls);
            dtgDetalleFactura.Rows.Clear();
            dtgDetalleFactura.Columns.Clear();
            Close();
        }

        public void AdicionaFactura()
        {
            try
            {
                AsientoContableDB objasi = new AsientoContableDB();
                FacturaDB objfac = new FacturaDB();
                DetalleFacturaDB objdefac = new DetalleFacturaDB();
                ProductoDB objproducto = new ProductoDB();
                LoteDB objLote = new LoteDB();
                PagoDB  objpa = new PagoDB();

                int respa;
                int respf;
                int respdf;
                int resppro;
                int resplo;
                int resppag;

                objasi.getAsientoContable().IDUSUARIO = usuario;
                objasi.getAsientoContable().NOMBRE_ASIENTO = "COMPRA DE MERCADERIA";
                objasi.getAsientoContable().DESCRIPCION = txtDescripFactura.Text;
                respa = objasi.InsertaAsientoContable(objasi.getAsientoContable());

                objfac.getFactura().IDPROVEEDOR = usuario;
                objfac.getFactura().IDFACTURA = Convert.ToString(id_asien);
                objfac.getFactura().FECHA = Utiles.girafecha(dtpFechaFactura.Value.ToShortDateString());
                objfac.getFactura().TOTAL = txtTotal.Text;
                objfac.getFactura().SUBTOTAL = txtSubTotal.Text;
                objfac.getFactura().IVA = txtIva.Text;
                objfac.getFactura().TIPOFACTURA = tipofac;
                respf = objfac.InsertaFactura(objfac.getFactura());

                objproducto.getProducto().Nombre = txtProducto.Text;
                objproducto.getProducto().Precio = costounidad;
                objproducto.getProducto().Estado = "A";
                objproducto.getProducto().Stock_global = totalunidades;
                resppro = objproducto.insertaProducto(objproducto.getProducto());

                if (resppro == 0)
                {
                    MessageBox.Show("No se ingreso datos de  producto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Producto Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < agrega; i++)
                    {
                        //objI.getDetalleFactura().idfac = Convert.ToInt32(txtid.Text);
                        //objI.getDetalleFactura().codpro = dgDatos.Rows[i].Cells[1].Value.ToString();
                        //cp = dgDatos.Rows[i].Cells[1].Value.ToString();
                        //objI.getDetalleFactura().canfac = Convert.ToInt32(dgDatos.Rows[i].Cells[0].Value);
                        //cca = Convert.ToInt32(dgDatos.Rows[i].Cells[0].Value);
                        //objI.getDetalleFactura().preven = Convert.ToDouble(dgDatos.Rows[i].Cells[3].Value);
                        //objI.getDetalleFactura().pretot = Convert.ToDouble(dgDatos.Rows[i].Cells[5].Value);
                        //resp1 = objI.InsertaItemFactura(objI.getDetalleFactura());

                        objdefac.getDetalleFactura().IDFACTURA = Convert.ToString(id_asien);
                        objdefac.getDetalleFactura().IDPRODUCTO = Convert.ToString(id_producto);
                        objdefac.getDetalleFactura().CANTIDAD = totalunidades.ToString();
                        objdefac.getDetalleFactura().NOMBREPRODUCTO = txtProducto.Text;
                        objdefac.getDetalleFactura().COSTOUNITARIO = txtCostoUnidad.Text;
                        objdefac.getDetalleFactura().COSTOTOTAL = total.ToString();
                    }
                }
                

                objLote.getLote().CODLOTE = txtCodLote.Text;
                objLote.getLote().IDPRODUCTO = Convert.ToString(id_producto);
                objLote.getLote().DESCRIPCION = txtDescripcionAsiento.Text;
                objLote.getLote().STOCKUNIDADES = Convert.ToString(totalunidades);
                objLote.getLote().FECHAVENCIMINTO = Utiles.girafecha(dtpFechaCadu.Value.ToShortDateString());
                objLote.getLote().FECHAELABORACION = Utiles.girafecha(dtpFechaEla.Value.ToShortDateString());

                

                objpa.getPago().IDPAGO = Convert.ToString(id_asien);
                objpa.getPago().FECHA = Utiles.girafecha(dtpFechaFactura.Value.ToShortDateString());
                objpa.getPago().MONTO = txtTotal.Text;

                
                
                
                respdf = objdefac.InsertaDetalleFactura(objdefac.getDetalleFactura());
                resplo = objLote.InsertaLote(objLote.getLote());
                resppag = objpa.InsertaPago(objpa.getPago());

                if (respa == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (respf == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                
                if (respdf == 0)
                {
                    MessageBox.Show("No se ingreso datos de  detalle Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("detalle Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (resplo == 0)
                {
                    MessageBox.Show("No se ingreso datos de Lote", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lote Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (resppag == 0)
                {
                    MessageBox.Show("No se ingreso datos de Pago", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Pago Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cboCriterio.SelectedIndex.Equals(0))
            {
                txtBuscaAsiento.Enabled = true;
                dtpBuscaAsiento.Enabled = false;
            }
            else
            {
                dtpBuscaAsiento.Enabled = true;
                txtBuscaAsiento.Enabled = false;
            }
            
        }
    }
}
