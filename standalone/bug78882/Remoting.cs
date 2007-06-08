using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;
using System.Threading;

namespace Test
{
	public class RemotingHelper
	{
		public static void Init()
		{
			Init(0);
		}

		public static void Init(int port)
		{
			BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
			serverProv.TypeFilterLevel = TypeFilterLevel.Full;
			BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
			IDictionary props = new Hashtable();
			props["port"] = port;
			TcpChannel tcp_channel = new TcpChannel(props, clientProv, serverProv);
			ChannelServices.RegisterChannel(tcp_channel, false);
		}
	}
}
