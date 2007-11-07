using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

public class Service : MarshalByRefObject
{
	private DateTime starttime;

	public Service ()
	{
		starttime = DateTime.Now;
	}

	~Service ()
	{
		Console.WriteLine ("ServiceClass being collected after " + (new TimeSpan (DateTime.Now.Ticks - starttime.Ticks)).ToString () + " seconds.");
	}

	public DateTime GetServerTime ()
	{
		return DateTime.Now;
	}
}
