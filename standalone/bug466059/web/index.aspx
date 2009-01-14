<%@ Page Language="C#" %>
<html>
	<head>
		<title>bug #466059</title>
	</head>
	<body>
		<p><asp:Localize runat="server" Text="<%$ Resources:TestResource,TestKey %>" /></p>
	</body>
</html>
