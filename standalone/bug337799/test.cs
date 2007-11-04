using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI;

class Program
{
	static int Main ()
	{
		CookieContainer cookieContainer = new CookieContainer ();

		HttpWebRequest request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081/Default.aspx");
		request.CookieContainer = cookieContainer;
		request.Method = "GET";

		string cssResourceURL = null;
		string scriptResourceURL = null;

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
#if !MONO
				if (result.IndexOf ("<script src=\"/WebResource.axd?d=Us9ckR5btm8lMMu0RQjwPXcda3w5uEBRwV0doPyQf08iZQHZVkFdjYzM9XD8dfq79jPt0yvp0EIolN3REA6hjQ2&amp;t=") == -1) {
					Console.WriteLine (result);
					return 1;
				}
				if (result.IndexOf ("<link rel='stylesheet' type='text/css' href='/WebResource.axd?d=Us9ckR5btm8lMMu0RQjwPXcda3w5uEBRwV0doPyQf08iZQHZVkFdjYzM9XD8dfq7_xG3t6VDAGM_m1oWVOQd-A2&t=") == -1) {
					Console.WriteLine (result);
					return 2;
				}
#endif

				int startIndex = result.IndexOf ("<script src=\"");
				int endIndex = result.IndexOf ("\"", startIndex + 13);
				scriptResourceURL = result.Substring (startIndex + 13, endIndex - (startIndex + 13));
				scriptResourceURL = scriptResourceURL.Replace ("&amp;", "&");

				startIndex = result.IndexOf ("<link rel='stylesheet' type='text/css' href='");
				endIndex = result.IndexOf ("' />", startIndex + 45);
				cssResourceURL = result.Substring (startIndex + 45, endIndex - (startIndex + 45));
				cssResourceURL = cssResourceURL.Replace ("&amp;", "&");

			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 3;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081" + scriptResourceURL);
		request.CookieContainer = cookieContainer;

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
				if (result.IndexOf ("document.write('<RES><%=WebResource(\"Mono.Web.Security.UI.MyResources.Test.css\")%></RES>');") == -1) {
					Console.WriteLine (result);
					return 4;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 5;
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8081" + cssResourceURL);
		request.CookieContainer = cookieContainer;

		try {
			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			using (StreamReader sr = new StreamReader (response.GetResponseStream (), Encoding.UTF8, true)) {
				string result = sr.ReadToEnd ();
#if MONO
				if (result.IndexOf ("background-image: url(" + scriptResourceURL + ")") == -1) {
#else
				if (result.IndexOf ("background-image: url(" + scriptResourceURL.Substring (1) + ")") == -1) {
#endif
					Console.WriteLine (result);
					return 6;
				}
			}
			response.Close ();
		} catch (WebException ex) {
			if (ex.Response != null) {
				StreamReader sr = new StreamReader (ex.Response.GetResponseStream ());
				Console.WriteLine (sr.ReadToEnd ());
			}
			return 7;
		}

		return 0;
	}
}
