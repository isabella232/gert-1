using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading;

public class RemotingClient
{
	static void Main ()
	{
		IRemoteLoggingSink m_sinkObj;
		IDictionary channelProperties = new Hashtable ();
		channelProperties ["typeFilterLevel"] = "Full";
		m_sinkObj = (IRemoteLoggingSink) Activator.GetObject (typeof (IRemoteLoggingSink), "tcp://localhost:8085/LoggingSink", channelProperties);

		LoggingEvent [] events = { new LoggingEvent ("whatever") };

		// Send the events
		m_sinkObj.LogEvents (events);
	}
}
