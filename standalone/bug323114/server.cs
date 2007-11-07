using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class TestServiceImpl : MarshalByRefObject, TestService
{
	public TestEnumBI64 Echo (TestEnumBI64 arg)
	{
		return arg;
	}

	public override object InitializeLifetimeService ()
	{
		return null;
	}
}

public class TestServer
{
	static void Main (string [] args)
	{
		TestServiceImpl impl = new TestServiceImpl ();
		RemotingServices.Marshal (impl, "test");
		TcpChannel chan = new TcpChannel (8089);
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif
		Console.ReadLine ();
		ChannelServices.UnregisterChannel (chan);
	}
}
