namespace Configurador.DNSResolver.Segunda_Version
{
    partial class frmMainConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainConfig));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbproxyauth = new System.Windows.Forms.ComboBox();
            this.cmbproxytype = new System.Windows.Forms.ComboBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.chkHasLocalProxy = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
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
            this.chkDLV = new System.Windows.Forms.CheckBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txtActualTAS = new System.Windows.Forms.TextBox();
            this.LBTas = new System.Windows.Forms.ListBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.CMDNSResolver = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.CMDNSResolver.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 382);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DNS Resolver";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.groupBox3.Controls.Add(this.btnGuardar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(14, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 203);
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
            // 
            // chkHasLocalProxy
            // 
            this.chkHasLocalProxy.AutoSize = true;
            this.chkHasLocalProxy.Location = new System.Drawing.Point(17, 15);
            this.chkHasLocalProxy.Name = "chkHasLocalProxy";
            this.chkHasLocalProxy.Size = new System.Drawing.Size(111, 17);
            this.chkHasLocalProxy.TabIndex = 22;
            this.chkHasLocalProxy.Text = "Tiene Proxy Local";
            this.chkHasLocalProxy.UseVisualStyleBackColor = true;
            this.chkHasLocalProxy.CheckedChanged += new System.EventHandler(this.chkHasLocalProxy_CheckedChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(25, 174);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 23);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Aplicar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tipo de Proxy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Puerto";
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
            this.groupBox2.Controls.Add(this.chkDLV);
            this.groupBox2.Controls.Add(this.btnAplicar);
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
            this.groupBox1.Text = "Protocolos de Transporte";
            // 
            // rdAutomatico
            // 
            this.rdAutomatico.AutoSize = true;
            this.rdAutomatico.Location = new System.Drawing.Point(114, 19);
            this.rdAutomatico.Name = "rdAutomatico";
            this.rdAutomatico.Size = new System.Drawing.Size(78, 17);
            this.rdAutomatico.TabIndex = 2;
            this.rdAutomatico.TabStop = true;
            this.rdAutomatico.Text = "Automatico";
            this.rdAutomatico.UseVisualStyleBackColor = true;
            // 
            // rdProxyHTTP
            // 
            this.rdProxyHTTP.AutoSize = true;
            this.rdProxyHTTP.Location = new System.Drawing.Point(7, 44);
            this.rdProxyHTTP.Name = "rdProxyHTTP";
            this.rdProxyHTTP.Size = new System.Drawing.Size(83, 17);
            this.rdProxyHTTP.TabIndex = 1;
            this.rdProxyHTTP.TabStop = true;
            this.rdProxyHTTP.Text = "Proxy HTTP";
            this.rdProxyHTTP.UseVisualStyleBackColor = true;
            // 
            // rdDNSNormal
            // 
            this.rdDNSNormal.AutoSize = true;
            this.rdDNSNormal.Location = new System.Drawing.Point(7, 20);
            this.rdDNSNormal.Name = "rdDNSNormal";
            this.rdDNSNormal.Size = new System.Drawing.Size(84, 17);
            this.rdDNSNormal.TabIndex = 0;
            this.rdDNSNormal.TabStop = true;
            this.rdDNSNormal.Text = "DNS Normal";
            this.rdDNSNormal.UseVisualStyleBackColor = true;
            // 
            // chkDLV
            // 
            this.chkDLV.AutoSize = true;
            this.chkDLV.Location = new System.Drawing.Point(210, 29);
            this.chkDLV.Name = "chkDLV";
            this.chkDLV.Size = new System.Drawing.Size(72, 17);
            this.chkDLV.TabIndex = 6;
            this.chkDLV.Text = "Usar DLV";
            this.chkDLV.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(210, 63);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(90, 23);
            this.btnAplicar.TabIndex = 7;
            this.btnAplicar.Text = "Aplicar Cambios";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.txtActualTAS);
            this.tabPage3.Controls.Add(this.LBTas);
            this.tabPage3.Controls.Add(this.btnEliminar);
            this.tabPage3.Controls.Add(this.btnEditar);
            this.tabPage3.Controls.Add(this.btnAdd);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(430, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "TAs Admin";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Aplicar Cambios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtActualTAS
            // 
            this.txtActualTAS.Location = new System.Drawing.Point(8, 18);
            this.txtActualTAS.Multiline = true;
            this.txtActualTAS.Name = "txtActualTAS";
            this.txtActualTAS.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtActualTAS.Size = new System.Drawing.Size(195, 256);
            this.txtActualTAS.TabIndex = 9;
            // 
            // LBTas
            // 
            this.LBTas.FormattingEnabled = true;
            this.LBTas.HorizontalScrollbar = true;
            this.LBTas.Location = new System.Drawing.Point(290, 18);
            this.LBTas.Name = "LBTas";
            this.LBTas.ScrollAlwaysVisible = true;
            this.LBTas.Size = new System.Drawing.Size(132, 264);
            this.LBTas.TabIndex = 8;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(209, 131);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(209, 190);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(209, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 35);
            this.panel1.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(322, 8);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.CMDNSResolver;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DNS Resolver";
            this.notifyIcon1.Visible = true;
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
            this.activarToolStripMenuItem.Click += new System.EventHandler(this.activarToolStripMenuItem_Click);
            // 
            // desactivarToolStripMenuItem
            // 
            this.desactivarToolStripMenuItem.Name = "desactivarToolStripMenuItem";
            this.desactivarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.desactivarToolStripMenuItem.Text = "Desactivar";
            this.desactivarToolStripMenuItem.Click += new System.EventHandler(this.desactivarToolStripMenuItem_Click);
            // 
            // configurarToolStripMenuItem
            // 
            this.configurarToolStripMenuItem.Name = "configurarToolStripMenuItem";
            this.configurarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.configurarToolStripMenuItem.Text = "Configurar";
            this.configurarToolStripMenuItem.Click += new System.EventHandler(this.configurarToolStripMenuItem_Click);
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
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // frmMainConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 382);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainConfig";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configurador DNS Resolver";
            this.Load += new System.EventHandler(this.frmMainConfig_Load);
            this.Shown += new System.EventHandler(this.frmMainConfig_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.CMDNSResolver.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdAutomatico;
        private System.Windows.Forms.RadioButton rdProxyHTTP;
        private System.Windows.Forms.RadioButton rdDNSNormal;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.CheckBox chkDLV;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtActualTAS;
        private System.Windows.Forms.ListBox LBTas;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbproxyauth;
        private System.Windows.Forms.ComboBox cmbproxytype;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.CheckBox chkHasLocalProxy;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip CMDNSResolver;
        private System.Windows.Forms.ToolStripMenuItem activarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem desactivarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}