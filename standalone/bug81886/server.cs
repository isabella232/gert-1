using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost ()
	{
		string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "web");
		string bin = Path.Combine (path, "bin");
		string asm = Path.GetFileName (typeof (TinyHost).Assembly.Location);

		Directory.CreateDirectory (bin);
		File.Copy (asm, Path.Combine (bin, asm), true);

		return (TinyHost) ApplicationHost.CreateApplicationHost (
			typeof (TinyHost), "/", path);
	}

	public void Execute (string page, TextWriter tw)
	{
		SimpleWorkerRequest req = new SimpleWorkerRequest (
			page, "", tw);
		HttpRuntime.ProcessRequest (req);
	}

	static int Main ()
	{
		TinyHost h = CreateHost ();

		HttpListener listener = new HttpListener ();
		listener.Prefixes.Add ("http://" + IPAddress.Loopback.ToString () + ":8081/");
		listener.Start ();

		HttpListenerContext ctx = listener.GetContext ();
		StreamWriter sw = new StreamWriter (ctx.Response.OutputStream);
		h.Execute ("FaultService.asmx", sw);
		sw.Flush ();
		ctx.Response.Close ();

		return 0;
	}
}
