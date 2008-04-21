<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Application Language="C#" %>
<script language="C#" runat="server">
	void Application_Start (object sender, EventArgs args)
	{
		BeginRequest += new EventHandler (HandleBeginRequest);
		EndRequest += new EventHandler (HandleEndRequest);
	}

	void HandleBeginRequest (object sender, EventArgs args)
	{
		throw new Exception ("BeginRequest fired!");
	}

	void HandleEndRequest (object sender, EventArgs args)
	{
		throw new Exception ("EndRequest fired!");
	}
</script>
