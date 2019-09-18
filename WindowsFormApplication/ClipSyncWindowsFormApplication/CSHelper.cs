using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;


namespace ClipSync {
    class CSHelper {

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

        public string GetMachineIpAddress() {
            IPHostEntry host;
            string localIP = "";
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

            return localIP;
        }

        public void OpenFireWallPOrt(int port, string rule_name, string rule_description) {
        }
    }
}
