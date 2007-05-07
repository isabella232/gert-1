using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost ()
	{
		string path = AppDomain.CurrentDomain.BaseDirectory;
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
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Thread.CurrentThread.CurrentUICulture = new CultureInfo ("nl-BE");

		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute ("WebForm1.aspx", sw);
		string result = sw.ToString ();
		if (result.IndexOf ("id=\"Calendar1\"") == -1) {
			Console.WriteLine (result);
			return 1;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("WebForm2.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("id=\"Calendar1\"") != -1) {
			Console.WriteLine (result);
			return 2;
		}
		return 0;
	}
}
