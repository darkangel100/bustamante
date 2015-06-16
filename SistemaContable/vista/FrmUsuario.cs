using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using SistemaContable.controlador;
namespace SistemaContable.vista
{
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AdicionaUsuario();
            AdicionaCuenta();
        }
       private void AdicionaUsuario()
        {
            try
            {
                UsuariosBD objU = new UsuariosBD();
                int resp;
                objU.getUsuarios().IdUsu = Convert.ToInt32(txtnroUsuarioGenerado.Text.Trim());
                objU.getUsuarios().IdRol = Convert.ToInt32(cmbRoles.SelectedValue.ToString());

                //  objF.getFacturas().cedper = cmbCliente.SelectedValue.ToString();
                objU.getUsuarios().CedUsu = txtcedula.Text.Trim();
                objU.getUsuarios().NomUsu = txtNombre.Text.Trim();
                objU.getUsuarios().ApeUsu = txtApellido.Text.Trim();
                objU.getUsuarios().TelUsu = txtTelefono.Text.Trim();
                objU.getUsuarios().DirUsu = txtDireccion.Text.Trim();



                /* if (rbAdm.Checked == true)
                     objU.getUsuarios().TipUsu = "A";
                 else
                     objU.getUsuarios().TipUsu = "V";*/

                resp = objU.Insertausuario(objU.getUsuarios());

                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Usuario", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Usuario Ingresado", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
       private void AdicionaCuenta()
       {
           try
           {
               CuentaBD objU = new CuentaBD();
               int resp;
               objU.getCuenta().IdUsuario = Convert.ToInt32(txtnroUsuarioGenerado.Text);
               //  objF.getFacturas().cedper = cmbCliente.SelectedValue.ToString();
               objU.getCuenta().Usuario = txtNomCusuario.Text.Trim();
               objU.getCuenta().Contrasenia = txtContraseñaCuenta.Text.Trim();

               if (rbA.Checked == true)
               {
                   objU.getCuenta().Estado = "A";
               }
               else
               {
                   objU.getCuenta().Estado = "P";
               }
               resp = objU.Insertacuenta(objU.getCuenta());

               if (resp == 0)
               {
                   MessageBox.Show("No se ingreso datos de Cuenta", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               }
               else
               {
                   MessageBox.Show("Cuenta Ingresada", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }

           catch (Exception ex)
           {
               MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }     
 

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            codigo();
            llenaRoles();
        }
        public void llenaRoles()
        {
            try
            {

                RolDB objU = new RolDB();

                objU.getRol().ListaRoles = objU.TraeRoles();
                if (objU.getRol().ListaRoles.Count == 0)
                {
                    MessageBox.Show("No existen registros de Roles", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cmbRoles.DisplayMember = "Tipo";
                cmbRoles.ValueMember = "IdRol";
                cmbRoles.DataSource = objU.getRol().ListaRoles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void codigo()
        {
            try
            {
                string cc = "";
                int nro;
                UsuariosBD objf = new UsuariosBD();
                nro = objf.TraeCodigo();

                if (nro == 0)
                {
                    txtnroUsuarioGenerado.Text = "1";
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
                    txtnroUsuarioGenerado.Text = Convert.ToString(nro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar los Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
