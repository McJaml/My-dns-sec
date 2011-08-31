using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Configurador.DNSResolver
{
    public partial class frmEditTAs : Form
    {
        public string TAs;
        public frmEditTAs()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                frmTasAdmin.ValidaTA(txtTA.Text);
                TAs = txtTA.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
        }

        private void frmEditTAs_Load(object sender, EventArgs e)
        {
            try
            {
                txtTA.Text = TAs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            
 
            }
        }
    }
}
