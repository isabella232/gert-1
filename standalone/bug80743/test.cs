using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost ()
	{
		string path = AppDomain.CurrentDomain.BaseDirectory;
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
		for (int i = 0; i < 20; i++) {
			TinyHost h = CreateHost ();
			File.SetLastWriteTime (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "global.asax"),
				DateTime.Now);
			StringWriter sw = new StringWriter ();
			h.Execute ("index.aspx", sw);
		}
		return 0;
	}
}
