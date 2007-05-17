using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;

namespace Foo
{
	public static class Start
	{
		public static void Main (string [] args)
		{
			IpcClientChannel channel = new IpcClientChannel ();
			ChannelServices.RegisterChannel (channel, false);
			IFoo foo = (IFoo) Activator.GetObject (typeof (IFoo), "ipc://Foo/Foo");
			foo.Foo ();
		}
	}
}
