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
		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();

		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		if (result.IndexOf ("<p>ok</p>") == -1) {
			Console.WriteLine (result);
			return 1;
		}
		if (result.IndexOf ("document.write(\"<sc\" + \"ript src='script/somescript.js?\" + dt.getTime() + \"'></sc\" + \"ript>\");") == -1) {
			Console.WriteLine (result);
			return 2;
		}
		if (result.IndexOf ("Error") != -1) {
			Console.WriteLine (result);
			return 3;
		}
		return 0;
	}
}
