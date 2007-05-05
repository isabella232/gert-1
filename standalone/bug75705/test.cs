using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Program
{
	static bool socketThreadRunning;
	static Socket socket;

	static int Main ()
	{
		// Opening socket like discovery does.
		socket = new Socket (AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		socket.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
		socket.Bind (new IPEndPoint (IPAddress.Any, 2917));
		socket.SetSocketOption (SocketOptionLevel.IP, SocketOptionName.AddMembership,
			new MulticastOption (IPAddress.Parse ("224.4.0.1"), IPAddress.Any));

		Thread socketThread = new Thread (new ThreadStart (SocketReceive));
		socketThread.Start ();
		socketThreadRunning = true;
		Thread.Sleep (50); // Give the thread a moment to be in it's socket.Receive() call.
		socket.Close ();
		Thread.Sleep (50);  // Give it a moment to end.
		if (socketThreadRunning)
			return 1;
		return 0;
	}

	static void SocketReceive ()
	{
		byte [] bytes = new byte [50];
		try {
			socket.Receive (bytes);
		} catch (SocketException) {
			socketThreadRunning = false;
		}
	}
}
