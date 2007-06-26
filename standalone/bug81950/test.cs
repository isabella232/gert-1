using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Hosting;

class TinyHost : MarshalByRefObject
{
	static TinyHost CreateHost (string virtualDir)
	{
		string path = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, "web");
		string bin = Path.Combine (path, "bin");
		string asm = Path.GetFileName (typeof (TinyHost).Assembly.Location);

		Directory.CreateDirectory (bin);
		File.Copy (asm, Path.Combine (bin, asm), true);

		return (TinyHost) ApplicationHost.CreateApplicationHost (
			typeof (TinyHost), virtualDir, path);
	}

	public void Execute (string page, TextWriter tw)
	{
		SimpleWorkerRequest req = new SimpleWorkerRequest (
			page, "", tw);
		HttpRuntime.ProcessRequest (req);
	}

	static int Main ()
	{
		TinyHost h = CreateHost ("/");
		StringWriter sw = new StringWriter ();
		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		string expected = string.Format (CultureInfo.InvariantCulture,
			"/test/blah.txt{0}/test/blah.txt{0}/", Environment.NewLine);
		if (result != expected) {
			Console.WriteLine (result);
			//return 1;
		}

#if NET_2_0
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("subdir" + Path.DirectorySeparatorChar + "Default.aspx", sw);
		result = sw.ToString ();
		expected = string.Format (CultureInfo.InvariantCulture,
			"/test/blah.txt{0}/subdir/test/blah.txt{0}/subdir", Environment.NewLine);
		if (result != expected) {
			Console.WriteLine (result);
			return 2;
		}
#endif

		h = CreateHost ("/sub");
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Default.aspx", sw);
		result = sw.ToString ();
		expected = string.Format (CultureInfo.InvariantCulture,
			"/sub/test/blah.txt{0}/sub/test/blah.txt{0}/sub", Environment.NewLine);
		if (result != expected) {
			Console.WriteLine (result);
			return 3;
		}

#if NET_2_0
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("subdir" + Path.DirectorySeparatorChar + "Default.aspx", sw);
		result = sw.ToString ();
		expected = string.Format (CultureInfo.InvariantCulture,
			"/sub/test/blah.txt{0}/sub/subdir/test/blah.txt{0}/sub/subdir", Environment.NewLine);
		if (result != expected) {
			Console.WriteLine (result);
			return 4;
		}
#endif

		return 0;
	}
}
