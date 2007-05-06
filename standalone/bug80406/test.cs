using System;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Threading;

public class Test
{
	static void Main (string [] args)
	{
		if (args [0] == "server") {
#if NET_2_0
			ChannelServices.RegisterChannel (new TcpChannel (8181), false);
#else
			ChannelServices.RegisterChannel (new TcpChannel (8181));
#endif
			Server server = new Server ();
			RemotingServices.Marshal (server, "test");
			Console.ReadLine ();
		} else {
			Server client = (Server)
				RemotingServices.Connect (
				typeof (Server),
				String.Format ("tcp://{0}:8181/test", IPAddress.Loopback.ToString ()));

			client.Reset ();
			Console.WriteLine ("Count after Reset: {0}", client.Count);

			int loops = 1000;

			for (int i = 0; i < loops; i++) {
				client.Test ();
			}

			Console.WriteLine ("OneWay calls performed: {0}", loops);

			while (true) {
				Thread.Sleep (1000);

				int c = client.Count;
				Console.WriteLine ("OneWay calls arrived: {0}", c);
				if (c == loops) break;
			}

			Console.WriteLine ("Test passed ok");
		}
	}
}

public class Server : MarshalByRefObject
{
	int count = 0;

	[OneWay]
	public void Test ()
	{
		lock (this) count++;
	}

	public int Count
	{
		get { return count; }
	}

	public void Reset ()
	{
		lock (this) count = 0;
	}
}
