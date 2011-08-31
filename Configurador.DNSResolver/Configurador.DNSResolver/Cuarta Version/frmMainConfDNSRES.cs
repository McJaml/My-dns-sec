using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.ServiceProcess;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Configurador.DNSResolver.Cuarta_Version
{
    public partial class frmMainConfDNSRES : Form
    {
        public int count;

        public frmMainConfDNSRES()
        {
            InitializeComponent();
            count = 0;
            timer1.Interval = 10000;
            //up mydnssec and unbound for first time
            upProcess();
            //set 127.0.0.1 as local dns after upload the process
            concatDNS();
            
            timer1.Start();

        }
        //----Unbound.conf Data--------------
        //String name = "name: \"itesm.edu\"";
        //String address = "forward-addr: 10.18.6.5";
        //----Unbound.conf Data--------------

        String name = "name: \".\"";
        String address = "forward-addr: 127.0.0.1@5380";
        String DLV = "dlv-anchor-file: \"dlv.isc.org.key\"";

        //Search Strings
        //Applied or not applied local proxy
        String has_local_proxy = "has-local-proxy";
        //URL
        String local_proxy = "local-proxy:";
        //Port
        String local_proxy_port = "local-proxy-port";
        //User
        String local_proxy_user = "local-proxy-user";
        //password
        String local_proxy_password = "local-proxy-password";
        //Proxy Type
        String local_proxy_type = "local-proxy-type";
        //Authentication Type
        String local_proxy_auth = "local-proxy-auth";


        DataTable DTAcciones = new DataTable("Acciones");

        public static Boolean ServicesEstatus = false;//true=Enabled, false=Disabled

        public void FormatTables()
        {
            try {
               

                DTAcciones.Columns.Add("TA",System.Type.GetType("System.String"));
                DTAcciones.Columns.Add("Accion", System.Type.GetType("System.String"));
                DTAcciones.Columns.Add("DeshacerAccion", System.Type.GetType("System.Boolean"));

                LBActionsList.DataSource = DTAcciones;
                
            }
            catch (Exception Exception) { throw Exception; }
        }

        private void LoadDNSResolverConfig()
        {
            try
            {
                String line;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\unbound.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "unbound.conf");
                bool AddressActivaded = false, nameActivaded = false;
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
                        if (line.Contains("#"))
                        {
                            chkDLV.Checked = false;
                        }
                        else
                        {
                            chkDLV.Checked = true;
                        }
                    }
                }

                obj.Close();

                if (AddressActivaded == true && nameActivaded == true)
                {
                    rdProxyHTTP.Checked = true;
                }
                else
                {

                    rdDNSNormal.Checked = true;

                }

                //if (automatico)
                //{
                //    rdAutomatico.Checked = true;
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading DNS Resolver Configuration. " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void LoadActualValues()
        {
            try
            {

                String line;
                String temp;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\mydnssec.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "mydnssec.conf");
                while ((line = obj.ReadLine()) != null)
                {
                    if (line.Contains(has_local_proxy))
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
                        txtURL.Text = FormatActualValues(line);
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
            try
            {

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
            try
            {
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

        public bool IsUrl(string Url)
        {
            string strRegex = "^[0-9a-z].[0-9a-z].$";
            Regex re = new Regex(strRegex);

            if (re.IsMatch(Url))
                return (true);
            else
                return (false);
        }

        public static void ValidaTA(string TAs)
        {
            try
            {

                string[] temp = TAs.Split(' ');
                if (temp.Length > 5)
                {
                    //string trust_anchor = temp[0].Trim();
                    string url = temp[0].Trim('"');
                    string DNSKEY = temp[1].Trim();
                    string code = temp[2].Trim();
                    string DNSSECproto = temp[3].Trim();
                    string Encript = temp[4].Trim();
                    string DecBase64 = "";
                    for (int i = 5; i < temp.Length; i++)
                    {
                        DecBase64 += temp[i].Trim('"');
                    }

                    //validate DNSKEY
                    if (!(DNSKEY == "DNSKEY"))
                    {
                        throw new Exception("The string should contain the value of \"DNSKEY\"");
                    }

                    //validate code
                    if (!(code == "256"))
                    {
                        if (!(code == "257"))
                        {
                            throw new Exception("The string should contain the value of \"256 0 257:\"");
                        }
                    }

                    //validate DNSSEC Protocol
                    if (!(DNSSECproto == "3"))
                    {
                        throw new Exception("The string should contain the value of \"3\" for protocol DNSSEC");
                    }

                    //Validate Encryption Algorithm
                    Boolean foundEncrypt = false;
                    for (int i = 0; i < 256; i++)
                    {
                        if (Encript==i.ToString())
                        {
                            foundEncrypt = true;
                        }
                    }
                    if (foundEncrypt == false)
                    {
                        throw new Exception("The string must contain a valid encryption algorithm.");
                    }
           
                    //Validate Base64 String
                    Regex ValidateBase64 = new Regex("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$");
                    if (!(ValidateBase64.IsMatch(DecBase64)))
                    {
                        throw new Exception("The string must be encoded in base 64.");
                    }

                }
                else { throw new Exception("The chain is not long enough"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadTas()
        {
            try
            {
                String line;

                //C:\MyDNSSEC\TAs.conf
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\TAs.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "TAs.conf");
                while ((line = obj.ReadLine()) != null)
                {
                    line=line.Replace("trust-anchor: ", "");
                    line = line.Replace("\"", "");
                    LBTas.Items.Add(line);
                    //counter++;
                }

                obj.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarTAs()
        {
            try
            {
                ValidaTA(txtActualTAS.Text);

                if (!String.IsNullOrEmpty(txtActualTAS.Text))
                {
                    LBTas.Items.Add(txtActualTAS.Text);
                    DataRow rw = DTAcciones.NewRow();
                    rw["TA"] = txtActualTAS.Text;
                    rw["Accion"] = "Agregado";
                    rw["DeshacerAccion"] = false;
                    DTAcciones.Rows.Add(rw);
                }
                else
                {
                    MessageBox.Show("Not provided TAs", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTAs()
        {
            try
            {

             
                Boolean Eliminado = false;
                if(!(String.IsNullOrEmpty(txtActualTAS.Text))){
                for (int i = 0; i < LBTas.Items.Count; i++)
                {
                    if (LBTas.Items[i].ToString() == txtActualTAS.Text)
                    {
                        LBTas.Items.RemoveAt(i);
                        Eliminado = true;
                        DataRow rw = DTAcciones.NewRow();
                        rw["TA"] = txtActualTAS.Text;
                        rw["Accion"] = "Eliminado";
                        rw["DeshacerAccion"] = false;
                        DTAcciones.Rows.Add(rw);
                        break;
                    }
                }

                if (Eliminado)
                {
                    MessageBox.Show("TA Removed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("The TA provided is not in the List.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClearList()
        {
            try {
                DataRow rw;
                for (int i = 0; i < LBTas.Items.Count; i++) {
                    rw = DTAcciones.NewRow();
                    rw["TA"] = LBTas.Items[i].ToString();
                    rw["Accion"] = "Eliminado";
                    rw["DeshacerAccion"] = false;
                    DTAcciones.Rows.Add(rw);
                
                }
                LBTas.Items.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SaveDNSResolverConfigurationDLV()
        {
            try { 
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
                            line = " " + DLV;
                        }
                        else
                        {
                            line = "    #" + DLV;
                        }
                    }
                    temp.AppendLine(line);
                }
                obj.Close();



                //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\unbound.conf", false);
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "unbound.conf", false);

                swobj.Write(temp.ToString());
                swobj.Flush();
                swobj.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void SaveDNSResolverConfiguration()
        {
            try
            {
                String line;
                StringBuilder temp = new StringBuilder();
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\unbound-local.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "unbound-local.conf");

                while ((line = obj.ReadLine()) != null)
                {
    
                    if (line.Contains(name))
                    {

                        if (rdProxyHTTP.Checked == true)
                        {
                            line = name;
                        }
                        if (rdDNSNormal.Checked == true)
                        {
                            line = name;
                            //Return the dchp configuration
                        

                            //line = "#" + name;
                            concatDNS();
                        }
                        if (rdAutomatico.Checked == true) {
                            SetConnectionAutomatic();

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
                         //   line = "#" + address;
                            line = address;
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



                //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\unbound-local.conf", false); 
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "unbound-local.conf", false);

                swobj.Write(temp.ToString());
                swobj.Flush();
                swobj.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void SaveLocalProxyConfiguration()
        {
            try
            {

                String line;
                StringBuilder temp = new StringBuilder();
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
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void SaveTAsConfiguration()
        {
            try {

                //vaciar lista al archivo Tas.conf
                //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\TAs.conf", false);
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "TAs.conf", false);
                for (int i = 0; i < LBTas.Items.Count; i++)
                {
                    swobj.WriteLine("trust-anchor: \"" + LBTas.GetItemText(LBTas.Items[i]) + "\"");
                }
                swobj.Flush();
                swobj.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void ReadDNSFromRegistry()
        {
            try {
                RegistryKey start = Registry.LocalMachine;
                string DNSservers = @"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters";
                RegistryKey DNSserverKey = start.OpenSubKey(DNSservers);
                if (DNSserverKey == null)
                {
                    throw new Exception("Inaccesible DNS servers key");
                }
                string serverlist = (string)DNSserverKey.GetValue("NameServer");
                Console.WriteLine("DNS Servers: {0}", serverlist);
                DNSserverKey.Close();
                start.Close();
                char[] token = new char[1];
                token[0] = ' ';
                string[] servers = serverlist.Split(token);
                int counter = 0;
                foreach (string server in servers)
                {
                    if (counter == 0)
                    {
                        //txtDNSPrimario.Text = server;
                    }
                    else {
                        //txtDNSSecundario.Text = server;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void frmMainCFG_Load(object sender, EventArgs e)
        {
            try
            {
                //Format Tables
                FormatTables();
                //Load the current configuration of the DNS Resolver
                LoadDNSResolverConfig();
                //Load the existing options file MyDNSSEc.conf
                getValueproxy_type_auth();
                LoadActualValues();
                //Load TAs
                LoadTas();
                //Load DNS Registry 
                ReadDNSFromRegistry();

                desactivarToolStripMenuItem.Enabled = true;
                activarToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmMainCFG_Shown(object sender, EventArgs e)
        {
            try
            {

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
                    
            try
            {

                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void configurarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAplicar_Click_1(object sender, EventArgs e)
        {
            
        }
        
        private void desactivarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Stop MyDNSSEC and Unbound
                downProcess();
                timer1.Stop();
                //DesactivarServicios
                //Se detienen Servicios
                /**  ServiceController stopMyDNSSEC = new ServiceController();
                  stopMyDNSSEC.ServiceName = "MyDnsSecService";
                  stopMyDNSSEC.Stop();
                  stopMyDNSSEC.WaitForStatus(ServiceControllerStatus.Stopped);
                  ServiceController stopUnbound = new ServiceController();
                  stopUnbound.ServiceName = "UnboundService";
                  stopUnbound.Stop();
                  stopUnbound.WaitForStatus(ServiceControllerStatus.Stopped);
                  **/
                ServicesEstatus = false;

                activarToolStripMenuItem.Enabled = true;
                desactivarToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void activarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                //ActivarServicios
                upProcess();
                timer1.Start();
                /**Se inician Servicios
                ServiceController sMyDNSSEC = new ServiceController();
                sMyDNSSEC.ServiceName = "MyDnsSecService";
                sMyDNSSEC.Start();
                sMyDNSSEC.WaitForStatus(ServiceControllerStatus.Running);
                ServiceController sUnbound = new ServiceController();
                sUnbound.ServiceName = "UnboundService";
                sUnbound.Start();
                sUnbound.WaitForStatus(ServiceControllerStatus.Running);
                **/
                ServicesEstatus = true;

                activarToolStripMenuItem.Enabled = false;
                desactivarToolStripMenuItem.Enabled =true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkHasLocalProxy_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
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
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRealizarAccion_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdAgregar.Checked == true)
                {
                    AgregarTAs();
                }
                if (rdEliminar.Checked == true)
                {
                    EliminarTAs();
                }
                if (rdClearList.Checked == true)
                {
                    ClearList();
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LBActionsList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try {
                
                if (LBActionsList.Rows[e.RowIndex].Cells[1].Value.ToString() == "Eliminado")
                {
                    LBTas.Items.Add(LBActionsList.Rows[e.RowIndex].Cells[0].Value);
                    LBActionsList.Rows.RemoveAt(e.RowIndex);
                }
                if (LBActionsList.Rows.Count > 0)
                {
                   if (LBActionsList.Rows[e.RowIndex].Cells[1].Value.ToString() == "Agregado")
                    { 
                        for(int i=0;i<LBTas.Items.Count;i++)
                        {
                            if (LBTas.Items[i].ToString() == LBActionsList.Rows[e.RowIndex].Cells[0].Value.ToString())
                            {
                                LBTas.Items.RemoveAt(i);
                                LBActionsList.Rows.RemoveAt(e.RowIndex);
                                break;
                            }
                        }
                    }
                }
                
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAplicarCambios_Click(object sender, EventArgs e)
        {
            try {
                //CHANGE INTERFACE IP
                downProcess();
                //Se detienen Servicios
                /**
                ServiceController stopMyDNSSEC = new ServiceController();
                stopMyDNSSEC.ServiceName = "MyDnsSecService";
                stopMyDNSSEC.Stop();
                stopMyDNSSEC.WaitForStatus(ServiceControllerStatus.Stopped);
                ServiceController stopUnbound = new ServiceController();
                stopUnbound.ServiceName = "UnboundService";
                stopUnbound.Stop();
                stopUnbound.WaitForStatus(ServiceControllerStatus.Stopped);
                **/
                activarToolStripMenuItem.Enabled = true;
                desactivarToolStripMenuItem.Enabled = false;
                
                ServicesEstatus = false;

                SaveDNSResolverConfigurationDLV();
                SaveDNSResolverConfiguration();
                SaveLocalProxyConfiguration();
                SaveTAsConfiguration();



                //Se inician Servicios
                //upProcesses

                upProcess();
                /**
                ServiceController sMyDNSSEC = new ServiceController();
                sMyDNSSEC.ServiceName = "MyDnsSecService";
                sMyDNSSEC.Start();
                sMyDNSSEC.WaitForStatus(ServiceControllerStatus.Running);
                ServiceController sUnbound = new ServiceController();
                sUnbound.ServiceName = "UnboundService";
                sUnbound.Start();
                sUnbound.WaitForStatus(ServiceControllerStatus.Running);
                **/
                ServicesEstatus = true;

                activarToolStripMenuItem.Enabled = false;
                desactivarToolStripMenuItem.Enabled = true;                

                this.Hide();

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try {
                if (LBActionsList.Rows.Count > 0)
                {
                    if (LBActionsList.Rows[0].Cells[1].Value.ToString() == "Agregado")
                    {
                        for (int i = 0; i < LBTas.Items.Count; i++)
                        {
                            if (LBTas.Items[i].ToString() == LBActionsList.Rows[0].Cells[0].Value.ToString())
                            {
                                LBTas.Items.RemoveAt(i);
                                LBActionsList.Rows.RemoveAt(0);
                                break;
                            }
                        }
                    }
                    if (LBActionsList.Rows.Count > 0) { 
                    
                    if (LBActionsList.Rows[0].Cells[1].Value.ToString() == "Eliminado")
                    {
                        LBTas.Items.Add(LBActionsList.Rows[0].Cells[0].Value);
                        LBActionsList.Rows.RemoveAt(0);

                    }
                    }

 
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkConfigurarDNS_CheckedChanged(object sender, EventArgs e)
        {
            //try {
            //    if (chkConfigurarDNS.Checked)
            //    {
            //        gbDNSsResolver.Enabled = true;
            //    }
            //    else {
            //        gbDNSsResolver.Enabled = false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {

        }
        private void upProcess() {
            try
            {   //Up MyDNSSEC
                if (Process.GetProcessesByName("MyDNSSEC").Length == 0)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "C:\\MyDNSSEC\\mydnssec.exe";
                    startInfo.FileName = MyDNSSecHelper.getInstallationPath() + "mydnssec.exe";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                }
                //Up Unbound 
                if (Process.GetProcessesByName("Unbound").Length == 0)
                {
                    // unbound = Process.Start("C:\\MyDNSSEC\\unbound.exe", "-c C:\\MyDNSSEC\\unbound.conf")
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "C:\\MyDNSSEC\\unbound.exe";
                    //startInfo.Arguments = "-c C:\\MyDNSSEC\\unbound.conf";
                    startInfo.FileName = MyDNSSecHelper.getInstallationPath() +"unbound.exe";
                    startInfo.Arguments = "-c "+MyDNSSecHelper.getInstallationPath() +"unbound.conf";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void downProcess() {
            try
            {
                Process[] processes = Process.GetProcessesByName("mydnssec");
                foreach (Process process in processes)
                {
                    process.Kill();
                }

                Process[] processes2 = Process.GetProcessesByName("unbound");
                foreach (Process process in processes2)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void downUnbound()
        {
            try
            {
                Process[] processes2 = Process.GetProcessesByName("unbound");
                foreach (Process process in processes2)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void upUnbound()
        {
            try
            {
                if (Process.GetProcessesByName("Unbound").Length == 0)
                {
                    // unbound = Process.Start("C:\\MyDNSSEC\\unbound.exe", "-c C:\\MyDNSSEC\\unbound.conf")
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    //startInfo.FileName = "C:\\MyDNSSEC\\unbound.exe";
                    //startInfo.Arguments = "-c C:\\MyDNSSEC\\unbound.conf";

                    startInfo.FileName = MyDNSSecHelper.getInstallationPath() + "unbound.exe";
                    startInfo.Arguments = "-c "+MyDNSSecHelper.getInstallationPath() +"unbound.conf";
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    Process process = new Process();
                    process.StartInfo = startInfo;
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void checkUp() {
            //Monitor of MyDNSSEC
            if (Process.GetProcessesByName("MyDNSSEC").Length > 0)
            {
              //  MessageBox.Show("The program works");
                
            }
            else
            {
                //    MessageBox.Show("The program does not works");
                upProcess();
                count++;
            }

            if (Process.GetProcessesByName("unbound").Length > 0)
            {
                //  MessageBox.Show("The program works");

            }
            else
            {
                //    MessageBox.Show("The program does not works");
                upProcess();
                count++;
            }
        }
        private void Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            checkUp();
            if (count >
                5)
            {
                DialogResult dlgResult = MessageBox.Show("Error: Can not established connection, Check your internet conection", "Server Error", MessageBoxButtons.RetryCancel);
                if (dlgResult == DialogResult.Retry)
                {
                    count = 0;
                    timer1.Start();
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    if (MessageBox.Show("Error: The server is down , please contact our engineers at contact@mydnssec.mx", "Contact",
                    MessageBoxButtons.OK, MessageBoxIcon.Question)
                         == DialogResult.OK)
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                timer1.Start();

            }
        }

        private void numberBox1_Validating(object sender, CancelEventArgs e)
        {
             try
            {
            int numberEntered = int.Parse(dns1.Text);
            if (numberEntered < 0 || numberEntered > 256)
            {
                e.Cancel = true;
                MessageBox.Show("You have to enter a number between 0 and 255");
            }
        }
        catch (FormatException)
        {
            e.Cancel = true;
            MessageBox.Show("You need to enter an integer");
            dns1.Text = "127";
            }
        }


        private void numberBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int numberEntered = int.Parse(dns2.Text);
                if (numberEntered < 0 || numberEntered > 256)
                {
                    e.Cancel = true;
                    MessageBox.Show("You have to enter a number between 0 and 255");
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("You need to enter an integer");
                dns2.Text = "0";
            }
        }
        private void numberBox3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int numberEntered = int.Parse(dns3.Text);
                if (numberEntered < 0 || numberEntered > 256)
                {
                    e.Cancel = true;
                    MessageBox.Show("You have to enter a number between 0 and 255");
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("You need to enter an integer");
                dns3.Text = "0";
            }
        }
        private void numberBox4_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int numberEntered = int.Parse(dns4.Text);
                if (numberEntered < 0 || numberEntered > 256)
                {
                    e.Cancel = true;
                    MessageBox.Show("You have to enter a number between 0 and 255");
                }
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("You need to enter an integer");
                dns4.Text = "0";
            }
        }

        private void localDNS_Click(object sender, EventArgs e)
        {
           

        }
        //http://msdn.microsoft.com/en-us/library/system.net.networkinformation.ipinterfaceproperties.dnsaddresses.aspx
        public static string DisplayDnsConfiguration()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            string DNSservers = "";
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = properties.DnsAddresses;
                //extracting each IP for each DNS server
                if (dnsServers.Count > 0 && (properties.IsDnsEnabled || properties.IsDynamicDnsEnabled))
                {
                    foreach (IPAddress dns in dnsServers)
                    {
                        //Console.WriteLine("  DNS Servers ............................. : {0}", dns.ToString());
                        DNSservers = String.Concat(DNSservers, ",", dns.ToString());
                        //Console.WriteLine("  DNS StrCat ............................. : {0}", DNSservers);
                    }
                }
            }
            return DNSservers.Remove(0, 1);
        }
        public static void setDNS(string DNS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    //if (objMO["Caption"].Equals(NIC))
                    //{
                    try
                    {
                        ManagementBaseObject newDNS = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                        ManagementBaseObject setDNS = objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    //}
                }
            }
        }
       
        private void concatDNS() {
            string DNSlist = DisplayDnsConfiguration();
            string DNSmain = String.Concat(dns1.Text, ".", dns2.Text, ".", dns3.Text, ".", dns4.Text);
            setDNS(DNSmain);
         }
        /*private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string DNSlist = DisplayDnsConfiguration();
                string DNSmain = String.Concat(dns1.Text, ".", dns2.Text, ".", dns3.Text, ".", dns4.Text);
                setDNS(DNSmain);
            }

        }*/

        private void rdAutomatico_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAutomatico.Checked == true) {
              
                dns1.Enabled = false;
                dns2.Enabled = false;
                dns3.Enabled = false;
                dns4.Enabled = false;
            }
        }

        private void rdDNSNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDNSNormal.Checked == true)
            {
                chkHasLocalProxy.Enabled = false;
                dns1.Enabled = true;
                dns2.Enabled = true;
                dns3.Enabled = true;
                dns4.Enabled = true;
              
            }
        }

        private void rdProxyHTTP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdProxyHTTP.Checked == true)
            {
                dns1.Enabled = false;
                dns2.Enabled = false;
                dns3.Enabled = false;
                dns4.Enabled = false;
                chkHasLocalProxy.Enabled = true;

            }
        }
        public void SetConnectionAutomatic()//(Connection c)
{
    ManagementObjectSearcher m =new ManagementObjectSearcher();
    m.Query = new ObjectQuery("Select * from Win32_NetworkAdapterConfiguration Where IPEnabled = True");
    foreach (ManagementObject mo in m.Get())
    {
       // if (mo["Index"].ToString() == c.ConnectionId)
       // {
            mo.InvokeMethod("EnableDHCP",null);
            mo.InvokeMethod("SetDNSServerSearchOrder",null);
            RegistryManager.EnableProxy = false;
            RegistryManager.ProxyAddress = "";
            RegistryManager.BypassProxyForLocalAddresses  = true;
       // }
    }
}

        private void button2_Click(object sender, EventArgs e)
        {
            ////string url1 = "https://itar.iana.org/anchors/anchors.mf.sha1";
            string url2 = "https://itar.iana.org/anchors/anchors.mf";
            ////string url3 = "anchors.mf.sha1";
            //string url4 = "c:\\MyDNSSEC\\anchors.mf";
            string url4 = MyDNSSecHelper.getInstallationPath() + "anchors.mf";
            ////string flag1 = webpage(url1,url3,false);
            string flag2 = webpage(url2, url4, true);
            downUnbound();
            upUnbound();
            
        }
        public static string webpage(string urlelement, string filename, bool hash)
        {
            StringBuilder sb = new StringBuilder(); // used to build entire input       
            byte[] buf = new byte[8192]; // used on each read operation       
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlelement); // prepare the web page we will be asking for       
            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); // execute the request
            Stream resStream = response.GetResponseStream(); // we will read data via the response stream

            string tempString = null;
            string result = null;
            int count = 0;
            do
            {
                count = resStream.Read(buf, 0, buf.Length); // fill the buffer with data
                if (count != 0)
                { // make sure we read some data
                    tempString = Encoding.ASCII.GetString(buf, 0, count); // translate from bytes to ASCII text               
                    sb.Append(tempString);// continue building the string
                }
            } while (count > 0); // any more data to read?

            if (hash == true)
            {
                ////Console.WriteLine(tempString); // print out page source
                SHA1 sha = new SHA1CryptoServiceProvider(); // This is one implementation of the abstract class SHA1.
                result = BitConverter.ToString(sha.ComputeHash(buf)).Replace("-", "");
            }
            ////splitting file content
            else
            {
                result = tempString;
                char[] r = { ' ', ',', '.', ':', '\t', '\n' };
                string[] arr = result.Split(r);
                result = arr[0];
            }

            TextWriter tw = new StreamWriter(filename); // create a writer and open the file
            tw.WriteLine(sb.ToString()); // write a line of text to the file
            tw.Close(); // close the stream

            //byte[] fileData = File.ReadAllBytes("c:\\MyDNSSEC\\anchors.mf");
            byte[] fileData = File.ReadAllBytes(MyDNSSecHelper.getInstallationPath() + "anchors.mf");

            string resultout = BitConverter.ToString(SHA1.Create().ComputeHash(fileData)).Replace("-", "");
            ////Console.WriteLine(resultout.ToString()); // print out page source
            return result; //file content
        }

     
        

        }
    }
