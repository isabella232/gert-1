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
		h.Execute ("Default20.aspx", sw);
#else
		h.Execute ("Default11.aspx", sw);
#endif
		string result = sw.ToString ();

#if NET_2_0
		if (result.IndexOf ("1Mono!Test11") == -1) {
#else
		if (result.IndexOf ("1Mono.Web.Config.TestConfiguration1") == -1) {
#endif
			Console.WriteLine (result);
			return 1;
		}

#if NET_2_0
		if (result.IndexOf ("2Mono.Web.Config.TestConfiguration2") == -1) {
#else
		if (result.IndexOf ("2Mono.Web.Config.TestConfiguration2") == -1) {
#endif
			Console.WriteLine (result);
			return 2;
		}

#if NET_2_0
		if (result.IndexOf ("3Mono.Web.Config.TestConfigurationSection3") == -1) {
			Console.WriteLine (result);
			return 3;
		}
#endif

		return 0;
	}
}
