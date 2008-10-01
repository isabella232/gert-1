using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Serialization.Formatters;

class Server
{
	static Client client;
	static AutoResetEvent clientConnected;
	static AutoResetEvent clientDisconnected;
	static string receivedMsg;

	[STAThread]
	static int Main ()
	{
		SoapServerFormatterSinkProvider serverFormatter = new SoapServerFormatterSinkProvider ();
		serverFormatter.TypeFilterLevel = TypeFilterLevel.Full;

		Hashtable ht = new Hashtable ();
		ht ["name"] = "hydraplus";
		ht ["port"] = 8081;
		ht ["authorizedGroup"] = "everyone";

		HttpChannel channel = new HttpChannel (ht, null, serverFormatter);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		WellKnownServiceTypeEntry entry = new WellKnownServiceTypeEntry (
			typeof (ServerTalk), "hydraplus.soap",
			WellKnownObjectMode.Singleton);
		RemotingConfiguration.RegisterWellKnownServiceType (entry);

		ServerTalk.NewUser = new delUserInfo (NewClient);
		ServerTalk.DelUser = new delRemoveUser (RemoveClient);
		ServerTalk.ClientToHost = new delCommsInfo (ClientToHost);

		clientConnected = new AutoResetEvent (false);
		clientDisconnected = new AutoResetEvent (false);

		// wait for client to connect
		if (!clientConnected.WaitOne (20000, false)) {
			ReportFailure ("No client connected in time.");
			return 1;
		}

		// wait for message to arrive
		while (true) {
			Thread.Sleep (50);
			if (ServerTalk.ClientToServerQueue.Count > 0) {
				CommsInfo info = (CommsInfo) ServerTalk.ClientToServerQueue.Dequeue ();
				ClientToHost (info);
				break;
			}
		}

		// send message to client
		ServerTalk.RaiseHostToClient (client.Id, "txt", receivedMsg);

		// wait for client to disconnect
		if (clientConnected.WaitOne (2000, false)) {
			ReportFailure ("Client did not disconnect in time.");
			return 2;
		}

		return 0;
	}

	static void NewClient (string ClientID, int IPAddress)
	{
		client = new Client (ClientID);
		clientConnected.Set ();
	}

	static void RemoveClient (string ClientID, int IPAddress)
	{
		client = null;
		clientDisconnected.Set ();
	}

	static void ClientToHost (CommsInfo info)
	{
		switch (info.Type) {
		case "txt":
			receivedMsg = info.Message;
			break;
		}
	}

	static void ReportFailure (string msg)
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;

		Console.Error.WriteLine (msg);
		using (StreamWriter sw = new StreamWriter (Path.Combine (basedir, "error"), false, Encoding.UTF8)) {
			sw.Write (msg);
		}
	}
}
