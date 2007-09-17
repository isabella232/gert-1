using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;

using Mono.Tests;

[assembly: NeutralResourcesLanguageAttribute ("nl-NL")]

class Program
{
	static void Main ()
	{
		ComponentResourceManager crm = new ComponentResourceManager (
			typeof (MyComponent));

		MyComponent comp = new MyComponent ("Welcome", "System");

		try {
			crm.ApplyResources (comp, "$this", CultureInfo.InvariantCulture);
			Assert.Fail ("#A1");
		} catch (MissingManifestResourceException ex) {
			// Could not find any resources appropriate for the
			// specified culture or the neutral culture.  Make sure
			// "Mono.Tests.MyComponent.resources" was correctly
			// embedded or linked into assembly "test2" at compile
			// time, or that all the satellite assemblies required
			// are loadable and fully signed
			Assert.AreEqual (typeof (MissingManifestResourceException), ex.GetType (), "#A2");
			Assert.IsNull (ex.InnerException, "#A3");
			Assert.IsNotNull (ex.Message, "#A4");
#if NET_2_0
			Assert.IsTrue (ex.Message.IndexOf ("\"Mono.Tests.MyComponent.resources\"") != -1, "#A5");
#else
			Assert.IsTrue (ex.Message.IndexOf ("MyComponent.resources") != -1, "#A5");
#endif
			Assert.IsTrue (ex.Message.IndexOf ("\"test2\"") != -1, "#A6");
		}

		comp = new MyComponent ("Welcome", "System");
		crm.IgnoreCase = false;

		try {
			crm.ApplyResources (comp, "$this", new CultureInfo ("nl-BE"));
			Assert.Fail ("#B1");
		} catch (MissingManifestResourceException ex) {
			// Could not find any resources appropriate for the
			// specified culture or the neutral culture.  Make sure
			// "Mono.Tests.MyComponent.resources" was correctly
			// embedded or linked into assembly "test2" at compile
			// time, or that all the satellite assemblies required
			// are loadable and fully signed
			Assert.AreEqual (typeof (MissingManifestResourceException), ex.GetType (), "#B2");
			Assert.IsNull (ex.InnerException, "#B3");
			Assert.IsNotNull (ex.Message, "#B4");
#if NET_2_0
			Assert.IsTrue (ex.Message.IndexOf ("\"Mono.Tests.MyComponent.resources\"") != -1, "#B5");
#else
			Assert.IsTrue (ex.Message.IndexOf ("MyComponent.resources") != -1, "#B5");
#endif
			Assert.IsTrue (ex.Message.IndexOf ("\"test2\"") != -1, "#B6");
		}
	}
}
