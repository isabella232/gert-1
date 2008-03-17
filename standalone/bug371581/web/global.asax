<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Application Language="C#" %>
<script language="C#" runat="server">
	void Application_BeginRequest (object sender, EventArgs e)
	{
		HttpApplication application = (HttpApplication) sender;
		application.Context.RewritePath ("/Index.aspx", application.Request.PathInfo,
			application.Request.QueryString.ToString ());
	}
</script>
