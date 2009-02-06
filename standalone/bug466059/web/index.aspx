<%@ Page Language="C#" %>
<html>
	<head>
		<title>bug #466059</title>
	</head>
	<body>
		<p1><asp:Localize runat="server" Text="<%$ Resources:TestResource,TestKey %>" /></p1>
		<p2><asp:Localize runat="server" Text="<%$ Resources:TestResource,AnotherTestKey %>" /></p2>
	</body>
</html>
