using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using BaseLib;

namespace ClientAsync
{
	class Client
	{
		delegate void SetValueDelegate (int pValue);
		delegate int GetValueDelegate ();
		delegate string GetTextDelegate ();

		[STAThread]
		static void Main (string [] args)
		{
			HttpChannel chnl = new HttpChannel ();
#if NET_2_0
			ChannelServices.RegisterChannel (chnl, false);
#else
			ChannelServices.RegisterChannel (chnl);
#endif
			BaseRemoteObject obj = (BaseRemoteObject) Activator.GetObject (typeof (BaseRemoteObject),
				"http://localhost:1237/MyRemoteObject.soap");
			Assert.AreEqual (2, obj.Properties.Count, "#1");
			Assert.AreEqual ("Y", obj.Properties ["X"], "#2");
			Assert.AreEqual ("A", obj.Properties ["Z"], "#2");
		}
	}
}
