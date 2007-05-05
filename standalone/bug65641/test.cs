using System;
using System.Globalization;
using System.Reflection;

public class EntryPoint
{
	public static void Main ()
	{
		AppDomainSetup setup = new AppDomainSetup ();
		setup.PrivateBinPath = "ab";

		AppDomain domain = AppDomain.CreateDomain ("test",
		  AppDomain.CurrentDomain.Evidence, setup);
		Helper helper = (Helper) domain.CreateInstanceAndUnwrap (
			typeof (EntryPoint).Assembly.FullName, typeof (Helper).FullName,
			false, BindingFlags.Public | BindingFlags.Instance, null,
			new object [0], CultureInfo.InvariantCulture, new object [0],
			AppDomain.CurrentDomain.Evidence);
		helper.Test ();
	}

	private class Helper : MarshalByRefObject
	{
		public void Test ()
		{
			Assembly assb = Assembly.LoadFrom ("b.dll");
			object b = assb.CreateInstance ("b.SomeClass");
			MethodInfo testMethod = b.GetType ().GetMethod ("Test");
			testMethod.Invoke (b, new object [0]);
		}
	}
}
