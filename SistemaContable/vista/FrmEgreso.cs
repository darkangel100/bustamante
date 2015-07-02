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
        string num = "",  idasiento = "", nombrepro = "";
        int id_factura, id_asien, idpro, fila, iddetalle;
        
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
            ProductoDB objpro = new ProductoDB();
            objpro.getProducto().Nombre = txtProducto.Text;
            int a=objpro.verificacionProducto(objpro.getProducto());
            if (a != 0)
            {
                objpro.setProducto(objpro.traeProducto(idpro, txtProducto.Text, "nombre"));
                idpro = objpro.getProducto().Id_producto;
                nombrepro = objpro.getProducto().Nombre;
                Agrega();
            }
            else
            {
                MessageBox.Show("No existe el producto en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
           

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
            dtgDetalleFactura.Rows[agrega].Cells[1].Value = idpro;
            dtgDetalleFactura.Rows[agrega].Cells[2].Value = nombrepro;
            dtgDetalleFactura.Rows[agrega].Cells[3].Value = totalunidades.ToString();
            dtgDetalleFactura.Rows[agrega].Cells[4].Value = txtCostoCaja.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[5].Value = dtpFechaEla.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[6].Value = dtpFechaCadu.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[7].Value = total.ToString();
            dtgDetalleFactura.Rows[agrega].Cells[8].Value = txtCostoUnidad.Text.Trim();

            txtSubTotal.Text = subtotal.ToString();
            txtIva.Text = iva.ToString();
            txtTotal.Text = totalfactura.ToString();
            Utiles.limpiar(paneldatosfactura.Controls);
        }
        private void txtGuardaFactura_Click(object sender, EventArgs e)
        {
            IDFACTURA();
            IDEASIENTO();
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
                
                int resplo;
                int resppag;

                objasi.getAsientoContable().IDUSUARIO = usuario;
                objasi.getAsientoContable().NOMBRE_ASIENTO = "COMPRA DE MERCADERIA";
                objasi.getAsientoContable().DESCRIPCION = txtDescripFactura.Text;
                respa = objasi.InsertaAsientoContable(objasi.getAsientoContable());
                if (respa == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                objfac.getFactura().IDPROVEEDOR = 1;
                objfac.getFactura().IDFACTURA = id_asien;
                objfac.getFactura().FECHA = Utiles.girafecha(dtpFechaFactura.Value.ToShortDateString());
                objfac.getFactura().TOTAL = total;
                objfac.getFactura().SUBTOTAL = subtotal;
                objfac.getFactura().IVA = iva;
                objfac.getFactura().TIPOFACTURA = tipofac;
                respf = objfac.InsertaFactura(objfac.getFactura());
                if (respf == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    for (int i = 0; i <= agrega; i++)
                    {
                        
                        objdefac.getDetalleFactura().IDFACTURA = Convert.ToString(id_asien);
                        objdefac.getDetalleFactura().IDPRODUCTO = dtgDetalleFactura.Rows[i].Cells[1].Value.ToString();
                        objdefac.getDetalleFactura().CANTIDAD = totalunidades.ToString();
                        objdefac.getDetalleFactura().NOMBREPRODUCTO = dtgDetalleFactura.Rows[i].Cells[2].Value.ToString();
                        objdefac.getDetalleFactura().COSTOUNITARIO = dtgDetalleFactura.Rows[i].Cells[8].Value.ToString();
                        objdefac.getDetalleFactura().COSTOTOTAL = dtgDetalleFactura.Rows[i].Cells[7].Value.ToString();

                        objLote.getLote().CODLOTE = dtgDetalleFactura.Rows[i].Cells[0].Value.ToString();
                        objLote.getLote().IDPRODUCTO = dtgDetalleFactura.Rows[i].Cells[1].Value.ToString();
                        objLote.getLote().DESCRIPCION = txtDescripFactura.Text;
                        objLote.getLote().STOCKUNIDADES = Convert.ToString(totalunidades);
                        objLote.getLote().FECHAVENCIMINTO = Utiles.girafecha(dtpFechaCadu.Value.ToShortDateString());
                        objLote.getLote().FECHAELABORACION = Utiles.girafecha(dtpFechaEla.Value.ToShortDateString());

                    }

                }
                respdf = objdefac.InsertaDetalleFactura(objdefac.getDetalleFactura());
                if (respdf == 0)
                {
                    MessageBox.Show("No se ingreso datos de  detalle Factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("detalle Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                resplo = objLote.InsertaLote(objLote.getLote());
                if (resplo == 0)
                {
                    MessageBox.Show("No se ingreso datos de Lote", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lote Factura Ingresada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                objpa.getPago().IDPAGO = Convert.ToString(id_asien);
                objpa.getPago().FECHA = Utiles.girafecha(dtpFechaFactura.Value.ToShortDateString());
                objpa.getPago().MONTO = txtTotal.Text;
                resppag = objpa.InsertaPago(objpa.getPago());
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

        private void cboCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCriterio.Text=="NOMBRE")
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

        private void txtCostoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (Char.IsDigit(e.KeyChar))
             {
                 e.Handled = false;
             }
             else if (Char.IsControl(e.KeyChar))
             {
                 e.Handled = false;
             }
             else if (Char.IsPunctuation(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 e.Handled = true;
                 MessageBox.Show("Introducir solo Numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            AsientoContableDB objasc = new AsientoContableDB();
            FacturaBD objf = new FacturaBD();
            PagoDB objpa = new PagoDB();
            try
            {
                if (cboCriterio.Text == "NOMBRE")
                {
                    traedatoasiento();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void traedatoasiento()
        {
            try
            {
                AsientoContableDB objasicon = new AsientoContableDB();
                objasicon.getAsientoContable().LISTAASIENTO = objasicon.traeasicon(txtBuscaAsiento.Text);
                if (objasicon.getAsientoContable().LISTAASIENTO.Count == 0)
                {
                    MessageBox.Show("No existen registros de cliente", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < objasicon.getAsientoContable().LISTAASIENTO.Count; i++)
                    {
                        dgvAsientoBusca.Rows.Add(1);
                        dgvAsientoBusca.Rows[i].Cells[0].Value = objasicon.getAsientoContable().LISTAASIENTO[i].IDASIENTO;
                        dgvAsientoBusca.Rows[i].Cells[1].Value = objasicon.getAsientoContable().LISTAASIENTO[i].NOMBRE_ASIENTO;
                        dgvAsientoBusca.Rows[i].Cells[2].Value = objasicon.getAsientoContable().LISTAASIENTO[i].DESCRIPCION;
                        dgvAsientoBusca.Rows[i].Cells[3].Value = objasicon.getAsientoContable().LISTAASIENTO[i].ESTADO;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsientoBusca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvAsientoBusca.CurrentRow.Index;
            iddetalle = Convert.ToInt32(dgvAsientoBusca.CurrentRow.Cells[0].Value);
            
            llenadetalle(iddetalle);
           

        }
        private void llenadetalle(int id)
        {
             try
            {
                FacturaDB objfac = new FacturaDB();
                objfac.getFactura().LISTAFACTURA = objfac.traefacid(iddetalle);
                if (objfac.getFactura().LISTAFACTURA.Count == 0)
                {
                    MessageBox.Show("No existen registros de cliente", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int i = 0; i < objasicon.getAsientoContable().LISTAASIENTO.Count; i++)
                    {
                //        dgvAsientoBusca.Rows.Add(1);
                //        dgvAsientoBusca.Rows[i].Cells[0].Value = objasicon.getAsientoContable().LISTAASIENTO[i].IDASIENTO;
                //        dgvAsientoBusca.Rows[i].Cells[1].Value = objasicon.getAsientoContable().LISTAASIENTO[i].NOMBRE_ASIENTO;
                //        dgvAsientoBusca.Rows[i].Cells[2].Value = objasicon.getAsientoContable().LISTAASIENTO[i].DESCRIPCION;
                //        dgvAsientoBusca.Rows[i].Cells[3].Value = objasicon.getAsientoContable().LISTAASIENTO[i].ESTADO;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
