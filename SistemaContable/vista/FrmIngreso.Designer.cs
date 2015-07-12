namespace SistemaContable.vista
{
    partial class FrmIngreso
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNueva = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgrega = new System.Windows.Forms.Button();
            this.btnQuita = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtSubt = new System.Windows.Forms.TextBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dGVProds = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFec = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnMostrarDetalles = new System.Windows.Forms.Button();
            this.dtpFecActualEncontrada = new System.Windows.Forms.DateTimePicker();
            this.cmbIds = new System.Windows.Forms.ComboBox();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.btnBusquedaPorFech = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpPorFechaBuscarLista = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlFactura = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescribeFactura = new System.Windows.Forms.TextBox();
            this.dgvItemsBusq = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActivar = new System.Windows.Forms.Button();
            this.dgvFacturasBusqueda = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBusquedaPorNumF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProds)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.pnlFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsBusq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1225, 686);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNueva);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dGVProds);
            this.tabPage1.Controls.Add(this.dtpFec);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lbl3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtIdFactura);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1217, 657);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrar Factura";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(91, 167);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(198, 23);
            this.btnNueva.TabIndex = 58;
            this.btnNueva.Text = "Nueva ";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.btnAgrega);
            this.panel1.Controls.Add(this.btnQuita);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtIva);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtSubt);
            this.panel1.Controls.Add(this.txtDescr);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(39, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 446);
            this.panel1.TabIndex = 57;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(582, 23);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(92, 30);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(231, 408);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 23);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(82, 362);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 17);
            this.label18.TabIndex = 52;
            this.label18.Text = "Descripcion";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column8,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvDatos.Location = new System.Drawing.Point(8, 81);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.Size = new System.Drawing.Size(650, 161);
            this.dgvDatos.TabIndex = 38;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cantidad";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "IdProd";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Producto";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Costo Unitario";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Costo Total";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // btnAgrega
            // 
            this.btnAgrega.Enabled = false;
            this.btnAgrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgrega.Location = new System.Drawing.Point(370, 22);
            this.btnAgrega.Name = "btnAgrega";
            this.btnAgrega.Size = new System.Drawing.Size(95, 28);
            this.btnAgrega.TabIndex = 42;
            this.btnAgrega.Text = "+";
            this.btnAgrega.UseVisualStyleBackColor = true;
            this.btnAgrega.Click += new System.EventHandler(this.btnAgrega_Click);
            // 
            // btnQuita
            // 
            this.btnQuita.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuita.Location = new System.Drawing.Point(481, 22);
            this.btnQuita.Name = "btnQuita";
            this.btnQuita.Size = new System.Drawing.Size(95, 31);
            this.btnQuita.TabIndex = 47;
            this.btnQuita.Text = "-";
            this.btnQuita.UseVisualStyleBackColor = true;
            this.btnQuita.Click += new System.EventHandler(this.btnQuita_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 45;
            this.label10.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(141, 23);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(214, 22);
            this.txtCantidad.TabIndex = 44;
            this.txtCantidad.Text = "1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(82, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 48;
            this.label12.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(148, 285);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(461, 22);
            this.txtIva.TabIndex = 49;
            this.txtIva.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(87, 288);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 17);
            this.label13.TabIndex = 50;
            this.label13.Text = "Iva";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(85, 403);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 28);
            this.btnGuardar.TabIndex = 41;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtSubt
            // 
            this.txtSubt.Location = new System.Drawing.Point(148, 257);
            this.txtSubt.Name = "txtSubt";
            this.txtSubt.Size = new System.Drawing.Size(463, 22);
            this.txtSubt.TabIndex = 51;
            this.txtSubt.Text = "0";
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(351, 344);
            this.txtDescr.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(258, 53);
            this.txtDescr.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(148, 314);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(461, 22);
            this.txtTotal.TabIndex = 40;
            this.txtTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1077, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 25);
            this.label11.TabIndex = 46;
            this.label11.Text = "Existencias";
            // 
            // dGVProds
            // 
            this.dGVProds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column5,
            this.Precio,
            this.Column6});
            this.dGVProds.GridColor = System.Drawing.SystemColors.HighlightText;
            this.dGVProds.Location = new System.Drawing.Point(596, 63);
            this.dGVProds.Name = "dGVProds";
            this.dGVProds.RowTemplate.Height = 24;
            this.dGVProds.Size = new System.Drawing.Size(553, 135);
            this.dGVProds.TabIndex = 43;
            this.dGVProds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVProds_CellClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "IdP";
            this.Column7.Name = "Column7";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 200F;
            this.Column5.HeaderText = "Producto";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio Unitario";
            this.Precio.Name = "Precio";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Stock";
            this.Column6.Name = "Column6";
            // 
            // dtpFec
            // 
            this.dtpFec.Location = new System.Drawing.Point(209, 125);
            this.dtpFec.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFec.Name = "dtpFec";
            this.dtpFec.Size = new System.Drawing.Size(265, 22);
            this.dtpFec.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(385, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(364, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Registro de Factura_Venta";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(44, 500);
            this.lbl3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(82, 17);
            this.lbl3.TabIndex = 4;
            this.lbl3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Enabled = false;
            this.txtIdFactura.Location = new System.Drawing.Point(221, 79);
            this.txtIdFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(253, 22);
            this.txtIdFactura.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo Factura";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnMostrarDetalles);
            this.tabPage2.Controls.Add(this.dtpFecActualEncontrada);
            this.tabPage2.Controls.Add(this.cmbIds);
            this.tabPage2.Controls.Add(this.cmbCriterio);
            this.tabPage2.Controls.Add(this.btnBusquedaPorFech);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.dtpPorFechaBuscarLista);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.pnlFactura);
            this.tabPage2.Controls.Add(this.btnActivar);
            this.tabPage2.Controls.Add(this.dgvFacturasBusqueda);
            this.tabPage2.Controls.Add(this.btnBusquedaPorNumF);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1217, 657);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Busqueda-Activacion/Desactivacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnMostrarDetalles
            // 
            this.btnMostrarDetalles.Enabled = false;
            this.btnMostrarDetalles.Location = new System.Drawing.Point(468, 266);
            this.btnMostrarDetalles.Name = "btnMostrarDetalles";
            this.btnMostrarDetalles.Size = new System.Drawing.Size(91, 41);
            this.btnMostrarDetalles.TabIndex = 63;
            this.btnMostrarDetalles.Text = "Detalles";
            this.btnMostrarDetalles.UseVisualStyleBackColor = true;
            this.btnMostrarDetalles.Click += new System.EventHandler(this.btnMostrarDetalles_Click);
            // 
            // dtpFecActualEncontrada
            // 
            this.dtpFecActualEncontrada.Enabled = false;
            this.dtpFecActualEncontrada.Location = new System.Drawing.Point(8, 236);
            this.dtpFecActualEncontrada.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecActualEncontrada.Name = "dtpFecActualEncontrada";
            this.dtpFecActualEncontrada.Size = new System.Drawing.Size(250, 22);
            this.dtpFecActualEncontrada.TabIndex = 44;
            // 
            // cmbIds
            // 
            this.cmbIds.Enabled = false;
            this.cmbIds.FormattingEnabled = true;
            this.cmbIds.Location = new System.Drawing.Point(168, 120);
            this.cmbIds.Name = "cmbIds";
            this.cmbIds.Size = new System.Drawing.Size(245, 24);
            this.cmbIds.TabIndex = 61;
            this.cmbIds.SelectedIndexChanged += new System.EventHandler(this.cmbIds_SelectedIndexChanged);
            this.cmbIds.SelectedValueChanged += new System.EventHandler(this.cmbIds_SelectedValueChanged);
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Items.AddRange(new object[] {
            "Id",
            "Fecha"});
            this.cmbCriterio.Location = new System.Drawing.Point(168, 76);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(245, 24);
            this.cmbCriterio.TabIndex = 60;
            this.cmbCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbCriterio_SelectedIndexChanged);
            // 
            // btnBusquedaPorFech
            // 
            this.btnBusquedaPorFech.Enabled = false;
            this.btnBusquedaPorFech.Location = new System.Drawing.Point(451, 162);
            this.btnBusquedaPorFech.Name = "btnBusquedaPorFech";
            this.btnBusquedaPorFech.Size = new System.Drawing.Size(100, 23);
            this.btnBusquedaPorFech.TabIndex = 59;
            this.btnBusquedaPorFech.Text = "Buscar";
            this.btnBusquedaPorFech.UseVisualStyleBackColor = true;
            this.btnBusquedaPorFech.Click += new System.EventHandler(this.btnBusquedaPorFech_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(42, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 17);
            this.label16.TabIndex = 58;
            this.label16.Text = "Elija Un Criterio ";
            // 
            // dtpPorFechaBuscarLista
            // 
            this.dtpPorFechaBuscarLista.Enabled = false;
            this.dtpPorFechaBuscarLista.Location = new System.Drawing.Point(168, 162);
            this.dtpPorFechaBuscarLista.Name = "dtpPorFechaBuscarLista";
            this.dtpPorFechaBuscarLista.Size = new System.Drawing.Size(245, 22);
            this.dtpPorFechaBuscarLista.TabIndex = 56;
            this.dtpPorFechaBuscarLista.ValueChanged += new System.EventHandler(this.dtpFechaListarTodas_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 17);
            this.label14.TabIndex = 54;
            this.label14.Text = "Fecha";
            // 
            // pnlFactura
            // 
            this.pnlFactura.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlFactura.Controls.Add(this.label8);
            this.pnlFactura.Controls.Add(this.label7);
            this.pnlFactura.Controls.Add(this.txtDescribeFactura);
            this.pnlFactura.Controls.Add(this.dgvItemsBusq);
            this.pnlFactura.Enabled = false;
            this.pnlFactura.Location = new System.Drawing.Point(575, 96);
            this.pnlFactura.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFactura.Name = "pnlFactura";
            this.pnlFactura.Size = new System.Drawing.Size(617, 528);
            this.pnlFactura.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Fecha";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 293);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Descripcion";
            // 
            // txtDescribeFactura
            // 
            this.txtDescribeFactura.Location = new System.Drawing.Point(132, 326);
            this.txtDescribeFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescribeFactura.Multiline = true;
            this.txtDescribeFactura.Name = "txtDescribeFactura";
            this.txtDescribeFactura.Size = new System.Drawing.Size(449, 111);
            this.txtDescribeFactura.TabIndex = 43;
            // 
            // dgvItemsBusq
            // 
            this.dgvItemsBusq.AllowUserToAddRows = false;
            this.dgvItemsBusq.AllowUserToDeleteRows = false;
            this.dgvItemsBusq.AllowUserToOrderColumns = true;
            this.dgvItemsBusq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsBusq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column9,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvItemsBusq.Location = new System.Drawing.Point(39, 91);
            this.dgvItemsBusq.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItemsBusq.Name = "dgvItemsBusq";
            this.dgvItemsBusq.ReadOnly = true;
            this.dgvItemsBusq.RowHeadersVisible = false;
            this.dgvItemsBusq.Size = new System.Drawing.Size(405, 154);
            this.dgvItemsBusq.TabIndex = 45;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "IdProd";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Producto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Costo Unitario";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Costo Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // btnActivar
            // 
            this.btnActivar.Enabled = false;
            this.btnActivar.Location = new System.Drawing.Point(386, 606);
            this.btnActivar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(151, 28);
            this.btnActivar.TabIndex = 51;
            this.btnActivar.Text = "Activar/Desactivar";
            this.btnActivar.UseVisualStyleBackColor = true;
            // 
            // dgvFacturasBusqueda
            // 
            this.dgvFacturasBusqueda.AllowUserToDeleteRows = false;
            this.dgvFacturasBusqueda.AllowUserToOrderColumns = true;
            this.dgvFacturasBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasBusqueda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvFacturasBusqueda.Location = new System.Drawing.Point(8, 266);
            this.dgvFacturasBusqueda.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturasBusqueda.Name = "dgvFacturasBusqueda";
            this.dgvFacturasBusqueda.ReadOnly = true;
            this.dgvFacturasBusqueda.RowHeadersVisible = false;
            this.dgvFacturasBusqueda.Size = new System.Drawing.Size(453, 267);
            this.dgvFacturasBusqueda.TabIndex = 49;
            this.dgvFacturasBusqueda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturasBusqueda_CellClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Total";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Subtotal";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Iva";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // btnBusquedaPorNumF
            // 
            this.btnBusquedaPorNumF.Enabled = false;
            this.btnBusquedaPorNumF.Location = new System.Drawing.Point(451, 118);
            this.btnBusquedaPorNumF.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusquedaPorNumF.Name = "btnBusquedaPorNumF";
            this.btnBusquedaPorNumF.Size = new System.Drawing.Size(100, 28);
            this.btnBusquedaPorNumF.TabIndex = 48;
            this.btnBusquedaPorNumF.Text = "Buscar";
            this.btnBusquedaPorNumF.UseVisualStyleBackColor = true;
            this.btnBusquedaPorNumF.Click += new System.EventHandler(this.btnBusquedaPorNumF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(609, 31);
            this.label3.TabIndex = 28;
            this.label3.Text = "Busqueda, Listado, Activacion/Desactivacion ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 123);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Codigo Factura";
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 715);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmIngreso";
            this.Text = "FrmIngreso";
            this.Load += new System.EventHandler(this.FrmIngreso_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVProds)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnlFactura.ResumeLayout(false);
            this.pnlFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsBusq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasBusqueda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIdFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvItemsBusq;
        private System.Windows.Forms.DateTimePicker dtpFecActualEncontrada;
        private System.Windows.Forms.TextBox txtDescribeFactura;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBusquedaPorNumF;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Panel pnlFactura;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.DataGridView dGVProds;
        private System.Windows.Forms.Button btnAgrega;
        private System.Windows.Forms.Button btnQuita;
        private System.Windows.Forms.TextBox txtSubt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnBusquedaPorFech;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpPorFechaBuscarLista;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.ComboBox cmbIds;
        private System.Windows.Forms.Button btnMostrarDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvFacturasBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}