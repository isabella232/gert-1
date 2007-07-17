using System.Runtime.Remoting.Channels.Tcp;

class Program
{
	static int Main ()
	{
		TcpChannel channel = new TcpChannel (1234);
		if (channel.ChannelName != "tcp")
			return 1;
#if NET_2_0
		if (channel.IsSecured)
			return 2;
#endif
		return 0;
	}
}
