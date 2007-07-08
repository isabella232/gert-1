using System;
using System.Globalization;
using System.Threading;

class Program
{
	static void Main ()
	{
		CultureInfo ci = Thread.CurrentThread.CurrentCulture;
		Assert.IsTrue (ci.IsReadOnly, "#A1");
		Assert.IsTrue (ci.NumberFormat.IsReadOnly, "#A2");
		Assert.IsTrue (ci.DateTimeFormat.IsReadOnly, "#A3");

		Thread.CurrentThread.CurrentCulture = new CultureInfo ("nl-BE");

		ci = Thread.CurrentThread.CurrentCulture;
		Assert.IsFalse (ci.IsReadOnly, "#B1");
		Assert.IsFalse (ci.NumberFormat.IsReadOnly, "#B2");
		Assert.IsFalse (ci.DateTimeFormat.IsReadOnly, "#B3");

		ci = Thread.CurrentThread.CurrentUICulture;
		Assert.IsTrue (ci.IsReadOnly, "#C1");
		Assert.IsTrue (ci.NumberFormat.IsReadOnly, "#C2");
		Assert.IsTrue (ci.DateTimeFormat.IsReadOnly, "#C3");

		Thread.CurrentThread.CurrentUICulture = new CultureInfo ("nl-BE");

		ci = Thread.CurrentThread.CurrentUICulture;
		Assert.IsFalse (ci.IsReadOnly, "#D1");
		Assert.IsFalse (ci.NumberFormat.IsReadOnly, "#D2");
		Assert.IsFalse (ci.DateTimeFormat.IsReadOnly, "#D3");
	}
}

class Assert
{
	public static void IsTrue (bool value, string msg)
	{
		if (!value)
			throw new Exception (msg);
	}

	public static void IsFalse (bool value, string msg)
	{
		if (value)
			throw new Exception (msg);
	}
}
