using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class client
{
	static void Main ()
	{
		string str = "hello";
		byte [] buffer = Encoding.ASCII.GetBytes (str.ToCharArray ());

		IPAddress ipAddress = IPAddress.Loopback;
		IPEndPoint remoteEP = new IPEndPoint (ipAddress, 12521);

		Socket sender = new Socket (AddressFamily.InterNetwork,
			SocketType.Stream, ProtocolType.Tcp);
		sender.Connect (remoteEP);
		sender.Send (buffer, 0, buffer.Length, SocketFlags.None);
		sender.Shutdown (SocketShutdown.Both);
		sender.Close ();
	}
}
