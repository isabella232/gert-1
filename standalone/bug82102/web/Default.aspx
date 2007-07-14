<%@ Page %>
<html>
<script language="C#" runat="server">
	string WebServiceName;

	void Page_Load(object sender, EventArgs e)
	{
		WebServiceName = "Mono ASP.NET";
	}
</script>
<head runat="server">
	<link rel="alternate" type="text/xml" href="<%=Request.FilePath%>?disco"/>
	<title><%=WebServiceName%> Rulez!</title>
</head>
<body>
</body>
</html>
