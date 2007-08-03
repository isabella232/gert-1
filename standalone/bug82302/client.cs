using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;
using System.Threading;

public class RemotingClient
{
	static void Main ()
	{
		IRemoteLoggingSink m_sinkObj;

		m_sinkObj = (IRemoteLoggingSink) Activator.GetObject (typeof (IRemoteLoggingSink), "tcp://localhost:8085/LoggingSink");
		IPerson person = m_sinkObj.GetPerson ();
		person.Call ();
		person.Call ("rere");
	}
}
