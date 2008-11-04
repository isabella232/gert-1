<%@ Application Language="C#" Inherits="Global" %>
<script runat="server">
	void Application_Start (object Sender, EventArgs e)
	{
		Counters.AppStart |= 1;
	}

	void Session_Start (object Sender, EventArgs e)
	{
		Counters.SessionStart |= 1;
	}
</script>
