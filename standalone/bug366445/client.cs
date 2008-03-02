using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Client
{
	static int Main (string [] args)
	{
		TcpChannel chan = new TcpChannel ();
#if NET_2_0
		ChannelServices.RegisterChannel (chan, false);
#else
		ChannelServices.RegisterChannel (chan);
#endif
		RemoteObject remObject = (RemoteObject) Activator.GetObject (
			typeof (RemoteObject),
			"tcp://localhost:8085/RemotingServer");
		Assert.AreEqual ("Reply: You there?", remObject.ReplyMessage ("You there?"), "#1");
		Assert.AreEqual ("Hello, World!", remObject.serverString, "#2");
		Assert.AreEqual (new DateTime (1973, 8, 13), remObject.serverTimestamp, "#3");
		return 0;
	}
}

