using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

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
			return "";
		}
	}
}
