using System;

public class Program : MarshalByRefObject
{
	public void foo (int id)
	{
		if (id == 5) {
			AppDomain domain = AppDomain.CreateDomain ("Test5");
			Program o = (Program) domain.CreateInstanceFromAndUnwrap (
				typeof (Program).Assembly.Location, "Program");
			o.foo (6);
		} else {
			Console.WriteLine (Environment.StackTrace);
		}
	}

	static void Main (String [] args)
	{
		AppDomain domain = AppDomain.CreateDomain ("Test4");
		Program o = (Program) domain.CreateInstanceFromAndUnwrap (
			typeof (Program).Assembly.Location, "Program");
		o.foo (5);
	}
}
