using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	static int Main (string [] args)
	{
		if (args.Length != 1)
			return 1;

		switch (args [0]) {
		case "client":
			SimpleClient client = new SimpleClient ();
			return client.Run ();
		case "server":
			SimpleServer server = new SimpleServer ();
			server.Run ();
			return 0;
		default:
			return 2;
		}
	}
}

class SimpleServer
{
	private TcpListener listener;

	public void Run ()
	{
		listener = new TcpListener (IPAddress.Loopback, 9999);
		listener.Start ();

		try {
			TcpClient client = listener.AcceptTcpClient ();
			NetworkStream stream = client.GetStream ();

			stream.WriteByte (0x00);
			stream.WriteByte (0x00);

			client.Close ();
		} finally {
			listener.Stop ();
		}
	}
}

class SimpleClient
{
	private TcpClient client;

	public int Run ()
	{
		client = new TcpClient ();
		IPEndPoint ipep = new IPEndPoint (IPAddress.Loopback, 9999);
		try {
			client.Connect (ipep);
		} catch (SocketException) {
			Console.WriteLine ("Failed to connect. Exiting...");
			return 1;
		}

		while (true) {
			int len = client.GetStream ().ReadByte ();
			if (len < 0) {
				return 0;
			}

			byte [] bytes = new byte [len];
			client.GetStream ().Read (bytes, 0, len);
		}
	}
}
