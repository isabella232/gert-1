using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class RemoteObject : MarshalByRefObject
{
	public string serverString;
	public DateTime serverTimestamp;

	public RemoteObject ()
	{
		serverString = "Hello, World!";
		serverTimestamp = new DateTime (1973, 8, 13);
	}

	public String ReplyMessage (String msg)
	{
		return "Reply: " + msg;
	}
}
