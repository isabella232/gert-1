using System;
using System.Runtime.Remoting;

class Program
{
	static void Main ()
	{
		RemotingConfiguration.RegisterWellKnownServiceType (typeof (Foo),
			"http://localhost:8000", WellKnownObjectMode.Singleton);
		RemotingConfiguration.RegisterWellKnownServiceType (typeof (Foo),
			"http://localhost:8000", WellKnownObjectMode.Singleton);
	}

	class Foo : MarshalByRefObject
	{
	}
}
