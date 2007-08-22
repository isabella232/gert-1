using System;
using System.Globalization;
using System.IO;
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
		string result = null;

		result = ExecuteRequest ("Web1.config", "Index1.aspx");
		if (result != "<html></html>") {
			Console.WriteLine (result);
			return 1;
		}

		result = ExecuteRequest ("Web2.config", "Index1.aspx");
		if (result != "<html></html>") {
			Console.WriteLine (result);
			return 2;
		}

		result = ExecuteRequest ("Web3.config", "Index1.aspx");
		if (result != "<html></html>") {
			Console.WriteLine (result);
			return 3;
		}

		result = ExecuteRequest ("Web4.config", "Index1.aspx");
#if NET_2_0
		if (result.IndexOf ("ConfigurationErrorsException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#else
		if (result.IndexOf ("ConfigurationException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#endif
			Console.WriteLine (result);
			return 4;
		}

		result = ExecuteRequest ("Web1.config", "Index2.aspx");
		if (result.IndexOf ("Parser Error") == -1 || result.IndexOf ("enableSessionState") == -1) {
			Console.WriteLine (result);
			return 5;
		}

		result = ExecuteRequest ("Web2.config", "Index2.aspx");
		if (result.IndexOf ("Parser Error") == -1 || result.IndexOf ("enableSessionState") == -1) {
			Console.WriteLine (result);
			return 6;
		}

		result = ExecuteRequest ("Web3.config", "Index2.aspx");
		if (result.IndexOf ("Parser Error") == -1 || result.IndexOf ("enableSessionState") == -1) {
			Console.WriteLine (result);
			return 7;
		}

		result = ExecuteRequest ("Web4.config", "Index2.aspx");
#if NET_2_0
		if (result.IndexOf ("ConfigurationErrorsException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#else
		if (result.IndexOf ("ConfigurationException") == -1 || result.IndexOf ("enableSessionState") == -1) {
#endif
			Console.WriteLine (result);
			return 8;
		}

		return 0;
	}

	static string ExecuteRequest (string config, string page)
	{
		File.Copy (Path.Combine (AppDomain.CurrentDomain.BaseDirectory, config),
			_webConfig, true);

		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();
		h.Execute (page, sw);
		return sw.ToString ();
	}

	static string _webConfig = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
		"Web.config");

}
