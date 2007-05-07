using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Test
{
	static void Main ()
	{
		IPEndPoint localEP = new IPEndPoint (IPAddress.Loopback, 5000);
		using (SocketResponder sr = new SocketResponder (localEP, new SocketRequestHandler (Response_Bug80944))) {
			sr.Start ();

			HttpWebRequest req = (HttpWebRequest) WebRequest.Create (
				"http://" + sr.LocalEndPoint.Address.ToString () + ":5000/");
			req.KeepAlive = false;
			req.Method = "GET";
			req.ReadWriteTimeout = 2000;
#if NET_2_0
			req.Proxy = null;
#endif
			req.Timeout = 2000;
#if NET_2_0
			Assert.IsNull (req.Proxy, "#1");
#else
			Assert.IsNotNull (req.Proxy, "#1");
#endif

			HttpWebResponse resp = (HttpWebResponse) req.GetResponse ();
			using (StreamReader r = new StreamReader (resp.GetResponseStream (), Encoding.UTF8)) {
				Assert.AreEqual ("FINE", r.ReadToEnd (), "#2");
			}
			resp.Close ();
		}
	}

	static byte[] Response_Bug80944 (Socket socket)
	{
		StringWriter sw = new StringWriter ();
		sw.WriteLine ("HTTP/1.1 200 OK");
		sw.WriteLine ("Content-Type: text/plain; charset=UTF-8");
		sw.WriteLine ("Content-Length: 4");
		sw.WriteLine ();
		sw.Write ("FINE");

		return Encoding.UTF8.GetBytes (sw.ToString ());
	}
}
