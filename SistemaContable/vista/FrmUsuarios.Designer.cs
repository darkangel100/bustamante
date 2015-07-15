namespace SistemaContable.vista
{
    partial class FrmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAutoIncremeId = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtCed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCeña2 = new System.Windows.Forms.TextBox();
            this.txtCeña1 = new System.Windows.Forms.TextBox();
            this.txtNomUsuario = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnEdita = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbPasMod = new System.Windows.Forms.RadioButton();
            this.rbActMod = new System.Windows.Forms.RadioButton();
            this.txtCeñaMod = new System.Windows.Forms.TextBox();
            this.txtNomUsuMod = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbRolMod = new System.Windows.Forms.ComboBox();
            this.txtTelMod = new System.Windows.Forms.TextBox();
            this.txtDirMod = new System.Windows.Forms.TextBox();
            this.txtApeMod = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNomMod = new System.Windows.Forms.TextBox();
            this.txtCedMod = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbUsuarioSeleccion = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTRAR USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(243, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id_Usuario";
            // 
            // txtAutoIncremeId
            // 
            this.txtAutoIncremeId.Enabled = false;
            this.txtAutoIncremeId.Location = new System.Drawing.Point(377, 39);
            this.txtAutoIncremeId.Name = "txtAutoIncremeId";
            this.txtAutoIncremeId.Size = new System.Drawing.Size(265, 22);
            this.txtAutoIncremeId.TabIndex = 2;
            this.txtAutoIncremeId.TextChanged += new System.EventHandler(this.txtAutoIncremeId_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbRoles);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.txtDir);
            this.panel1.Controls.Add(this.txtApellido);
            this.panel1.Controls.Add(this.txtNom);
            this.panel1.Controls.Add(this.txtCed);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(49, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 300);
            this.panel1.TabIndex = 3;
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(108, 254);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(242, 24);
            this.cmbRoles.TabIndex = 11;
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(108, 162);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(242, 22);
            this.txtDir.TabIndex = 9;
            this.txtDir.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDir_KeyPress);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(108, 119);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(242, 22);
            this.txtApellido.TabIndex = 8;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(108, 69);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(242, 22);
            this.txtNom.TabIndex = 7;
            this.txtNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNom_KeyPress);
            // 
            // txtCed
            // 
            this.txtCed.Location = new System.Drawing.Point(108, 30);
            this.txtCed.Name = "txtCed";
            this.txtCed.Size = new System.Drawing.Size(242, 22);
            this.txtCed.TabIndex = 6;
            this.txtCed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCed_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Roles";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cedula";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "DATOS USUARIO";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(30, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(826, 445);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtAutoIncremeId);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(818, 416);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.Location = new System.Drawing.Point(528, 289);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(114, 67);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCeña2);
            this.panel2.Controls.Add(this.txtCeña1);
            this.panel2.Controls.Add(this.txtNomUsuario);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(434, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(368, 181);
            this.panel2.TabIndex = 6;
            // 
            // txtCeña2
            // 
            this.txtCeña2.Location = new System.Drawing.Point(181, 119);
            this.txtCeña2.Name = "txtCeña2";
            this.txtCeña2.PasswordChar = '*';
            this.txtCeña2.Size = new System.Drawing.Size(165, 22);
            this.txtCeña2.TabIndex = 8;
            // 
            // txtCeña1
            // 
            this.txtCeña1.Location = new System.Drawing.Point(177, 84);
            this.txtCeña1.Name = "txtCeña1";
            this.txtCeña1.PasswordChar = '*';
            this.txtCeña1.Size = new System.Drawing.Size(165, 22);
            this.txtCeña1.TabIndex = 7;
            // 
            // txtNomUsuario
            // 
            this.txtNomUsuario.Location = new System.Drawing.Point(173, 55);
            this.txtNomUsuario.Name = "txtNomUsuario";
            this.txtNomUsuario.Size = new System.Drawing.Size(169, 22);
            this.txtNomUsuario.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "Confirmar Contraseña";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Contraseña";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = " usuario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(648, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 5;
            this.label10.Text = "DATOS CUENTA";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnEdita);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.cmbUsuarioSeleccion);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(818, 416);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modificar Desactivar";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnEdita
            // 
            this.btnEdita.Image = ((System.Drawing.Image)(resources.GetObject("btnEdita.Image")));
            this.btnEdita.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdita.Location = new System.Drawing.Point(536, 332);
            this.btnEdita.Name = "btnEdita";
            this.btnEdita.Size = new System.Drawing.Size(124, 49);
            this.btnEdita.TabIndex = 9;
            this.btnEdita.Text = "Modificar";
            this.btnEdita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdita.UseVisualStyleBackColor = true;
            this.btnEdita.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(427, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(129, 17);
            this.label25.TabIndex = 8;
            this.label25.Text = "Datos de Cuenta";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.txtCeñaMod);
            this.panel4.Controls.Add(this.txtNomUsuMod);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Location = new System.Drawing.Point(421, 78);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(368, 233);
            this.panel4.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbPasMod);
            this.groupBox2.Controls.Add(this.rbActMod);
            this.groupBox2.Location = new System.Drawing.Point(36, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado";
            // 
            // rbPasMod
            // 
            this.rbPasMod.AutoSize = true;
            this.rbPasMod.Location = new System.Drawing.Point(19, 49);
            this.rbPasMod.Name = "rbPasMod";
            this.rbPasMod.Size = new System.Drawing.Size(77, 21);
            this.rbPasMod.TabIndex = 1;
            this.rbPasMod.TabStop = true;
            this.rbPasMod.Text = "Pasivo";
            this.rbPasMod.UseVisualStyleBackColor = true;
            // 
            // rbActMod
            // 
            this.rbActMod.AutoSize = true;
            this.rbActMod.Location = new System.Drawing.Point(19, 21);
            this.rbActMod.Name = "rbActMod";
            this.rbActMod.Size = new System.Drawing.Size(73, 21);
            this.rbActMod.TabIndex = 0;
            this.rbActMod.TabStop = true;
            this.rbActMod.Text = "Activo";
            this.rbActMod.UseVisualStyleBackColor = true;
            // 
            // txtCeñaMod
            // 
            this.txtCeñaMod.Location = new System.Drawing.Point(177, 84);
            this.txtCeñaMod.Name = "txtCeñaMod";
            this.txtCeñaMod.PasswordChar = '*';
            this.txtCeñaMod.Size = new System.Drawing.Size(165, 22);
            this.txtCeñaMod.TabIndex = 7;
            // 
            // txtNomUsuMod
            // 
            this.txtNomUsuMod.Enabled = false;
            this.txtNomUsuMod.Location = new System.Drawing.Point(173, 55);
            this.txtNomUsuMod.Name = "txtNomUsuMod";
            this.txtNomUsuMod.Size = new System.Drawing.Size(169, 22);
            this.txtNomUsuMod.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 89);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 17);
            this.label23.TabIndex = 1;
            this.label23.Text = "Contraseña";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 55);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(67, 17);
            this.label24.TabIndex = 0;
            this.label24.Text = " usuario";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbRolMod);
            this.panel3.Controls.Add(this.txtTelMod);
            this.panel3.Controls.Add(this.txtDirMod);
            this.panel3.Controls.Add(this.txtApeMod);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.txtNomMod);
            this.panel3.Controls.Add(this.txtCedMod);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Location = new System.Drawing.Point(29, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 294);
            this.panel3.TabIndex = 4;
            // 
            // cmbRolMod
            // 
            this.cmbRolMod.FormattingEnabled = true;
            this.cmbRolMod.Location = new System.Drawing.Point(108, 254);
            this.cmbRolMod.Name = "cmbRolMod";
            this.cmbRolMod.Size = new System.Drawing.Size(242, 24);
            this.cmbRolMod.TabIndex = 11;
            // 
            // txtTelMod
            // 
            this.txtTelMod.Location = new System.Drawing.Point(109, 208);
            this.txtTelMod.Name = "txtTelMod";
            this.txtTelMod.Size = new System.Drawing.Size(241, 22);
            this.txtTelMod.TabIndex = 10;
            this.txtTelMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelMod_KeyPress);
            // 
            // txtDirMod
            // 
            this.txtDirMod.Location = new System.Drawing.Point(108, 162);
            this.txtDirMod.Name = "txtDirMod";
            this.txtDirMod.Size = new System.Drawing.Size(242, 22);
            this.txtDirMod.TabIndex = 9;
            this.txtDirMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDirMod_KeyPress);
            // 
            // txtApeMod
            // 
            this.txtApeMod.Enabled = false;
            this.txtApeMod.Location = new System.Drawing.Point(108, 119);
            this.txtApeMod.Name = "txtApeMod";
            this.txtApeMod.Size = new System.Drawing.Size(242, 22);
            this.txtApeMod.TabIndex = 8;
            this.txtApeMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApeMod_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 17);
            this.label20.TabIndex = 1;
            this.label20.Text = "Apellido";
            // 
            // txtNomMod
            // 
            this.txtNomMod.Enabled = false;
            this.txtNomMod.Location = new System.Drawing.Point(108, 69);
            this.txtNomMod.Name = "txtNomMod";
            this.txtNomMod.Size = new System.Drawing.Size(242, 22);
            this.txtNomMod.TabIndex = 7;
            this.txtNomMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNomMod_KeyPress);
            // 
            // txtCedMod
            // 
            this.txtCedMod.Enabled = false;
            this.txtCedMod.Location = new System.Drawing.Point(108, 30);
            this.txtCedMod.Name = "txtCedMod";
            this.txtCedMod.Size = new System.Drawing.Size(242, 22);
            this.txtCedMod.TabIndex = 6;
            this.txtCedMod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCedMod_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 254);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 17);
            this.label16.TabIndex = 5;
            this.label16.Text = "Rol";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 211);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(72, 17);
            this.label17.TabIndex = 4;
            this.label17.Text = "Telefono";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "Direccion";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(16, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 17);
            this.label19.TabIndex = 2;
            this.label19.Text = "Cedula";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Nombre";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 17);
            this.label15.TabIndex = 2;
            this.label15.Text = "Datos usuario";
            // 
            // cmbUsuarioSeleccion
            // 
            this.cmbUsuarioSeleccion.FormattingEnabled = true;
            this.cmbUsuarioSeleccion.Location = new System.Drawing.Point(279, 13);
            this.cmbUsuarioSeleccion.Name = "cmbUsuarioSeleccion";
            this.cmbUsuarioSeleccion.Size = new System.Drawing.Size(381, 24);
            this.cmbUsuarioSeleccion.TabIndex = 1;
            this.cmbUsuarioSeleccion.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarioSeleccion_SelectedIndexChanged);
            this.cmbUsuarioSeleccion.SelectedValueChanged += new System.EventHandler(this.cmbUsuarioSeleccion_SelectedValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(77, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Seleccionar ID Usuario";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(109, 208);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(241, 22);
            this.txtTel.TabIndex = 10;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 458);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmUsuarios";
            this.Text = "FrmUsuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAutoIncremeId;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtCed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCeña2;
        private System.Windows.Forms.TextBox txtCeña1;
        private System.Windows.Forms.TextBox txtNomUsuario;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtCeñaMod;
        private System.Windows.Forms.TextBox txtNomUsuMod;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbRolMod;
        private System.Windows.Forms.TextBox txtTelMod;
        private System.Windows.Forms.TextBox txtDirMod;
        private System.Windows.Forms.TextBox txtApeMod;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNomMod;
        private System.Windows.Forms.TextBox txtCedMod;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbUsuarioSeleccion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEdita;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbPasMod;
        private System.Windows.Forms.RadioButton rbActMod;
        private System.Windows.Forms.TextBox txtTel;
    }
}