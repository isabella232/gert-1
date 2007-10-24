using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	public static TinyHost CreateHost ()
	{
		string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "web");
		string bin = Path.Combine (path, "bin");
		string asm = Path.GetFileName (typeof (TinyHost).Assembly.Location);

		Directory.CreateDirectory (bin);
		File.Copy (asm, Path.Combine (bin, asm), true);

		return (TinyHost) ApplicationHost.CreateApplicationHost (
			typeof (TinyHost), "/", path);
	}

	public void Execute (string page, string query, TextWriter tw)
	{
		SimpleWorkerRequest req = new SimpleWorkerRequest (
			page, query, tw);
		HttpRuntime.ProcessRequest (req);
	}

	static int Main ()
	{
		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute ("Default.aspx", "arg1=1&arg2=2", sw);
		string result = sw.ToString ();

		if (result.IndexOf ("<p>ARG1=1</p>") == -1) {
			Console.WriteLine (result);
			return 1;
		}
		if (result.IndexOf ("<p>ARG2=2</p>") == -1) {
			Console.WriteLine (result);
			return 2;
		}

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Default.aspx", "arg1=1;arg2=2", sw);
		result = sw.ToString ();

		if (result.IndexOf ("<p>ARG1=1;arg2=2</p>") == -1) {
			Console.WriteLine (result);
			return 3;
		}
		if (result.IndexOf ("<p>ARG2=</p>") == -1) {
			Console.WriteLine (result);
			return 4;
		}

		return 0;
	}
}
