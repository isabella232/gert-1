using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;

using Mono.Tests;

class Program
{
	static void Main ()
	{
		ComponentResourceManager crm = new ComponentResourceManager (
			typeof (MyComponent));

		MyComponent comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, "$this", new CultureInfo ("nl-BE"));

		Assert.IsNotNull (comp.BackgroundImage, "#A1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#A2");
#else
		Assert.IsNotNull (comp.Company, "#A2");
		Assert.AreEqual ("Company (NL-BE)", comp.Company, "#A3");
#endif
		Assert.AreEqual (0, comp.Interval, "#A4");
		Assert.IsTrue (comp.Localizable, "#A5");
		Assert.IsNull (comp.Name, "#A6");
		Assert.IsNotNull (comp.Text, "#A8");	
		Assert.AreEqual ("Mono", comp.Text, "#A9");
		Assert.IsNotNull (comp.Title, "#A10");
		Assert.AreEqual ("Welcome", comp.Title, "#A11");
		Assert.IsNotNull (comp.Zone, "#A12");
		Assert.AreEqual ("Zone (NL-BE)", comp.Zone, "#A13");

		comp = new MyComponent ("Welcome", "System");
		crm = new ComponentResourceManager (typeof (MyComponent));
		crm.ApplyResources (comp, "$this", new CultureInfo ("ja-JP"));

		Assert.IsNotNull (comp.BackgroundImage, "#B1");
		Assert.IsNotNull (comp.Company, "#B2");
		Assert.AreEqual ("OSF", comp.Company, "#B3");
		Assert.AreEqual (0, comp.Interval, "#B4");
		Assert.IsTrue (comp.Localizable, "#B5");
		Assert.IsNull (comp.Name, "#B6");
		Assert.IsNotNull (comp.Text, "#B7");
		Assert.AreEqual ("Mono", comp.Text, "#B8");
		Assert.IsNotNull (comp.Title, "#B9");
		Assert.AreEqual ("Welcome", comp.Title, "#B10");
#if NET_2_0
		Assert.IsNull (comp.Zone, "#B11");
#else
		Assert.IsNotNull (comp.Zone, "#B11");
		Assert.AreEqual (string.Empty, comp.Zone, "#B12");
#endif
	}
}
