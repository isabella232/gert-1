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
		// ensure the exception messages are not localized
		Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
		Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

		string result;

		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();

		h.Execute ("root.ashx", sw);
		result = sw.ToString ();
		Assert.IsTrue (result.IndexOf ("Hello from ROOT handler") != -1, "#A:" + result);

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("whatever", "root.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0
		Assert.IsTrue (result.IndexOf ("Hello from ROOT handler") != -1, "#B:" + result);
#else
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#B1:" + result);
		Assert.IsTrue (result.IndexOf (@"/whatever\root.ashx") != -1, "#B2:" + result);
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.DirectorySeparatorChar + Path.Combine ("doc", "index.html"), sw);
		result = sw.ToString ();
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#C1:" + result);
#if NET_2_0
		Assert.IsTrue (result.IndexOf ("/doc/index.html") != -1, "#C2:" + result);
#else
		Assert.IsTrue (result.IndexOf (@"/\doc\index.html") != -1, "#C2:" + result);
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "index.html"), sw);
		result = sw.ToString ();
#if NET_2_0
		Assert.AreEqual ("<html><head><title>index</title></head></html>", result, "#D");
#else
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#D1:" + result);
		Assert.IsTrue (result.IndexOf (@"/doc\index.html") != -1, "#D2:" + result);
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.DirectorySeparatorChar + Path.Combine ("doc", "root.ashx"), sw);
		result = sw.ToString ();
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#E1:" + result);
#if NET_2_0
		Assert.IsTrue (result.IndexOf ("/doc/root.ashx") != -1, "#E2:" + result);
#else
		Assert.IsTrue (result.IndexOf (@"/\doc\root.ashx") != -1, "#E2:" + result);
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "root.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0
		Assert.IsTrue (result.IndexOf ("Hello from ROOT handler") != -1, "#F:" + result);
#else
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#F1:" + result);
		Assert.IsTrue (result.IndexOf (@"/doc\root.ashx") != -1, "#F2:" + result);
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "subdir.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0
		Assert.IsTrue (result.IndexOf ("Hello from Subdir handler") != -1, "#G:" + result);
#else
		Assert.IsTrue (result.IndexOf ("The resource cannot be found.") != -1, "#G1:" + result);
		Assert.IsTrue (result.IndexOf (@"/doc\subdir.ashx") != -1, "#G2:" + result);
#endif

		return 0;
	}
}
