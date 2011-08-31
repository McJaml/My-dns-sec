using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Configurador.DNSResolver
{
    public partial class frmMaincfg : Form
    {   
        String name="name: \"itesm.edu\"";
        String address = "forward-addr: 10.18.6.5";
        String DLV = "dlv-anchor-file: \"dlv.isc.org.key\"";

        public frmMaincfg()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                String line;
                StringBuilder temp = new StringBuilder();
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\unbound.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "unbound.conf");
              
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Contains(DLV))
                    {
                        if (chkDLV.Checked == true)
                        {
                            line =" " + DLV;
                        }
                        else {
                            line = "    #" + DLV;
                        }
                    }
                    if (line.Contains(name))
                    {

                        if (rdProxyHTTP.Checked == true)
                        {
                            line = name;
                        }
                        if (rdDNSNormal.Checked == true)
                        {
                            line = "#"+name;
                        }
                    }
                    if (line.Contains(address))
                    {
                        if (rdProxyHTTP.Checked == true)
                        {
                            line = address;
                        }
                        if (rdDNSNormal.Checked == true)
                        {
                            line = "#" + address;
                        }

                    }
                    //if (line.Contains(automatico))
                    //{
                    //    if (rdAutomatico.Checked == true)
                    //    { }
                       
                    //}

                    temp.AppendLine(line);
                }
                obj.Close();



                //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\unbound.conf", false);
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() +"unbound.conf", false);

                swobj.Write(temp.ToString());
                swobj.Flush();
                swobj.Close();

                //aplicar cambios-detectar linea de cambio y reemplazarla
                //desactivar servicios--puede que tenga que ir al inicio.
                //activar servicios
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAdminTAS_Click(object sender, EventArgs e)
        {
            try
            {
                frmTasAdmin frm = new frmTasAdmin();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
        }

        private void frmMaincfg_Load(object sender, EventArgs e)
        {
            try {
                String line;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\unbound.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "unbound.conf");
                bool AddressActivaded=false, nameActivaded = false;
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Contains(name))
                    {
                        if (line.Contains("#"))
                        {
                            nameActivaded = false; 
                        }
                        else
                        {
                            nameActivaded = true;
                        }
                    }
                    if (line.Contains(address))
                    {
                        if (line.Contains("#"))
                        {
                            AddressActivaded = false;
                        }
                        else
                        {
                            AddressActivaded = true;
                        }  
                    }
                    //if (line.Contains(automatico))
                    //{
                    //  Acciones cuando se encuentra establecido el
                    //  valor de automatico
                    //
                    //}
                    if (line.Contains(DLV))
                    {
                        if(line.Contains("#"))
                        {
                            chkDLV.Checked=false;
                        }
                        else
                        {
                            chkDLV.Checked=true;
                        }
                    }
                }

                obj.Close();

                if (AddressActivaded == true && nameActivaded == true)
                {
                    rdProxyHTTP.Checked = true;
                }
                else {

                    rdDNSNormal.Checked = true;
                
                }

                //if (automatico)
                //{
                //    rdAutomatico.Checked = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TMConfigurar_Click(object sender, EventArgs e)
        {
            try {
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void TMSalir_Click(object sender, EventArgs e)
        {
            try {
                this.Close();            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void frmMaincfg_Shown(object sender, EventArgs e)
        {
            try {

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void TMActivar_Click(object sender, EventArgs e)
        {
            try { 
              
               //Iniciar Servicios de windows
                //validar que los servicios no este corriendo, si es asi avisar a el usuario
                MessageBox.Show("Los servicios han sido iniciados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
        }

        private void TMDesactivar_Click(object sender, EventArgs e)
        {
            try
            {

                //Apagar Servicios de windows
                //validar que los servicios no este apagados, si es asi avisar a el usuario
                MessageBox.Show("Los servicios han sido apagados", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                frmConfLocalProxy obj = new frmConfLocalProxy();
                obj.ShowInTaskbar = false;
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkDLV_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
