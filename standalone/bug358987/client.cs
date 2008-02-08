using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
	static void Main ()
	{
		Socket s = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		s.Connect (IPAddress.Parse ("127.0.0.1"), 8081);
		string request = "GET / HTTP/1.1\r\n" +
				 "Host: 127.0.0.1\r\n\r\n";
		//request = "GET / HTTP/1.1\r\nHost: 127.0.0.1:8001\r\n\r\n";
		s.Send (Encoding.UTF8.GetBytes (request));
		s.Shutdown (SocketShutdown.Both);
		s.Close ();
	}
}
