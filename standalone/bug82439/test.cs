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
		if (result.IndexOf ("FilePath=/Default.aspx") == -1) {
			Console.WriteLine (result);
			return 1;
		}
		if (result.IndexOf ("Path=/Default.aspx") == -1) {
			Console.WriteLine (result);
			return 2;
		}
		if (result.IndexOf ("RawUrl=/Default.aspx") == -1) {
			Console.WriteLine (result);
			return 3;
		}

		string webPath = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "web");
		string expectedPhysicalPath = Path.Combine (webPath, "Default.aspx");
		if (result.IndexOf ("PhysPath=" + expectedPhysicalPath) == -1) {
			Console.WriteLine (result);
			return 4;
		}
		return 0;
	}
}
