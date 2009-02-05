using System;
using System.Net;
using System.Net.Sockets;
//using System.Threading;

namespace TestCase
{
	class MainClass
	{
		public static void Main (string [] args)
		{
			IPEndPoint ep = new IPEndPoint (IPAddress.Loopback, 10000);
			Socket accept = new Socket (AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
			Socket client = new Socket (AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);
			Socket listener = new Socket (AddressFamily.InterNetwork,
				SocketType.Stream, ProtocolType.Tcp);

			listener.Bind (ep);
			listener.Listen (8);
			IAsyncResult listenResult = listener.BeginAccept (accept,
				0, null, null);

			client.Connect (ep);
			Assert.IsFalse (accept.Connected, "#1");

			Socket connected = listener.EndAccept (listenResult);
			Assert.IsTrue (accept.Connected, "#2");
			Assert.AreSame (connected, accept, "#3");
		}
	}
}
