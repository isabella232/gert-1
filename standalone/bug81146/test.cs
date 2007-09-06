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
		h.Execute ("Create.aspx", sw);
		string result = sw.ToString ();

		int index = result.IndexOf ("<option value=\"Item 1\">Data 1</option>");
		if (index == -1) {
			Console.WriteLine (result);
			return 1;
		}

		index = result.IndexOf ("<option value=\"Item 1\">Data 1</option>", index + 1);
		if (index != -1) {
			Console.WriteLine (result);
			return 2;
		}

		index = result.IndexOf ("<option value=\"Item 2\">Data 2</option>");
		if (index == -1) {
			Console.WriteLine (result);
			return 3;
		}

		index = result.IndexOf ("<option value=\"Item 2\">Data 2</option>", index + 1);
		if (index != -1) {
			Console.WriteLine (result);
			return 4;
		}

		return 0;
	}
}
