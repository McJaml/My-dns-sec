namespace Configurador.DNSResolver
{
    partial class frmMaincfg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaincfg));
            this.chkDLV = new System.Windows.Forms.CheckBox();
            this.btnAdminTAS = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.NIDNSResolver = new System.Windows.Forms.NotifyIcon(this.components);
            this.CMDNSResolver = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TMActivar = new System.Windows.Forms.ToolStripMenuItem();
            this.TMDesactivar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TMConfigurar = new System.Windows.Forms.ToolStripMenuItem();
            this.TMSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdAutomatico = new System.Windows.Forms.RadioButton();
            this.rdProxyHTTP = new System.Windows.Forms.RadioButton();
            this.rdDNSNormal = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.CMDNSResolver.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDLV
            // 
            this.chkDLV.AutoSize = true;
            this.chkDLV.Location = new System.Drawing.Point(7, 90);
            this.chkDLV.Name = "chkDLV";
            this.chkDLV.Size = new System.Drawing.Size(72, 17);
            this.chkDLV.TabIndex = 1;
            this.chkDLV.Text = "Usar DLV";
            this.chkDLV.UseVisualStyleBackColor = true;
            this.chkDLV.CheckedChanged += new System.EventHandler(this.chkDLV_CheckedChanged);
            // 
            // btnAdminTAS
            // 
            this.btnAdminTAS.Location = new System.Drawing.Point(101, 116);
            this.btnAdminTAS.Name = "btnAdminTAS";
            this.btnAdminTAS.Size = new System.Drawing.Size(104, 23);
            this.btnAdminTAS.TabIndex = 2;
            this.btnAdminTAS.Text = "Administrar TAS";
            this.btnAdminTAS.UseVisualStyleBackColor = true;
            this.btnAdminTAS.Click += new System.EventHandler(this.btnAdminTAS_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(5, 145);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(90, 23);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar Cambios";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(101, 145);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(104, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // NIDNSResolver
            // 
            this.NIDNSResolver.ContextMenuStrip = this.CMDNSResolver;
            this.NIDNSResolver.Icon = ((System.Drawing.Icon)(resources.GetObject("NIDNSResolver.Icon")));
            this.NIDNSResolver.Text = "DNS Resolver";
            this.NIDNSResolver.Visible = true;
            // 
            // CMDNSResolver
            // 
            this.CMDNSResolver.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TMActivar,
            this.TMDesactivar,
            this.toolStripSeparator1,
            this.TMConfigurar,
            this.TMSalir});
            this.CMDNSResolver.Name = "CMDNSResolver";
            this.CMDNSResolver.Size = new System.Drawing.Size(137, 98);
            // 
            // TMActivar
            // 
            this.TMActivar.Name = "TMActivar";
            this.TMActivar.Size = new System.Drawing.Size(136, 22);
            this.TMActivar.Text = "Activar";
            // 
            // TMDesactivar
            // 
            this.TMDesactivar.Name = "TMDesactivar";
            this.TMDesactivar.Size = new System.Drawing.Size(136, 22);
            this.TMDesactivar.Text = "Desactivar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // TMConfigurar
            // 
            this.TMConfigurar.Name = "TMConfigurar";
            this.TMConfigurar.Size = new System.Drawing.Size(136, 22);
            this.TMConfigurar.Text = "Configurar";
            this.TMConfigurar.Click += new System.EventHandler(this.TMConfigurar_Click);
            // 
            // TMSalir
            // 
            this.TMSalir.Name = "TMSalir";
            this.TMSalir.Size = new System.Drawing.Size(136, 22);
            this.TMSalir.Text = "Salir";
            this.TMSalir.Click += new System.EventHandler(this.TMSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdAutomatico);
            this.groupBox1.Controls.Add(this.rdProxyHTTP);
            this.groupBox1.Controls.Add(this.rdDNSNormal);
            this.groupBox1.Location = new System.Drawing.Point(7, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 72);
            this.groupBox1.TabIndex = 5;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Local Proxy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMaincfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 174);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnAdminTAS);
            this.Controls.Add(this.chkDLV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMaincfg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurador DNS Resolver";
            this.Load += new System.EventHandler(this.frmMaincfg_Load);
            this.Shown += new System.EventHandler(this.frmMaincfg_Shown);
            this.CMDNSResolver.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDLV;
        private System.Windows.Forms.Button btnAdminTAS;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.NotifyIcon NIDNSResolver;
        private System.Windows.Forms.ContextMenuStrip CMDNSResolver;
        private System.Windows.Forms.ToolStripMenuItem TMActivar;
        private System.Windows.Forms.ToolStripMenuItem TMDesactivar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TMConfigurar;
        private System.Windows.Forms.ToolStripMenuItem TMSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdAutomatico;
        private System.Windows.Forms.RadioButton rdProxyHTTP;
        private System.Windows.Forms.RadioButton rdDNSNormal;
        private System.Windows.Forms.Button button1;
    }
}