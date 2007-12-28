using System;
using System.Globalization;
using System.Threading;

using TestLocale;

class Program
{
	static void Main ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hi", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Bonjour", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Good morning", Lang.GetData ("HelloMsg"), "#1");
	}
}
