using System;
using System.Runtime.Remoting.Messaging;

[Serializable]
public class SessionContext : ILogicalThreadAffinative
{
	private ISession m_Session;

	public SessionContext (ISession m_Session)
	{
		this.m_Session = m_Session;
	}

	public ISession Session
	{
		get { return m_Session; }
	}
}

public interface IServer
{
	ISession LogOn (string user);
}

public interface ISession
{
	string GetName ();
}

