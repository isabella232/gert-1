using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

public class Client
{
	static void Main ()
	{
		HttpClientChannel channel = new HttpClientChannel ();
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		IRemoteInterfaceFactory factory = (IRemoteInterfaceFactory)
			Activator.GetObject (typeof (IRemoteInterfaceFactory),
			"http://localhost:8000/RemoteInterfaceFactory.soap");
		factory.Create ();
	}
}
