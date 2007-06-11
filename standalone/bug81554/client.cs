using System;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

class Program
{
	static int Main ()
	{
		TcpChannel chan = new TcpChannel ();
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif

		Common.ISayHello helloObj = Activator.GetObject (typeof (Common.ISayHello),
			"tcp://localhost:8085/SayHello") as Common.ISayHello;

		if (helloObj == null)
			Console.WriteLine ("Could not locate server");

		if (helloObj.SayHello () != "Hello")
			return 1;
		return 0;
	}
}
