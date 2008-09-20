using System;
using System.Threading;

class Program : MarshalByRefObject
{
	AutoResetEvent handle;
	string domain;

	static void Main (string [] args)
	{
		Program p = new Program ();
		p.handle = new AutoResetEvent (false);
		Client client = Client.CreateInNewAppDomain ();
		client.Completed += new Client.VoidDel (p.CompletedHandler);
		client.Run ();
		if (!p.handle.WaitOne (30000, false))
			throw new Exception ("Operation timed out");

		Assert.AreEqual (AppDomain.CurrentDomain.FriendlyName, p.domain, "#1");
	}

	public void CompletedHandler ()
	{
		domain = AppDomain.CurrentDomain.FriendlyName;
		handle.Set ();
	}
}

class Client : MarshalByRefObject
{
	public delegate void VoidDel ();
	public event VoidDel Completed;

	public static Client CreateInNewAppDomain ()
	{
		AppDomain clientDomain = AppDomain.CreateDomain ("client");
		return (Client) clientDomain.CreateInstanceAndUnwrap (
			typeof (Client).Assembly.FullName, typeof (Client).FullName);
	}

	void OnCompleted (object unused)
	{
		Completed ();
	}

	public void Run ()
	{
		ThreadPool.QueueUserWorkItem (new WaitCallback (OnCompleted));
	}
}
