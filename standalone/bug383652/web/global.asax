<script Language="C#" RunAt="server">
	void Application_BeginRequest (object sender, EventArgs e)
	{
		HttpApplication application = (HttpApplication) sender;
		application.Context.RewritePath ("~/Default.aspx", false);
	}
</script>
