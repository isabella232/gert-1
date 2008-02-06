<% @Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">
	static string webDir = null;

	void Application_Start(object o, EventArgs e)
	{
		webDir = Server.MapPath (".");
		File.Create (Path.Combine (webDir, "app_start")).Close ();
	}

	void Application_End (object o, EventArgs e)
	{
		File.Create (Path.Combine (webDir, "app_end")).Close ();
	}
</script>
