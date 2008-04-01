using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class TestClient
{
	static int Main (string [] args)
	{
		TcpChannel chan = new TcpChannel ();
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif

		TestService sv = (TestService) RemotingServices.Connect (typeof (TestService),
									 "tcp://localhost:8089/test");

		try {
			for (int i = 0; i < 100; i++) {
				TestEnumBI64 arg = TestEnumBI64.AL;
				TestEnumBI64 result = sv.Echo (arg);

				if (arg != result)
					return 1;
				if ((long) arg != (long) result)
					return 2;
				if (!arg.Equals (result))
					return 3;
			}
		} finally {
			ChannelServices.UnregisterChannel (chan);
		}

		return 0;
	}
}
