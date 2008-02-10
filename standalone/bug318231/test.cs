using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		string dir = AppDomain.CurrentDomain.BaseDirectory;

		Assembly a = Assembly.LoadFrom (Path.Combine (dir, "lib.dll"));
		Assert.AreEqual ("lib, Version=0.0.0.0, Culture=doesnot-exist, PublicKeyToken=null", a.FullName, "#A1");
		Assert.AreEqual ("lib, Version=0.0.0.0, Culture=doesnot-exist, PublicKeyToken=null", a.ToString (), "#A2");

		try {
			a.GetName ();
			Assert.Fail ("#B1");
		} catch (ArgumentException ex) {
			Assert.AreEqual (typeof (ArgumentException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
			Assert.IsTrue (ex.Message.IndexOf ("doesnot-exist") != -1, "#B5");
			Assert.AreEqual ("name", ex.ParamName, "#B6");
		}
	}
}
