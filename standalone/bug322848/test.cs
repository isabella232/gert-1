using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost (string baseDir)
	{
		string bin = Path.Combine (baseDir, "bin");
		string asm = Path.GetFileName (typeof (TinyHost).Assembly.Location);

		Directory.CreateDirectory (bin);
		File.Copy (asm, Path.Combine (bin, asm), true);

		return (TinyHost) ApplicationHost.CreateApplicationHost (
			typeof (TinyHost), "/", baseDir);
	}

	public void Execute (string page, TextWriter tw)
	{
		SimpleWorkerRequest req = new SimpleWorkerRequest (
			page, "", tw);
		HttpRuntime.ProcessRequest (req);
	}

	static int Main ()
	{
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;

		TinyHost h = CreateHost (baseDir);
		StringWriter sw = new StringWriter ();
		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		Assert.IsTrue (result.Length != 0, "#1");
		Assert.IsTrue (result.IndexOf ("<p>default</p>") != -1, "#2:" + result);
		Assert.IsTrue (File.Exists (Path.Combine (baseDir, "Default.executed")), "#3");
		Assert.IsTrue (result.IndexOf ("<p>other</p>") != -1, "#4:" + result);
#if NET_2_0
		Assert.IsTrue (File.Exists (Path.Combine (baseDir, "Other.executed")), "#5");
#else
		Assert.IsFalse (File.Exists (Path.Combine (baseDir, "Other.executed")), "#5");
#endif

		return 0;
	}
}
