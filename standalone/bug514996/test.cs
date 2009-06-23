using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class Program
{
	static int Main ()
	{
		IPEndPoint ep = new IPEndPoint (IPAddress.Loopback, 8001);

		NetworkConnection con = new NetworkConnection (ep);
		Assert.IsFalse (con.IsActive, "#1");

		for (int i = 1; i < 50; i++) {
			int result = Run (ep);
			if (result != 0)
				return result;
		}

		Assert.IsFalse (con.IsActive, "#2");

		return 0;
	}

	static int Run (IPEndPoint ep)
	{
		string url = "http://" + ep.ToString () + "/test/";

		using (SocketResponder responder = new SocketResponder (ep, new SocketRequestHandler (EchoRequestHandler))) {
			responder.Start ();

			HttpWebRequest req;
			Stream rs;

			req = (HttpWebRequest) WebRequest.Create (url);
			req.Method = "POST";
			req.ContentLength = 2;
			rs = req.GetRequestStream ();
			rs.WriteByte (0x0d);
			try {
				rs.Close ();
				return 1;
			} catch (WebException) {
			}

			req = (HttpWebRequest) WebRequest.Create (url);
			req.Method = "POST";
			req.ContentLength = 2;
			rs = req.GetRequestStream ();
			rs.WriteByte (0x0d);
			try {
				rs.Close ();
				return 2;
			} catch (WebException) {
			}

			req = (HttpWebRequest) WebRequest.Create (url);
			req.Method = "POST";
			req.ContentLength = 2;
			rs = req.GetRequestStream ();
			rs.WriteByte (0x0d);
			rs.WriteByte (0x0d);
			rs.Close ();

			responder.Stop ();
		}

		return 0;
	}

	static byte [] EchoRequestHandler (Socket socket)
	{
		MemoryStream ms = new MemoryStream ();
		byte [] buffer = new byte [4096];
		int bytesReceived = socket.Receive (buffer);
		while (bytesReceived > 0) {
			ms.Write (buffer, 0, bytesReceived);
			if (socket.Available > 0) {
				bytesReceived = socket.Receive (buffer);
			} else {
				bytesReceived = 0;
			}
		}
		ms.Flush ();
		ms.Position = 0;

		string request = string.Empty;
		using (StreamReader sr = new StreamReader (ms, Encoding.UTF8)) {
			request = sr.ReadToEnd ();
		}

		StringWriter sw = new StringWriter ();
		sw.WriteLine ("HTTP/1.1 200 OK");
		sw.WriteLine ("Content-Type: text/xml");
		sw.WriteLine ("Content-Length: " + request.Length.ToString (CultureInfo.InvariantCulture));
		sw.WriteLine ();
		sw.Write (request);
		sw.Flush ();

		return Encoding.UTF8.GetBytes (sw.ToString ());
	}
}
