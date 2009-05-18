using System;
using System.Collections.Specialized;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Messaging;
using System.Threading;

class Server
{
	[STAThread]
	static void Main ()
	{
		TcpChannel tcpChannel = new TcpChannel (1238);
		ChannelServices.RegisterChannel (tcpChannel);

		RemotingConfiguration.RegisterWellKnownServiceType (typeof (MyRemoteObject), "MyRemoteObject.soap", WellKnownObjectMode.Singleton);
		Console.ReadLine ();
	}
}

public class MyRemoteObject : MarshalByRefObject, ITest
{
	public IWhatever Do (int version)
	{
		switch (version) {
		case 1:
			return new WhateverOne ();
		case 2:
			return new WhateverTwo ();
		default:
			throw new NotSupportedException ();
		}
	}

	public string Execute (IWhatever whatever)
	{
		return whatever.Execute ();
	}
}

[Serializable]
public class WhateverOne : MarshalByRefObject, IWhatever
{
	string IWhatever.Execute ()
	{
		return "one";
	}
}

[Serializable]
public class WhateverTwo : IWhatever
{
	string IWhatever.Execute ()
	{
		return "two";
	}
}
