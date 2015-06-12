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
    public partial class FrmEgreso : Form
    {
        public FrmEgreso()
        {
            InitializeComponent();
        }
        string estado = "";
        string usuario = "usu";

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            pnlAsiento.Enabled = true;
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            estado = "N";
            llenaAsiento();

        }
        private void llenaAsiento()
        {
            try
            {
                AsientoDB objasi = new AsientoDB();
                objasi.getAsiento().LISTAASIENTO = objasi.TraeAsientos();
                if (objasi.getAsiento().LISTAASIENTO.Count == 0)
                {
                    MessageBox.Show("No existen Asientos Registrados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pnlAsiento.Enabled = true;
                    btnGuardarAsiento.Enabled = false;
                }
                //cboNomAsiento.ValueMember = "nombre_asiento";
                cboNomAsiento.DataSource = objasi.getAsiento().LISTAASIENTO;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void btnGuardarAsiento_Click(object sender, EventArgs e)
        {
            if (estado == "N")
            {
                Adiciona();
            }
        }

        private void Adiciona()
        {
            try
            {
                AsientoContableDB asicon = new AsientoContableDB();
                PagoDB objpa = new PagoDB();
                int resp;
                asicon.getAsientoContable().IDUSUARIO = "1";
                objpa.getPago().FECHA = dtFechaAsiento.Text.Trim();
                asicon.getAsientoContable().NOMBRE_ASIENTO = cboNomAsiento.Text.Trim();
                objpa.getPago().MONTO = txtMonto.Text.Trim();
                asicon.getAsientoContable().DESCRIPCION = txtDescripcionAsiento.Text.Trim();
                

                resp=objpa.InsertaPago(objpa.getPago());
                resp = asicon.InsertaAsientoContable(asicon.getAsientoContable());
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Asiento Contable", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Contable  Ingresado", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estado = "";
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardaAsi_Click(object sender, EventArgs e)
        {
            AdicionaAsiento();
            btnGuardarAsiento.Enabled = true;
            llenaAsiento();
        }
        private void AdicionaAsiento()
        {
            try
            {
                AsientoDB objas = new AsientoDB();
                int resp;
                objas.getAsiento().LISTAASIENTO = objas.TraeAsientos();
                resp = objas.InsertaAsiento(objas.getAsiento());
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos del Asiento", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Ingresado", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if ((le >= 'A' && le <= 'Z') || (le == 8) || (le == 32))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo letras");
            }
        }

       

       

        
    }
}
