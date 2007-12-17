using System;
using System.IO;
using System.Net;
#if NET_2_0
using System.Net.Security;
#endif
using System.Net.Sockets;
using System.Reflection;
using SSCX = System.Security.Cryptography.X509Certificates;
using System.Text;

using Mono.Security.X509;
using Mono.Security.Protocol.Tls;

class Program
{
	static int Main (string [] args)
	{
		string site = "https://www.microsoft.com";

		if (args.Length != 1) {
			Console.WriteLine ("Please specify the action to perform.");
			return 1;
		}

		switch (args [0]) {
		case "save-chain":
			X509CertificateCollection certs = DownloadCertificates (site);
			string dir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
				"chain");
			for (int i = 0; i < certs.Count; i++) {
				X509Certificate cert = certs [i];

				if (i == 0) {
					using (FileStream fs = File.OpenWrite (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "www.microsoft.com.crt"))) {
						byte [] raw = cert.RawData;
						fs.Write (raw, 0, raw.Length);
					}
				} else {
					using (FileStream fs = File.OpenWrite (Path.Combine (dir, cert.SubjectName + ".crt"))) {
						byte [] raw = cert.RawData;
						fs.Write (raw, 0, raw.Length);
					}
				}
			}
			break;
		case "test":
			return Test (site);
		default:
			Console.WriteLine ("Action '{0}' is not supported.", args [0]);
			return 1;
		}

		return 0;
	}

	static int Test (string site)
	{
#if NET_2_0
		string certFile = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"www.microsoft.com.crt");

		SSCX.X509Certificate2 cer = new SSCX.X509Certificate2 (certFile);
		Assert.IsTrue (cer.Verify (), "#1");

		SSCX.X509Chain chain = new SSCX.X509Chain ();
		Assert.IsTrue (chain.Build (cer), "#2");
#endif
		
		HttpWebRequest request = (HttpWebRequest) WebRequest.Create (site);
		request.Method = "GET";

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("<title>Microsoft Corporation</title>") == -1) {
					Console.WriteLine (result);
					return 1;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			} else {
				Console.WriteLine (ex.ToString ());
			}
			return 2;
		}

		return 0;
	}

#if NET_2_0
		public static bool DumpCertificateInfo (object sender, SSCX.X509Certificate certificate, SSCX.X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			Console.WriteLine ("Certificate:");
			Console.WriteLine ("============");
			Console.WriteLine ("Subject: " + certificate.Subject);
			Console.WriteLine ("Errors: {0}", sslPolicyErrors);
			Console.WriteLine ();

			foreach (SSCX.X509Certificate2 cert in chain.ChainPolicy.ExtraStore) {
				Console.WriteLine ("ExtraStore Certificate:");
				Console.WriteLine ();
				Console.WriteLine ("Subject: {0}", cert.Subject);
				Console.WriteLine ("Issuer: {0}", cert.Issuer);
				Console.WriteLine ("Valid: {0}", cert.Verify ());
				Console.WriteLine ();
			}

			foreach (SSCX.X509ChainElement element in chain.ChainElements) {
				Console.WriteLine ("ChainElement Certificate:");
				Console.WriteLine ();

				Console.WriteLine ("Subject: {0}", element.Certificate.Subject);
				Console.WriteLine ("Issuer: {0}", element.Certificate.Issuer);
				Console.WriteLine ("Valid: {0}", element.Certificate.Verify ());
				Console.WriteLine ("Extensions: {0}", element.Certificate.Extensions.Count);
				Console.WriteLine ("Status:");
				for (int index = 0; index < element.ChainElementStatus.Length; index++) {
					Console.WriteLine ("\t{0}:{1}",
						element.ChainElementStatus [index].Status,
						element.ChainElementStatus [index].StatusInformation);
				}
				Console.WriteLine ();
			}

			if (sslPolicyErrors == SslPolicyErrors.None)
				return true;

			return true;
		}
#endif

	static X509CertificateCollection DownloadCertificates (string site)
	{
		Uri uri = new Uri (site);
#if NET_2_0
		IPHostEntry host = Dns.GetHostEntry (uri.Host);
#else
		IPHostEntry host = Dns.Resolve (uri.Host);
#endif
		IPAddress ip = host.AddressList [0];
		Socket socket = new Socket (ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		socket.Connect (new IPEndPoint (ip, uri.Port));
		NetworkStream ns = new NetworkStream (socket, false);
		SslClientStream ssl = new SslClientStream (ns, uri.Host, false, Mono.Security.Protocol.Tls.SecurityProtocolType.Default, null);
		ssl.ServerCertValidationDelegate += new CertificateValidationCallback (CertificateValidation);

		try {
			// we don't really want to write to the server (as we don't know
			// the protocol it using) but we must send something to be sure the
			// SSL handshake is done (so we receive the X.509 certificates).
			StreamWriter sw = new StreamWriter (ssl);
			sw.WriteLine (Environment.NewLine);
			sw.Flush ();
			socket.Poll (30000, SelectMode.SelectRead);
		} finally {
			socket.Close ();
		}

		// we need a little reflection magic to get this information
		PropertyInfo pi = typeof (SslStreamBase).GetProperty ("ServerCertificates", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
		if (pi == null) {
			throw new ArgumentException ("Sorry but you need a newer version of Mono.Security.dll to use this feature.");
		}

		return (X509CertificateCollection) pi.GetValue (ssl, null);
	}

	static bool CertificateValidation (SSCX.X509Certificate certificate, int [] certificateErrors)
	{
		// the main reason to download it is that it's not trusted
		return true;
		// OTOH we ask user confirmation before adding certificates into the stores
	}
}
