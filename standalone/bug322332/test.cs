using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

[module: Category ("ModTest")]

class Program
{
	static void Main ()
	{
		Assembly a = Assembly.GetExecutingAssembly ();
		object [] attrs;

		AssemblyFileVersionAttribute fv = (AssemblyFileVersionAttribute)
			Attribute.GetCustomAttribute (a,
			typeof (AssemblyFileVersionAttribute));
		Assert.IsNotNull (fv, "#A1");
		Assert.AreEqual ("2.0", fv.Version, "#A2");

		AssemblyTitleAttribute tl = (AssemblyTitleAttribute)
			Attribute.GetCustomAttribute (a,
			typeof (AssemblyTitleAttribute));
		Assert.IsNotNull (tl, "#B1");
		Assert.AreEqual ("bug 322332", tl.Title, "#B2");

		Type type;

#if NET_2_0
		if (!IsMono) {
			// https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=351042
			type = a.GetType ("Bar");
			Assert.IsNotNull (type, "#C1");
			Assert.AreEqual ("Bar", type.FullName, "#C2");
		} else {
			type = a.GetType ("Foo+Bar");
			Assert.IsNotNull (type, "#C1");
			Assert.AreEqual ("Foo+Bar", type.FullName, "#C2");
		}
#else
		type = a.GetType ("Foo+Bar");
		Assert.IsNotNull (type, "#C1");
		Assert.AreEqual ("Foo+Bar", type.FullName, "#C2");
#endif

		type = a.GetType ("Bar+Foo");
		Assert.IsNotNull (type, "#D1");
		Assert.AreEqual ("Bar+Foo", type.FullName, "#D2");

		type = a.GetType ("Foo");
		Assert.IsNotNull (type, "#E1");
		Assert.AreEqual ("Foo", type.FullName, "#E2");

		type = a.GetType ("Bar");
		Assert.IsNotNull (type, "#F1");
		Assert.AreEqual ("Bar", type.FullName, "#F2");

		Module [] mods = a.GetModules (false);
		Assert.AreEqual (3, mods.Length, "#G");

		foreach (Module mod in mods) {
			CategoryAttribute cat = (CategoryAttribute) Attribute.
				GetCustomAttribute (mod, typeof (CategoryAttribute));
			Assert.IsNotNull (cat, "#H1:" + mod.Name);

			switch (mod.Name.ToLower (CultureInfo.InvariantCulture)) {
			case "bar.netmodule":
				Assert.AreEqual ("ModB", cat.Category, "#H2:" + mod.Name);
				attrs = mod.GetCustomAttributes (true);
				Assert.AreEqual (1, attrs.Length, "#H3:" + mod.Name);
				cat = attrs [0] as CategoryAttribute;
				Assert.IsNotNull (cat, "#H4:" + mod.Name);
				Assert.AreEqual ("ModB", cat.Category, "#H5:" + mod.Name);
				break;
			case "foo.netmodule":
				Assert.AreEqual ("ModA", cat.Category, "#H2:" + mod.Name);
				attrs = mod.GetCustomAttributes (true);
				Assert.AreEqual (1, attrs.Length, "#H3:" + mod.Name);
				cat = attrs [0] as CategoryAttribute;
				Assert.IsNotNull (cat, "#H4:" + mod.Name);
				Assert.AreEqual ("ModA", cat.Category, "#H5:" + mod.Name);
				break;
			case "test.exe":
				Assert.AreEqual ("ModTest", cat.Category, "#H2:" + mod.Name);
				attrs = mod.GetCustomAttributes (true);
				Assert.AreEqual (1, attrs.Length, "#H3:" + mod.Name);
				cat = attrs [0] as CategoryAttribute;
				Assert.IsNotNull (cat, "#H4:" + mod.Name);
				Assert.AreEqual ("ModTest", cat.Category, "#H5:" + mod.Name);
				break;
			default:
				Assert.Fail ("Unexpected module '" + mod.Name + "'.");
				break;
			}
		}
	}

#if NET_2_0
	static bool IsMono {
		get {
			return (Type.GetType ("System.MonoType", false) != null);
		}
	}
#endif
}
