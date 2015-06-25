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
                llenaDistri(cmbRDistri);
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

        public void llenaDistri(ComboBox cb)
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
                cb.DisplayMember = "nombre"; //lo q se quiere visualizar
                cb.ValueMember = "id"; //la llave primaria segun el atributo
                cb.DataSource = cdb.getDistribuidora().ListaDistribuidora;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos ()," + ex.Message, "Tienda", MessageBoxButtons.OK);
            }
        }

        public void llenaProveedor()
        {
            try
            {
                ProveedorDB cdb = new ProveedorDB();
                cdb.getProveedor().ListaProveedor = cdb.traeProveedores();
                if (cdb.getProveedor().ListaProveedor.Count == 0)
                {
                    cmbRDistri.Text = "No existen proveedores registrados";
                }
                //variables
                cmbMProv.DisplayMember = "nombre"; //lo q se quiere visualizar
                cmbMProv.ValueMember = "idProveedor"; //la llave primaria segun el atributo
                cmbMProv.DataSource = cdb.getProveedor().ListaProveedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos ()," + ex.Message, "Tienda", MessageBoxButtons.OK);
            }
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            llenaDistri(cmbRDistri);
            llenaDistri(cmbMdis);
            llenaDistri(cmbMdistribuidoraP);
            llenaProveedor();
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (txtRNombre.Text != "" && txtRCelular.Text != "")
            {
                agregarProveedor();
                Utiles.limpiar(pnlProveedor.Controls);
                llenaProveedor();
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

        private void cmbMProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarProveedor();
            btnMProveedor.Enabled = true;
        }

        private void mostrarProveedor()
        {
            try
            {
                ProveedorDB objB = new ProveedorDB();
                objB.setProveedor(objB.traeProveedor(int.Parse(cmbMProv.SelectedValue.ToString())));
                if (objB.getProveedor().IdProveedor == 0)
                {
                    MessageBox.Show("No existe registro de proveedores", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    txtMcelular.Text = objB.getProveedor().Celular;
                    txtMNombre.Text = objB.getProveedor().Nombre;
                    txtMcorreo.Text = objB.getProveedor().Correo;
                    txtMtiempo.Text = objB.getProveedor().Tiempo;
                    for (int i = 0; i < cmbMdistribuidoraP.Items.Count; i++)
                    {
                        cmbMdistribuidoraP.SelectedIndex = i;
                        if (cmbMdistribuidoraP.SelectedValue.ToString() == objB.getProveedor().IdDistri.ToString())
                            i = cmbMdistribuidoraP.Items.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMProveedor_Click(object sender, EventArgs e)
        {
            modificarProveedor();
            cmbMProv.Text = "";
            cmbMdistribuidoraP.Text = "";
            txtMNombre.Text = "";
            txtMcorreo.Text = "";
            txtMcelular.Text = "";
            txtMtiempo.Text = "";
            btnMProveedor.Enabled = false;
        }

        public void modificarProveedor()
        {
            try
            {
                ProveedorDB objB = new ProveedorDB();
                objB.getProveedor().IdProveedor = int.Parse(cmbMProv.SelectedValue.ToString());
                objB.getProveedor().IdDistri = int.Parse(cmbMdistribuidoraP.SelectedValue.ToString());
                objB.getProveedor().Nombre = txtMNombre.Text;
                objB.getProveedor().Tiempo = txtMtiempo.Text;
                objB.getProveedor().Celular = txtMcelular.Text;
                objB.getProveedor().Correo = txtMcorreo.Text;
                
                int resp = objB.actualizaProveedor(objB.getProveedor());
                if (resp == 0)
                {
                    MessageBox.Show("No se modifico datos del Proveedor", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Proveedor modificado", "Sistema Contable", MessageBoxButtons.OK);
                    llenaProveedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos, " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }

        private void btnMDistri_Click(object sender, EventArgs e)
        {
            modificarDistribuidora();
            cmbMdis.Text = "";
            txtMnombreD.Text = "";
            txtMTelefono.Text = "";
            txtMdireccion.Text = "";
            btnMDistri.Enabled = false;
        }

        private void cmbMdis_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarDistribuidora();
            btnMDistri.Enabled = true;
        }

        private void mostrarDistribuidora()
        {
            try
            {
                DistribuidoraDB objB = new DistribuidoraDB();
                objB.setDistribuidora(objB.traeDistribuidora(int.Parse(cmbMdis.SelectedValue.ToString())));
                if (objB.getDistribuidora().Id == 0)
                {
                    MessageBox.Show("No existe registro de distribuidoras", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    txtMnombreD.Text = objB.getDistribuidora().Nombre;
                    txtMTelefono.Text = objB.getDistribuidora().Telefono;
                    txtMdireccion.Text = objB.getDistribuidora().Direccion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Sistema Contable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void modificarDistribuidora()
        {
            try
            {
                DistribuidoraDB objB = new DistribuidoraDB();
                objB.getDistribuidora().Id = int.Parse(cmbMdis.SelectedValue.ToString());
                objB.getDistribuidora().Nombre = txtMnombreD.Text;
                objB.getDistribuidora().Direccion = txtMdireccion.Text;
                objB.getDistribuidora().Telefono = txtMTelefono.Text;
                objB.getDistribuidora().Estado = txtMcorreo.Text;

                int resp = objB.actualizaDistribuidora(objB.getDistribuidora());
                if (resp == 0)
                {
                    MessageBox.Show("No se modifico los datos de la Distribuidora", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Distribuidora modificada", "Sistema Contable", MessageBoxButtons.OK);
                    llenaProveedor();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos, " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }
    }
}
