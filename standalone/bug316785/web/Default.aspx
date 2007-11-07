<%@ Page Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<html>
<head>
	<script runat="server">
		protected override void OnLoad(EventArgs e) 
		{
			Span1.InnerHtml = "Server Year = " + Client.ServerTime.ToString ("yyyy",
				 CultureInfo.InvariantCulture);
		}
	</script>
</head>
<body>
	<h3>HtmlButton Sample</h3>
	<form id="ServerForm" runat="server">     
		<span id="Span1" runat="server" />
	</form>
</body>
</html>
