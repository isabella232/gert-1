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
#if NET_2_0
		if (result.IndexOf ("<span id=\"ctl00_Label1\">Mono</span><span id=\"ctl01_Label2\">ASP.NET</span><span id=\"ctl02_Label3\">rocks!</span>") == -1) {
#else
		if (result.IndexOf ("<span id=\"_ctl0_Label1\">Mono</span><span id=\"_ctl1_Label2\">ASP.NET</span><span id=\"_ctl2_Label3\">rocks!</span>") == -1) {
#endif
			Console.WriteLine (result);
			return 1;
		}
		return 0;
	}
}
