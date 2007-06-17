using System.Net;
using System.Net.Sockets;

class Program
{
	static void Main ()
	{
		EndPoint multicast = new IPEndPoint (IPAddress.Any, 9090);

		Socket socket_a = new Socket (AddressFamily.InterNetwork, SocketType.Dgram,
			ProtocolType.Udp);
		socket_a.SetSocketOption (SocketOptionLevel.Socket,
			SocketOptionName.ReuseAddress, 1);
		socket_a.SetSocketOption (SocketOptionLevel.IP,
			SocketOptionName.MulticastLoopback, 1);
		socket_a.SetSocketOption (SocketOptionLevel.IP,
			SocketOptionName.MulticastTimeToLive, 1);
		socket_a.Bind (multicast);

		Socket socket_b = new Socket (AddressFamily.InterNetwork, SocketType.Dgram,
			ProtocolType.Udp);
		socket_b.SetSocketOption (SocketOptionLevel.Socket,
			SocketOptionName.ReuseAddress, 1);
		socket_b.SetSocketOption (SocketOptionLevel.IP,
			SocketOptionName.MulticastLoopback, 1);
		socket_b.SetSocketOption (SocketOptionLevel.IP,
			SocketOptionName.MulticastTimeToLive, 1);
		socket_b.Bind (multicast);
	}
}
