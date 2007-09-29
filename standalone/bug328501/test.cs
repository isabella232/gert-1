using System;
using System.Reflection;

class Program
{
	[STAThread]
	static void Main ()
	{
		for (int i = 0; i < 10; i++) {
			AppDomain domain = AppDomain.CreateDomain ("test");
			Runner runner = (Runner) domain.CreateInstanceAndUnwrap (
				typeof (Runner).Assembly.FullName,
				typeof (Runner).FullName);
			runner.Run ();
			AppDomain.Unload (domain);
		}
	}
}

public class Runner : MarshalByRefObject
{
	public void Run ()
	{
		Assembly a = Assembly.LoadFrom ("lib.dll");
		object p = a.CreateInstance ("Container", false);
		object address = p.GetType ().GetField ("Bag").GetValue (p);
		if (address.ToString () != "WHATEVER")
			throw new Exception ();
	}
}
