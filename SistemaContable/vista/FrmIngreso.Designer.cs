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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngreso));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNueva = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEditar = new System.Windows.Forms.Button();
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
            this.txtSubt = new System.Windows.Forms.TextBox();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dGVProds = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpFec = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIdFactura = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.btnBusqPorFecha = new System.Windows.Forms.Button();
            this.btnMostrarDetalles = new System.Windows.Forms.Button();
            this.dtpFecBusq = new System.Windows.Forms.DateTimePicker();
            this.cmbIds = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpFechaBusq = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.pnlFactura = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExplicacionAsiento = new System.Windows.Forms.TextBox();
            this.dgvItemsBusq = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalDetalles = new System.Windows.Forms.TextBox();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(1225, 715);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnNueva);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.txtStock);
            this.tabPage1.Controls.Add(this.txtPrecio);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.dGVProds);
            this.tabPage1.Controls.Add(this.dtpFec);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lbl3);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtIdFactura);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1217, 686);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Registrar Factura";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNueva
            // 
            this.btnNueva.Location = new System.Drawing.Point(91, 167);
            this.btnNueva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNueva.Name = "btnNueva";
            this.btnNueva.Size = new System.Drawing.Size(197, 23);
            this.btnNueva.TabIndex = 58;
            this.btnNueva.Text = "Nueva ";
            this.btnNueva.UseVisualStyleBackColor = true;
            this.btnNueva.Click += new System.EventHandler(this.btnNueva_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dgvDatos);
            this.panel1.Controls.Add(this.btnAgrega);
            this.panel1.Controls.Add(this.btnQuita);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtIva);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtSubt);
            this.panel1.Controls.Add(this.txtDescr);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(35, 231);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 446);
            this.panel1.TabIndex = 57;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(581, 23);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(92, 30);
            this.btnEditar.TabIndex = 54;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(83, 362);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(156, 17);
            this.label18.TabIndex = 52;
            this.label18.Text = "Descripcion del Asiento";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
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
            this.dgvDatos.Size = new System.Drawing.Size(651, 161);
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
            this.btnAgrega.Location = new System.Drawing.Point(371, 22);
            this.btnAgrega.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.btnQuita.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(215, 22);
            this.txtCantidad.TabIndex = 44;
            this.txtCantidad.Text = "1";
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 48;
            this.label12.Text = "Subtotal";
            // 
            // txtIva
            // 
            this.txtIva.Location = new System.Drawing.Point(148, 286);
            this.txtIva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // txtSubt
            // 
            this.txtSubt.Location = new System.Drawing.Point(148, 257);
            this.txtSubt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubt.Name = "txtSubt";
            this.txtSubt.Size = new System.Drawing.Size(463, 22);
            this.txtSubt.TabIndex = 51;
            this.txtSubt.Text = "0";
            // 
            // txtDescr
            // 
            this.txtDescr.Location = new System.Drawing.Point(351, 345);
            this.txtDescr.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(257, 53);
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
            this.label5.Location = new System.Drawing.Point(83, 313);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 39;
            this.label5.Text = "Total";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(837, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 17);
            this.label17.TabIndex = 55;
            this.label17.Text = "Stock";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(915, 268);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(239, 22);
            this.txtStock.TabIndex = 54;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(915, 234);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(239, 22);
            this.txtPrecio.TabIndex = 53;
            this.txtPrecio.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(837, 231);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 17);
            this.label15.TabIndex = 52;
            this.label15.Text = "Precio";
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
            this.dGVProds.AllowUserToAddRows = false;
            this.dGVProds.AllowUserToDeleteRows = false;
            this.dGVProds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVProds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column5,
            this.Precio,
            this.Column6});
            this.dGVProds.GridColor = System.Drawing.SystemColors.HighlightText;
            this.dGVProds.Location = new System.Drawing.Point(535, 79);
            this.dGVProds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dGVProds.Name = "dGVProds";
            this.dGVProds.ReadOnly = true;
            this.dGVProds.RowHeadersVisible = false;
            this.dGVProds.RowTemplate.Height = 24;
            this.dGVProds.Size = new System.Drawing.Size(639, 145);
            this.dGVProds.TabIndex = 43;
            this.dGVProds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVProds_CellClick);
            // 
            // Column7
            // 
            this.Column7.HeaderText = "IdP";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 200F;
            this.Column5.HeaderText = "Producto";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio Unitario";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Stock";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // dtpFec
            // 
            this.dtpFec.Location = new System.Drawing.Point(209, 126);
            this.dtpFec.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFec.Name = "dtpFec";
            this.dtpFec.Size = new System.Drawing.Size(265, 22);
            this.dtpFec.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(412, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Registro de Facturas Ventas";
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
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(871, 393);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 68);
            this.btnGuardar.TabIndex = 41;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // txtIdFactura
            // 
            this.txtIdFactura.Location = new System.Drawing.Point(221, 79);
            this.txtIdFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdFactura.Name = "txtIdFactura";
            this.txtIdFactura.Size = new System.Drawing.Size(253, 22);
            this.txtIdFactura.TabIndex = 1;
            this.txtIdFactura.Visible = false;
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
            this.label1.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDesactivar);
            this.tabPage2.Controls.Add(this.btnBusqPorFecha);
            this.tabPage2.Controls.Add(this.btnMostrarDetalles);
            this.tabPage2.Controls.Add(this.dtpFecBusq);
            this.tabPage2.Controls.Add(this.cmbIds);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.dtpFechaBusq);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.pnlFactura);
            this.tabPage2.Controls.Add(this.dgvFacturas);
            this.tabPage2.Controls.Add(this.btnBusquedaPorNumF);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1217, 686);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Busqueda/Listado/Desactivacion";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Enabled = false;
            this.btnDesactivar.Location = new System.Drawing.Point(575, 518);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(138, 38);
            this.btnDesactivar.TabIndex = 48;
            this.btnDesactivar.Text = "Desactivar Asiento";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // btnBusqPorFecha
            // 
            this.btnBusqPorFecha.Enabled = false;
            this.btnBusqPorFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnBusqPorFecha.Image")));
            this.btnBusqPorFecha.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBusqPorFecha.Location = new System.Drawing.Point(451, 162);
            this.btnBusqPorFecha.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusqPorFecha.Name = "btnBusqPorFecha";
            this.btnBusqPorFecha.Size = new System.Drawing.Size(116, 44);
            this.btnBusqPorFecha.TabIndex = 64;
            this.btnBusqPorFecha.Text = "Buscar ";
            this.btnBusqPorFecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusqPorFecha.UseVisualStyleBackColor = true;
            this.btnBusqPorFecha.Click += new System.EventHandler(this.btnBusqPorFecha_Click);
            // 
            // btnMostrarDetalles
            // 
            this.btnMostrarDetalles.Location = new System.Drawing.Point(468, 266);
            this.btnMostrarDetalles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMostrarDetalles.Name = "btnMostrarDetalles";
            this.btnMostrarDetalles.Size = new System.Drawing.Size(92, 41);
            this.btnMostrarDetalles.TabIndex = 63;
            this.btnMostrarDetalles.Text = "Detalles";
            this.btnMostrarDetalles.UseVisualStyleBackColor = true;
            this.btnMostrarDetalles.Click += new System.EventHandler(this.btnMostrarDetalles_Click);
            // 
            // dtpFecBusq
            // 
            this.dtpFecBusq.Location = new System.Drawing.Point(8, 236);
            this.dtpFecBusq.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecBusq.Name = "dtpFecBusq";
            this.dtpFecBusq.Size = new System.Drawing.Size(233, 22);
            this.dtpFecBusq.TabIndex = 44;
            // 
            // cmbIds
            // 
            this.cmbIds.FormattingEnabled = true;
            this.cmbIds.Location = new System.Drawing.Point(168, 121);
            this.cmbIds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbIds.Name = "cmbIds";
            this.cmbIds.Size = new System.Drawing.Size(245, 24);
            this.cmbIds.TabIndex = 61;
            this.cmbIds.SelectedIndexChanged += new System.EventHandler(this.cmbIds_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Id",
            "Fecha"});
            this.comboBox1.Location = new System.Drawing.Point(168, 76);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 24);
            this.comboBox1.TabIndex = 60;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(43, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(109, 17);
            this.label16.TabIndex = 58;
            this.label16.Text = "Elija Un Criterio ";
            // 
            // dtpFechaBusq
            // 
            this.dtpFechaBusq.Enabled = false;
            this.dtpFechaBusq.Location = new System.Drawing.Point(168, 162);
            this.dtpFechaBusq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaBusq.Name = "dtpFechaBusq";
            this.dtpFechaBusq.Size = new System.Drawing.Size(245, 22);
            this.dtpFechaBusq.TabIndex = 56;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(43, 167);
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
            this.pnlFactura.Controls.Add(this.txtExplicacionAsiento);
            this.pnlFactura.Controls.Add(this.dgvItemsBusq);
            this.pnlFactura.Controls.Add(this.label6);
            this.pnlFactura.Controls.Add(this.txtTotalDetalles);
            this.pnlFactura.Enabled = false;
            this.pnlFactura.Location = new System.Drawing.Point(575, 96);
            this.pnlFactura.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFactura.Name = "pnlFactura";
            this.pnlFactura.Size = new System.Drawing.Size(617, 415);
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
            this.label7.Location = new System.Drawing.Point(42, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 42;
            this.label7.Text = "Descripcion Asiento";
            // 
            // txtExplicacionAsiento
            // 
            this.txtExplicacionAsiento.Location = new System.Drawing.Point(98, 334);
            this.txtExplicacionAsiento.Margin = new System.Windows.Forms.Padding(4);
            this.txtExplicacionAsiento.Multiline = true;
            this.txtExplicacionAsiento.Name = "txtExplicacionAsiento";
            this.txtExplicacionAsiento.Size = new System.Drawing.Size(449, 73);
            this.txtExplicacionAsiento.TabIndex = 43;
            // 
            // dgvItemsBusq
            // 
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
            this.dgvItemsBusq.RowHeadersVisible = false;
            this.dgvItemsBusq.Size = new System.Drawing.Size(508, 154);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 263);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 46;
            this.label6.Text = "Total";
            // 
            // txtTotalDetalles
            // 
            this.txtTotalDetalles.Location = new System.Drawing.Point(113, 263);
            this.txtTotalDetalles.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalDetalles.Name = "txtTotalDetalles";
            this.txtTotalDetalles.Size = new System.Drawing.Size(132, 22);
            this.txtTotalDetalles.TabIndex = 47;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToOrderColumns = true;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvFacturas.Location = new System.Drawing.Point(8, 266);
            this.dgvFacturas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.Size = new System.Drawing.Size(453, 290);
            this.dgvFacturas.TabIndex = 49;
            this.dgvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellClick);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Total";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Subtotal";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Iva";
            this.Column12.Name = "Column12";
            // 
            // btnBusquedaPorNumF
            // 
            this.btnBusquedaPorNumF.Enabled = false;
            this.btnBusquedaPorNumF.Image = ((System.Drawing.Image)(resources.GetObject("btnBusquedaPorNumF.Image")));
            this.btnBusquedaPorNumF.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBusquedaPorNumF.Location = new System.Drawing.Point(451, 96);
            this.btnBusquedaPorNumF.Margin = new System.Windows.Forms.Padding(4);
            this.btnBusquedaPorNumF.Name = "btnBusquedaPorNumF";
            this.btnBusquedaPorNumF.Size = new System.Drawing.Size(116, 44);
            this.btnBusquedaPorNumF.TabIndex = 48;
            this.btnBusquedaPorNumF.Text = "Buscar ";
            this.btnBusquedaPorNumF.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBusquedaPorNumF.UseVisualStyleBackColor = true;
            this.btnBusquedaPorNumF.Click += new System.EventHandler(this.btnBusquedaPorNumF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(416, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(449, 31);
            this.label3.TabIndex = 28;
            this.label3.Text = "Busqueda, Listado,Desactivacion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 123);
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
            this.ClientSize = new System.Drawing.Size(1257, 745);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
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
        private System.Windows.Forms.TextBox txtTotalDetalles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvItemsBusq;
        private System.Windows.Forms.DateTimePicker dtpFecBusq;
        private System.Windows.Forms.TextBox txtExplicacionAsiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnBusquedaPorNumF;
        private System.Windows.Forms.DataGridView dgvFacturas;
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
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpFechaBusq;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnNueva;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbIds;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Button btnMostrarDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnBusqPorFecha;
        private System.Windows.Forms.Button btnDesactivar;
    }
}