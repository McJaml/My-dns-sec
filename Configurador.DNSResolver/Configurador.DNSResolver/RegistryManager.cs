using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Configurador.DNSResolver {
    public class RegistryManager {
        private static RegistryKey _Settings;
        public static string ProxyAddress {
            get {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                string value = (string)_Settings.GetValue("ProxyServer", string.Empty);
                _Settings.Close();
                return value;
            }
            set {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                _Settings.SetValue("ProxyServer", value);
                _Settings.Close();
            }
        }

        public static bool EnableProxy {
            get {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                int value = (int)_Settings.GetValue("ProxyEnable", 0);
                _Settings.Close();
                return (value > 0);
            }
            set {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                int setValue = (value ? 1 : 0);
                _Settings.SetValue("ProxyEnable", setValue);
                _Settings.Close();
            }
        }

        public static bool BypassProxyForLocalAddresses {
            get {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                string value = (string)_Settings.GetValue("ProxyOverride", string.Empty);
                _Settings.Close();
                // If bypass proxy set, then it should contain <local>
                if (value.IndexOf("<local>") >= 0) {
                    return true;
                } else {
                    return false;
                }
            }
            set {
                _Settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true);
                string existingValue = (string)_Settings.GetValue("ProxyOverride", string.Empty);
                if (existingValue.IndexOf("<local>") >= 0) {
                    if (!value) {
                        existingValue = existingValue.Replace(";" + Environment.NewLine + "<local>", "");
                    }
                } else {
                    if (value) {
                        existingValue += ";" + Environment.NewLine + "<local>";
                    }
                }

                _Settings.SetValue("ProxyOverride", existingValue);
                _Settings.Close();
            }
        }

    }

    public class MyDNSSecHelper {
        public static string getInstallationPath() {
            return (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\ITESM\", "Path", "#Missing Value#");
        }
        public string Path { get; set; }
    }
}
