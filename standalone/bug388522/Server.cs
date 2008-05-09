using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class Server
{
	static void Main ()
	{
		HttpServerChannel channel = new HttpServerChannel (8000);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		RemotingConfiguration.RegisterWellKnownServiceType (
			typeof (RemoteInterfaceFactory),
			"RemoteInterfaceFactory.soap",
			WellKnownObjectMode.Singleton);
		Console.ReadLine ();
	}
}

public class RemoteInterface : MarshalByRefObject, IRemoteInterface
{
}

public class RemoteInterfaceFactory : MarshalByRefObject, IRemoteInterfaceFactory
{
	public IRemoteInterface Create ()
	{
		return new RemoteInterface ();
	}
}
