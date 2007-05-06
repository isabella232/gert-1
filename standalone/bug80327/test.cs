using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

class Program
{
	static void Main (string [] args)
	{
		Thread s = new Thread (new ThreadStart (WontDie));
		s.IsBackground = true;
		s.Start ();
		System.Threading.Thread.Sleep (1000);
	}

	private static void WontDie ()
	{
		while (true) {
			IPEndPoint endpoint = new IPEndPoint (IPAddress.Loopback, 1900);
			UdpClient s = new UdpClient ();
			byte [] buffer = new byte [1024];
			s.Send (buffer, buffer.Length, endpoint);
			s.Receive (ref endpoint);
		}
	}
}
