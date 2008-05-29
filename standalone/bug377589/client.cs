using System;
using System.Net;
using System.Net.Sockets;
using System.Timers;

class Client
{
	static int Main ()
	{
		new Client ();

		System.Threading.Thread.Sleep (3000);

		if (!_test1)
			return 1;
		if (!_test2)
			return 2;
		return 0;
	}

	Client ()
	{
		//
		// Establish first connection.
		//
		Socket socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Blocking = false;
		socket.BeginConnect (new IPEndPoint (IPAddress.Loopback, 10000),
			new AsyncCallback (OnConnect), socket);
	}

	public void OnConnect (IAsyncResult ar)
	{
		Socket socket = (Socket) ar.AsyncState;
		socket.EndConnect (ar);

		//
		// Start reading over the first connection. Note that this
		// is necessary to reproduce the bug, without this, the
		// call to BeginReceive on the second connection works
		// fine. With this however, the BeginReceive call on the
		// second connection fails with WSAEWOULDBLOCK.
		//
		byte [] buff = new byte [50];
		socket.BeginReceive (buff, 0, buff.Length, SocketFlags.None, new AsyncCallback (OnReceive), socket);

		//
		// Close immediatly the first connection.
		//
		socket.Close ();

		//
		// Establish a second connection.
		//
		socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		socket.Blocking = false;
		socket.BeginConnect (new IPEndPoint (IPAddress.Loopback, 10000),
			new AsyncCallback (OnConnect2), socket);
	}

	public void OnReceive (IAsyncResult ar)
	{
		Socket socket = (Socket) ar.AsyncState;
		if (!socket.Connected)
			_test1 = true;
	}

	public void OnConnect2 (IAsyncResult ar)
	{
		//
		// Start reading over the second connection.
		//
		Socket socket = (Socket) ar.AsyncState;
		socket.EndConnect (ar);
		byte [] buff = new byte [50];
		socket.BeginReceive (buff, 0, buff.Length, SocketFlags.None, new AsyncCallback (OnReceive2), socket);
	}

	public void OnReceive2 (IAsyncResult ar)
	{
		Socket socket = (Socket) ar.AsyncState;
		try {
			int n = socket.EndReceive (ar);
			if (n == 3)
				_test2 = true;
		} catch (Exception ex) {
			Console.WriteLine (ex.ToString ());
		} finally {
			socket.Close ();
		}
	}

	private static bool _test1;
	private static bool _test2;
}
