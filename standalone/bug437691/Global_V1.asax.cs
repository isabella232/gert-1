using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	protected virtual void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart++;
	}

	protected void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart++;
	}

	protected virtual void Application_EndRequest (object sender, EventArgs e)
	{
	}

	protected virtual void Application_AuthenticateRequest (object sender, EventArgs e)
	{
	}

	protected virtual void Application_Error (object sender, EventArgs e)
	{
	}

	protected virtual void Session_End (object sender, EventArgs e)
	{
	}

	protected virtual void Application_End (object sender, EventArgs e)
	{
	}
}

public class Global : GlobalBase
{
	protected override void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart += 2;
	}

	private void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppStart += 4;
	}
}

public class Counters
{
	public static int AppStart;
	public static int SessionStart;
}
