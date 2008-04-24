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

		Assert.IsFalse (result.IndexOf (">About<") != -1, "#A1:" + result);
		Assert.IsFalse (result.IndexOf ("title=\"OmschrijvingAbout!\"") != -1, "#A2:" + result);
		Assert.IsFalse (result.IndexOf (">Tester<") != -1, "#A3:" + result);
		Assert.IsFalse (result.IndexOf ("title=\"OmschrijvingTester!\"") != -1, "#A4:" + result);
		Assert.IsFalse (result.IndexOf (">Titel!Admins<") != -1, "#A5:" + result);
		Assert.IsFalse (result.IndexOf ("title=\"Omschrijving!Admins\"") != -1, "#A6:" + result);
		Assert.IsFalse (result.IndexOf (">Admins<") != -1, "#A7:" + result);
		Assert.IsFalse (result.IndexOf (">Auth Users Only<") != -1, "#A8:" + result);
		Assert.IsFalse (result.IndexOf ("Error") != -1, "#A9:" + result);

		sw.GetStringBuilder ().Length = 0;
		h.Execute ("Index.aspx", sw);
		result = sw.ToString ();

		Assert.IsTrue (result.IndexOf (">About<") != -1, "#B1:" + result);
		Assert.IsTrue (result.IndexOf ("title=\"OmschrijvingAbout!\"") != -1, "#B2:" + result);
		Assert.IsTrue (result.IndexOf (">Tester<") != -1, "#B3:" + result);
		Assert.IsTrue (result.IndexOf ("title=\"OmschrijvingTester!\"") != -1, "#B4:" + result);
		Assert.IsFalse (result.IndexOf (">Titel!Admins<") != -1, "#B5:" + result);
		Assert.IsFalse (result.IndexOf ("title=\"Omschrijving!Admins\"") != -1, "#B6:" + result);
		Assert.IsTrue (result.IndexOf (">Admins<") != -1, "#B7:" + result);
		Assert.IsTrue (result.IndexOf (">Auth Users Only<") != -1, "#B8:" + result);
		Assert.IsFalse (result.IndexOf ("Error") != -1, "#B9:" + result);

		return 0;
	}
}
