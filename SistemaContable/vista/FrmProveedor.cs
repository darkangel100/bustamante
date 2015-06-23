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
    public partial class FrmProveedor : Form
    {
        public FrmProveedor()
        {
            InitializeComponent();
        
        }
        private void btnAgregarDistribuidora_Click_1(object sender, EventArgs e)
        {
            pnlDistribuidora.Enabled = true;
        }

        private void btnGuardarDistribuidora_Click(object sender, EventArgs e)
        {
            if (txtRDireccion.Text != "" && txtRNDistri.Text != "" && txtRTelefono.Text != "")
            {
                agregarDis();
                llenaDistri();
                Utiles.limpiar(pnlDistribuidora.Controls);
                pnlDistribuidora.Enabled = false;
            }
            else
                MessageBox.Show("Llene todos los campos", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        //llenar el objeto para guardar los datos de la distribuidora
        private void agregarDis()
        {
            try
            {
                DistribuidoraDB objB = new DistribuidoraDB();
                objB.getDistribuidora().Nombre = txtRNDistri.Text.Trim();
                objB.getDistribuidora().Telefono = txtRTelefono.Text.Trim();
                objB.getDistribuidora().Direccion = txtRDireccion.Text.Trim();
                objB.getDistribuidora().Estado = "a";
                int verificacion = objB.verificacionDistri(objB.getDistribuidora());
                if (verificacion == 0)
                {
                    int resp = objB.insertaDistribuidora(objB.getDistribuidora());
                    if (resp == 0)
                    {
                        MessageBox.Show("No se registro la distribuidora", "Sistema Contable", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Distribuidora Registrada", "Sistema Contable", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("La distribuidora ya se encuentra registrada", "Sistema Contable", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }

        public void llenaDistri()
        {
            try
            {
                DistribuidoraDB cdb = new DistribuidoraDB();
                cdb.getDistribuidora().ListaDistribuidora = cdb.traeDistribuidoras();
                if (cdb.getDistribuidora().ListaDistribuidora.Count == 0)
                {
                    cmbRDistri.Text = "No existen distribuidoras registradas";
                }
                //variables
                cmbRDistri.DisplayMember = "nombre"; //lo q se quiere visualizar
                cmbRDistri.ValueMember = "id"; //la llave primaria segun el atributo
                cmbRDistri.DataSource = cdb.getDistribuidora().ListaDistribuidora;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos ()," + ex.Message, "Tienda", MessageBoxButtons.OK);
            }
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            llenaDistri();
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (txtRNombre.Text != "" && txtRCelular.Text != "")
            {
                agregarProveedor();
                Utiles.limpiar(pnlProveedor.Controls);
            }
            else
                MessageBox.Show("Llene todos los campos obligatorios", "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void agregarProveedor()
        {
            try
            {
                ProveedorDB objB = new ProveedorDB();
                objB.getProveedor().IdDistri = int.Parse(cmbRDistri.SelectedValue.ToString());
                objB.getProveedor().Nombre = txtRNombre.Text;
                objB.getProveedor().Tiempo = txtRVisita.Text;
                objB.getProveedor().Celular = txtRCelular.Text;
                objB.getProveedor().Correo = txtRCorreo.Text;
                int resp = objB.insertaDistribuidora(objB.getProveedor());
                if (resp == 0)
                {
                    MessageBox.Show("No se logro registrar al proveedor", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Proveedor Registrado", "Sistema Contable", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar los datos " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }
    }
}
