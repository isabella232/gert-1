using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	internal static void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 4;
	}

	protected internal void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 8;
	}

	public static void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart |= 4;
	}
}

public class Global : GlobalBase
{
}
