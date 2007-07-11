using System;
using System.Globalization;
using System.Reflection;
using System.Threading;

class Program
{
	static void Main ()
	{
		Thread.CurrentThread.CurrentCulture = new MyCultureInfo ();

		AppDomain domain = AppDomain.CreateDomain ("test");

		Tester tester = (Tester) domain.CreateInstanceAndUnwrap (
			Assembly.GetExecutingAssembly ().FullName,
			typeof (Tester).FullName);
		tester.PerformTest ();
	}

	private class Tester : MarshalByRefObject
	{
		public void PerformTest ()
		{
			Thread.CurrentThread.CurrentCulture = new MyCultureInfo ();
		}
	}

	private sealed class MyCultureInfo : CultureInfo
	{
		internal MyCultureInfo () : base ("en-US")
		{
		}
	}
}
