using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Trac79.Shared;

namespace Trac79.Server
{
	public sealed class RemoteObject : MarshalByRefObject, IRemoteObject
	{
		public RemoteObject ()
		{
		}

		public int DoIt ()
		{
			return 1;
		}

		int IRemoteObject.DoIt ()
		{
			return 2;
		}
	}

	internal class Program
	{
		static void Main ()
		{
			TcpServerChannel channel = new TcpServerChannel (7777);
#if NET_2_0
			ChannelServices.RegisterChannel (channel, false);
#else
			ChannelServices.RegisterChannel (channel);
#endif
			RemotingConfiguration.RegisterWellKnownServiceType (
				typeof (RemoteObject),
				"remote-object",
				WellKnownObjectMode.Singleton
			);
			Console.ReadLine ();
		}
	}
}
