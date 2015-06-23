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
        Utiles objUtil = new Utiles();
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlFactura.Enabled = true;
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarfactura();
        }
        private void guardarfactura()
        {
            try
            {
                FacturaBD objF = new FacturaBD();
                int resp;
                //IdProveedor debe ir null
                objF.getFacturas().Id_Factura = Convert.ToInt32(txtIdFactura.Text);
                objF.getFacturas().Fecha = objUtil.girafechaVenta(dtpFec.Value.ToShortDateString());

                objF.getFacturas().Total = Convert.ToInt32(txtTotal.Text);
                objF.getFacturas().SubTotal = Convert.ToInt32(txtSubt.Text);
                objF.getFacturas().Iva = Convert.ToInt32(txtIva.Text);

                
                objF.getFacturas().Tipo_fac = "I";// A de actualiza  E de eliminar
                resp = objF.InsertaFacturas(objF.getFacturas());


                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de la factura", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
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
            codigo();
        }
        private void codigo()
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
        }
    }
}
