using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	protected virtual void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 4;
	}

	internal static void Application_BeginRequest ()
	{
		Counters.AppBeginRequest |= 2;
	}

	protected void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart |= 4;
	}

	void Session_Start ()
	{
		Counters.SessionStart |= 8;
	}
}

public class Global : GlobalBase
{
	protected override void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 2;
	}

	void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 2;
	}
}
