using System;
using System.ComponentModel;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading;

class Client
{
	static AutoResetEvent receivedMsg;
	static string messageReceived;

	[STAThread]
	static int Main ()
	{
		receivedMsg = new AutoResetEvent (false);

		HttpChannel channel = new HttpChannel (0);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		ServerTalk _ServerTalk = (ServerTalk) Activator.GetObject (typeof (ServerTalk), "http://localhost:8081/hydraplus.soap");

		CallbackSink _CallbackSink = new CallbackSink ();
		_CallbackSink.OnHostToClient += new delCommsInfo (CallbackSink_OnHostToClient);

		_ServerTalk.RegisterHostToClient ("Me", 0, new delCommsInfo (_CallbackSink.HandleToClient));

		string messageSent = Guid.NewGuid ().ToString ();

		_ServerTalk.SendMessageToServer (new CommsInfo ("Me", "txt", messageSent));

		if (receivedMsg.WaitOne (5000, false)) {
			Assert.AreEqual (messageReceived, messageSent, "#1");
			return 0;
		} else {
			return 1;
		}
	}

	static void CallbackSink_OnHostToClient (CommsInfo info)
	{
		switch (info.Type) {
		case "txt":
			messageReceived = info.Message;
			receivedMsg.Set ();
			break;
		case "connect":
			Console.WriteLine (info.Code + "-" + info.Message);
			break;
		case "disconnect":
			Console.WriteLine (info.Code + "-" + info.Message);
			break;
		}
	}
}
