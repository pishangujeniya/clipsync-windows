using System.Management.Automation;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using NLog;

namespace ClipSync.Helpers {
    /// <summary>
    /// All Global Helper Methods
    /// </summary>
    class GlobalHelper {
        /// <summary>
        /// General Logger Target
        /// </summary>
        public static Logger generaLogger = LogManager.GetLogger("GeneralLog");
        /// <summary>
        /// Copy History Logger Target
        /// </summary>
        public static Logger copyHistoryLogger = LogManager.GetLogger("CopyHistory");

        /// <summary>
        /// Provides the MAC address of current system
        /// </summary>
        /// <returns></returns>
        public string GetMacAddress() {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces()) {
                //// Only consider Ethernet network interfaces
                //if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                //	nic.OperationalStatus == OperationalStatus.Up) {
                //	return nic.GetPhysicalAddress();
                //}
                if (nic.OperationalStatus == OperationalStatus.Up) {
                    return nic.GetPhysicalAddress().ToString();
                }
            }
            return "UNKNOWN";
        }

        /// <summary>
        /// Provides the Ip Address of current connected network
        /// </summary>
        /// <returns></returns>
        public string GetMachineIpAddress() {
            IPHostEntry host;
            string localIP = "";
            try {
                host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ip in host.AddressList) {
                    localIP = ip.ToString();

                    string[] temp = localIP.Split('.');

                    if (ip.AddressFamily == AddressFamily.InterNetwork && temp[0] == "192") {
                        break;
                    } else {
                        localIP = null;
                    }
                }
            } catch (System.Exception ex) {
                generaLogger.Error(ex);
            }
            return localIP;
        }

        /// <summary>
        /// Opens the given Port in the inbound Windows Firewall
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="ruleDisplayName">Rule Display Name</param>
        /// <param name="ruleDescription">Rule Description</param>
        /// <returns></returns>
        public bool OpenInboundFirewallPort(int port, string ruleDisplayName, string ruleDescription) {
            try {
                var powershell = PowerShell.Create();
                var psCommand = $"New-NetFirewallRule -DisplayName \"" + ruleDisplayName + "\" -Description " + ruleDescription + " -Direction Inbound -LocalPort " + port + " -Protocol TCP -Action Allow";
                powershell.Commands.AddScript(psCommand);
                var x = powershell.Invoke();
                if (x.Count > 0) {
                    return true;
                } else {
                    return false;
                }
            } catch (System.Exception ex) {
                generaLogger.Error(ex);
                return false;
            }
        }

        /// <summary>
        /// Checks where the port is opened or not
        /// </summary>
        /// <param name="port"></param>
        /// <param name="displayName"></param>
        /// <returns></returns>
        public bool IsPortOpened(int port, string displayName) {
            try {
                var powershell = PowerShell.Create();
                var psCommand = $"Get-NetFirewallRule -DisplayName \"" + displayName + "\"";
                powershell.Commands.AddScript(psCommand);
                var x = powershell.Invoke();
                foreach (var rule in x) {
                    if (rule.Properties["Description"].Value.ToString() == port.ToString()) {
                        return true;
                    }
                }
                return false;
            } catch (System.Exception ex) {
                generaLogger.Error(ex);
                return false;
            }
        }
    }
}
