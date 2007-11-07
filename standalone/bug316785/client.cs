using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Client
{
	private static Client client = null;
	private Service service = null;

	internal Client ()
	{
		ChannelServices.RegisterChannel (new TcpChannel ());

		WellKnownClientTypeEntry remotetype =
			new WellKnownClientTypeEntry (typeof (Service), "tcp://localhost:8082/TcpService");
		RemotingConfiguration.RegisterWellKnownClientType (remotetype);

		service = new Service ();
	}

	private static Client Instance
	{
		get
		{
			if (client == null)
				client = new Client ();
			return client;
		}
	}

	public static DateTime ServerTime
	{
		get
		{
			return Instance.service.GetServerTime ();
		}
	}

	public static void Main (string [] args)
	{
		Console.WriteLine ("Server time = {0}", ServerTime);
	}
}

