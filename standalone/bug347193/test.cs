using System;
using System.IO;
using System.Reflection;

class Program
{
	static void Main ()
	{
		Assembly a = typeof (Lang).Assembly;
		string dir = Path.Combine (AppDomain.CurrentDomain.BaseDirectory,
			"en-US");
		string expected = Path.Combine (dir, "Lang.dll");
		string actual = a.Location;
		int result = string.Compare (expected, actual, true);
		Assert.AreEqual (0, result, "#1:" + actual);
	}
}
