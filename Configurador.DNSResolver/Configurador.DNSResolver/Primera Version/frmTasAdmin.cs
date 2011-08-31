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

namespace Configurador.DNSResolver
{
    public partial class frmTasAdmin : Form
    {

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
            try {

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

        public frmTasAdmin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
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
            this.Close();
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

        private void frmTasAdmin_Load(object sender, EventArgs e)
        {
            try {

                String line;

                //C:\MyDNSSEC\TAs.conf
                //StreamReader obj=new StreamReader("C:\\MyDNSSEC\\TAs.conf");
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
                MessageBox.Show(ex.Message, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try {

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
            try {
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
    }
}
