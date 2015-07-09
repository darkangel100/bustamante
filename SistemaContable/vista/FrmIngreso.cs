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
    public partial class FrmIngreso : Form
    {
       
        int pos = 0;
        double tot = 0;
        double iva = 0;
        double pre = 0;
        int fila = -1, col = -1;
        //
        string idasiento="";
        int id_asien;
       
        Utiles objUtil = new Utiles();
     
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlFactura.Enabled = true;
        }
        //Trae el Id Asiento Ultimo+1
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
                txtIdFactura.Text = id_asien.ToString();
            }
        }
        
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarfactura();
        }
        private void guardarfactura()
        {
            try
            {
                //Paso 1
                AsientoContableDB objAsiVenta = new AsientoContableDB();
                int respa;
                objAsiVenta.getAsientoContable().IDUSUARIO = Convert.ToString(Utiles.IdUsuarioActual);
                objAsiVenta.getAsientoContable().NOMBRE_ASIENTO = "VENTA DE MERCADERIAS";
                objAsiVenta.getAsientoContable().DESCRIPCION = txtDescr.Text;
                objAsiVenta.getAsientoContable().ESTADO = "A";
                respa = objAsiVenta.InsertaAsientoContable(objAsiVenta.getAsientoContable());
                if (respa == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 
                }
                /*Paso 2
                FacturaBD objF = new FacturaBD();
                ProductoDB objproducto = new ProductoDB();
                DetalleFacturaDB objI = new DetalleFacturaDB();

                int resp;
                int resp1;
                int resp2;
                string cp = "";
                int cca = 0;
                //IdProveedor debe ir null

                objF.getFacturas().IDFACTURA = Convert.ToInt32(txtIdFactura.Text);
                //  objF.getFacturas().Fecha = objUtil.girafechaVenta(dtpFec.Value.ToShortDateString());
                objF.getFacturas().FECHA = Utiles.girafecha(dtpFec.Value.ToShortDateString());
                objF.getFacturas().TOTAL = Convert.ToDouble(txtTotal.Text);
                objF.getFacturas().SUBTOTAL = Convert.ToDouble(txtSubt.Text);
                objF.getFacturas().IVA = Convert.ToDouble(txtIva.Text);


                objF.getFacturas().TIPOFACTURA = tipofac;// V de ventas
                resp = objF.InsertaFacturas(objF.getFacturas(), objF.getFacturas().TIPOFACTURA.ToString());
                */
                FacturaDB objF = new FacturaDB();
                ProductoDB objproducto = new ProductoDB();
                DetalleFacturaDB objI = new DetalleFacturaDB();

                int resp;
                int resp1;
                int resp2;
                string cp = "";
                int cca = 0;
                //IdProveedor debe ir null               
                objF.getFactura().IDFACTURA = Convert.ToInt32(txtIdFactura.Text);
                //  objF.getFacturas().Fecha = objUtil.girafechaVenta(dtpFec.Value.ToShortDateString());
                objF.getFactura().FECHA = Utiles.girafecha(dtpFec.Value.ToShortDateString());
                objF.getFactura().TOTAL = Convert.ToDouble(txtTotal.Text);
                objF.getFactura().SUBTOTAL = Convert.ToDouble(txtSubt.Text);
                objF.getFactura().IVA = Convert.ToDouble(txtIva.Text);
                objF.getFactura().TIPOFACTURA = "V";// V de ventas
                resp = objF.InsertaFacturasV(objF.getFactura());
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de la factura", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    for (int i = 0; i < pos; i++)
                    {
                        objI.getDetalleFactura().IDFACTURA = txtIdFactura.Text;
                        objI.getDetalleFactura().IDPRODUCTO = dgvDatos.Rows[i].Cells[1].Value.ToString();
                        //Id_producto
                        cp = dgvDatos.Rows[i].Cells[1].Value.ToString();
                        objI.getDetalleFactura().CANTIDAD = dgvDatos.Rows[i].Cells[0].Value.ToString();
                        //Cantidad 
                        cca = Convert.ToInt32(dgvDatos.Rows[i].Cells[0].Value);
                        objI.getDetalleFactura().NOMBREPRODUCTO = dgvDatos.Rows[i].Cells[2].Value.ToString();//descripcion
                        objI.getDetalleFactura().COSTOUNITARIO = dgvDatos.Rows[i].Cells[3].Value.ToString();
                        objI.getDetalleFactura().COSTOTOTAL = dgvDatos.Rows[i].Cells[4].Value.ToString();
                        resp1 = objI.InsertaDetalleFactura(objI.getDetalleFactura());
                        if (resp1 == 0)
                        {
                            MessageBox.Show("No se ingreso item de datos de la Factura", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        resp2 = objproducto.agregapro(cp, cca);
                        if (resp2 == 0)
                        {
                            MessageBox.Show("No se actualizo Productos", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                 
                  //  MessageBox.Show("Factura de Ventas Ingresada", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            //Referncia Nro Asiento, se fija en el txt de Factura
            IDEASIENTO();
            //codigo();
            llenaProductos();
            //Edicion
            llenafacts("V");
        }
        private void llenafacts(string tipoV)
        {
            //MessageBox.Show(ced.ToString());
            try
            {
                FacturaDB objP = new FacturaDB();
                objP.getFactura().LISTAFACTURA = objP.TraeFacts(tipoV);

                if (objP.getFactura().LISTAFACTURA.Count == 0)
                {
                    MessageBox.Show("No existen registros de Facturas para Ventas", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cmbIds.DisplayMember = "IDFACTURA";
                cmbIds.ValueMember = "IDFACTURA";
                cmbIds.DataSource = objP.getFactura().LISTAFACTURA;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void llenaProductos()
        {
            try
            {
                dGVProds.Rows.Clear();
                ProductoDB objC = new ProductoDB();
                objC.getProducto().ListaProducto = objC.traeProductos();
                if (objC.getProducto().ListaProducto.Count == 0)
                {
                    MessageBox.Show("No existen Productos registrados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    fila = 0;
                    for (int i = 0; i < objC.getProducto().ListaProducto.Count; i++)
                    {
                        dGVProds.Rows.Add(1);
                        dGVProds.Rows[i].Cells[0].Value = objC.getProducto().ListaProducto[i].Id_producto;
                        dGVProds.Rows[i].Cells[1].Value = objC.getProducto().ListaProducto[i].Nombre;
                        dGVProds.Rows[i].Cells[2].Value = objC.getProducto().ListaProducto[i].Precio;
                        dGVProds.Rows[i].Cells[3].Value = objC.getProducto().ListaProducto[i].Stock_global;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       /* private void codigo()
        {
            try
            {
                string cc = "";
                int nro;
                FacturaBD objf = new FacturaBD();
                nro = objf.TraeCodigo();

                if (nro == 0)
                {
                    txtIdFactura.Text = "000001";
                }
                else
                {
                    nro++;
                    if (nro < 10)
                        cc = "00000";
                    else if (nro < 100)
                        cc = "0000";
                    else if (nro < 1000)
                        cc = "000";
                    else if (nro < 10000)
                        cc = "00";
                    else if (nro < 100000)
                        cc = "0";
                    else
                        cc = "";
                    txtIdFactura.Text = Convert.ToString(cc + nro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar los Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void dGVProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dGVProds.CurrentRow.Index;
           // cargadatos(lstpro.SelectedValue.ToString());
            cargadatos(Convert.ToInt32(dGVProds.Rows[fila].Cells[0].Value));
            btnAgrega.Enabled = true;
        }
        private void cargadatos(int cod)
        {
           
            try
            {
                ProductoDB pro = new ProductoDB();
                pro.setProducto(pro.traeProducto(cod,"x","y"));
                //if (pro.getProducto().Id_producto == "")
                if (pro.getProducto().Id_producto == 0)
                {
                    MessageBox.Show("No existe registro del Producto", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtPrecio.Text = pro.getProducto().Precio.ToString();
                    txtStock.Text = pro.getProducto().Stock_global.ToString(); ;
                    //lblIva.Text = pro.getProducto().iva.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgrega_Click(object sender, EventArgs e)
        {
            agregaItems();
            btnAgrega.Enabled = false;
        }
        private void agregaItems()
        {
            dgvDatos.Rows.Add(1);
            dgvDatos.Rows[pos].Cells[0].Value = txtCantidad.Text;
            //codigo Producto
            dgvDatos.Rows[pos].Cells[1].Value = dGVProds.Rows[fila].Cells[0].Value.ToString();
            //Nombre Producto
            dgvDatos.Rows[pos].Cells[2].Value = dGVProds.Rows[fila].Cells[1].Value.ToString();
            dgvDatos.Rows[pos].Cells[3].Value = dGVProds.Rows[fila].Cells[2].Value.ToString();//Corresponde a "pre_ven" por la ref lblpre
           // dgvDatos.Rows[pos].Cells[4].Value = ;
            //Este tot referencia al valor del producto (+ iva) 
            tot = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(dGVProds.Rows[fila].Cells[2].Value.ToString());
            txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + (tot/1.12));
            iva = tot - (tot / 1.12);    
            txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) + iva);
            txtTotal.Text = Convert.ToString(Convert.ToDouble(txtTotal.Text)+tot);
            dgvDatos.Rows[pos].Cells[4].Value = tot.ToString();

            if (pos == 0) btnEditar.Enabled = true;
            pos++;
        }

        private void dgvDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvDatos.CurrentRow.Index;
            col = dgvDatos.CurrentCell.ColumnIndex;
            //btnEditar.Enabled = true;
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btnNueva.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            edita();
        }
        private void edita()
        {
            string ca = "";
            if (fila >= 0)
            {
                if (btnEditar.Text == "Editar")
                {
                    ca = dgvDatos.Rows[fila].Cells[0].Value.ToString();
                    pre = Convert.ToDouble(dgvDatos.Rows[fila].Cells[3].Value);
           
                    tot = Convert.ToDouble(dgvDatos.Rows[fila].Cells[4].Value);
                    
                    txtCantidad.Text = ca.ToString();
                   
                    txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) - (tot/1.12));
                  
                    iva = tot-(tot/1.12);
                    txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) - iva);
                    
                    txtTotal.Text = Convert.ToString(Convert.ToDouble(txtTotal.Text)-tot);
                    btnAgrega.Enabled = false;
                    btnQuita.Enabled = false;
                    dgvDatos.Enabled = false;
                    btnEditar.Text = "Actualiza";
                    txtCantidad.Focus();
                }
                else
                {
                    
                    dgvDatos.Rows[fila].Cells[0].Value = txtCantidad.Text;
                    tot = Convert.ToDouble(txtCantidad.Text) * pre;

                 
                    txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + (tot/1.12));
                    
                    iva = tot-(tot/1.12);
                    txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) + iva);
                   
                    txtTotal.Text = Convert.ToString(Convert.ToDouble(txtTotal.Text)+tot);
                    dgvDatos.Rows[fila].Cells[4].Value = tot.ToString();
                    btnAgrega.Enabled = true;
                    btnQuita.Enabled = true;
                    dgvDatos.Enabled = true;
                    btnEditar.Text = "Editar";
                }
            }
        }   
        private void btnQuita_Click(object sender, EventArgs e)
        {
            quita();
        }
        private void quita()
        {
           
            if (fila >= 0)
            {
               
                tot = Convert.ToDouble(dgvDatos.Rows[fila].Cells[4].Value);

                
                iva = tot-(tot/1.12);
                txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) - iva);
                txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) - (tot/1.12));

            }
            txtTotal.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + Convert.ToDouble(txtIva.Text));
            dgvDatos.Rows.RemoveAt(fila);
            pos--;

            fila = -1;
        }

        private void cmbIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrar();
        }
        public void mostrar()
        {

            //Destino Vista
            try
            {

                int idFacAnulacion = Convert.ToInt32(cmbIds.SelectedValue.ToString());
                FacturaDB objFac = new FacturaDB();
                objFac.setFactura(objFac.Traefactura(idFacAnulacion));
                //MessageBox.Show("Factura Extraida ");
                if (objFac.getFactura().SUBTOTAL == 0.0)
                {
                    MessageBox.Show("No existe registro de la factura", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                  //  MessageBox.Show("Factura A llenar ");
                    dtpFecBusq.Value = Convert.ToDateTime(objFac.getFactura().FECHA);
                    //txtXXX.Text = objFac.getFactura().IVA.ToString();
                    dgvFacturas.Rows[0].Cells[0].Value = objFac.getFactura().IDFACTURA.ToString();
                    dgvFacturas.Rows[0].Cells[1].Value = objFac.getFactura().TOTAL.ToString();
                    dgvFacturas.Rows[0].Cells[2].Value = objFac.getFactura().SUBTOTAL.ToString();
                    dgvFacturas.Rows[0].Cells[3].Value = objFac.getFactura().IVA.ToString();
                  
                    //llenaItems(Convert.ToInt32(objFac.getFactura().IDFACTURA.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void llenaItems(int Idfact)
        {
            try
            {
                dgvItemsBusq.Rows.Clear();
                DetalleFacturaDB objC = new DetalleFacturaDB();
                //objC.getPersona().ListaPersonas = objC.TraeClientes(est)
                objC.getDetalleFactura().LISTADETALLE = objC.traedetaid(Idfact);
                if (objC.getDetalleFactura().LISTADETALLE.Count == 0)
                {
                    MessageBox.Show("No existen Items registrados en la factura ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    //VER-LA
                    fila = 0;
                    //
                    for (int i = 0; i < objC.getDetalleFactura().LISTADETALLE.Count; i++)
                    {
                        dgvItemsBusq.Rows.Add(1);
                        dgvItemsBusq.Rows[i].Cells[0].Value = objC.getDetalleFactura().LISTADETALLE[i].CANTIDAD;
                        dgvItemsBusq.Rows[i].Cells[1].Value = objC.getDetalleFactura().LISTADETALLE[i].IDPRODUCTO;
                        //uso del cod_pro
                         /* ProductoDB objP = new ProductoDB();
                          string pr = objC.getDetalleFactura().LISTADETALLE[i].IDPRODUCTO;
                          int px = Convert.ToInt32(pr);
                           Producto p = new Producto();
                           p = objP.traeProducto(px,"X","Y");

                         dgvItemsBusq.Rows[i].Cells[2].Value = p.Nombre.ToString();*/
                       // dgvItemsBusq.Rows[i].Cells[3].Value = objC.getDetalleFactura().Listaitemfacturas[i].preven;
                        //dgvItems.Rows[i].Cells[4].Value = p.ivasn;
                        //dgvItems.Rows[i].Cells[5].Value = objC.getDetalleFactura().Listaitemfacturas[i].pretot;

                        //dgvItems.Rows[i].Cells[3].Value = objC.getPersona().ListaPersonas[i].telper;
                        //
                        dgvItemsBusq.Rows[i].Cells[2].Value = objC.getDetalleFactura().LISTADETALLE[i].NOMBREPRODUCTO;
                        dgvItemsBusq.Rows[i].Cells[3].Value = objC.getDetalleFactura().LISTADETALLE[i].COSTOUNITARIO;
                        dgvItemsBusq.Rows[i].Cells[4].Value = objC.getDetalleFactura().LISTADETALLE[i].COSTOTOTAL;
                        if (i == 0)
                        {
                           // txtPro1.Text = p.nompro.ToString();
                           // txtStockActualPro1.Text = p.canpro.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMostrarDetalles_Click(object sender, EventArgs e)
        {
         int idF=Convert.ToInt32(dgvFacturas.Rows[0].Cells[0].Value);
         llenaItems(idF);
        }

      


      

    

      
    }
}
