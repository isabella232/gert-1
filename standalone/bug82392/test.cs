using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
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
		StringWriter sw = new StringWriter ();

		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		if (result.IndexOf ("IsReadOnly = True") == -1) {
			Console.WriteLine (result);
			return 1;
		}
		if (result.IndexOf ("Mode = InProc") == -1) {
			Console.WriteLine (result);
			return 2;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Disabled.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("Session state can only be used when enableSessionState is set to true") == -1) {
			Console.WriteLine (result);
			return 3;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Enabled.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("IsReadOnly = False") == -1) {
			Console.WriteLine (result);
			return 4;
		}
		if (result.IndexOf ("Mode = InProc") == -1) {
			Console.WriteLine (result);
			return 5;
		}

		return 0;
	}
}
