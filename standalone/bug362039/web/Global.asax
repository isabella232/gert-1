<%@ Application Language="C#" %>
<%@ Import Namespace="AspNet.StarterKits.Classifieds.Web" %>

<script RunAt="server">

	void Application_Start(Object sender, EventArgs e)
	{
		ClassifiedsHttpApplication cha = new ClassifiedsHttpApplication();
		cha.Application_Start(sender, e);
	}
	
</script>

