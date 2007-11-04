using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;

class Program
{
	static int Main ()
	{
		BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider ();
		provider.TypeFilterLevel = TypeFilterLevel.Full;
		Register ("name1", "62000", provider);
		Register ("name2", "62001", provider);
		return 0;
	}

	static void Register (string name, string port, IServerChannelSinkProvider provider)
	{
		Hashtable props = new Hashtable ();
		props ["name"] = name;
		props ["port"] = port;
		TcpChannel c = new TcpChannel (props, null, provider);
		ChannelServices.RegisterChannel (c, false);
	}
}
