<%@ Page Language="C#"%>
<%@ Import Namespace="System.IO" %>
<html xmlns="http://www.w3.org/1999/xhtml">
	<script runat="server">
		protected override void OnLoad (EventArgs e)
		{
			StreamReader sr = new StreamReader (Request.InputStream);
			string request = sr.ReadToEnd ();
			if (request == "Mono ASP.NET")
				Response.Redirect ("http://localhost:8081/New.aspx", true);
		}
	</script>
</html>
