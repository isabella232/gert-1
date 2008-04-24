<%@ Application Language="C#" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">
	void Session_Start(object o, EventArgs e)
	{
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		Session.Timeout = 1;
		File.Create (Path.Combine (baseDir, "session_start")).Close ();
	}

	void Session_End(object o, EventArgs e)
	{
		string baseDir = AppDomain.CurrentDomain.BaseDirectory;
		File.Create (Path.Combine (baseDir, "session_end")).Close ();
	}
</script>
