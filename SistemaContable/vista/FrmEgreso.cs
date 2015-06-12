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
            panelAsiento.Enabled = true;
        }

        private void FrmEgreso_Load(object sender, EventArgs e)
        {
            estado = "N";
        }

       private void btnGuardarAsiento_Click(object sender, EventArgs e)
        {
            if (estado == "N")
            {
                Adiciona();
            }
        }

        public void Adiciona()
        {
            try
            {
                AsientoContableDB asicon = new AsientoContableDB();
                PagoDB objpa = new PagoDB();
                int resp;

                objpa.getPago().FECHA = dtFechaAsiento.ToString();
                objpa.getPago().MONTO = txtMonto.ToString();
                asicon.getAsientoContable().IDUSUARIO = usuario;
                //asicon.getAsientoContable().IDASIENTO = "1";
                asicon.getAsientoContable().NOMBREASIENTO = cboNomAsiento.ToString();
                asicon.getAsientoContable().DESCRIPCION = txtDescripcionAsiento.ToString();
                asicon.getAsientoContable().ESTADO = "A";
                
                
                resp = asicon.InsertaAsiento(asicon.getAsientoContable());
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Asiento Contable", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Asiento Contable  Ingresado", "Panda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estado = "";
                    // Util.limpiar(tp2.Controls);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Panda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
