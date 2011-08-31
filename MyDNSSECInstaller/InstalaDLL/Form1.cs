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


namespace ÌnstalaDLL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process regsvr1;
            this.Hide();

            String installPath = getInstallationPath();

            regsvr1 = new Process();
            regsvr1.StartInfo.FileName = "regsvr32";
            regsvr1.StartInfo.Arguments = installPath+"DNSSECVerify4IENav.dll";
            regsvr1.StartInfo.CreateNoWindow = true;
            regsvr1.Start();

            this.Close();

        }
        private string getInstallationPath()
        {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ITESM\", "Path", "#Missing Value#");
        }
    }
}
