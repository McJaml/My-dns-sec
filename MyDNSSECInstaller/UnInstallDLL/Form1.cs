using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace UnInstallDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Process[] process1 = Process.GetProcessesByName("iexplorer");
                foreach (Process process in process1)
                {
                    process.Kill();
                }

                Process[] process2 = Process.GetProcessesByName("Configurador.DNSResolver");
                foreach (Process process in process2)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Hide();
            Process regsvr2;

            String installPath = getInstallationPath();

            regsvr2 = new Process();
            regsvr2.StartInfo.FileName = "regsvr32";
            regsvr2.StartInfo.Arguments = "/u "+installPath+"DNSSECVerify4IENav.dll";
            regsvr2.StartInfo.CreateNoWindow = true;
            regsvr2.Start();

            this.Close();
        }

        private string getInstallationPath()
        {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ITESM\", "Path", "#Missing Value#");
        }
    }
}
