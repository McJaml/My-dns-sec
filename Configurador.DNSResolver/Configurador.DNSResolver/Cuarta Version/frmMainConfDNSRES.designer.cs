namespace Configurador.DNSResolver.Cuarta_Version
{
    partial class frmMainConfDNSRES
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
                downProcess();
                SetConnectionAutomatic();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainConfDNSRES));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicarCambios = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.CMDNSResolver = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkDLV = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.AutoTa = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LBActionsList = new System.Windows.Forms.DataGridView();
            this.btnRealizarAccion = new System.Windows.Forms.Button();
            this.txtActualTAS = new System.Windows.Forms.TextBox();
            this.LBTas = new System.Windows.Forms.ListBox();
            this.rdClearList = new System.Windows.Forms.RadioButton();
            this.rdEliminar = new System.Windows.Forms.RadioButton();
            this.rdAgregar = new System.Windows.Forms.RadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dns4 = new System.Windows.Forms.TextBox();
            this.dns3 = new System.Windows.Forms.TextBox();
            this.dns2 = new System.Windows.Forms.TextBox();
            this.dns1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbproxyauth = new System.Windows.Forms.ComboBox();
            this.cmbproxytype = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.chkHasLocalProxy = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdAutomatico = new System.Windows.Forms.RadioButton();
            this.rdProxyHTTP = new System.Windows.Forms.RadioButton();
            this.rdDNSNormal = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.CMDNSResolver.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBActionsList)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAplicarCambios);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 416);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(436, 35);
            this.panel1.TabIndex = 3;
            // 
            // btnAplicarCambios
            // 
            this.btnAplicarCambios.Location = new System.Drawing.Point(350, 5);
            this.btnAplicarCambios.Name = "btnAplicarCambios";
            this.btnAplicarCambios.Size = new System.Drawing.Size(82, 23);
            this.btnAplicarCambios.TabIndex = 6;
            this.btnAplicarCambios.Text = "Apply";
            this.btnAplicarCambios.UseVisualStyleBackColor = true;
            this.btnAplicarCambios.Click += new System.EventHandler(this.btnAplicarCambios_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(266, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(78, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Cancel";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // CMDNSResolver
            // 
            this.CMDNSResolver.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarToolStripMenuItem,
            this.desactivarToolStripMenuItem,
            this.configurarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.CMDNSResolver.Name = "contextMenuStrip1";
            this.CMDNSResolver.Size = new System.Drawing.Size(137, 98);
            // 
            // activarToolStripMenuItem
            // 
            this.activarToolStripMenuItem.Name = "activarToolStripMenuItem";
            this.activarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.activarToolStripMenuItem.Text = "Activar";
            this.activarToolStripMenuItem.Click += new System.EventHandler(this.activarToolStripMenuItem_Click_1);
            // 
            // desactivarToolStripMenuItem
            // 
            this.desactivarToolStripMenuItem.Name = "desactivarToolStripMenuItem";
            this.desactivarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.desactivarToolStripMenuItem.Text = "Desactivar";
            this.desactivarToolStripMenuItem.Click += new System.EventHandler(this.desactivarToolStripMenuItem_Click_1);
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.configurarToolStripMenuItem.Text = "Configurar";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.CMDNSResolver;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DNS Resolver";
            this.notifyIcon1.Visible = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkDLV);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 425);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "DLV";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkDLV
            // 
            this.chkDLV.AutoSize = true;
            this.chkDLV.Location = new System.Drawing.Point(8, 15);
            this.chkDLV.Name = "chkDLV";
            this.chkDLV.Size = new System.Drawing.Size(69, 17);
            this.chkDLV.TabIndex = 7;
            this.chkDLV.Text = "Use DLV";
            this.chkDLV.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.AutoTa);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.LBActionsList);
            this.tabPage3.Controls.Add(this.btnRealizarAccion);
            this.tabPage3.Controls.Add(this.txtActualTAS);
            this.tabPage3.Controls.Add(this.LBTas);
            this.tabPage3.Controls.Add(this.rdClearList);
            this.tabPage3.Controls.Add(this.rdEliminar);
            this.tabPage3.Controls.Add(this.rdAgregar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(428, 425);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TAs Admin";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 18;
            this.button2.Text = "Update Now";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AutoTa
            // 
            this.AutoTa.AutoSize = true;
            this.AutoTa.Location = new System.Drawing.Point(8, 183);
            this.AutoTa.Name = "AutoTa";
            this.AutoTa.Size = new System.Drawing.Size(145, 17);
            this.AutoTa.TabIndex = 17;
            this.AutoTa.Text = "TA Update Automatically ";
            this.AutoTa.UseVisualStyleBackColor = true;
            this.AutoTa.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "Undo Last Action";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Changes Made in actual Session";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "TA List";
            // 
            // LBActionsList
            // 
            this.LBActionsList.AllowUserToAddRows = false;
            this.LBActionsList.AllowUserToDeleteRows = false;
            this.LBActionsList.AllowUserToResizeColumns = false;
            this.LBActionsList.AllowUserToResizeRows = false;
            this.LBActionsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LBActionsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LBActionsList.Location = new System.Drawing.Point(9, 268);
            this.LBActionsList.Name = "LBActionsList";
            this.LBActionsList.Size = new System.Drawing.Size(410, 120);
            this.LBActionsList.TabIndex = 13;
            this.LBActionsList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.LBActionsList_CellValueChanged);
            // 
            // btnRealizarAccion
            // 
            this.btnRealizarAccion.Location = new System.Drawing.Point(342, 39);
            this.btnRealizarAccion.Name = "btnRealizarAccion";
            this.btnRealizarAccion.Size = new System.Drawing.Size(75, 23);
            this.btnRealizarAccion.TabIndex = 11;
            this.btnRealizarAccion.Text = "Accept";
            this.btnRealizarAccion.UseVisualStyleBackColor = true;
            this.btnRealizarAccion.Click += new System.EventHandler(this.btnRealizarAccion_Click);
            // 
            // txtActualTAS
            // 
            this.txtActualTAS.Location = new System.Drawing.Point(9, 39);
            this.txtActualTAS.Multiline = true;
            this.txtActualTAS.Name = "txtActualTAS";
            this.txtActualTAS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActualTAS.Size = new System.Drawing.Size(327, 48);
            this.txtActualTAS.TabIndex = 10;
            // 
            // LBTas
            // 
            this.LBTas.FormattingEnabled = true;
            this.LBTas.HorizontalScrollbar = true;
            this.LBTas.Location = new System.Drawing.Point(8, 110);
            this.LBTas.MultiColumn = true;
            this.LBTas.Name = "LBTas";
            this.LBTas.ScrollAlwaysVisible = true;
            this.LBTas.Size = new System.Drawing.Size(411, 56);
            this.LBTas.TabIndex = 9;
            // 
            // rdClearList
            // 
            this.rdClearList.AutoSize = true;
            this.rdClearList.Location = new System.Drawing.Point(214, 15);
            this.rdClearList.Name = "rdClearList";
            this.rdClearList.Size = new System.Drawing.Size(71, 17);
            this.rdClearList.TabIndex = 2;
            this.rdClearList.Text = "Clean List";
            this.rdClearList.UseVisualStyleBackColor = true;
            // 
            // rdEliminar
            // 
            this.rdEliminar.AutoSize = true;
            this.rdEliminar.Location = new System.Drawing.Point(105, 15);
            this.rdEliminar.Name = "rdEliminar";
            this.rdEliminar.Size = new System.Drawing.Size(56, 17);
            this.rdEliminar.TabIndex = 1;
            this.rdEliminar.Text = "Delete";
            this.rdEliminar.UseVisualStyleBackColor = true;
            // 
            // rdAgregar
            // 
            this.rdAgregar.AutoSize = true;
            this.rdAgregar.Checked = true;
            this.rdAgregar.Location = new System.Drawing.Point(4, 15);
            this.rdAgregar.Name = "rdAgregar";
            this.rdAgregar.Size = new System.Drawing.Size(44, 17);
            this.rdAgregar.TabIndex = 0;
            this.rdAgregar.TabStop = true;
            this.rdAgregar.Text = "Add";
            this.rdAgregar.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(428, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DNS Resolver";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dns4);
            this.groupBox4.Controls.Add(this.dns3);
            this.groupBox4.Controls.Add(this.dns2);
            this.groupBox4.Controls.Add(this.dns1);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(9, 115);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(413, 58);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Primary DNS";
            // 
            // dns4
            // 
            this.dns4.Enabled = false;
            this.dns4.Location = new System.Drawing.Point(147, 19);
            this.dns4.MaxLength = 3;
            this.dns4.Name = "dns4";
            this.dns4.Size = new System.Drawing.Size(30, 20);
            this.dns4.TabIndex = 3;
            this.dns4.Text = "1";
            this.dns4.Validating += new System.ComponentModel.CancelEventHandler(this.numberBox4_Validating);
            // 
            // dns3
            // 
            this.dns3.Enabled = false;
            this.dns3.Location = new System.Drawing.Point(102, 19);
            this.dns3.MaxLength = 3;
            this.dns3.Name = "dns3";
            this.dns3.Size = new System.Drawing.Size(30, 20);
            this.dns3.TabIndex = 2;
            this.dns3.Text = "0";
            this.dns3.Validating += new System.ComponentModel.CancelEventHandler(this.numberBox3_Validating);
            // 
            // dns2
            // 
            this.dns2.Enabled = false;
            this.dns2.Location = new System.Drawing.Point(58, 19);
            this.dns2.MaxLength = 3;
            this.dns2.Name = "dns2";
            this.dns2.Size = new System.Drawing.Size(30, 20);
            this.dns2.TabIndex = 1;
            this.dns2.Text = "0";
            this.dns2.Validating += new System.ComponentModel.CancelEventHandler(this.numberBox2_Validating);
            // 
            // dns1
            // 
            this.dns1.Enabled = false;
            this.dns1.Location = new System.Drawing.Point(12, 19);
            this.dns1.MaxLength = 3;
            this.dns1.Name = "dns1";
            this.dns1.Size = new System.Drawing.Size(30, 20);
            this.dns1.TabIndex = 0;
            this.dns1.Text = "127";
            this.dns1.Validating += new System.ComponentModel.CancelEventHandler(this.numberBox1_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(42, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 29);
            this.label9.TabIndex = 4;
            this.label9.Text = ".";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 29);
            this.label10.TabIndex = 5;
            this.label10.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(132, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 29);
            this.label11.TabIndex = 6;
            this.label11.Text = ".";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbproxyauth);
            this.groupBox3.Controls.Add(this.cmbproxytype);
            this.groupBox3.Controls.Add(this.txtpassword);
            this.groupBox3.Controls.Add(this.txtuser);
            this.groupBox3.Controls.Add(this.txtport);
            this.groupBox3.Controls.Add(this.txtURL);
            this.groupBox3.Controls.Add(this.chkHasLocalProxy);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(8, 179);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 176);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Local Proxy";
            // 
            // cmbproxyauth
            // 
            this.cmbproxyauth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproxyauth.FormattingEnabled = true;
            this.cmbproxyauth.Location = new System.Drawing.Point(95, 147);
            this.cmbproxyauth.Name = "cmbproxyauth";
            this.cmbproxyauth.Size = new System.Drawing.Size(196, 21);
            this.cmbproxyauth.TabIndex = 28;
            // 
            // cmbproxytype
            // 
            this.cmbproxytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproxytype.FormattingEnabled = true;
            this.cmbproxytype.Location = new System.Drawing.Point(95, 123);
            this.cmbproxytype.Name = "cmbproxytype";
            this.cmbproxytype.Size = new System.Drawing.Size(196, 21);
            this.cmbproxytype.TabIndex = 27;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(94, 100);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(197, 20);
            this.txtpassword.TabIndex = 26;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(94, 77);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(197, 20);
            this.txtuser.TabIndex = 25;
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(94, 54);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(197, 20);
            this.txtport.TabIndex = 24;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(94, 31);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(197, 20);
            this.txtURL.TabIndex = 23;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // chkHasLocalProxy
            // 
            this.chkHasLocalProxy.AutoSize = true;
            this.chkHasLocalProxy.Enabled = false;
            this.chkHasLocalProxy.Location = new System.Drawing.Point(17, 15);
            this.chkHasLocalProxy.Name = "chkHasLocalProxy";
            this.chkHasLocalProxy.Size = new System.Drawing.Size(81, 17);
            this.chkHasLocalProxy.TabIndex = 22;
            this.chkHasLocalProxy.Text = "Local Proxy";
            this.chkHasLocalProxy.UseVisualStyleBackColor = true;
            this.chkHasLocalProxy.CheckedChanged += new System.EventHandler(this.chkHasLocalProxy_CheckedChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Poxy-Auth";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Proxy Type ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "URL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 102);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DNS Resolver";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdAutomatico);
            this.groupBox1.Controls.Add(this.rdProxyHTTP);
            this.groupBox1.Controls.Add(this.rdDNSNormal);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 72);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transport Protocols";
            // 
            // rdAutomatico
            // 
            this.rdAutomatico.AutoSize = true;
            this.rdAutomatico.Location = new System.Drawing.Point(114, 19);
            this.rdAutomatico.Name = "rdAutomatico";
            this.rdAutomatico.Size = new System.Drawing.Size(72, 17);
            this.rdAutomatico.TabIndex = 2;
            this.rdAutomatico.TabStop = true;
            this.rdAutomatico.Text = "Automatic";
            this.rdAutomatico.UseVisualStyleBackColor = true;
            this.rdAutomatico.CheckedChanged += new System.EventHandler(this.rdAutomatico_CheckedChanged);
            // 
            // rdProxyHTTP
            // 
            this.rdProxyHTTP.AutoSize = true;
            this.rdProxyHTTP.Enabled = false;
            this.rdProxyHTTP.Location = new System.Drawing.Point(7, 44);
            this.rdProxyHTTP.Name = "rdProxyHTTP";
            this.rdProxyHTTP.Size = new System.Drawing.Size(83, 17);
            this.rdProxyHTTP.TabIndex = 1;
            this.rdProxyHTTP.TabStop = true;
            this.rdProxyHTTP.Text = "HTTP Proxy";
            this.rdProxyHTTP.UseVisualStyleBackColor = true;
            this.rdProxyHTTP.CheckedChanged += new System.EventHandler(this.rdProxyHTTP_CheckedChanged);
            // 
            // rdDNSNormal
            // 
            this.rdDNSNormal.AutoSize = true;
            this.rdDNSNormal.Location = new System.Drawing.Point(7, 20);
            this.rdDNSNormal.Name = "rdDNSNormal";
            this.rdDNSNormal.Size = new System.Drawing.Size(84, 17);
            this.rdDNSNormal.TabIndex = 0;
            this.rdDNSNormal.TabStop = true;
            this.rdDNSNormal.Text = "Normal DNS";
            this.rdDNSNormal.UseVisualStyleBackColor = true;
            this.rdDNSNormal.CheckedChanged += new System.EventHandler(this.rdDNSNormal_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 451);
            this.tabControl1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Tick);
            // 
            // frmMainConfDNSRES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 451);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainConfDNSRES";
            this.ShowInTaskbar = false;
            this.Text = "Settings DNS Resolver";
            this.Load += new System.EventHandler(this.frmMainCFG_Load);
            this.Shown += new System.EventHandler(this.frmMainCFG_Shown);
            this.panel1.ResumeLayout(false);
            this.CMDNSResolver.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBActionsList)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ContextMenuStrip CMDNSResolver;
        private System.Windows.Forms.ToolStripMenuItem activarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnAplicarCambios;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkDLV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton AutoTa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView LBActionsList;
        private System.Windows.Forms.Button btnRealizarAccion;
        private System.Windows.Forms.TextBox txtActualTAS;
        private System.Windows.Forms.ListBox LBTas;
        private System.Windows.Forms.RadioButton rdClearList;
        private System.Windows.Forms.RadioButton rdEliminar;
        private System.Windows.Forms.RadioButton rdAgregar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbproxyauth;
        private System.Windows.Forms.ComboBox cmbproxytype;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkHasLocalProxy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdAutomatico;
        private System.Windows.Forms.RadioButton rdProxyHTTP;
        private System.Windows.Forms.RadioButton rdDNSNormal;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox dns1;
        private System.Windows.Forms.TextBox dns4;
        private System.Windows.Forms.TextBox dns3;
        private System.Windows.Forms.TextBox dns2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}