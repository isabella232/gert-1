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

		int index1 = result.IndexOf ("<h1>Begin TestModule</h1>");
		if (index1 == -1) {
			Console.WriteLine (result);
			return 1;
		}

		int index2 = result.IndexOf ("<h1>Begin DebugModule</h1>");
		if (index2 == -1 || index2 <= index1) {
			Console.WriteLine (result);
			return 2;
		}

		int index3 = result.IndexOf ("<p>Hello!</p>");
		if (index3 == -1 || index3 <= index2) {
			Console.WriteLine (result);
			return 3;
		}

		int index4 = result.IndexOf ("<h1>End TestModule</h1>");
		if (index4 == -1 || index4 <= index3) {
			Console.WriteLine (result);
			return 4;
		}

		int index5 = result.IndexOf ("<h1>End DebugModule</h1>");
		if (index5 == -1 || index5 <= index4) {
			Console.WriteLine (result);
			return 5;
		}

		return 0;
	}
}
