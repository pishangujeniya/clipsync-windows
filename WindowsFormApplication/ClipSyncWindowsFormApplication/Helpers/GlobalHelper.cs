using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;


namespace ClipSync.Helpers {
    /// <summary>
    /// All Global Helper Methods
    /// </summary>
    class GlobalHelper {
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
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList) {
                localIP = ip.ToString();

                string[] temp = localIP.Split('.');

                if (ip.AddressFamily == AddressFamily.InterNetwork && temp[0] == "192") {
                    break;
                }
                else {
                    localIP = null;
                }
            }

            return localIP;
        }

        /// <summary>
        /// [UNDER DEVELOPMENT] Open the given Port in the Windows Firewall
        /// </summary>
        /// <param name="port"></param>
        /// <param name="rule_name"></param>
        /// <param name="rule_description"></param>
        public void OpenFireWallPOrt(int port, string rule_name, string rule_description) {
        }
    }
}
