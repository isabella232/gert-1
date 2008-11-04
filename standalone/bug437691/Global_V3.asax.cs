using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;

public class GlobalBase : System.Web.HttpApplication
{
	internal void Application_Start (object sender, EventArgs e)
	{
		Counters.AppStart |= 4;
	}

	internal void Session_Start (object sender, EventArgs e)
	{
		Counters.SessionStart |= 4;
	}
}

public class Global : GlobalBase
{
	void Application_BeginRequest (object sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 2;
	}
}
