using System;
using System.Net;
using System.Net.Sockets;
using System.Timers;

class Server
{
	static void Main (string [] args)
	{
		new Server ();

		Console.ReadLine ();
	}

	Server ()
	{
		_listener = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		_listener.Bind (new IPEndPoint (IPAddress.Loopback, 10000));
		_listener.Listen (10);
		_listener.BeginAccept (new AsyncCallback (OnAccept), _listener);
	}

	public void OnAccept (IAsyncResult ar)
	{
		_pendingClient = _listener.EndAccept (ar);

		//
		// Sleep for 1s before sending a byte to the client and accepting a new connection.
		//
		Timer t = new Timer ();
		t.AutoReset = false;
		t.Interval = 1000;
		t.Elapsed += new ElapsedEventHandler (OnAcceptContinue);
		t.Enabled = true;
	}

	public void OnAcceptContinue (object sender, ElapsedEventArgs e)
	{
		Byte [] data = new Byte [3];
		data [0] = 1;
		data [1] = 5;
		data [2] = 7;
		try {
			_pendingClient.Send (data, data.Length, SocketFlags.None);
		} catch (SocketException) {
			// socket will be closed by the client
		} finally {
			_pendingClient = null;
		}

		_listener.BeginAccept (new AsyncCallback (OnAccept), _listener);
	}

	Socket _listener;
	Socket _pendingClient;
}

