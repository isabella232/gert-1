using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace Foo
{
	public class Fooo : MarshalByRefObject, IFoo
	{
		public IFoo Foo ()
		{
			return this;
		}
	}

	class Program
	{
		static void Main (string [] args)
		{
			IpcServerChannel channel = new IpcServerChannel ("Foo");
			ChannelServices.RegisterChannel (channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType (typeof (Fooo), "Foo", WellKnownObjectMode.Singleton);
			Console.ReadLine ();
		}
	}
}
