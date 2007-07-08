using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
	static void Main ()
	{
		IPAddress mcastAddress = IPAddress.Parse ("FF01::1");
		IPEndPoint bindEp = new IPEndPoint (IPAddress.IPv6Any, 555);

		Socket s = new Socket (AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
		s.Bind (bindEp);
		s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
		s.SetSocketOption (SocketOptionLevel.IPv6, SocketOptionName.MulticastTimeToLive, 0);
		s.SetSocketOption (SocketOptionLevel.IPv6, SocketOptionName.AddMembership, new IPv6MulticastOption (mcastAddress));
		s.Connect (new IPEndPoint (mcastAddress, 4567));

		for (int i = 0; i < 5; i++) {
			s.Send (Encoding.ASCII.GetBytes ("hello"));
			Thread.Sleep (500);
		}
	}
}
