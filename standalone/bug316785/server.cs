using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;

public class ServerProcess
{
	static void Main ()
	{
		TcpChannel channel = new TcpChannel (8082);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		Service service = new Service ();
		ObjRef obj = RemotingServices.Marshal (service, "TcpService");

		RemotingServices.Unmarshal (obj);

		Console.ReadLine ();

		RemotingServices.Disconnect (service);
	}
}
