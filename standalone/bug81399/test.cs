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

		h.Execute ("ValidPageClass.aspx", sw);
		string result = sw.ToString ();
		if (result.IndexOf ("<p>OK-ValidPageClass</p>") == -1) {
			Console.WriteLine (result);
			return 1;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("ValidPageClassNs.aspx", sw);
		result = sw.ToString ();
#if NET_2_0
		if (result.IndexOf ("<p>OK-ValidPageClassNs</p>") == -1) {
			Console.WriteLine (result);
			return 2;
		}
#else
		if (result.IndexOf ("'Mono.Web.UI.ValidPage' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 2;
		}
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("ValidControlClass.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("_Label1\">OK-ValidControlClass</span>") == -1) {
			Console.WriteLine (result);
			return 3;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("ValidControlClassNs.aspx", sw);
		result = sw.ToString ();
#if NET_2_0
		if (result.IndexOf ("_Label1\">OK-ValidControlClassNs</span>") == -1) {
			Console.WriteLine (result);
			return 4;
		}
#else
		if (result.IndexOf ("'Mono.Web.UI.ValidControl' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 4;
		}
#endif

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("InvalidPageClass.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("'@InvalidPage' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 5;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("InvalidPageClassNs.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("'Mono.Web.@UI.InvalidPage' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 6;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("InvalidControlClass.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("'@InvalidControl' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 7;
		}

		sw.GetStringBuilder ().Length = 0;
		h = CreateHost ();
		h.Execute ("InvalidControlClassNs.aspx", sw);
		result = sw.ToString ();
		if (result.IndexOf ("'Mono.Web.@UI.InvalidControl' is not a valid value for attribute 'classname'.") == -1) {
			Console.WriteLine (result);
			return 8;
		}

		return 0;
	}
}
