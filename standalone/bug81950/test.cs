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
		if (RunningOnUnix)
			return 0;

		TinyHost h = CreateHost ("/");
		StringWriter sw = new StringWriter ();
		h.Execute ("Default.aspx", sw);
		string result = sw.ToString ();
		string expected = "/test/blah.txt||/test/blah.txt||/";
		if (result != expected) {
			Console.WriteLine (result);
			return 1;
		}

#if NET_2_0
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("subdir" + Path.DirectorySeparatorChar + "Default.aspx", sw);
		result = sw.ToString ();
		expected = "/test/blah.txt||/subdir/test/blah.txt||/subdir";
		if (result != expected) {
			Console.WriteLine (result);
			return 2;
		}
#endif

		h = CreateHost ("/sub");
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Default.aspx", sw);
		result = sw.ToString ();
		expected = "/sub/test/blah.txt||/sub/test/blah.txt||/sub";
		if (result != expected) {
			Console.WriteLine (result);
			return 3;
		}

#if NET_2_0
		sw.GetStringBuilder ().Length = 0;
		h.Execute ("subdir" + Path.DirectorySeparatorChar + "Default.aspx", sw);
		result = sw.ToString ();
		expected = "/sub/test/blah.txt||/sub/subdir/test/blah.txt||/sub/subdir";
		if (result != expected) {
			Console.WriteLine (result);
			return 4;
		}
#endif

		return 0;
	}

	static bool RunningOnUnix {
		get {
#if NET_2_0
			return Environment.OSVersion.Platform == PlatformID.Unix;
#else
			return (int) Environment.OSVersion.Platform == 128;
#endif
		}
	}
}
