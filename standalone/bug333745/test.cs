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

		if (result.IndexOf ("|Total providers|2|Total providers|") == - 1) {
			Console.WriteLine (result);
			return 1;
		}

		if (result.IndexOf ("|Default provider|DummyProvider|Default provider|") == -1) {
			Console.WriteLine (result);
			return 2;
		}

		int index1 = result.IndexOf ("|Provider|AspNetSqlMembershipProvider|Provider|");
		if (index1 == -1) {
			Console.WriteLine (result);
			return 3;
		}

		int index2 = result.IndexOf ("|Provider|DummyProvider|Provider|");
		if (index2 == -1 || index2 <= index1) {
			Console.WriteLine (result);
			return 4;
		}

		if (result.IndexOf ("|Config Total providers|2|Config Total providers|") == -1) {
			Console.WriteLine (result);
			return 5;
		}

		if (result.IndexOf ("|Config Default provider|DummyProvider|Config Default provider|") == -1) {
			Console.WriteLine (result);
			return 6;
		}

		index1 = result.IndexOf ("|Config Provider|AspNetSqlMembershipProvider|Config Provider|");
		if (index1 == -1) {
			Console.WriteLine (result);
			return 7;
		}

		index2 = result.IndexOf ("|Config Provider|DummyProvider|Config Provider|");
		if (index2 == -1) {
			Console.WriteLine (result);
			return 8;
		}

		return 0;
	}
}
