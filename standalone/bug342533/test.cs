using System;
using System.IO;
using System.Net;
#if NET_2_0
using System.Net.Security;
#endif
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace test
{
	class MainClass
	{
		public static void Main (string [] args)
		{
#if NET_2_0 && !MONO
			ServicePointManager.ServerCertificateValidationCallback =
				new RemoteCertificateValidationCallback (ValidateServerCertificate);
#else
			ServicePointManager.CertificatePolicy = new AllowAllCertificatePolicy ();
#endif

			HttpWebRequest hwRequest = null;
			HttpWebResponse hwResponse = null;
			CookieContainer ccCookies = null;
			ccCookies = new CookieContainer ();
			String strPostData = "ltmpl=yj_blanco&ltmplcache=2&continue=http%3A%2F%2Fmail.google.com%2Fmail%3Fui%3Dhtml%26zy%3Dl&service=mail&rm=false&ltmpl=yj_blanco&Email=my0test&Passwd=testtest&rmShown=1&null=Zaloguj+si%C4%99";
			String strAccept = "application/x-shockwave-flash,text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,video/x-mng,image/png,image/jpeg,image/gif;q=0.2,*/*;q=0.1";
			String strBrowserMozzila = "Mozilla/5.0 (Windows; U; Windows NT 5.1; pl; rv:1.8.1.2) Gecko/20070219 Firefox/2.0.0.2";
			Stream streamRequest = null;
			StreamReader streamrResponse = null;
			hwRequest = (HttpWebRequest) HttpWebRequest.Create ("https://www.google.com/accounts/ServiceLoginAuth");
			hwRequest.AllowAutoRedirect = true;
			hwRequest.Method = "POST";
			hwRequest.Referer = hwRequest.Address.AbsoluteUri;
			hwRequest.ContentType = "application/x-www-form-urlencoded";
			hwRequest.UserAgent = strBrowserMozzila;
			hwRequest.KeepAlive = true;
			hwRequest.AllowAutoRedirect = true;
			hwRequest.AllowWriteStreamBuffering = true;
			hwRequest.CookieContainer = ccCookies;
			hwRequest.Timeout = 30 * 1000;
			hwRequest.Accept = strAccept;
			ASCIIEncoding ascii = new ASCIIEncoding ();
			byte [] byData = ascii.GetBytes (strPostData);
			try {
				hwRequest.ContentLength = byData.Length;
				streamRequest = hwRequest.GetRequestStream ();
				streamRequest.Write (byData, 0, byData.Length);
			} finally {
				try {
					streamRequest.Close ();
				} catch {
					;
				}
			}
			hwResponse = (HttpWebResponse) hwRequest.GetResponse ();
			Stream myResponse = hwResponse.GetResponseStream ();
			streamrResponse = new StreamReader (myResponse);
			string myout, mytmp = "";
			myout = "";
			while (mytmp != null) {
				myout += mytmp + "\r\n";
				mytmp = streamrResponse.ReadLine ();
			}
			streamrResponse.Close ();
			myResponse.Close ();
			myResponse.Close ();

			String strLink = myout.Substring (myout.IndexOf ("http://www.google.")).Replace ("&amp;", "&");

			int index = strLink.IndexOf ("'");
			strLink = strLink.Remove (index, strLink.Length - index);

			string referer = hwRequest.Address.AbsoluteUri;
			hwRequest = null;
			hwRequest = (HttpWebRequest) HttpWebRequest.Create (strLink);
			hwRequest.AllowAutoRedirect = true;
			hwRequest.Method = "GET";
			hwRequest.Referer = referer;
			hwRequest.ContentType = "application/x-www-form-urlencoded";
			hwRequest.UserAgent = strBrowserMozzila;
			hwRequest.KeepAlive = true;
			hwRequest.AllowAutoRedirect = true;
			hwRequest.AllowWriteStreamBuffering = true;
			hwRequest.CookieContainer = ccCookies;
			hwRequest.Timeout = 30 * 1000;
			hwRequest.Accept = strAccept;
			hwResponse = null;
			hwResponse = (HttpWebResponse) hwRequest.GetResponse ();
			using (StreamReader sr = new StreamReader (hwResponse.GetResponseStream ())) {
				string body = sr.ReadToEnd ();
				Assert.IsTrue (body.IndexOf ("<title>Google Mobile</title>") != -1, body);
			}
		}

#if NET_2_0 && !MONJO
		public static bool ValidateServerCertificate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
#endif
	}
}

#if ONLY_1_1 || MONO
internal class AllowAllCertificatePolicy : ICertificatePolicy
{
	public bool CheckValidationResult (ServicePoint point, X509Certificate certificate, WebRequest request, int certificateProblem)
	{
		return true;
	}
}
#endif
