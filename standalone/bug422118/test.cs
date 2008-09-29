using System;
using System.Net;
using System.Net.NetworkInformation;

class Program
{
	static void Main ()
	{
		NetworkInterface [] nics = NetworkInterface.GetAllNetworkInterfaces ();

		for (int i = 0; i < nics.Length; i++) {
			NetworkInterface adapter = nics [i];

			if (adapter.NetworkInterfaceType != NetworkInterfaceType.Loopback)
				continue;

			PhysicalAddress address = adapter.GetPhysicalAddress ();

			Assert.AreEqual (PhysicalAddress.None, address, "#1");
			byte [] bytes = address.GetAddressBytes ();
			Assert.AreEqual (0, bytes.Length, "#2");
		}
	}
}
