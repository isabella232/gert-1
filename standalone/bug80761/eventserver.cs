using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class MyTest : MarshalByRefObject, ITest
{
	public void Raise ()
	{
		if (TestEvent != null)
			TestEvent (this, EventArgs.Empty);
	}

	public event EventHandler TestEvent;

	public MethodInfo Info
	{
		get { return info; }
		set { info = value; }
	}

	MethodInfo info;

	public void Test (DateTime d)
	{
	}
}

public class TestImpl
{
	static void Main ()
	{
		BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider ();
		provider.TypeFilterLevel = TypeFilterLevel.Full;

		IDictionary props = new Hashtable ();
		props ["port"] = 5000;
		props ["name"] = "originalTcpChannel";

		TcpChannel channel = new TcpChannel (props, null, provider);
#if NET_2_0
		ChannelServices.RegisterChannel(channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		RemotingServices.Marshal (new MyTest (), "Test");

		Console.ReadLine ();
	}
}
