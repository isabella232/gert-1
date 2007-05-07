using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
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
		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute ("Index.aspx", sw);
		string result = sw.ToString ();
#if NET_2_0
		if (result.IndexOf ("ConfigurationErrorsException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#else
		if (result.IndexOf ("ConfigurationException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#endif
			Console.WriteLine (result);
			return 1;
		}

		return 0;
	}
}
