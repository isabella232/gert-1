using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class server
{
	static void Main (string [] args)
	{
		byte [] buffer = new byte [10];

		IPAddress ipAddress = IPAddress.Loopback;
		IPEndPoint localEndPoint = new IPEndPoint (ipAddress, 12521);

		Socket listener = new Socket (AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);

		listener.Bind (localEndPoint);
		listener.Listen (5);

		Socket handler = listener.Accept ();

		int bytesRec = handler.Receive (buffer, 0, 10, SocketFlags.None);

		string msg = Encoding.ASCII.GetString (buffer, 0, bytesRec);
		if (msg != "hello") {
			string dir = AppDomain.CurrentDomain.BaseDirectory;
			using (StreamWriter sw = File.CreateText (Path.Combine (dir, "error"))) {
				sw.WriteLine (msg);
			}
		}

		handler.Close ();

		Thread.Sleep (200);
	}
}
