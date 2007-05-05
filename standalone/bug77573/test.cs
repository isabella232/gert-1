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
#if NET_2_0
		h.Execute ("default20.aspx", sw);
#else
		h.Execute ("default11.aspx", sw);
#endif
		string result = sw.ToString ();

		if (result.IndexOf ("<td>0</td>") == -1) {
			Console.WriteLine (result);
			return 1;
		}

		if (result.IndexOf ("<td>ParentItem 0</td>") == -1) {
			Console.WriteLine (result);
			return 2;
		}

		if (result.IndexOf ("<td>1</td>") == -1) {
			Console.WriteLine (result);
			return 3;
		}

		if (result.IndexOf ("<td>ParentItem 1</td>") == -1) {
			Console.WriteLine (result);
			return 4;
		}

		if (result.IndexOf ("<td>2</td>") == -1) {
			Console.WriteLine (result);
			return 5;
		}

		if (result.IndexOf ("<td>ParentItem 2</td>") == -1) {
			Console.WriteLine (result);
			return 6;
		}

		return 0;
	}
}
