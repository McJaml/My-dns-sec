namespace Configurador.DNSResolver
{
    partial class frmConfLocalProxy
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.chkHasLocalProxy = new System.Windows.Forms.CheckBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtport = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.cmbproxytype = new System.Windows.Forms.ComboBox();
            this.cmbproxyauth = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Puerto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo de Proxy";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Poxy-Auth";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(34, 182);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Aplicar Cambios";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(146, 181);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(96, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chkHasLocalProxy
            // 
            this.chkHasLocalProxy.AutoSize = true;
            this.chkHasLocalProxy.Location = new System.Drawing.Point(13, 13);
            this.chkHasLocalProxy.Name = "chkHasLocalProxy";
            this.chkHasLocalProxy.Size = new System.Drawing.Size(111, 17);
            this.chkHasLocalProxy.TabIndex = 8;
            this.chkHasLocalProxy.Text = "Tiene Proxy Local";
            this.chkHasLocalProxy.UseVisualStyleBackColor = true;
            this.chkHasLocalProxy.CheckedChanged += new System.EventHandler(this.chkHasLocalProxy_CheckedChanged);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(90, 29);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(197, 20);
            this.txtURL.TabIndex = 9;
            // 
            // txtport
            // 
            this.txtport.Location = new System.Drawing.Point(90, 52);
            this.txtport.Name = "txtport";
            this.txtport.Size = new System.Drawing.Size(197, 20);
            this.txtport.TabIndex = 10;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(90, 75);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(197, 20);
            this.txtuser.TabIndex = 11;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(90, 98);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(197, 20);
            this.txtpassword.TabIndex = 12;
            // 
            // cmbproxytype
            // 
            this.cmbproxytype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproxytype.FormattingEnabled = true;
            this.cmbproxytype.Location = new System.Drawing.Point(91, 121);
            this.cmbproxytype.Name = "cmbproxytype";
            this.cmbproxytype.Size = new System.Drawing.Size(196, 21);
            this.cmbproxytype.TabIndex = 13;
            // 
            // cmbproxyauth
            // 
            this.cmbproxyauth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproxyauth.FormattingEnabled = true;
            this.cmbproxyauth.Location = new System.Drawing.Point(91, 145);
            this.cmbproxyauth.Name = "cmbproxyauth";
            this.cmbproxyauth.Size = new System.Drawing.Size(196, 21);
            this.cmbproxyauth.TabIndex = 14;
            // 
            // frmConfLocalProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 216);
            this.ControlBox = false;
            this.Controls.Add(this.cmbproxyauth);
            this.Controls.Add(this.cmbproxytype);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.txtport);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.chkHasLocalProxy);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConfLocalProxy";
            this.Text = "Configuración de Proxy Local";
            this.Load += new System.EventHandler(this.frmConfLocalProxy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chkHasLocalProxy;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtport;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.ComboBox cmbproxytype;
        private System.Windows.Forms.ComboBox cmbproxyauth;
    }
}