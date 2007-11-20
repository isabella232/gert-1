using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

internal class Program
{
	static void Main (string [] args)
	{
		Server http = new Server ();
		Proxy proxy = new Proxy ();

		new Thread (http.Run).Start ();
		new Thread (proxy.Run).Start ();

		IPAddress ip = GetIPv4Address (Dns.GetHostName ());

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://" + ip.ToString () + ":8080/default.htm");
		request.Proxy = new WebProxy (ip.ToString (), 8081);

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			Assert.IsNull (response.CharacterSet, "#A1");
			Assert.AreEqual (HttpStatusCode.OK, response.StatusCode, "#A2");
			Assert.AreEqual (string.Empty, response.ContentEncoding, "#A3");
			Assert.AreEqual (string.Empty, response.ContentType, "#A4");

			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string body = sr.ReadToEnd ();
				Assert.AreEqual ("<html><body>ok</body></html>", body, "#A5");
			}
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			throw;
		} finally {
			http.Stop ();
			proxy.Stop ();
		}
	}

	public static IPAddress GetIPv4Address (string hostName)
	{
		IPAddress [] addresses = Dns.GetHostEntry (Dns.GetHostName ()).AddressList;
		foreach (IPAddress address in addresses)
			if (address.AddressFamily == AddressFamily.InterNetwork)
				return address;
		throw new Exception ("No IPv4 address found.");
	}
}

internal class Proxy
{
	private readonly TcpListener Listener;
	private readonly IPAddress ip;

	public Proxy ()
	{
		ip = Program.GetIPv4Address (Dns.GetHostName ());
		Listener = new TcpListener (ip, 8081);
		Listener.Start ();
	}

	public void Stop ()
	{
		Listener.Stop ();
	}

	public void Run ()
	{
		Socket client;
		try {
			while (true) {
				client = Listener.AcceptSocket ();
				byte [] buffer = new byte [50000];

				int bytesReceived = client.Receive (buffer);

				string request = Encoding.UTF8.GetString (buffer, 0, bytesReceived);

				string expected = string.Format (CultureInfo.InvariantCulture,
					"GET http://{0}:8080/default.htm HTTP/1.1{1}" +
					"Host: {0}:8080{1}" +
					"Proxy-Connection: Keep-Alive{1}{1}",
					ip.ToString (), Environment.NewLine);

				Assert.AreEqual (expected, request, "#B");

				Socket req = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				req.Connect (ip, 8080);
				req.Send (buffer, 0, bytesReceived, SocketFlags.None);

				buffer = new byte [50000];

				bytesReceived = req.Receive (buffer);
				req.Close ();

				client.Send (buffer, 0, bytesReceived, SocketFlags.None);
				client.Shutdown (SocketShutdown.Both);
				client.Close ();
			}
		} catch (SocketException) {
		}

	}
}

internal class Server
{
	private HttpListener Listener = new HttpListener ();

	public Server ()
	{
		IPAddress ip = Program.GetIPv4Address (Dns.GetHostName ());
		Listener.Prefixes.Add (@"http://" + ip.ToString () + ":8080/");
		Listener.Start ();
	}

	public void Stop ()
	{
		Listener.Stop ();
	}

	public void Run ()
	{
		while (Listener.IsListening) {
			try {
				HttpListenerContext context = Listener.GetContext ();
				HttpListenerResponse response = context.Response;

				StringBuilder sb = new StringBuilder ();
				sb.Append ("<html>");
				sb.Append ("<body>ok</body>");
				sb.Append ("</html>");
				response.ContentLength64 = sb.Length;

				using (StreamWriter writer = new StreamWriter (response.OutputStream)) {
					writer.Write (sb.ToString ());
				}
				context.Response.Close ();
			} catch (HttpListenerException) {
			}
		}
	}
}
