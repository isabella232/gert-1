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
		if (!result.Contains ("<input name=\"TextBox1\" type=\"text\" value=\"Normal TextBox\" id=\"TextBox1\" />")) {
			Console.WriteLine (result);
			return 1;
		}
		if (!result.Contains ("<input type=\"password\" value=\"Mono is great\">")) {
			Console.WriteLine (result);
			return 2;
		}
		if (!result.Contains ("<span id=\"MyBanner_Label1\">OK</span>")) {
			Console.WriteLine (result);
			return 3;
		}
		if (!result.Contains ("<input name=\"TextBox2\" type=\"text\" value=\"Another TextBox\" id=\"TextBox2\" />")) {
			Console.WriteLine (result);
			return 4;
		}
		return 0;
	}
}
