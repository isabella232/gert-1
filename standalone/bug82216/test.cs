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
#if MONO
		if (!result.Contains ("<input type=\"text\" value=\"Normal TextBox\" name=\"TextBox1\" id=\"TextBox1\" />")) {
#else
		if (!result.Contains ("<input name=\"TextBox1\" type=\"text\" value=\"Normal TextBox\" id=\"TextBox1\" />")) {
#endif
			Console.WriteLine (result);
			return 1;
		}
		if (!result.Contains ("<input type=\"password\" value=\"Mono is great\">")) {
			Console.WriteLine (result);
			return 2;
		}
		if (!result.Contains ("<span id=\"MyLabel_Label1\">CustomFINE</span>")) {
			Console.WriteLine (result);
			return 3;
		}
		if (!result.Contains ("<span id=\"MyBanner_Label1\">CustomOK</span>")) {
			Console.WriteLine (result);
			return 4;
		}
#if MONO
		if (!result.Contains ("<input type=\"text\" value=\"Another TextBox\" name=\"TextBox2\" id=\"TextBox2\" />")) {
#else
		if (!result.Contains ("<input name=\"TextBox2\" type=\"text\" value=\"Another TextBox\" id=\"TextBox2\" />")) {
#endif
			Console.WriteLine (result);
			return 5;
		}
		return 0;
	}
}
