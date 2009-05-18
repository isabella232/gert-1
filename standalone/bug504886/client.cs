using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

class Client
{
	[STAThread]
	static void Main ()
	{
		TcpChannel chnl = new TcpChannel (0);
		ChannelServices.RegisterChannel (chnl);
		ITest obj = (ITest) Activator.GetObject (typeof (ITest),
			"tcp://localhost:1238/MyRemoteObject.soap");

		IWhatever whatever;

		whatever = obj.Do (1);
		Assert.AreEqual ("one", whatever.Execute (), "#1");
		whatever = obj.Do (2);
		Assert.AreEqual ("two", whatever.Execute (), "#2");
#if MONO
		whatever = new WhateverThree ();
		Assert.AreEqual ("three", obj.Execute (whatever), "#3");
#endif
		whatever = new WhateverFour ();
		Assert.AreEqual ("four", obj.Execute (whatever), "#4");
	}
}

[Serializable]
public class WhateverThree : MarshalByRefObject, IWhatever
{
	string IWhatever.Execute ()
	{
		return "three";
	}
}

[Serializable]
public class WhateverFour : IWhatever
{
	string IWhatever.Execute ()
	{
		return "four";
	}
}
