using System;
using System.ComponentModel;
using System.Reflection;

class Program
{
	static void AssemblyLoadHandler (object ob, AssemblyLoadEventArgs args)
	{
		args.LoadedAssembly.GetTypes ();
	}

	static void Main ()
	{
		AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler (AssemblyLoadHandler);
		AssemblyName aname = typeof (Component).Assembly.GetName ();
		Assembly.Load (aname).GetTypes ();
	}
}
