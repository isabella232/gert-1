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
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("ja-JP");

		MyComponent comp = new MyComponent ("Welcome", "System");
		crm.ApplyResources (comp, "$this", new CultureInfo ("fr-FR"));

		Assert.IsNotNull (comp.BackgroundImage, "#1");
#if NET_2_0
		Assert.IsNull (comp.Company, "#2");
#else
		Assert.IsNotNull (comp.Company, "#2");
		Assert.AreEqual ("Company (fr-FR)", comp.Company, "#3");
#endif
		Assert.AreEqual (0, comp.Interval, "#4");
		Assert.IsTrue (comp.Localizable, "#5");
		Assert.IsNotNull (comp.Name, "#6");
		Assert.AreEqual ("Component (fr)", comp.Name, "#7");
		Assert.IsNotNull (comp.Text, "#8");
		Assert.AreEqual ("Mono", comp.Text, "#9");
		Assert.IsNotNull (comp.Title, "#10");
		Assert.AreEqual ("Welcome", comp.Title, "#11");
		Assert.IsNotNull (comp.Zone, "#D12");
		Assert.AreEqual ("Zone (fr)", comp.Zone, "#D13");
	}
}
