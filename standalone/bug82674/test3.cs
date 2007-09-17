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
		crm.IgnoreCase = true;
		crm.ApplyResources (comp, "$this", new CultureInfo ("nl-BE"));

		Assert.IsNotNull (comp.BackgroundImage, "#A1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#A2");
#else
		Assert.IsNotNull (comp.Company, "#A2");
		Assert.AreEqual ("Company (NL-NL)", comp.Company, "#A3");
#endif
		Assert.AreEqual (0, comp.Interval, "#A4");
		Assert.IsTrue (comp.Localizable, "#A5");
		Assert.IsNotNull (comp.Name, "#A6");
		Assert.AreEqual ("Component (NL-NL)", comp.Name, "#A7");
		Assert.IsNotNull (comp.Text, "#A8");
		Assert.AreEqual ("Mono", comp.Text, "#A9");
		Assert.IsNotNull (comp.Title, "#A10");
		Assert.AreEqual ("Welcome", comp.Title, "#A11");
		Assert.IsNotNull (comp.Zone, "#A12");
		Assert.AreEqual ("Zone (NL-NL)", comp.Zone, "#A13");

		comp = new OURComponent ("Welcome", "System");
		crm = new ComponentResourceManager (typeof (OURComponent));
		crm.ApplyResources (comp, "$this", new CultureInfo ("nl-BE"));

		Assert.IsNotNull (comp.BackgroundImage, "#B1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#B2");
#else
		Assert.IsNotNull (comp.Company, "#B2");
		Assert.AreEqual ("Company (nl-BE)", comp.Company, "#B3");
#endif
		Assert.AreEqual (0, comp.Interval, "#B4");
		Assert.IsTrue (comp.Localizable, "#B5");
		Assert.IsNull (comp.Name, "#B6");
		Assert.IsNotNull (comp.Text, "#B7");
		Assert.AreEqual ("Mono", comp.Text, "#B8");
		Assert.IsNotNull (comp.Title, "#B9");
		Assert.AreEqual ("Welcome", comp.Title, "#B10");
		Assert.IsNotNull (comp.Zone, "#B11");
		Assert.AreEqual ("Zone (nl-BE)", comp.Zone, "#B12");

		comp = new OURComponent ("Welcome", "System");
		crm = new ComponentResourceManager (typeof (OURComponent));
		crm.ApplyResources (comp, "$this", CultureInfo.InvariantCulture);

		Assert.IsNotNull (comp.BackgroundImage, "#C1");
		Assert.IsNotNull (comp.Company, "#C2");
		Assert.AreEqual ("OSF", comp.Company, "#C3");
		Assert.AreEqual (0, comp.Interval, "#C4");
		Assert.IsTrue (comp.Localizable, "#C5");
		Assert.IsNull (comp.Name, "#C6");
		Assert.IsNotNull (comp.Text, "#C7");
		Assert.AreEqual ("Mono", comp.Text, "#C8");
		Assert.IsNotNull (comp.Title, "#C9");
		Assert.AreEqual ("Welcome", comp.Title, "#C10");
#if NET_2_0
		Assert.IsNull (comp.Zone, "#C11");
#else
		Assert.IsNotNull (comp.Zone, "#C11");
		Assert.AreEqual (string.Empty, comp.Zone, "#C12");
#endif

		ResourceManager rm = new ResourceManager ("MonO.TestS.MYcomPonenT",
			Assembly.GetExecutingAssembly ());
		Assert.IsNotNull (rm.GetString ("$this.Company", new CultureInfo ("fr-FR")), "#D1");
#if NET_2_0
		Assert.AreEqual ("OSF", rm.GetString ("$this.Company", new CultureInfo ("fr-FR")), "#D2");
#else
		Assert.AreEqual ("Company (fr-FR)", rm.GetString ("$this.Company", new CultureInfo ("fr-FR")), "#D2");
#endif

		rm = new ResourceManager ("MonO.TestS.MYcomPonenT",
			Assembly.GetExecutingAssembly ());
		Assert.IsNotNull (rm.GetString ("$this.Company", CultureInfo.InvariantCulture), "#E1");
		Assert.AreEqual ("OSF", rm.GetString ("$this.Company", CultureInfo.InvariantCulture), "#E2");

		rm = new ResourceManager ("OurcomPonenT", Assembly.GetExecutingAssembly ());
		Assert.IsNotNull (rm.GetString ("$this.Company", new CultureInfo ("nl-BE")), "#F1");
#if NET_2_0
		Assert.AreEqual ("OSF", rm.GetString ("$this.Company", new CultureInfo ("nl-BE")), "#F2");
#else
		Assert.AreEqual ("Company (nl-BE)", rm.GetString ("$this.Company", new CultureInfo ("nl-BE")), "#F2");
#endif

		rm = new ResourceManager ("OurcomPonenT", Assembly.GetExecutingAssembly ());
		Assert.IsNotNull (rm.GetString ("$this.Company", CultureInfo.InvariantCulture), "#G1");
		Assert.AreEqual ("OSF", rm.GetString ("$this.Company", CultureInfo.InvariantCulture), "#G2");
	}
}

class OURComponent : MyComponent
{
	public OURComponent (string title, string zone)
		: base (title, zone)
	{
	}
}
