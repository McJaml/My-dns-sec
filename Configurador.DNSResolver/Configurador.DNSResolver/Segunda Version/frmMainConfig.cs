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

namespace Configurador.DNSResolver.Segunda_Version
{
    public partial class frmMainConfig : Form
    {

        String name = "name: \"itesm.edu\"";
        String address = "forward-addr: 10.18.6.5";
        String DLV = "dlv-anchor-file: \"dlv.isc.org.key\"";

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


        private void LoadDNSResolverConfig()
        {
            try
            {
                String line;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\unbound.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath()+"unbound.conf");
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
                MessageBox.Show("Error al Cargar Configuración del DNS Resolver. "+ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private string getInstallDir()
        {
            throw new NotImplementedException();
        }

        public void LoadActualValues()
        {
            try
            {

                String line;
                String temp;
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\mydnssec.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath()+"mydnssec.conf");
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
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath()+"mydnssec.conf");
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
                    string trust_anchor = temp[0].Trim();
                    string url = temp[1].Trim('"');
                    string DNSKEY = temp[2].Trim();
                    string code = temp[3].Trim();
                    string DNSSECproto = temp[4].Trim();
                    string Encript = temp[5].Trim();
                    string DecBase64 = "";
                    for (int i = 6; i < temp.Length; i++)
                    {
                        DecBase64 += temp[i].Trim('"');
                    }

                    //Validando trust anchor
                    if (!(trust_anchor == "trust-anchor:"))
                    {
                        throw new Exception("La cadena debe de empezar con el valor de \"trust-anchor:\"");
                    }
                    //validando url 
                    //if(!(this.IsUrl(url)))
                    //{
                    //    throw new Exception("El nombre de dominio proporcionado no es valido");
                    //}

                    //validando DNSKEY
                    if (!(DNSKEY == "DNSKEY"))
                    {
                        throw new Exception("La cadena debe de contener el valor de \"DNSKEY\"");
                    }

                    //validando code
                    if (!(code == "256"))
                    {
                        if (!(code == "257"))
                        {
                            throw new Exception("La cadena debe de contener el valor de \"256 0 257:\"");
                        }
                    }

                    //validando DNSSEC Protocol
                    if (!(DNSSECproto == "3"))
                    {
                        throw new Exception("La cadena debe de contener el valor de \"3\" para el protocolo DNSSEC");
                    }

                    //Validando Algoritmo de encriptación
                    switch (Encript)
                    {
                        case "5":
                            break;
                        //se pueden agregar otros case para validar otro algoritmo
                        default:
                            throw new Exception("La cadena debe de contener un algoritmo valido de encriptación.");

                    }

                    //Validando cadena Base64
                    Regex ValidateBase64 = new Regex("^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$");
                    if (!(ValidateBase64.IsMatch(DecBase64)))
                    {
                        throw new Exception("La cadena debe de estar codificada en base 64.");
                    }

                }
                else { throw new Exception("La cadena no tiene suficiente longitud"); }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LoadTas()
        {
            try {
                String line;

                //C:\MyDNSSEC\TAs.conf
                //StreamReader obj = new StreamReader("C:\\MyDNSSEC\\TAs.conf");
                StreamReader obj = new StreamReader(MyDNSSecHelper.getInstallationPath() + "TAs.conf");
                while ((line = obj.ReadLine()) != null)
                {
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

        public frmMainConfig()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try {

                this.Hide();
            
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                this.Show();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
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
                            line = " " + DLV;
                        }
                        else
                        {
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
                            line = "#" + name;
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
                StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "unbound.conf", false);

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

        private void btnGuardar_Click(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmMainConfig_Load(object sender, EventArgs e)
        {
            try
            {
                //carga la configuracion actual del DNS Resolver
                LoadDNSResolverConfig();
                //cargar las opciones que existentes en el archivo MyDNSSEc.conf
                getValueproxy_type_auth();
                LoadActualValues();
                //Carga los TAs
                LoadTas();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void chkHasLocalProxy_CheckedChanged(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
         try { 
                //ActivarServicios
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                //DesactivarServicios
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //vaciar lista al archivo Tas.conf
            //StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\TAs.conf", false);
            StreamWriter swobj = new StreamWriter(MyDNSSecHelper.getInstallationPath() + "TAs.conf", false);
            for (int i = 0; i < LBTas.Items.Count; i++)
            {
                swobj.WriteLine(LBTas.GetItemText(LBTas.Items[i]));
            }
            swobj.Flush();
            swobj.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        try
            {
                ValidaTA(txtActualTAS.Text);

                if (!String.IsNullOrEmpty(txtActualTAS.Text))
                {
                    LBTas.Items.Add(txtActualTAS.Text);
                         }
                else
                {
                    MessageBox.Show("No se ha proporcionado el TAS", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try {
            //    if (tabControl1.SelectedIndex != 0)
            //    {
            //        LBTas.Items.Clear();
            //        String line;

            //        //C:\MyDNSSEC\TAs.conf
            //        StreamReader obj = new StreamReader("C:\\MyDNSSEC\\TAs.conf");
            //        while ((line = obj.ReadLine()) != null)
            //        {
            //            LBTas.Items.Add(line);
            //            //counter++;
            //        }

            //        obj.Close();
            //    }
            //    else {
            //        //vaciar lista al archivo Tas.conf
            //        StreamWriter swobj = new StreamWriter(@"C:\\MyDNSSEC\\TAs.conf", false);
            //        for (int i = 0; i < LBTas.Items.Count; i++)
            //        {
            //            swobj.WriteLine(LBTas.GetItemText(LBTas.Items[i]));
            //        }
            //        swobj.Flush();
            //        swobj.Close();
                    
            //    }

               
            //}
            //catch (Exception ex)
            //{
            //     MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                if (LBTas.SelectedItem == null)
                {
                    MessageBox.Show("No hay Tas seleccionado para eliminar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (MessageBox.Show("Se eliminar el elemento,¿Desea continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    LBTas.Items.RemoveAt(LBTas.SelectedIndex);

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LBTas.SelectedItem != null)
                {
                    frmEditTAs obj = new frmEditTAs();
                    obj.TAs = LBTas.GetItemText(LBTas.SelectedItem);
                    obj.ShowInTaskbar = false;
                    obj.ShowDialog();
                }
                else { MessageBox.Show("No se ha seleccionado algun elemento de la lista", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmMainConfig_Shown(object sender, EventArgs e)
        {
            try {

                this.Hide();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


    }
}
