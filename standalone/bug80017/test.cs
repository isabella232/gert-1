using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;

class Program
{
	static int Main ()
	{
		for (int i = 0; i < 10; i++) {
			if (!RunTest ())
				return 1;
		}

		return 0;
	}

	static bool RunTest ()
	{
		// Start the server thread
		ServerThread serverThread = new ServerThread ();
		serverThread.Start ();

		// Create the client
		HttpWebRequest rq = (HttpWebRequest) WebRequest.Create ("http://" + IPAddress.Loopback.ToString () + ":54321");
		rq.ProtocolVersion = HttpVersion.Version11;
		rq.KeepAlive = false;

		// Get the response
		HttpWebResponse rsp = (HttpWebResponse) rq.GetResponse ();
		ASCIIEncoding enc = new ASCIIEncoding ();

		StringBuilder result = new StringBuilder ();

		// Stream the body in 1 byte at a time
		byte [] bytearr = new byte [1];
		Stream st = rsp.GetResponseStream ();
		while (true) {
			int b = st.Read (bytearr, 0, 1);
			if (b == 0) {
				break;
			}

			result.Append (enc.GetString (bytearr));
		}

		return (result.ToString () == "012345670123456789abcdefabcdefghijklmnopqrstuvwxyz");
	}
}

class ServerThread
{
	public ServerThread ()
	{
		iThread = new Thread (new ThreadStart (this.Serve));
	}

	public void Start ()
	{
		iThread.Start ();
		iStarted.WaitOne ();
	}

	public void Serve ()
	{
		// Create the server socket
		Socket sock = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		sock.Bind (new IPEndPoint (IPAddress.Loopback, 54321));
		sock.Listen (5);

		// Wait for connection
		iStarted.Set ();
		Socket sock2 = sock.Accept ();

		// connection made - wait for http request
		byte [] data = new byte [1000];
		sock2.Receive (data);

		ASCIIEncoding enc = new ASCIIEncoding ();

		// Send the response - chunked responses will very likely be
		// sent as a series of Send() calls.
		sock2.Send (enc.GetBytes ("HTTP/1.1 200 OK\r\n"));
		sock2.Send (enc.GetBytes ("Transfer-Encoding: chunked\r\n"));
		sock2.Send (enc.GetBytes ("\r\n"));
		sock2.Send (enc.GetBytes ("8\r\n"));
		sock2.Send (enc.GetBytes ("01234567\r\n"));
		sock2.Send (enc.GetBytes ("10\r\n"));
		sock2.Send (enc.GetBytes ("0123456789abcdef\r\n"));
		sock2.Send (enc.GetBytes ("7\r\n"));
		sock2.Send (enc.GetBytes ("abcdefg\r\n"));
		sock2.Send (enc.GetBytes ("9\r\n"));
		sock2.Send (enc.GetBytes ("hijklmnop\r\n"));
		sock2.Send (enc.GetBytes ("a\r\n"));
		sock2.Send (enc.GetBytes ("qrstuvwxyz\r\n"));
		sock2.Send (enc.GetBytes ("0\r\n"));
		sock2.Send (enc.GetBytes ("\r\n"));

		// Close the sockets
		sock2.Close ();
		sock.Close ();
	}

	private Thread iThread;
	private ManualResetEvent iStarted = new ManualResetEvent (false);
}
