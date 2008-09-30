using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;

using BaseLib;

namespace Server
{
	class MyRemoteObject : BaseRemoteObject
	{
		Hashtable _properties;

		public MyRemoteObject ()
		{
			_properties = new Hashtable ();
			_properties.Add ("X", "Y");
			_properties.Add ("Z", "A");
		}

		public override IDictionary Properties {
			get { return _properties; }
		}
	}

	class ServerStartup
	{
		[STAThread]
		static void Main (string [] args)
		{
			HttpChannel chnl = new HttpChannel (1237);
#if NET_2_0
			ChannelServices.RegisterChannel (chnl, false);
#else
			ChannelServices.RegisterChannel (chnl);
#endif

			RemotingConfiguration.RegisterWellKnownServiceType (typeof (MyRemoteObject), "MyRemoteObject.soap", WellKnownObjectMode.Singleton);
			Console.ReadLine ();
		}
	}
}
