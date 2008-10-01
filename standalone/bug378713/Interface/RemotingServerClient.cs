using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

public delegate void delUserInfo (string UserID, int SessionId);
public delegate void delRemoveUser (string UserID, int SessionId);
public delegate void delCommsInfo (CommsInfo info);

public class ServerTalk : MarshalByRefObject
{
	private static delUserInfo _NewUser;
	private static delRemoveUser _DelUser;
	private static delCommsInfo _ClientToHost;
	private static ArrayList _list = new ArrayList ();

	public void RegisterHostToClient (string UserID, int SessionId, delCommsInfo htc)
	{
		_list.Add (new ClientWrap (UserID, SessionId, htc));

		if (_NewUser != null) {
			_NewUser (UserID, SessionId);
		}
	}

	public override Object InitializeLifetimeService ()
	{
		ILease lease = (ILease) base.InitializeLifetimeService ();
		if (lease.CurrentState == LeaseState.Initial) {
			lease.InitialLeaseTime = TimeSpan.Zero;
		}
		return lease;
	}

	public void UnregisterHostToClient (string UserID, int SessionId, delCommsInfo htc)
	{
		_list.Remove (new ClientWrap (UserID, SessionId, htc));

		if (_DelUser != null) {
			_DelUser (UserID, SessionId);
		}
	}

	public static delUserInfo NewUser
	{
		get { return _NewUser; }
		set { _NewUser = value; }
	}

	public static delRemoveUser DelUser
	{
		get { return _DelUser; }
		set { _DelUser = value; }
	}

	public static delCommsInfo ClientToHost
	{
		get { return _ClientToHost; }
		set { _ClientToHost = value; }
	}

	public static void RaiseHostToClient (string UserID, string Message)
	{
		RaiseHostToClient (UserID, string.Empty, string.Empty, Message);
	}

	public static void RaiseHostToClient (string UserID, string type, string Message)
	{
		RaiseHostToClient (UserID, type, string.Empty, Message);
	}

	public static void RaiseHostToClient (string UserID, string type, string code, string Message)
	{
		foreach (ClientWrap client in _list) {
			if ((client.UserID == UserID || UserID == "*") && client.HostToClient != null) {
				client.HostToClient (new CommsInfo (UserID, type, code, Message));
			}
		}
	}

	private static Queue _ClientToServer = Queue.Synchronized (new Queue ());

	public void SendMessageToServer (CommsInfo Message)
	{
		_ClientToServer.Enqueue (Message);
	}

	public static Queue ClientToServerQueue
	{
		get { return _ClientToServer; }
	}

	private class ClientWrap
	{
		private string _UserID = string.Empty;
		private int _SessionID = -1;
		private delCommsInfo _HostToClient = null;

		public ClientWrap (string UserID, int SessionId, delCommsInfo HostToClient)
		{
			_UserID = UserID;
			_SessionID = SessionID;
			_HostToClient = HostToClient;
		}

		public string UserID
		{
			get { return _UserID; }
		}

		public int SessionID
		{
			get { return _SessionID; }
		}

		public delCommsInfo HostToClient
		{
			get { return _HostToClient; }
		}
	}
}

public class CallbackSink : MarshalByRefObject
{
	public event delCommsInfo OnHostToClient;

	public CallbackSink ()
	{
	}

	[OneWay]
	public void HandleToClient (CommsInfo info)
	{
		if (OnHostToClient != null)
			OnHostToClient (info);
	}

	public override Object InitializeLifetimeService ()
	{
		ILease lease = (ILease) base.InitializeLifetimeService ();
		if (lease.CurrentState == LeaseState.Initial) {
			lease.InitialLeaseTime = TimeSpan.Zero;
		}
		return lease;
	}
}
