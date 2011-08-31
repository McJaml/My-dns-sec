using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Configurador.DNSResolver
{
    public partial class frmMain : Form
    {
        //Process dig;
        //String s;
        //System.Timers.Timer timer = new System.Timers.Timer();
        //int it = 0;

        //public frmMain()
        //{
        //    InitializeComponent();
        //}

        //private bool checkServer()
        //{

        //    //Start the Resolver
        //    dig = new Process();
        //    dig.StartInfo.RedirectStandardOutput = true;
        //    dig.StartInfo.Arguments = "version.bind chaos txt";
        //    dig.StartInfo.FileName = "C:\\MyDNSSEC\\dig\\dig.exe";
        //    dig.StartInfo.UseShellExecute = false;
        //    dig.StartInfo.CreateNoWindow = true;
        //    dig.Start();
        //    //Receive the respones from the resolver
        //    s = dig.StandardOutput.ReadToEnd();
        //    string[] words = s.Split(' ');
        //    bool up = true;
        //    //Searching for response
        //    if (!words[12].Equals("Got"))
        //    {
        //        s = "";
        //        for (int i = 12; i < words.Length; i++)
        //        {
        //            s = s + words[i].ToString() + " ";
        //        }
        //        //turn on the flag up
        //        up = false;
        //    }

        //    return up;
        //}


        //private void frmMain_Shown(object sender, EventArgs e)
        //{

        //    // hide the form
        //    this.Hide();
        //    //set up the timer

        //    timer.Interval = 5000;
        //    timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        //    timer.Enabled = true;

        //}

        //private void timer_Elapsed(object sender, EventArgs e)
        //{
        //    timer.Enabled = false;
        //    if (!checkServer())
        //    {
        //        //try to execute the unbound until 5 times before ask the user for another try
        //        it++;
        //        if (it > 4)
        //        {
        //            DialogResult dR = MessageBox.Show(s, "MyDNSSEC", MessageBoxButtons.RetryCancel);
        //            if (dR == System.Windows.Forms.DialogResult.Yes)
        //            {
        //                unbound = Process.Start("C:\\MyDNSSEC\\unbound.exe", "-c C:\\MyDNSSEC\\unbound.conf");
        //                it = 0;
        //            }
        //            else
        //            {
        //                timer.Enabled = false;
        //            }
        //        }

        //    }
        //    else
        //    {
        //        //if the connection is ok the timer is enable again
        //        unbound = Process.Start("C:\\MyDNSSEC\\unbound.exe", "-c C:\\MyDNSSEC\\unbound.conf");
        //        timer.Enabled = true;
        //    }
        //}
    }
}