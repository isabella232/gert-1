using System;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Trac79.Shared;

namespace Trac79.Client
{
	internal class Program
	{
		static int Main ()
		{
			TcpClientChannel channel = new TcpClientChannel ();
#if NET_2_0
			ChannelServices.RegisterChannel (channel, false);
#else
			ChannelServices.RegisterChannel (channel);
#endif
			IRemoteObject target = (IRemoteObject) Activator.GetObject (
				typeof (IRemoteObject),
				"tcp://localhost:7777/remote-object"
			);
			if (target.DoIt () != 2)
				return 1;
			return 0;
		}
	}
}
