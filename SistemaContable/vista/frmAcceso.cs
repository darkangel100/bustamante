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

        private void verificar()
        {
            try
            {
               //Fijar Cuenta
                CuentaBD objC = new CuentaBD();         
                //Se envia de parametro un string
                objC.setCuenta(objC.TraeCuenta(txtNomCuent.Text));          
                //paso 2
                if (objC.getCuenta().Contrasenia.Equals(txtClave.Text))
                {
                   // MessageBox.Show("Clave Correcta", "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  //paso 3
                   UsuariosBD objU = new UsuariosBD();
                   int idCuentaUsuario = objC.getCuenta().IdUsuario;
                   objU.setUsuarios(objU.TraeUsuario(idCuentaUsuario));
                   
                    //Extraccion de Usuario del Acceso
                   Utiles.IdUsuarioActual = objU.getUsuarios().IdUsu;
                   //
                    int rolDeUsu = objU.getUsuarios().IdRol;
                    //
                    RolDB objR = new RolDB();
                    objR.setRol(objR.TraeRol(rolDeUsu));
                    //objC.setCuenta(objC.TraeCuenta((int)cmbNombreusuarios.SelectedValue));
                    string tipo = objR.getRol().Tipo;
                    FrmPrincipal frmp = new FrmPrincipal(tipo);
                    frmp.Text = tipo.ToString();
                    frmp.ShowDialog();
                    // this.Close();
                }
                else
                {
                    MessageBox.Show("Cedula o Clave Incorrectas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
