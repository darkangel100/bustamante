using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaContable.controlador;

namespace SistemaContable.vista
{
    public partial class frmAcceso : Form
    {
        public frmAcceso()
        {
            InitializeComponent();
        }

        private void frmAcceso_Load(object sender, EventArgs e)
        {
            llenausuario();
        }
        public void llenausuario()
        {
            //Inicio
            try
            {
                CuentaBD objU = new CuentaBD();
                objU.getCuenta().ListaCuentas = objU.Traecuentas();
                if (objU.getCuenta().ListaCuentas.Count == 0)
                {
                    MessageBox.Show("No existen registros de usuarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                comboBoxNomUsu.DisplayMember = "Usuario";
                comboBoxNomUsu.ValueMember = "IdUsuario";
                comboBoxNomUsu.DataSource = objU.getCuenta().ListaCuentas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void verificar()
        {
            try
            {
                //Paso 1
                CuentaBD objC = new CuentaBD();
                objC.setCuenta(objC.TraeCuenta((int)comboBoxNomUsu.SelectedValue));
                int idCuentaUsuario = objC.getCuenta().IdUsuario;
                //paso 2
                UsuariosBD objU = new UsuariosBD();
                objU.setUsuarios(objU.TraeUsuario(idCuentaUsuario));
                //paso 3
                if (objC.getCuenta().Contrasenia.Equals(txtClave.Text) && objU.getUsuarios().CedUsu.Equals(txtCedUsu.Text))
                {
                    

                }
                else
                {
                   // MessageBox.Show("Cedula o Clave Incorrectas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);          
                }
                int rol = objU.getUsuarios().IdRol;
                //
                RolDB objR = new RolDB();
                objR.setRol(objR.TraeRol(rol));
                //objC.setCuenta(objC.TraeCuenta((int)cmbNombreusuarios.SelectedValue));
                string tipo = objR.getRol().Tipo;
                FrmPrincipal frmp = new FrmPrincipal(tipo);
                frmp.Text = tipo.ToString();
                frmp.ShowDialog();
                // this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            verificar();
        }

    }
}
