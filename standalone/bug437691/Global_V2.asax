<%@ Application Language="C#" Inherits="Global" %>
<script runat="server">
	public static void Application_BeginRequest (object Sender, EventArgs e)
	{
		Counters.AppBeginRequest |= 1;
	}

	public static void Application_Start (object Sender, EventArgs e)
	{
		Counters.AppStart |= 1;
	}

	public static void Session_Start (object Sender, EventArgs e)
	{
		Counters.SessionStart |= 1;
	}
</script>
