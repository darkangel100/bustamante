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
                llenaDistri(cmbRDistri);
                llenaDistri(cmbMdis);
                llenaDistri(cmbMdistribuidoraP);
                llenaProveedor(0);
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

        public void llenaProveedor(int componente)
        {
            try
            {
                ProveedorDB cdb = new ProveedorDB();
                cdb.getProveedor().ListaProveedor = cdb.traeProveedores();
                if (cdb.getProveedor().ListaProveedor.Count == 0)
                {
                    cmbRDistri.Text = "No existen proveedores registrados";
                }
                if (componente == 0)
                {
                    cmbMProv.DisplayMember = "nombre"; //lo q se quiere visualizar
                    cmbMProv.ValueMember = "idProveedor"; //la llave primaria segun el atributo
                    cmbMProv.DataSource = cdb.getProveedor().ListaProveedor;
                }
                else
                {
                    for (int i = 0; i < cdb.getProveedor().ListaProveedor.Count; i++)
                    {
                        DistribuidoraDB d = new DistribuidoraDB();
                        d.setDistribuidora(d.traeDistribuidora(cdb.getProveedor().ListaProveedor[i].IdDistri));
                        dgvBusqueda.Rows.Add(1);
                        dgvBusqueda.Rows[i].Cells[0].Value = cdb.getProveedor().ListaProveedor[i].Nombre;
                        dgvBusqueda.Rows[i].Cells[1].Value = cdb.getProveedor().ListaProveedor[i].Correo;
                        dgvBusqueda.Rows[i].Cells[2].Value = cdb.getProveedor().ListaProveedor[i].Celular;
                        dgvBusqueda.Rows[i].Cells[3].Value = cdb.getProveedor().ListaProveedor[i].Tiempo;
                        dgvBusqueda.Rows[i].Cells[4].Value = d.getDistribuidora().Nombre;
                        dgvBusqueda.Rows[i].Cells[5].Value = d.getDistribuidora().Telefono;
                        dgvBusqueda.Rows[i].Cells[6].Value = cdb.getProveedor().ListaProveedor[i].Estado;
                    }
                }
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
            llenaProveedor(0);
        }

        private void btnGuardarProveedor_Click(object sender, EventArgs e)
        {
            if (txtRNombre.Text != "" && txtRCelular.Text != "")
            {
                agregarProveedor();
                Utiles.limpiar(pnlProveedor.Controls);
                llenaProveedor(0);
                llenaDistri(cmbRDistri);
                llenaDistri(cmbMdis);
                llenaDistri(cmbMdistribuidoraP);
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
            mostrarProveedor("", -1);
            btnMProveedor.Enabled = true;
        }

        private void mostrarProveedor(string parametro, int criterio)
        {
            ProveedorDB objB = new ProveedorDB();
            try
            {
                
                if (criterio == -1)
                    objB.setProveedor(objB.traeProveedor(int.Parse(cmbMProv.SelectedValue.ToString()), parametro, criterio));
                if (criterio != -1)
                    objB.setProveedor(objB.traeProveedor(0, parametro, criterio));
                if (objB.getProveedor().IdProveedor == 0)
                {
                    MessageBox.Show("No existe registro de proveedores", "Sistema Contable", MessageBoxButtons.OK);
                }
                else
                {
                    if (criterio == -1)
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
                    if (criterio != -1 && parametro != "")
                    {
                        DistribuidoraDB d = new DistribuidoraDB();
                        d.setDistribuidora(d.traeDistribuidora(objB.getProveedor().IdDistri));
                        dgvBusqueda.Rows.Add(1);
                        dgvBusqueda.Rows[0].Cells[0].Value = objB.getProveedor().Nombre;
                        dgvBusqueda.Rows[0].Cells[1].Value = objB.getProveedor().Correo;
                        dgvBusqueda.Rows[0].Cells[2].Value = objB.getProveedor().Celular;
                        dgvBusqueda.Rows[0].Cells[3].Value = objB.getProveedor().Tiempo;
                        dgvBusqueda.Rows[0].Cells[4].Value = d.getDistribuidora().Nombre;
                        dgvBusqueda.Rows[0].Cells[5].Value = d.getDistribuidora().Telefono;
                        dgvBusqueda.Rows[0].Cells[6].Value = objB.getProveedor().Estado;
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
            if (txtMNombre.Text != "" && txtMcelular.Text != "")
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
                    llenaProveedor(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos, " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }

        private void btnMDistri_Click(object sender, EventArgs e)
        {
            if (txtMnombreD.Text != "" && txtMdireccion.Text != "" && txtMTelefono.Text != "")
            {
                modificarDistribuidora();
                cmbMdis.Text = "";
                txtMnombreD.Text = "";
                txtMTelefono.Text = "";
                txtMdireccion.Text = "";
                btnMDistri.Enabled = false;
            }
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
                    llenaProveedor(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar datos, " + ex.Message, "Sistema Contable", MessageBoxButtons.OK);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvBusqueda.Rows.Clear();
            string parametro="";
            if (cmbParamBusqueda.SelectedIndex == 0)
                parametro = txtBusqueda.Text;
            if (cmbParamBusqueda.SelectedIndex == 1)
                parametro = txtBusqueda.Text;
            if (parametro != "")
                mostrarProveedor(parametro, cmbParamBusqueda.SelectedIndex);
            else
                llenaProveedor(1);
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbParamBusqueda.SelectedIndex == 0)
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar!=32 && e.KeyChar!=8)
                {
                    e.Handled = true;
                }
            }
            if(cmbParamBusqueda.SelectedIndex==1)
            {
                if(!char.IsDigit(e.KeyChar) && e.KeyChar!=8)
                    e.Handled=true;
            }
        }

        private void cmbParamBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
        }

        private void txtRNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }   
        }

        private void txtRCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar!=64 && e.KeyChar!=46 && e.KeyChar!=95 && e.KeyChar!=45 && e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void txtRCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtRVisita_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar!=32)
            {
                e.Handled = true;
            } 
        }

        private void txtRNDistri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtRTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtRDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar!= 32 && e.KeyChar != 8 && e.KeyChar!=45)
            {
                e.Handled = true;
            }
        }

        private void txtMNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 64 && e.KeyChar != 46 && e.KeyChar != 95 && e.KeyChar != 45 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMcelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMtiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
            {
                e.Handled = true;
            }
        }

        private void txtMnombreD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMdireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != 32 && e.KeyChar != 8 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }
    }
}
