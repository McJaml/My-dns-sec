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
    public partial class frmConfLocalProxy : Form
    {
        //Cadenas de Busqueda
        //Aplica o no aplica proxy local
        String has_local_proxy = "has-local-proxy";
        //URL
        String local_proxy = "local-proxy:";
        //puerto
        String local_proxy_port = "local-proxy-port";
        //usuario
        String local_proxy_user = "local-proxy-user";
        //password
        String local_proxy_password = "local-proxy-password";
        //Tipo de proxy
        String local_proxy_type = "local-proxy-type";
        //Tipo de Autenticación
        String local_proxy_auth = "local-proxy-auth";

        //Valores Deafult para el archivo de Configuración
        //Aplica o no aplica proxy local
        //String def_has_local_proxy = "has-local-proxy: NO";
        ////URL
        //String def_local_proxy = "local-proxy: myproxy.example.com";
        ////puerto
        //String def_local_proxy_port = "local-proxy-port: 1080";
        ////usuario
        //String def_local_proxy_user="local-proxy-user: proxyuser";
        ////password
        //String def_local_proxy_password="local-proxy-password: password";
        ////Tipo de proxy
        //String def_local_proxy_type = "local-proxy-type: HTTP";
        ////Tipo de Autenticación
        //String def_local_proxy_auth = "local-proxy-auth: DIGEST";

        public void LoadActualValues()
        {
            try {

                String line;
                String temp;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\mydnssec.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "mydnssec.conf");
                while ((line = obj.ReadLine()) != null)
                {
                    if(line.Contains(has_local_proxy))
                    {
                        temp = FormatActualValues(line);
                        if (temp == "YES")
                        {
                            chkHasLocalProxy.Checked = true;
                            SetControlAccess(true);
                        }
                        else
                        {
                            chkHasLocalProxy.Checked = false;
                            SetControlAccess(false);
                        }
                    }
                    if (line.Contains(local_proxy))
                    {
                        txtURL.Text=FormatActualValues(line);
                    }
                    if (line.Contains(local_proxy_port))
                    {
                        txtport.Text = FormatActualValues(line);
                    }
                    if (line.Contains(local_proxy_user))
                    {
                        txtuser.Text = FormatActualValues(line);
                    }
                    if (line.Contains(local_proxy_password))
                    {
                        txtpassword.Text = FormatActualValues(line);
                    }
                    if (line.Contains(local_proxy_type))
                    {
                        cmbproxytype.Text = FormatActualValues(line);
                    }
                    if (line.Contains(local_proxy_auth))
                    {
                        cmbproxyauth.Text = FormatActualValues(line);
                    }
               }

                obj.Close();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetControlAccess(bool valor)
        {
            try {

                txtURL.Enabled = valor;
                txtport.Enabled = valor;
                txtuser.Enabled = valor;
                txtpassword.Enabled = valor;
                cmbproxyauth.Enabled = valor;
                cmbproxytype.Enabled = valor;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String FormatActualValues(string unformat)
        {
            try {
                string[] cadenas = new string[2];
                cadenas = unformat.Split(':');
                String rvalue = cadenas[1].Trim();
                return rvalue;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void getValueproxy_type_auth()
        {
            try
            {

                String line;
                string[] temp;
                string[] proxytype;
                bool proxytypevalues = false;
                string[] proxyauth;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\mydnssec.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "mydnssec.conf");
                int counter = 0;
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Contains("Allowed values are:"))
                    {
                        counter++;
                        if (counter > 1)
                        {
                            if (proxytypevalues)
                            {
                                temp = line.Split(':');
                                proxyauth = temp[1].Split(',');
                                for (int i = 0; i < proxyauth.Length - 1; i++)
                                {
                                    cmbproxyauth.Items.Add(proxyauth[i].Trim());
                                }
                            }
                            else
                            {
                                temp = line.Split(':');
                                proxytype = temp[1].Split(',');
                                for (int i = 0; i < proxytype.Length - 1; i++)
                                {
                                    cmbproxytype.Items.Add(proxytype[i].Trim());
                                }
                                proxytypevalues = true;
                            }
                        }
                    }
                }
                obj.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public frmConfLocalProxy()
        {
            InitializeComponent();
        }        

        private void frmConfLocalProxy_Load(object sender, EventArgs e)
        {
            try { 
            
            //cargar las opciones que existentes en el archivo MyDNSSEc.conf
                getValueproxy_type_auth();
                LoadActualValues();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkHasLocalProxy_CheckedChanged(object sender, EventArgs e)
        {
            try {
                if (chkHasLocalProxy.Checked)
                { 
                
                //Habilitar los controles de configuración
                    SetControlAccess(true);
                }
                else
                { 
                //Deshabilitar los controles de configuración
                    SetControlAccess(false);
    
                }
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
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try { 

                String line;
                StringBuilder temp=new StringBuilder();
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\mydnssec.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "mydnssec.conf");
                bool enter = false;
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Contains(has_local_proxy))
                    {
                        if (enter == false)
                        {
                            if (chkHasLocalProxy.Checked)
                            {
                                line = has_local_proxy + ": YES";
                            }
                            else
                            {
                                line = has_local_proxy + ": NO";
                            }
                            enter = true;
                        }
                    }
                    if (line.Contains(local_proxy))
                    {
                        if (enter == false)
                        {
                            if (chkHasLocalProxy.Checked)
                            {
                                line = local_proxy + " " + txtURL.Text;
                            }
                            else
                            {
                                line = "#" + local_proxy + " " + txtURL.Text;
                            }
                        }
                        else { enter = false; }
                    }
                    if (line.Contains(local_proxy_port))
                    {
                        if (chkHasLocalProxy.Checked)
                        {
                            line = local_proxy_port + ": " + txtport.Text;
                        }
                        else
                        {
                            line = "#" + local_proxy_port + ": " + txtport.Text;
                        }
                    }
                    if (line.Contains(local_proxy_user))
                    {
                        if (chkHasLocalProxy.Checked)
                        {
                            line = local_proxy_user + ": " + txtuser.Text;
                        }
                        else
                        {
                            line = "#" + local_proxy_user + ": " + txtuser.Text;
                        }
                    }
                    if (line.Contains(local_proxy_password))
                    {
                        if (chkHasLocalProxy.Checked)
                        {
                            line = local_proxy_password + ": " + txtpassword.Text;
                        }
                        else
                        {
                            line = "#" + local_proxy_password + ": " + txtpassword.Text;
                        }
                    }
                    if (line.Contains(local_proxy_type))
                    {
                        if (chkHasLocalProxy.Checked)
                        {
                            line = local_proxy_type + ": " + cmbproxytype.Text;
                        }
                        else
                        {
                            line = "#" + local_proxy_type + ": " + cmbproxytype.Text;
                        }
                    }
                    if (line.Contains(local_proxy_auth))
                    {
                        if (chkHasLocalProxy.Checked)
                        {
                            line = local_proxy_auth + ": " + cmbproxyauth.Text;
                        }
                        else
                        {
                            line = "#" + local_proxy_auth + ": " + cmbproxyauth.Text;
                        }
                    }

                    temp.AppendLine(line);
                }
                obj.Close();



                //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\mydnssec.conf", false);
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "mydnssec.conf", false);
               
                swobj.Write(temp.ToString());
                swobj.Flush();
                swobj.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

   
    }
}
