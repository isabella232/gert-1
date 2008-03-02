using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Server
{
	static void Main (string [] args)
	{
		TcpChannel chan = new TcpChannel (8085);
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif

		RemotingConfiguration.RegisterWellKnownServiceType (
			typeof (RemoteObject),
			"RemotingServer",
			WellKnownObjectMode.SingleCall);
		Console.ReadLine ();
	}
}
