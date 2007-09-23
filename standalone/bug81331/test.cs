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
		string result;

		TinyHost h = CreateHost ();
		StringWriter sw = new StringWriter ();

		h.Execute ("root.ashx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("Hello from ROOT handler") == -1) {
			Console.WriteLine (result);
			return 1;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("whatever", "root.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0 || MONO
		if (result.IndexOf ("Hello from ROOT handler") == -1) {
			Console.WriteLine (result);
			return 2;
		}
#else
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 2;
		}
		if (result.IndexOf (@"/whatever\root.ashx") == -1) {
			Console.WriteLine (result);
			return 2;
		}
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.DirectorySeparatorChar + Path.Combine ("doc", "index.html"), sw);
		result = sw.ToString ();
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 3;
		}
#if NET_2_0 || MONO
		if (result.IndexOf ("/doc/index.html") == -1) {
#else
		if (result.IndexOf (@"/\doc\index.html") == -1) {
#endif
			Console.WriteLine (result);
			return 3;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "index.html"), sw);
		result = sw.ToString ();
#if NET_2_0 || MONO
		if (result != "<html><head><title>index</title></head></html>") {
			Console.WriteLine (result);
			return 4;
		}
#else
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 4;
		}
		if (result.IndexOf (@"/doc\index.html") == -1) {
			Console.WriteLine (result);
			return 4;
		}
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.DirectorySeparatorChar + Path.Combine ("doc", "root.ashx"), sw);
		result = sw.ToString ();
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 5;
		}
#if NET_2_0 || MONO
		if (result.IndexOf ("/doc/root.ashx") == -1) {
#else
		if (result.IndexOf (@"/\doc\root.ashx") == -1) {
#endif
			Console.WriteLine (result);
			return 5;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "root.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0 || MONO
		if (result.IndexOf ("Hello from ROOT handler") == -1) {
			Console.WriteLine (result);
			return 6;
		}
#else
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 6;
		}
		if (result.IndexOf (@"/doc\root.ashx") == -1) {
			Console.WriteLine (result);
			return 6;
		}
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute (Path.Combine ("doc", "subdir.ashx"), sw);
		result = sw.ToString ();
#if NET_2_0
		if (result.IndexOf ("Hello from Subdir handler") == -1) {
			Console.WriteLine (result);
			return 7;
		}
#else
		if (result.IndexOf ("The resource cannot be found.") == -1) {
			Console.WriteLine (result);
			return 7;
		}
		if (result.IndexOf (@"/doc\subdir.ashx") == -1) {
			Console.WriteLine (result);
			return 7;
		}
#endif

		return 0;
	}
}
