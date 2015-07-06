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
    public partial class FrmIngreso : Form
    {
        string estado = "";
        //int fila = -1;
        //Joe
        int pos = 0;
        double tot = 0;
        double iva = 0;
        double pre = 0;
        int fila = -1, col = -1;
        //

        //

        //VARIABLES
        string tipofac = "V";
        string usuario = "usu";
        int agrega = -1;
        string num = "", idasiento = "", nombrepro = "";
        //int id_factura, id_asien, idpro, fila, iddetalle;
        int id_factura, id_asien, idpro, iddetalle;
        //
        Utiles objUtil = new Utiles();
     
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlFactura.Enabled = true;
        }
        private void codigo()
        {
            try
            {
                int nro;
                AsientoContableDB objf = new AsientoContableDB();
                nro = objf.TraeNumeroUltimo();
                nro++;
                txtIdFactura.Text = Convert.ToString(nro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        //TRAE EL ID DE ASIENTO
        
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
                    MessageBox.Show("Asiento Ingresado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // IDEASIENTO();
                }
                //Paso 2
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
                    // MessageBox.Show("Factura Ingresado", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Presentar Nro Autoincrementable
            //
            IDEASIENTO();
            //codigo();
            llenaProductos();
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
        }
        private void agregaItems()
        {
            dgvDatos.Rows.Add(1);
            dgvDatos.Rows[pos].Cells[0].Value = txtCantidad.Text;
            //dgvDatos.Rows[pos].Cells[1].Value = lstpro.SelectedValue.ToString();
            //codigo Producto
            dgvDatos.Rows[pos].Cells[1].Value = dGVProds.Rows[fila].Cells[0].Value.ToString();
            //Nombre Producto
            dgvDatos.Rows[pos].Cells[2].Value = dGVProds.Rows[fila].Cells[1].Value.ToString();
            dgvDatos.Rows[pos].Cells[3].Value = dGVProds.Rows[fila].Cells[2].Value.ToString();//Corresponde a "pre_ven" por la ref lblpre
           // dgvDatos.Rows[pos].Cells[4].Value = ;
            //Este tot referencia al valor del producto (+ iva) 
            tot = Convert.ToDouble(txtCantidad.Text) * Convert.ToDouble(dGVProds.Rows[fila].Cells[2].Value.ToString());

          //  if (lbliva.Text.Equals("N"))

                txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + tot);
          //  else
           // {
                iva = Math.Round(tot - tot / 1.12, 2);
                //....incrementa txt
                txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) + iva);
                //...incrementa txt
             //   txtTotal.Text = Convert.ToString(Convert.ToDouble(txtTotal.Text) + tot);
           // }
            txtTotal.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + Convert.ToDouble(txtIva.Text));
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
                    //  lbliva.Text = dgDatos.Rows[fila].Cells[4].Value.ToString();
                    tot = Convert.ToDouble(dgvDatos.Rows[fila].Cells[4].Value);
                    txtCantidad.Text = ca.ToString();
                    //if (lbliva.Equals("N"))
                    txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) - tot);
                    // else
                    //{
                    iva = Math.Round(tot - tot / 1.12, 2);
                    txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) - iva);
                    //txtTotal.Text = Convert.ToString(Convert.ToDouble(txtTotal.Text) - tot);
                    //}
                    txtTotal.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + Convert.ToString(txtIva.Text));
                    btnAgrega.Enabled = false;
                    btnQuita.Enabled = false;
                    dgvDatos.Enabled = false;
                    btnEditar.Text = "Actualiza";
                    txtCantidad.Focus();
                }
                else
                {
                    //si = dgDatos.Rows[fila].Cells[4].Value.ToString();
                    dgvDatos.Rows[fila].Cells[0].Value = txtCantidad.Text;
                    tot = Convert.ToDouble(txtCantidad.Text) * pre;

                    //   if (lbliva.Text.Equals("N"))
                    txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + tot);
                    // else
                    // {
                    iva = Math.Round(tot - tot / 1.12, 2);
                    txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) + iva);
                    // txt12.Text = Convert.ToString(Convert.ToDouble(txt12.Text) + tot);
                    //  }
                    txtTotal.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) + Convert.ToDouble(txtSubt.Text));
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
            // string si = "";
            if (fila >= 0)
            {
                // si = dgvDatos.Rows[fila].Cells[4].Value.ToString();
                tot = Convert.ToDouble(dgvDatos.Rows[fila].Cells[4].Value);

                //if (si.Equals("N"))
                //    txt0.Text = Convert.ToString(Convert.ToDouble(txt0.Text) - tot);
                //else
                //{
                iva = Math.Round(tot - tot / 1.12, 2);
                txtIva.Text = Convert.ToString(Convert.ToDouble(txtIva.Text) - iva);
                txtSubt.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) - tot);
            }
            txtTotal.Text = Convert.ToString(Convert.ToDouble(txtSubt.Text) + Convert.ToDouble(txtIva.Text));
            dgvDatos.Rows.RemoveAt(fila);
            pos--;

            fila = -1;
        }

      

    

      
    }
}
