using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	protected static void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 4;
	}

	void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart |= 4;
	}
}

public class Global : GlobalBase
{
	public static void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart |= 2;
	}

	public static void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 2;
	}
}
