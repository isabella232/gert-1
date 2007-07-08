using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	static void Main ()
	{
		Socket s = new Socket (AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
		s.Bind (new IPEndPoint (IPAddress.Parse ("::1"), 12345));
	}
}
