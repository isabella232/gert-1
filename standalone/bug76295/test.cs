using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;

public interface TestIf
{
	int One ();
}

class MainClass : MarshalByRefObject, TestIf
{
	int TestIf.One ()
	{
		return 1;
	}

	static int Main ()
	{
		ChannelServices.RegisterChannel (new HttpChannel (1234));
		RemotingServices.Marshal (new MainClass (), "TestUri", typeof (TestIf));

		TestIf o = RemotingServices.Connect (typeof (TestIf), "http://localhost:1234/TestUri") as TestIf;
		if (o.One () != 1)
			return 1;
		return 0;
	}
}
