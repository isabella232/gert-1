using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;
using System.Text;

class Program
{
	static void Main ()
	{
		SoapServerFormatterSinkProvider sfsp = new SoapServerFormatterSinkProvider ();
		sfsp.TypeFilterLevel = TypeFilterLevel.Full;
		HttpServerChannel channel = new HttpServerChannel ("Serv", 8080, sfsp);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif

		ServerImpl impl = new ServerImpl ();
		RemotingServices.Marshal (impl, "Server.rem");
		channel.StartListening (null);
		Console.ReadLine ();
		channel.StopListening (null);
	}
}

class ServerImpl : MarshalByRefObject, IServer
{
	public ISession LogOn (string user)
	{
		ISession session = new SessionImpl ();
		SessionContext ctx = new SessionContext (session);
		CallContext.SetData ("session_ctx", ctx);
		return session;
	}
}


class SessionImpl : MarshalByRefObject, ISession
{
	public string GetName ()
	{
		return "Session here";
	}
}
