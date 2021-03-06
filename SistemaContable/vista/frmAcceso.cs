﻿using System;
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
                if(objC.getCuenta().IdUsuario!=0)
                { 
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
                        string nomActual=objU.getUsuarios().NomUsu.ToString();
                        string apeActual = objU.getUsuarios().ApeUsu.ToString();
                        FrmPrincipal frmp = new FrmPrincipal(tipo ,nomActual,apeActual);
                        frmp.Text = tipo.ToString()+ " - " + nomActual.ToString() + apeActual.ToString();
                        frmp.ShowDialog();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Cedula o Clave Incorrectas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtNomCuent.Text != "" && txtClave.Text != "")
            {
                verificar();
            }
            else
                MessageBox.Show("Faltan campos por llenar", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
