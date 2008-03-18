<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>
<%@ Application Language="C#" %>
<script language="C#" runat="server">
	public override void Init ()
	{
		BeginRequest += new EventHandler (this.RewritePath);
	}

	void Application_Init (object sender, EventArgs args)
	{
		throw new Exception ("Application_Init");
	}
	
	void RewritePath (object sender, EventArgs args)
	{
		HttpApplication application = (HttpApplication) sender;
		application.Context.RewritePath ("Index1.aspx", application.Request.PathInfo,
			application.Request.QueryString.ToString ());
	}
</script>
