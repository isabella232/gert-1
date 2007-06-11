using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

class Program
{
	static void Main( string[] args )
	{
		TcpChannel chan = new TcpChannel (8085);
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif
		RemotingConfiguration.RegisterWellKnownServiceType (typeof (Common.HelloClass),
			"SayHello", WellKnownObjectMode.Singleton);
		Console.ReadLine();
	}
}

