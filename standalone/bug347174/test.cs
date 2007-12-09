using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyVersion ("1.0.0.0")]
#if ONLY_1_1 && !MONO
[assembly: AssemblyKeyFile ("test.snk")]
#endif

class Program
{
	static void Main ()
	{
		Assembly a;
		CultureInfo culture;

		string dir = AppDomain.CurrentDomain.BaseDirectory;

		a = Assembly.LoadFrom (Path.Combine (dir, "Lang.dll"));
		culture = a.GetName ().CultureInfo;

		Assert.IsTrue (culture.IsNeutralCulture, "#A1");
		Assert.IsFalse (culture.IsReadOnly, "#A2");
		Assert.AreEqual (9, culture.LCID, "#A3");
		Assert.AreEqual ("en", culture.Name, "#A4");
		Assert.IsTrue (culture.UseUserOverride, "#A5");

		a = Assembly.GetExecutingAssembly ();
		culture = a.GetName ().CultureInfo;

		Assert.IsFalse (culture.IsNeutralCulture, "#B1");
#if NET_2_0
		Assert.IsFalse (culture.IsReadOnly, "#B2");
#else
		Assert.IsTrue (culture.IsReadOnly, "#B2");
#endif
		Assert.AreEqual (127, culture.LCID, "#B3");
		Assert.AreEqual (string.Empty, culture.Name, "#B4");
		Assert.IsFalse (culture.UseUserOverride, "#B5");

		a = typeof (int).Assembly;
		culture = a.GetName ().CultureInfo;

		Assert.IsFalse (culture.IsNeutralCulture, "#C1");
#if NET_2_0
		Assert.IsFalse (culture.IsReadOnly, "#C2");
#else
		Assert.IsTrue (culture.IsReadOnly, "#C2");
#endif
		Assert.AreEqual (127, culture.LCID, "#C3");
		Assert.AreEqual (string.Empty, culture.Name, "#C4");
		Assert.IsFalse (culture.UseUserOverride, "#C5");

		AssemblyName [] refs = Assembly.GetExecutingAssembly ().GetReferencedAssemblies ();
		foreach (AssemblyName aname in refs) {
			culture = aname.CultureInfo;
			Assert.IsFalse (culture.IsReadOnly, "#D1:" + aname.Name);
			if (aname.Name == "Locale") {
				Assert.IsTrue (culture.UseUserOverride, "#D2:" + aname.Name);
				Assert.IsTrue (culture.IsNeutralCulture, "#D3");
				Assert.AreEqual (19, culture.LCID, "#D4");
				Assert.AreEqual ("nl", culture.Name, "#D5");
			} else {
#if NET_2_0
				Assert.IsFalse (culture.UseUserOverride, "#D2:" + aname.Name);
#else
				Assert.IsTrue (culture.UseUserOverride, "#D2:" + aname.Name);
#endif
				Assert.IsFalse (culture.IsNeutralCulture, "#D3");
				Assert.AreEqual (127, culture.LCID, "#D4");
				Assert.AreEqual (string.Empty, culture.Name, "#D5");
			}
		}

		a = typeof (NonLocale).Assembly;
		culture = a.GetName ().CultureInfo;

		Assert.IsFalse (culture.IsNeutralCulture, "#E1");
#if NET_2_0
		Assert.IsFalse (culture.IsReadOnly, "#E2");
#else
		Assert.IsTrue (culture.IsReadOnly, "#E2");
#endif
		Assert.AreEqual (127, culture.LCID, "#E3");
		Assert.AreEqual (string.Empty, culture.Name, "#E4");
		Assert.IsFalse (culture.UseUserOverride, "#E5");

		a = Assembly.LoadFrom (Path.Combine (dir, "NonSigned.dll"));
		culture = a.GetName ().CultureInfo;

		Assert.IsFalse (culture.IsNeutralCulture, "#F1");
#if NET_2_0
		Assert.IsFalse (culture.IsReadOnly, "#F2");
#else
		Assert.IsTrue (culture.IsReadOnly, "#F2");
#endif
		Assert.AreEqual (127, culture.LCID, "#F3");
		Assert.AreEqual (string.Empty, culture.Name, "#F4");
		Assert.IsFalse (culture.UseUserOverride, "#F5");

		a = typeof (Locale).Assembly;
		culture = a.GetName ().CultureInfo;

		Assert.IsTrue (culture.IsNeutralCulture, "#G1");
		Assert.IsFalse (culture.IsReadOnly, "#G2");
		Assert.AreEqual (19, culture.LCID, "#G3");
		Assert.AreEqual ("nl", culture.Name, "#G4");
		Assert.IsTrue (culture.UseUserOverride, "#G5");
	}
}
