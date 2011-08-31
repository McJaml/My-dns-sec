using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Configurador.DNSResolver.Segunda_Version;
using Configurador.DNSResolver.Tercera_Version;
using Configurador.DNSResolver.Cuarta_Version;
using System.ServiceProcess;

namespace Configurador.DNSResolver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////Se inician Servicios
            //ServiceController sMyDNSSEC = new ServiceController();
            //sMyDNSSEC.ServiceName = "MyDnsSecService";
            //sMyDNSSEC.Start();
            //sMyDNSSEC.WaitForStatus(ServiceControllerStatus.Running);
            //ServiceController sUnbound = new ServiceController();
            //sUnbound.ServiceName = "UnboundService";
            //sUnbound.Start();
            //sUnbound.WaitForStatus(ServiceControllerStatus.Running);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMainConfDNSRES.ServicesEstatus = true;
            
            Application.Run(new frmMainConfDNSRES());
            if (frmMainConfDNSRES.ServicesEstatus == false)
            {
                //Se detienen Servicios
                ServiceController stopMyDNSSEC = new ServiceController();
                stopMyDNSSEC.ServiceName = "MyDnsSecService";
                stopMyDNSSEC.Stop();
                stopMyDNSSEC.WaitForStatus(ServiceControllerStatus.Stopped);
                ServiceController stopUnbound = new ServiceController();
                stopUnbound.ServiceName = "UnboundService";
                stopUnbound.Stop();
                stopUnbound.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
    }
}
