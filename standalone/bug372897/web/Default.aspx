<%@ Page Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<script runat="server">
	void Page_Init(object o, EventArgs e)
	{
		if (Session ["test"] == null) {
			Session ["test"] = 1;
		} else {
			int counter = (int) Session ["test"];
			Session ["test"] = ++counter;
		}
	
		int result = (int) Session ["test"];
		Response.Write ("<p>" + result.ToString (CultureInfo.InvariantCulture) + "</p>");
	}
</script>
