﻿namespace SistemaContable.vista
{
    partial class frmAcceso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCedUsu = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.comboBoxNomUsu = new System.Windows.Forms.ComboBox();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cedula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clave";
            // 
            // txtCedUsu
            // 
            this.txtCedUsu.Location = new System.Drawing.Point(279, 110);
            this.txtCedUsu.Name = "txtCedUsu";
            this.txtCedUsu.Size = new System.Drawing.Size(602, 22);
            this.txtCedUsu.TabIndex = 4;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(279, 169);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(602, 22);
            this.txtClave.TabIndex = 5;
            // 
            // comboBoxNomUsu
            // 
            this.comboBoxNomUsu.FormattingEnabled = true;
            this.comboBoxNomUsu.Location = new System.Drawing.Point(279, 55);
            this.comboBoxNomUsu.Name = "comboBoxNomUsu";
            this.comboBoxNomUsu.Size = new System.Drawing.Size(602, 24);
            this.comboBoxNomUsu.TabIndex = 6;
            // 
            // btnIngreso
            // 
            this.btnIngreso.Location = new System.Drawing.Point(279, 280);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(141, 23);
            this.btnIngreso.TabIndex = 7;
            this.btnIngreso.Text = "ACEPTAR";
            this.btnIngreso.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(489, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(329, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(309, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = " SUPERMERCADO PANDA";
            // 
            // frmAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 418);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.comboBoxNomUsu);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtCedUsu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAcceso";
            this.Text = "frmAcceso";
            this.Load += new System.EventHandler(this.frmAcceso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCedUsu;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.ComboBox comboBoxNomUsu;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
    }
}