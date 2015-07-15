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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            codigo();
            llenaRoles();
            llenaUsuarios();
            
        }

        //Edicion: Encuentra y fija al combo los usuarios existentes
        public void llenaUsuarios()
        {
            try
            {
                UsuariosBD objU = new UsuariosBD();
                objU.getUsuarios().ListaUsuarios = objU.Traeusuarios();
                if (objU.getUsuarios().ListaUsuarios.Count == 0)
                {
                    MessageBox.Show("No existen registros de usuarios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                cmbUsuarioSeleccion.DisplayMember = "ApeUsu";
                cmbUsuarioSeleccion.ValueMember = "IdUsu";
                cmbUsuarioSeleccion.DataSource = objU.getUsuarios().ListaUsuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Numero generado para el usuario registrado proximo
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
                    txtAutoIncremeId.Text = "1";
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
                    txtAutoIncremeId.Text = Convert.ToString(nro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar los Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Roles Existentes en la empresa
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


                cmbRolMod.DisplayMember = "Tipo";
                cmbRolMod.ValueMember = "IdRol";
                cmbRolMod.DataSource = objU.getRol().ListaRoles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Presentar los Datos," + ex.Message, "VENTAS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {       
               AdicionaUsuario();
               AdicionaCuenta();   
        }
        //Guarda al Usuario a la DB
        private void AdicionaUsuario()
        {
           
            try
            {
                UsuariosBD objU = new UsuariosBD();
                int resp;
                objU.getUsuarios().IdUsu = Convert.ToInt32(txtAutoIncremeId.Text.Trim());
                objU.getUsuarios().IdRol = Convert.ToInt32(cmbRoles.SelectedValue.ToString());
               
                objU.getUsuarios().CedUsu = txtCed.Text.Trim();
                objU.getUsuarios().NomUsu = txtNom.Text.Trim();
                objU.getUsuarios().ApeUsu = txtApellido.Text.Trim();
                objU.getUsuarios().TelUsu = txtTel.Text.Trim();
                objU.getUsuarios().DirUsu = txtDir.Text.Trim();
                
                resp = objU.Insertausuario(objU.getUsuarios());

                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Usuario", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                   // MessageBox.Show("Usuario Ingresado", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Guarda la Cuenta Asociada al Usuario
        private void AdicionaCuenta()
        {
            try
            {
                CuentaBD objU = new CuentaBD();
                int resp;
                objU.getCuenta().IdUsuario = Convert.ToInt32(txtAutoIncremeId.Text);
                
                objU.getCuenta().Usuario = txtNomUsuario.Text.Trim();
                if(txtCeña1.Text.ToString().Equals(txtCeña2.Text.ToString())){
                      objU.getCuenta().Contrasenia = txtCeña1.Text.Trim();
                }       
                 objU.getCuenta().Estado = "A";        
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Editar();
           
        }
        //Guarda Datos nuevos para el usuario y la cuenta respectiva en la DB
        private void Editar()
        {
            try
            {
                UsuariosBD objP = new UsuariosBD();
                int resp;
                objP.getUsuarios().IdUsu = Convert.ToInt32(cmbUsuarioSeleccion.SelectedValue.ToString());
                objP.getUsuarios().IdRol = Convert.ToInt32(cmbRolMod.SelectedValue.ToString());
                objP.getUsuarios().CedUsu = txtCedMod.Text.Trim();
               
                objP.getUsuarios().NomUsu = txtNomMod.Text.Trim();
                objP.getUsuarios().ApeUsu = txtApeMod.Text.Trim();//ERROR YANI
                objP.getUsuarios().TelUsu = txtTelMod.Text.Trim();
                objP.getUsuarios().DirUsu = txtDirMod.Text.Trim();

                /*Para cuenta
                if (rbActMod.Checked == true)
                    objP.getUsuarios().Est = "A";
                else
                    objP.getPersonas().EstCli = "P";
                */
                resp = objP.ActualizaUsuario(objP.getUsuarios());

                
                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Usuario", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Usuario Modificado", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                CuentaBD objC = new CuentaBD();
                int resp;
              
                objC.getCuenta().IdUsuario = Convert.ToInt32(cmbUsuarioSeleccion.SelectedValue.ToString());
                objC.getCuenta().Usuario = txtNomUsuMod.Text.Trim();
                objC.getCuenta().Contrasenia = txtCeñaMod.Text.Trim();
                
                if (rbActMod.Checked == true)
                    objC.getCuenta().Estado = "A";
                else
                    objC.getCuenta().Estado = "P";
               
                resp = objC.ActualizaCuenta(objC.getCuenta());

                if (resp == 0)
                {
                    MessageBox.Show("No se ingreso datos de Cuenta", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Cuenta Modificada", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Ingresar Datos," + ex.Message, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Fija los datos en el formulario usuario y cuenta
        private void modificar()
        {
            try
            {
                //usuario
                UsuariosBD objB = new UsuariosBD();
                objB.setUsuarios(objB.TraeUsuario(Convert.ToInt32(cmbUsuarioSeleccion.SelectedValue.ToString())));
                if (objB.getUsuarios().CedUsu == "")
                {
                    MessageBox.Show("No existe registro del Usuario", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cmbRolMod.SelectedValue = objB.getUsuarios().IdRol;
                    txtCedMod.Text = objB.getUsuarios().CedUsu;
                    txtNomMod.Text = objB.getUsuarios().NomUsu;
                    txtApeMod.Text = objB.getUsuarios().ApeUsu;
                    txtTelMod.Text = objB.getUsuarios().TelUsu;
                    txtDirMod.Text = objB.getUsuarios().DirUsu;                
                }
                //Cuenta
                CuentaBD objC = new CuentaBD();
                objC.setCuenta(objC.TraeCuentaPorId(Convert.ToInt32(cmbUsuarioSeleccion.SelectedValue.ToString())));
                if (objC.getCuenta().Usuario == "")
                {
                    MessageBox.Show("No existen Cuentas", "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {             
                    txtNomUsuMod.Text = objC.getCuenta().Usuario;
                    txtCeñaMod.Text = objC.getCuenta().Contrasenia;
                    if (objC.getCuenta().Estado.Equals("A"))
                    {
                        rbActMod.Checked = true;
                    }
                    else
                    {
                        rbPasMod.Checked = true;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al presentar los datos," + ex.Message, "Tienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbUsuarioSeleccion_SelectedValueChanged(object sender, EventArgs e)
        {
           // modificar();
        }

        private void cmbUsuarioSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
             modificar();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtAutoIncremeId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCed_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if ((letra < 48 || letra > 57) && letra != 8)
            {
                e.Handled = true;
            }
        }

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtDir_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if ((letra < 48 || letra > 57) && letra != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCedMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if ((letra < 48 || letra > 57) && letra != 8)
            {
                e.Handled = true;
            }
        }

        private void txtNomMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtApeMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtDirMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != 8 && letra != 13 && letra != 32)
            {
                e.Handled = true;
            }
        }

        private void txtTelMod_KeyPress(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            if ((letra < 48 || letra > 57) && letra != 8)
            {
                e.Handled = true;
            }
        }
    }
}
