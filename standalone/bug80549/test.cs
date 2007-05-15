using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	static int Main ()
	{
		Socket server = new Socket (AddressFamily.InterNetwork, SocketType.Stream,
						ProtocolType.Tcp);
		IPEndPoint ep = new IPEndPoint (IPAddress.Loopback, 1234);
		server.Bind (ep);
		server.Listen (1);

		Socket client = new Socket (AddressFamily.InterNetwork, SocketType.Stream,
						ProtocolType.Tcp);
		client.Connect (ep);

		Socket accepted = server.Accept ();

		string endPoint = accepted.RemoteEndPoint.ToString ();
		if (endPoint == null || endPoint.Length == 0)
			return 1;

		client.Close ();
		if (endPoint != accepted.RemoteEndPoint.ToString ())
			return 2;
		return 0;
	}
}
