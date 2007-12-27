using System;
using System.Globalization;
using System.Threading;

using TestLocale;

class Program
{
	static int Main (string [] args)
	{
		switch (args [0]) {
		case "test3a":
			Test3a ();
			break;
		case "test3b":
			Test3b ();
			break;
		case "test3c":
			Test3c ();
			break;
		case "test3d":
			Test3d ();
			break;
		case "test6":
			Test6 ();
			break;
		case "test7":
			Test7 ();
			break;
		default:
			Console.Error.WriteLine ("Test not supported.");
			return 1;
		}
		return 0;
	}

	static void Test3a ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hi", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Bonjour", Lang.GetData ("HelloMsg"), "#2");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Good morning", Lang.GetData ("HelloMsg"), "#3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#4");
	}

	static void Test3b ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hi", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Bonjour", Lang.GetData ("HelloMsg"), "#2");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#4");
	}

	static void Test3c ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hi", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#2");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#4");
	}

	static void Test3d ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		bool isLocalized = (string.Compare ("Hi", Lang.GetData ("HelloMsg")) == 0);

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		if (string.Compare ("Bonjour", Lang.GetData ("HelloMsg")) != 0) {
			Assert.IsTrue (isLocalized, "#1");
			isLocalized = false;
		}

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		if (string.Compare ("Good morning", Lang.GetData ("HelloMsg")) != 0) {
			Assert.IsTrue (isLocalized, "#2");
			isLocalized = false;
		}

		Assert.IsFalse (isLocalized, "#3");
	}

	static void Test6 ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#2");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#4");
	}

	static void Test7 ()
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-US");
		Assert.AreEqual ("Hi", Lang.GetData ("HelloMsg"), "#1");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("fr-FR");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#2");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("en-GB");
		Assert.AreEqual ("Good morning", Lang.GetData ("HelloMsg"), "#3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");
		Assert.AreEqual ("Hello", Lang.GetData ("HelloMsg"), "#4");
	}
}
