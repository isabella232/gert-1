using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	static int Main (string [] args)
	{
		int port = 8001;
		UdpClient udpClient = new UdpClient (port);
		IPAddress ip = IPAddress.Parse ("224.0.0.2");
		udpClient.JoinMulticastGroup (ip, IPAddress.Any);
		udpClient.MulticastLoopback = true;
		udpClient.Ttl = 1;
		udpClient.BeginReceive (ReceiveNotification, udpClient);
		udpClient.Send (new byte [1] { 255 }, 1, new IPEndPoint (ip, port));
		System.Threading.Thread.Sleep (1000);
		udpClient.DropMulticastGroup (ip);
		if (!_receivedNotification)
			return 1;
		return 0;
	}

	static void ReceiveNotification (IAsyncResult asyncResult)
	{
		_receivedNotification = true;
		((UdpClient) asyncResult.AsyncState).BeginReceive (ReceiveNotification, asyncResult.AsyncState);
	}

	static bool _receivedNotification;
}
