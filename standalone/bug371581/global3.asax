<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Application Language="C#" %>
<script language="C#" runat="server">
	void Application_Start (object sender, EventArgs args)
	{
		BeginRequest += new EventHandler (this.RewritePath);
	}
	
	void RewritePath (object sender, EventArgs args)
	{
		HttpApplication application = (HttpApplication) sender;
		application.Context.RewritePath ("Index1.aspx", application.Request.PathInfo,
			application.Request.QueryString.ToString ());
	}
</script>
