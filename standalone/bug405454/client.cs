using System;
using System.Collections;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;

class Program
{
	static void Main ()
	{
		SoapClientFormatterSinkProvider ccsp = new SoapClientFormatterSinkProvider ();
		HttpClientChannel channel = new HttpClientChannel ((IDictionary) null, ccsp);
#if NET_2_0
		ChannelServices.RegisterChannel (channel, false);
#else
		ChannelServices.RegisterChannel (channel);
#endif
		IServer server = (IServer) Activator.GetObject (typeof (IServer), "http://127.0.0.1:8080/Server.rem");
		ISession session = server.LogOn ("Test");
		SessionContext ctx = (SessionContext) CallContext.GetData ("session_ctx");
		Assert.AreSame (session, ctx.Session, "#1");
		Assert.AreEqual ("Session here", session.GetName (), "#2");
	}
}
