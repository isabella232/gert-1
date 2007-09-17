using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;

using Mono.Tests;

[assembly: NeutralResourcesLanguageAttribute ("nl-NL")]

class Program
{
	static void Main ()
	{
		ComponentResourceManager crm = new ComponentResourceManager (
			typeof (MyComponent));

		Thread.CurrentThread.CurrentUICulture = new CultureInfo ("en-GB");
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");

		MyComponent comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, "$this", CultureInfo.InvariantCulture);

		Assert.IsNotNull (comp.BackgroundImage, "#A1");
		Assert.IsNotNull (comp.Company, "#A2");
		Assert.AreEqual ("OSF", comp.Company, "#A3");
		Assert.AreEqual (0, comp.Interval, "#A4");
		Assert.IsTrue (comp.Localizable, "#A5");
		Assert.IsNull (comp.Name, "#A6");
		Assert.IsNotNull (comp.Text, "#A7");
		Assert.AreEqual ("Mono", comp.Text, "#A8");
		Assert.IsNotNull (comp.Title, "#A9");
		Assert.AreEqual ("Welcome", comp.Title, "#A10");
#if NET_2_0
		Assert.IsNull (comp.Zone, "#A11");
#else
		Assert.IsNotNull (comp.Zone, "#A11");
		Assert.AreEqual (string.Empty, comp.Zone, "#A12");
#endif

		comp = new MyComponent ("Welcome", "System");
		crm.IgnoreCase = true;
		crm.ApplyResources (comp, "$this", CultureInfo.InvariantCulture);

		Assert.IsNotNull (comp.BackgroundImage, "#B1");
		Assert.IsNotNull (comp.Company, "#B2");
		Assert.AreEqual ("OSF", comp.Company, "#B3");
		Assert.AreEqual (0, comp.Interval, "#B4");
		Assert.IsTrue (comp.Localizable, "#B5");
		Assert.IsNotNull (comp.Name, "#B6");
		Assert.AreEqual ("Mono Component", comp.Name, "#B7");
		Assert.IsNotNull (comp.Text, "#B8");
		Assert.AreEqual ("Mono", comp.Text, "#B9");
		Assert.IsNotNull (comp.Title, "#B10");
		Assert.AreEqual ("Welcome", comp.Title, "#B11");
#if NET_2_0
		Assert.IsNull (comp.Zone, "#B12");
#else
		Assert.IsNotNull (comp.Zone, "#B12");
		Assert.AreEqual (string.Empty, comp.Zone, "#B13");
#endif

		comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, string.Empty, CultureInfo.InvariantCulture);
		Assert.IsNull (comp.Name, "#C");

		comp = new MyComponent ("Welcome", "System");
		crm.IgnoreCase = false;
		crm.ApplyResources (comp, "$this", new CultureInfo ("nl-BE"));

		Assert.IsNotNull (comp.BackgroundImage, "#D1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#D2");
#else
		Assert.IsNotNull (comp.Company, "#D2");
		Assert.AreEqual ("Company (NL-BE)", comp.Company, "#D3");
#endif
		Assert.AreEqual (0, comp.Interval, "#D4");
		Assert.IsTrue (comp.Localizable, "#D5");
		Assert.IsNull (comp.Name, "#D6");
		Assert.IsNotNull (comp.Text, "#D7");
		Assert.AreEqual ("Mono", comp.Text, "#D8");
		Assert.IsNotNull (comp.Title, "#D9");
		Assert.AreEqual ("Welcome", comp.Title, "#D10");
		Assert.IsNotNull (comp.Zone, "#D11");
		Assert.AreEqual ("Zone (NL-BE)", comp.Zone, "#D12");

		comp = new MyComponent ("Welcome", "System");
		crm.IgnoreCase = false;
		crm.ApplyResources (comp, "$this", new CultureInfo ("nl-NL"));

		Assert.IsNotNull (comp.BackgroundImage, "#E1");
		Assert.IsNotNull (comp.Company, "#E2");
		Assert.AreEqual ("OSF", comp.Company, "#E3");
		Assert.AreEqual (0, comp.Interval, "#E4");
		Assert.IsTrue (comp.Localizable, "#E5");
		Assert.IsNull (comp.Name, "#E6");
		Assert.IsNotNull (comp.Text, "#E7");
		Assert.AreEqual ("Mono", comp.Text, "#E8");
		Assert.IsNotNull (comp.Title, "#E9");
		Assert.AreEqual ("Welcome", comp.Title, "#E10");
#if NET_2_0
		Assert.IsNull (comp.Zone, "#E11");
#else
		Assert.IsNotNull (comp.Zone, "#E11");
		Assert.AreEqual (string.Empty, comp.Zone, "#E12");
#endif

		comp = new MyComponent ("Welcome", "System");
		crm.IgnoreCase = true;
		crm.ApplyResources (comp, "$this", new CultureInfo ("fr-FR"));

		Assert.IsNotNull (comp.BackgroundImage, "#F1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#F2");
#else
		Assert.IsNotNull (comp.Company, "#F2");
		Assert.AreEqual ("Company (fr-FR)", comp.Company, "#F3");
#endif
		Assert.AreEqual (0, comp.Interval, "#F4");
		Assert.IsTrue (comp.Localizable, "#F5");
		Assert.IsNotNull (comp.Name, "#F6");
		Assert.AreEqual ("Component (fr-FR)", comp.Name, "#F7");
		Assert.IsNotNull (comp.Text, "#F8");
		Assert.AreEqual ("Mono", comp.Text, "#F9");
		Assert.IsNotNull (comp.Title, "#F10");
		Assert.AreEqual ("Welcome", comp.Title, "#F11");
		Assert.IsNotNull (comp.Zone, "#F12");
		Assert.AreEqual ("Zone (fr)", comp.Zone, "#F13");

		comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, "$this", null);

		Assert.IsNotNull (comp.BackgroundImage, "#G1");
		Assert.IsNotNull (comp.Company, "#G2");
		Assert.AreEqual ("Company (en-GB)", comp.Company, "#G3");
		Assert.AreEqual (0, comp.Interval, "#G4");
		Assert.IsTrue (comp.Localizable, "#G5");
		Assert.IsNotNull (comp.Name, "#G6");
		Assert.AreEqual ("Component (en-GB)", comp.Name, "#G7");
		Assert.IsNotNull (comp.Text, "#G8");
		Assert.AreEqual ("Mono", comp.Text, "#G9");
		Assert.IsNotNull (comp.Title, "#G10");
		Assert.AreEqual ("Welcome", comp.Title, "#G11");
		Assert.IsNotNull (comp.Zone, "#G12");
		Assert.AreEqual ("Zone (en-GB)", comp.Zone, "#G13");

		comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, "$this");

		Assert.IsNotNull (comp.BackgroundImage, "#H1");
		Assert.IsNotNull (comp.Company, "#H2");
		Assert.AreEqual ("Company (en-GB)", comp.Company, "#H3");
		Assert.AreEqual (0, comp.Interval, "#H4");
		Assert.IsTrue (comp.Localizable, "#H5");
		Assert.IsNotNull (comp.Name, "#H6");
		Assert.AreEqual ("Component (en-GB)", comp.Name, "#H7");
		Assert.IsNotNull (comp.Text, "#H8");
		Assert.AreEqual ("Mono", comp.Text, "#H9");
		Assert.IsNotNull (comp.Title, "#H10");
		Assert.AreEqual ("Welcome", comp.Title, "#H11");
		Assert.IsNotNull (comp.Zone, "#H12");
		Assert.AreEqual ("Zone (en-GB)", comp.Zone, "#H13");
	}
}
