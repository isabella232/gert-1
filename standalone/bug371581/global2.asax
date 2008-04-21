<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Application Language="C#" %>
<script language="C#" runat="server">
	void Application_Init (object sender, EventArgs args)
	{
		throw new Exception ("Application_Init");
	}
	
	void Application_BeginRequest (object sender, EventArgs e)
	{
		HttpApplication application = (HttpApplication) sender;
		application.Context.RewritePath ("Index2.aspx", application.Request.PathInfo,
			application.Request.QueryString.ToString ());
	}
</script>
