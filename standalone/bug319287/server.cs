using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading;

using BaseLib;

namespace Server
{
	class MyRemoteObject : BaseRemoteObject
	{
		int mValue;
		public MyRemoteObject ()
		{
			if (this.test != null)
				Console.WriteLine ("Value of test: " + this.test.t);
		}

		public override void setValue (int pValue)
		{
			Thread.Sleep (5000);
			mValue = pValue;
		}

		public override int getValue ()
		{
			return mValue;
		}

		public override string getText ()
		{
			Thread.Sleep (5000);
			return "Narendra";
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
