using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	[STAThread]
	static void Main (string [] args)
	{
		int port;

		Random random = new Random ();
		Socket socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

		do {
			port = random.Next (0xc350, 0xffdc);
			IPEndPoint localEP = new IPEndPoint (IPAddress.Loopback, port);
			try {
				socket.Bind (localEP);
				break;
			} catch {
			}
		} while (true);

		socket.Close ();

		IPEndPoint LocalEP = new IPEndPoint (IPAddress.Loopback, port);
		Socket ListeningSocket = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		ListeningSocket.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
		ListeningSocket.Bind (LocalEP);
		ListeningSocket.SetSocketOption (SocketOptionLevel.IP, SocketOptionName.AddMembership,
			new MulticastOption (IPAddress.Parse ("239.255.255.250"), IPAddress.Loopback));
		ListeningSocket.Close ();
	}
}
