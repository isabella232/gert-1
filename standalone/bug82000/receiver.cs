using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
	static int Main ()
	{
		IPAddress mcastAddress = IPAddress.Parse ("FF01::1");
		IPEndPoint bindEp = new IPEndPoint (IPAddress.IPv6Any, 4567);

		Socket s = new Socket (AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
		s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
		s.Bind (bindEp);
		s.SetSocketOption (SocketOptionLevel.IPv6, SocketOptionName.AddMembership, new IPv6MulticastOption (mcastAddress));

		byte [] buffer = new byte [10];
		int count = s.Receive (buffer);
		if (count != 5)
			return 1;
		if (Encoding.ASCII.GetString (buffer, 0, count) != "hello")
			return 2;
		return 0;
	}
}
