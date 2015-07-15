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
        //Trae el Id Asiento Ultimo + 1
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
                // 1: Guardar Asiento
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
                //2.Guardar Factura
                FacturaDB objF = new FacturaDB();
                ProductoDB objproducto = new ProductoDB();
                DetalleFacturaDB objI = new DetalleFacturaDB();
                ProveedorDB pdb = new ProveedorDB();
                pdb.setProveedor(pdb.traeProveedor(0, "default", 0));
                int resp;
                int resp1;
                int resp2;
                string cp = "";
                int cca = 0;
                //IdProveedor debe ir null
                objF.getFactura().IDPROVEEDOR = pdb.getProveedor().IdProveedor;
                objF.getFactura().IDFACTURA = Convert.ToInt32(txtIdFactura.Text);
                //  objF.getFacturas().Fecha = objUtil.girafechaVenta(dtpFec.Value.ToShortDateString());
                objF.getFactura().FECHA = Utiles.fecha(dtpFec);
                objF.getFactura().TOTAL = Convert.ToDouble(txtTotal.Text);
                objF.getFactura().SUBTOTAL = Convert.ToDouble(txtSubt.Text);
                objF.getFactura().IVA = Convert.ToDouble(txtIva.Text);
                objF.getFactura().TIPOFACTURA = "v";// V de ventas
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
                        
                        resp2 = objproducto.restarpro(cp, cca);
                        if (resp2 == 0)
                        {
                            MessageBox.Show("No se actualizo Productos", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                 
                    MessageBox.Show("Factura de Ventas Ingresada", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Nro de Factura Generada automaticamente
            IDEASIENTO();
            //Traer Produtos Existentes
            llenaProductos();
            //LLena Nros de Facturas existentes
            llenafactsTodas("v");
            //Llena Tabla con Facturas existentes
            llenafacts("v");
            
        }
        //LLena la tabla con todas las facturas al mostrar la ventana
        public void llenafactsTodas(string tipoV)
        {           
            try
            {
                dgvFacturas.Rows.Clear();
                FacturaDB objC = new FacturaDB();
                objC.getFactura().LISTAFACTURA = objC.TraeFacts(tipoV);
                if (objC.getFactura().LISTAFACTURA.Count == 0)
                {
                    MessageBox.Show("No existen Facturas Venta registradas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    fila = 0;
                    for (int i = 0; i < objC.getFactura().LISTAFACTURA.Count;i++ )
                    {
                        dgvFacturas.Rows.Add(1);
                        dgvFacturas.Rows[i].Cells[0].Value = objC.getFactura().LISTAFACTURA[i].IDFACTURA;
                        dgvFacturas.Rows[i].Cells[1].Value = objC.getFactura().LISTAFACTURA[i].TOTAL;
                        dgvFacturas.Rows[i].Cells[2].Value = objC.getFactura().LISTAFACTURA[i].SUBTOTAL;
                        dgvFacturas.Rows[i].Cells[3].Value = objC.getFactura().LISTAFACTURA[i].IVA;
                    }
                }         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        //Muestra los numeros de facturas de venta en el combo 
        private void llenafacts(string tipoV)
        {        
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

        //LLena la tabla de productos con la informacion de cada producto
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
       
        private void dGVProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dGVProds.CurrentRow.Index;        
            cargadatos(Convert.ToInt32(dGVProds.Rows[fila].Cells[0].Value));
            btnAgrega.Enabled = true;
            btnQuita.Enabled = false;
        }
        //Para agregar un detalle mas a la tabla toma un producto 
        private void cargadatos(int cod)
        {           
            try
            {
                ProductoDB pro = new ProductoDB();
                pro.setProducto(pro.traeProducto(cod,"x","y"));           
                if (pro.getProducto().Id_producto == 0)
                {
                    MessageBox.Show("No existe registro del Producto", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtPrecio.Text = pro.getProducto().Precio.ToString();
                    txtStock.Text = pro.getProducto().Stock_global.ToString(); ;             
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
           
            dgvDatos.Rows[pos].Cells[1].Value = dGVProds.Rows[fila].Cells[0].Value.ToString();
            
            dgvDatos.Rows[pos].Cells[2].Value = dGVProds.Rows[fila].Cells[1].Value.ToString();
            dgvDatos.Rows[pos].Cells[3].Value = dGVProds.Rows[fila].Cells[2].Value.ToString();//Corresponde a "pre_ven" por la ref lblpre
           
            tot =Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(dGVProds.Rows[fila].Cells[2].Value.ToString());
            tot = Math.Round(tot,2);
            txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + (tot/1.12));
            iva = Math.Round(tot - (tot / 1.12),2);    
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
            btnEditar.Enabled = true;
            btnQuita.Enabled = true;
        }
        //Registrar: Habilita el panel de detalles
        private void btnNueva_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            btnNueva.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            edita();
        }
        //Carga los datos de una fila de detalles para  la cantidad
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
            btnAgrega.Enabled = false;
        }
        //Quita una fila de la tabla y resta del total no grabado
        private void quita()
        {
            if (fila >= 0)
            {
                tot = Convert.ToDouble(dgvDatos.Rows[fila].Cells[4].Value);
                iva = tot - (tot / 1.12);
                txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) - iva);
                txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) - (tot / 1.12));
                
                txtTotal.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + Convert.ToDouble(txtIva.Text));
                dgvDatos.Rows.RemoveAt(fila);
                pos--;

                fila = -1;
            }
            if (pos == 0)
            {
                btnEditar.Enabled = false;
                txtSubt.Text = "0";
                txtIva.Text = "0";
                txtTotal.Text = "0";          
            }              
        }

        private void cmbIds_SelectedIndexChanged(object sender, EventArgs e)
        {        
            btnBusquedaPorNumF.Enabled = true;
        }
        //Fija la factura encontrada en la tabla de encontrada/s
        public void mostrar()
        {
            try
            {
                dgvFacturas.Rows.Clear();
                int idFacAnulacion = Convert.ToInt32(cmbIds.SelectedValue.ToString());
                FacturaDB objFac = new FacturaDB();
                objFac.setFactura(objFac.Traefactura(idFacAnulacion));
                if (objFac.getFactura().SUBTOTAL == 0.0)
                {
                    MessageBox.Show("No existe registro de la factura", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {                 
                    dtpFecBusq.Value = Convert.ToDateTime(objFac.getFactura().FECHA);
                    dgvFacturas.Rows[0].Cells[0].Value = objFac.getFactura().IDFACTURA.ToString();
                    dgvFacturas.Rows[0].Cells[1].Value = objFac.getFactura().TOTAL.ToString();
                    dgvFacturas.Rows[0].Cells[2].Value = objFac.getFactura().SUBTOTAL.ToString();
                    dgvFacturas.Rows[0].Cells[3].Value = objFac.getFactura().IVA.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //LLena los detalles de la factura seleccionada.
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
                    fila = 0;                  
                    for (int i = 0; i < objC.getDetalleFactura().LISTADETALLE.Count; i++)
                    {
                        dgvItemsBusq.Rows.Add(1);
                        dgvItemsBusq.Rows[i].Cells[0].Value = objC.getDetalleFactura().LISTADETALLE[i].CANTIDAD;
                        dgvItemsBusq.Rows[i].Cells[1].Value = objC.getDetalleFactura().LISTADETALLE[i].IDPRODUCTO;
                        
                        dgvItemsBusq.Rows[i].Cells[2].Value = objC.getDetalleFactura().LISTADETALLE[i].NOMBREPRODUCTO;
                        dgvItemsBusq.Rows[i].Cells[3].Value = objC.getDetalleFactura().LISTADETALLE[i].COSTOUNITARIO;
                        dgvItemsBusq.Rows[i].Cells[4].Value = objC.getDetalleFactura().LISTADETALLE[i].COSTOTOTAL;
                        if (i == 0)
                        {
                          
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
         int idF = Convert.ToInt32(dgvFacturas.Rows[fila].Cells[0].Value);
         llenaDescripcion(idF);
         llenaItems(idF);
         panel1.Enabled = true;
         btnMostrarDetalles.Enabled = false;
         txtTotalDetalles.Text =Convert.ToString(dgvFacturas.Rows[fila].Cells[1].Value);          
        }
        //LLenado de la descripcion de asiento contable
        public void llenaDescripcion(int idF)
        {         
            try
            {
                AsientoContableDB objA = new AsientoContableDB();
                objA.setAsientoContable(objA.TraeAsientoPorId(idF));
                if (objA.getAsientoContable().IDASIENTO == " ")
                {
                    MessageBox.Show("No existe registro de ID de  asiento contable", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtExplicacionAsiento.Text = objA.getAsientoContable().DESCRIPCION.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnDesactivar.Enabled = true;

        }

        private void btnBusquedaPorNumF_Click(object sender, EventArgs e)
        {
            mostrar();
        }
        
        private void btnBusqPorFecha_Click(object sender, EventArgs e)
        {
            llenaFacturasPorFecha();          
        }
        
        public void llenaFacturasPorFecha()
        {
            try
            {
                dgvFacturas.Rows.Clear();
                FacturaDB objC = new FacturaDB();
                string dato = Utiles.girafecha(dtpFechaBusq.Value.ToShortDateString());
                objC.getFactura().LISTAFACTURA = objC.TraeFactsFecha(dato);
                if (objC.getFactura().LISTAFACTURA.Count == 0)
                {
                    MessageBox.Show("No existen Facturas registradas en esta fecha", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {                 
                    fila = 0;
                    dtpFecBusq.Value = dtpFechaBusq.Value;
                    
                    for (int i = 0; i < objC.getFactura().LISTAFACTURA.Count; i++)
                    {
                        dgvFacturas.Rows.Add(1);
                        dgvFacturas.Rows[i].Cells[0].Value = objC.getFactura().LISTAFACTURA[i].IDFACTURA;
                        dgvFacturas.Rows[i].Cells[1].Value = objC.getFactura().LISTAFACTURA[i].TOTAL;
                        dgvFacturas.Rows[i].Cells[2].Value = objC.getFactura().LISTAFACTURA[i].SUBTOTAL;
                        dgvFacturas.Rows[i].Cells[3].Value = objC.getFactura().LISTAFACTURA[i].IVA;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFacturas.Rows.Clear();
            if (comboBox1.Text == "Id")
            {
                cmbIds.Enabled = true;
                dtpFechaBusq.Enabled = false;
                btnBusqPorFecha.Enabled = false;
                btnBusquedaPorNumF.Enabled = true;
            }
            else
            {
                if (comboBox1.Text == "Fecha")
                {
                    cmbIds.Enabled = false;
                    
                    dtpFechaBusq.Enabled = true;
                    btnBusquedaPorNumF.Enabled = false;
                    btnBusqPorFecha.Enabled = true;
                }
            }
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = dgvFacturas.CurrentRow.Index;
            col = dgvFacturas.CurrentCell.ColumnIndex;
            btnMostrarDetalles.Enabled = true;
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            int idF = Convert.ToInt32(dgvFacturas.Rows[fila].Cells[0].Value);
            try
            {
                AsientoContableDB objAsiVenta = new AsientoContableDB();
                int respa;
                objAsiVenta.getAsientoContable().IDASIENTO = idF.ToString();
                
                objAsiVenta.getAsientoContable().ESTADO = "P";
                respa = objAsiVenta.ActualizaASientoContable(objAsiVenta.getAsientoContable());
                if (respa == 0)
                {
                    MessageBox.Show("No se ingreso datos de  Asiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Desactivado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al actualizar " + ex.Message);
            }
            btnDesactivar.Enabled = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if ((letra <= 48 || letra > 57) && letra != 8)
            {
                e.Handled = true;
            }
        }
      
    }
}
