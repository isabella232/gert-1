using System;
using System.IO;
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
		string webDir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"web");
		string appCodeDir = Path.Combine (webDir, "App_Code");
		string invalidSourceFile = Path.Combine (appCodeDir, "invalid.cs");
		string invalidConfigFile = Path.Combine (webDir, "Web.config");

		Directory.CreateDirectory (appCodeDir);
		File.Delete (invalidSourceFile);
		File.Delete (invalidConfigFile);

		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		if (result != "bug81127") {
			Console.WriteLine (result);
			return 1;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("~/Doc/Default.aspx", sw);
		result = sw.ToString ();
		if (result != "bug81127") {
			Console.WriteLine (result);
			return 2;
		}

		return 0;
	}
}
