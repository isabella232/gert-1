using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web.Hosting;

class Program
{
	static void Main ()
	{
		ThreadPool.QueueUserWorkItem (StartAspNetHost, "foo1");

		System.Threading.Thread.Sleep (2000);

		ThreadPool.QueueUserWorkItem (StartAspNetHost, "foo2");

		System.Threading.Thread.Sleep (2000);

		HttpWebRequest request;

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8880/foo1/Default.aspx");
		using (HttpWebResponse response = (HttpWebResponse) request.GetResponse ()) {
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string body = sr.ReadToEnd ();
				Assert.IsTrue (body.IndexOf ("<body><h1>GET http://localhost:8880/foo1/Default.aspx</h1>") != -1, "#A1:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>AcceptTypes:</b> <i>null</i></li>") != -1, "#A2:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>ContentLength64:</b> 0</li>") != -1, "#A3:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>ContentType:</b> <i>null</i></li>") != -1, "#A4:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>HttpMethod:</b> GET</li>") != -1, "#A5:" + body);
				Assert.IsTrue (body.IndexOf ("<li>Host = localhost:8880</li>") != -1, "#A6:" + body);
			}
		}

		request = (HttpWebRequest) WebRequest.Create ("http://localhost:8880/foo2/Default.aspx");
		using (HttpWebResponse response = (HttpWebResponse) request.GetResponse ()) {
			using (StreamReader sr = new StreamReader (response.GetResponseStream ())) {
				string body = sr.ReadToEnd ();
				Assert.IsTrue (body.IndexOf ("<body><h1>GET http://localhost:8880/foo2/Default.aspx</h1>") != -1, "#B1:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>AcceptTypes:</b> <i>null</i></li>") != -1, "#B2:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>ContentLength64:</b> 0</li>") != -1, "#B3:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>ContentType:</b> <i>null</i></li>") != -1, "#B4:" + body);
				Assert.IsTrue (body.IndexOf ("<li><b>HttpMethod:</b> GET</li>") != -1, "#B5:" + body);
				Assert.IsTrue (body.IndexOf ("<li>Host = localhost:8880</li>") != -1, "#B6:" + body);
			}
		}
	}

	static void StartAspNetHost (Object args)
	{
		ApplicationManager appman = ApplicationManager.GetApplicationManager ();
		Host host = (Host) appman.CreateObject (Guid.NewGuid ().ToString (),
			typeof (Host), string.Format ("/{0}/", args),
			Path.Combine (AppDomain.CurrentDomain.BaseDirectory, (string) args),
			false);
		host.StartListener (args);
	}
}
