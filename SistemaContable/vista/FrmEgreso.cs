﻿using System;
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
        string tipofac = "c";
        string usuario = "usu";
        int agrega = -1;
        string num = "",  idasiento = "", nombrepro = "";
        int id_factura, id_asien, idpro, fila, iddetalle, idproveedor;
        
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
            FrmProveedor f = new FrmProveedor();
            f.llenaProveedor(cboProvedor);
            txtNomAsiento.CharacterCasing = CharacterCasing.Upper;
            llenaAsiento(cboNomAsiento);
            FrmProducto fprod = new FrmProducto();
            fprod.llenaProductos(cboProductoFac);


        }
  //CARGA LOS ASIENTOS_CONTABLES AL COMBOBOX
        public void llenaAsiento(ComboBox cbo)
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
            if (txtMonto.TextLength < 0 || txtDescripcionAsiento.TextLength < 5)
            {
                MessageBox.Show("Faltan datos");
            }
            else
            {
                AdicionaAsientoContable();
                Utiles.limpiar(tbAsientoContable.Controls);
            }
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
                resp = objAs.InsertaAsientoContable(objAs.getAsientoContable());
                
                IDEASIENTO();
                
                objpa.getPago().IDPAGO = id_asien.ToString();
                objpa.getPago().FECHA = Utiles.fecha(dtFechaAsiento);
                objpa.getPago().MONTO = Convert.ToDouble(txtMonto.Text);


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
            if (txtNomAsiento.Text == "")
            {
                MessageBox.Show("Faltan Datos");
            }
            else
            {
                AdicionaAsiento();
                btnGuardarAsiento.Enabled = true;
                pnlAsiento.Enabled = false;
                llenaAsiento(cboNomAsiento);
                Utiles.limpiar(pnlAsiento.Controls);
            }
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
            if ((le >= '0' && le <= '9') || (le == 8) || (le == 46))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros");
            }
        }

        private void txtNomAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //METODO PARA INGRESAR SOLO LETRAS
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
            if (txtCodLote.Text == "" || txtCantidadCajas.Text == "" || txtCanUnidades.Text == "" || txtCostoCaja.Text == "" || txtCostoUnidad.Text == "" || cboProductoFac.Text == "")
            {
                MessageBox.Show("Faltan datos de la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dtpFechaEla.Value.ToShortDateString() == dtpFechaFactura.Value.ToShortDateString() || dtpFechaCadu.Value.ToShortDateString() == dtpFechaFactura.Value.ToShortDateString())
                {
                    MessageBox.Show("La fecha de elaboracion o fecha de  caducacion no pueden ser iguales a la fecha actual ");
                }
                else
                {
                    if (dtpFechaEla.Value.ToShortDateString() == dtpFechaCadu.Value.ToShortDateString())
                    {
                        MessageBox.Show("La fecha de elaboracion o fecha de  caducacion no pueden ser iguales");
                    }
                    else
                    {
                        ProductoDB objpro = new ProductoDB();
                        objpro.getProducto().Nombre = cboProductoFac.Text;
                        int a = objpro.verificacionProducto(objpro.getProducto());
                        if (a != 0)
                        {
                            objpro.setProducto(objpro.traeProducto(idpro, cboProductoFac.Text, "nombre"));
                            idpro = objpro.getProducto().Id_producto;
                            nombrepro = objpro.getProducto().Nombre;
                            Agrega();
                        }
                        else
                        {
                            MessageBox.Show("No existe el producto en la base de datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }
        
        private void Agrega()
        {
            numcajas = Convert.ToInt32(txtCantidadCajas.Text);
            unidades = Convert.ToInt32(txtCanUnidades.Text);
            costocaja = Convert.ToDouble(txtCostoCaja.Text);
            costounidad = Convert.ToDouble(txtCostoUnidad.Text);

            totalunidades = numcajas * unidades;
            total = totalunidades * costounidad;

            subtotal = subtotal + total;
            iva = subtotal * 0.12;
            totalfactura = subtotal + iva;

            agrega++;
            dtgDetalleFactura.Rows.Add(1);
            dtgDetalleFactura.Rows[agrega].Cells[0].Value = txtCodLote.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[1].Value = idpro;
            dtgDetalleFactura.Rows[agrega].Cells[2].Value = nombrepro;
            dtgDetalleFactura.Rows[agrega].Cells[3].Value = totalunidades.ToString();
            dtgDetalleFactura.Rows[agrega].Cells[4].Value = txtCostoUnidad.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[5].Value = dtpFechaEla.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[6].Value = dtpFechaCadu.Text.Trim();
            dtgDetalleFactura.Rows[agrega].Cells[7].Value = total.ToString();

            txtSubTotal.Text = subtotal.ToString();
            txtIva.Text = iva.ToString();
            txtTotal.Text = totalfactura.ToString();
            Utiles.limpiar(paneldatosfactura.Controls);
        }
        private void txtGuardaFactura_Click(object sender, EventArgs e)
        {
            if (txtDescripFactura.Text == "")
            {
                MessageBox.Show("Faltan datos de la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripFactura.Focus();
            }
            else
            {
                AdicionaFactura();
                Utiles.limpiar(tbpRegistroFactura.Controls);
                dtgDetalleFactura.Rows.Clear();
                dtgDetalleFactura.Columns.Clear();
                Close();
            }
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
                int respro;
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
                    IDEASIENTO();
                }

                objfac.getFactura().IDPROVEEDOR = Convert.ToInt32(cboProvedor.SelectedValue.ToString());
                objfac.getFactura().IDFACTURA = id_asien;
                objfac.getFactura().FECHA = Utiles.fecha(dtpFechaFactura);
                objfac.getFactura().TOTAL = totalfactura;
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
                        objdefac.getDetalleFactura().COSTOUNITARIO = dtgDetalleFactura.Rows[i].Cells[4].Value.ToString();
                        objdefac.getDetalleFactura().COSTOTOTAL = dtgDetalleFactura.Rows[i].Cells[7].Value.ToString();
                        respdf = objdefac.InsertaDetalleFactura(objdefac.getDetalleFactura());
                        if (respdf != 0)
                        {
                            
                                respro=objproducto.agregapro(dtgDetalleFactura.Rows[i].Cells[1].Value.ToString(),totalunidades);
                            
                        }
                        objLote.getLote().CODLOTE = dtgDetalleFactura.Rows[i].Cells[0].Value.ToString();
                        objLote.getLote().IDPRODUCTO = dtgDetalleFactura.Rows[i].Cells[1].Value.ToString();
                        objLote.getLote().DESCRIPCION = txtDescripFactura.Text;
                        objLote.getLote().STOCKUNIDADES = Convert.ToString(totalunidades);
                        objLote.getLote().FECHAVENCIMINTO = Utiles.fecha(dtpFechaCadu);
                        objLote.getLote().FECHAELABORACION = Utiles.fecha(dtpFechaEla);
                        resplo = objLote.InsertaLote(objLote.getLote());

                    }
                 
                }
                
                

                objpa.getPago().IDPAGO = Convert.ToString(id_asien);
                objpa.getPago().FECHA = Utiles.fecha(dtpFechaFactura);
                objpa.getPago().MONTO = Convert.ToDouble(txtTotal.Text);
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

       

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            dgvAsientoBusca.Rows.Clear();
            AsientoContableDB objasc = new AsientoContableDB();
            FacturaBD objf = new FacturaBD();
            PagoDB objpa = new PagoDB();
            try
            {
                if (cboCriterio.Text == "NOMBRE")
                {
                    traedatoasiento();
                }
                else
                {
                    traefechasiento();
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
        private void traefechasiento()
        {
            int idas;
            try
            {
                PagoDB objpago = new PagoDB();
                objpago.getPago().LISTAPAGO = objpago.traePAGOfecha(Utiles.girafecha(dtpBuscaAsiento.Value.ToShortDateString()));

                if (objpago.getPago().LISTAPAGO.Count == 0)
                {
                    MessageBox.Show("No existen registros de aseinto contable", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    for (int j = 0; j < objpago.getPago().LISTAPAGO.Count; j++)
                    {
                        idas = Convert.ToInt32(objpago.getPago().LISTAPAGO[j].IDPAGO);
                        AsientoContableDB objasicon = new AsientoContableDB();
                        objasicon.setAsientoContable(objasicon.cuentasLibros(idas));
                        dgvAsientoBusca.Rows.Add(1);
                        dgvAsientoBusca.Rows[j].Cells[0].Value = objasicon.getAsientoContable().IDASIENTO;
                        dgvAsientoBusca.Rows[j].Cells[1].Value = objasicon.getAsientoContable().NOMBRE_ASIENTO;
                        dgvAsientoBusca.Rows[j].Cells[2].Value = objasicon.getAsientoContable().DESCRIPCION;
                        dgvAsientoBusca.Rows[j].Cells[3].Value = objasicon.getAsientoContable().ESTADO;


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
            dgvBuscaFactu.Rows.Clear();
            dgvBuscPago.Rows.Clear();
            fila = dgvAsientoBusca.CurrentRow.Index;
            iddetalle = Convert.ToInt32(dgvAsientoBusca.CurrentRow.Cells[0].Value);
            llenadetalle(iddetalle);
           

        }
        private void llenadetalle(int id)
        {
             try
            {
                //FacturaDB objfac = new FacturaDB();
                //objfac.getFactura().LISTAFACTURA = objfac.traefacid(iddetalle);
                PagoDB objpago = new PagoDB();
                objpago.getPago().LISTAPAGO = objpago.traePAGOtid(iddetalle);
                 DetalleFacturaDB objdetalle=new DetalleFacturaDB();
                 objdetalle.getDetalleFactura().LISTADETALLE=objdetalle.traedetaid(iddetalle);
                if (objdetalle.getDetalleFactura().LISTADETALLE.Count==0)
                {
                    
                    if (objpago.getPago().LISTAPAGO.Count == 0)
                    {
                        MessageBox.Show("No existen registros de asiento contable", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        for (int i = 0; i < objpago.getPago().LISTAPAGO.Count; i++)
                        {
                            dgvBuscPago.Rows.Add(1);
                            dgvBuscPago.Rows[i].Cells[0].Value = objpago.getPago().LISTAPAGO[i].FECHA;
                            dgvBuscPago.Rows[i].Cells[1].Value = objpago.getPago().LISTAPAGO[i].MONTO;
                            dgvBuscPago.Rows[i].Cells[2].Value = dgvAsientoBusca.Rows[fila].Cells[2].Value;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < objdetalle.getDetalleFactura().LISTADETALLE.Count;i++)
                    {
                        dgvBuscaFactu.Rows.Add(1);
                        dgvBuscaFactu.Rows[i].Cells[0].Value = objpago.getPago().LISTAPAGO[0].FECHA;
                        dgvBuscaFactu.Rows[i].Cells[1].Value = objdetalle.getDetalleFactura().LISTADETALLE[i].CANTIDAD;
                        dgvBuscaFactu.Rows[i].Cells[2].Value = objdetalle.getDetalleFactura().LISTADETALLE[i].NOMBREPRODUCTO;
                        dgvBuscaFactu.Rows[i].Cells[3].Value = objdetalle.getDetalleFactura().LISTADETALLE[i].COSTOUNITARIO;
                        dgvBuscaFactu.Rows[i].Cells[4].Value = objdetalle.getDetalleFactura().LISTADETALLE[i].COSTOTOTAL;
                    }
                    for (int i = 0; i < objpago.getPago().LISTAPAGO.Count; i++)
                    {
                        dgvBuscPago.Rows.Add(1);
                        dgvBuscPago.Rows[i].Cells[0].Value = objpago.getPago().LISTAPAGO[i].FECHA;
                        dgvBuscPago.Rows[i].Cells[1].Value = objpago.getPago().LISTAPAGO[i].MONTO;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcionAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que se ingrese solo letras
            char le = e.KeyChar;
            if ((le >= 'a' && le <= 'z') || (le >= 'A' && le <= 'Z') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo letras");
            }
        }

        private void txtCodLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= 'a' && le <= 'z') || (le >= 'A' && le <= 'Z') || (le >= '0' && le <= '9') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("No caracteres");
            }
        }

        private void txtCantidadCajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= '0' && le <= '9') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros enteros");
            }
        }
        private void txtCostoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= '0' && le <= '9') || (le == 8) || (le == 46))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ingresar el .(punto) no la ,(coma)");
            }
        }

        private void txtCanUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= '0' && le <= '9') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo numeros enteros");
            }
        }

        private void txtCostoUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= '0' && le <= '9') || (le == 8) || (le == 46))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Ingresar el .(punto) no la ,(coma)");
            }
        }

        private void txtDescripFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            char le = e.KeyChar;
            if ((le >= 'a' && le <= 'z') || (le >= 'A' && le <= 'Z') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo letras");
            }
        }

        private void dgvBuscaFactu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

       
        private void tbpRegistroFactura_Click(object sender, EventArgs e)
        {
            FrmProveedor fpv = new FrmProveedor();
            fpv.llenaProveedor(cboProvedor);
            
        }
        private void cboProvedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            

        }

        public void cargarAsientosRtp(ComboBox cbo)
        {
            AsientoContableDB objAsi = new AsientoContableDB();
            objAsi.getAsientoContable().LISTAASIENTO = objAsi.traeasicon();
            if (objAsi.getAsientoContable().LISTAASIENTO.Count == 0)
            {
                MessageBox.Show("No existen registros de Asientos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pnlAsiento.Enabled = true;
                txtNomAsiento.Focus();
                btnGuardarAsiento.Enabled = false;
            }
            cbo.DisplayMember = "NOMBRE_ASIENTO";
            cbo.ValueMember = "IDASIENTO";
            cbo.DataSource = objAsi.getAsientoContable().LISTAASIENTO;
        }

        private void btnActiva_Click(object sender, EventArgs e)
        {

        }
    }
}
