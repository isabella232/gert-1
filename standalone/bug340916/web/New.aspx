<%@ Page Language="C#"%>
<%@ Import Namespace="System.Globalization" %>
<html xmlns="http://www.w3.org/1999/xhtml">
	<script runat="server">
		protected override void OnLoad (EventArgs e)
		{
			string input = Request.InputStream.Length.ToString (CultureInfo.InvariantCulture);
			Response.Write ("<p>REQ:" + input + "</p>");
			Response.End ();
		}
	</script>
</html>
