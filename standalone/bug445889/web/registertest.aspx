<%@ Page language="C#" %>
<%@ Register TagPrefix="Acme" TagName="Three" Src="registertest3.ascx" %>
<html>
<head>
<script runat="Server">
	void Page_Load ()
	{
		DataBind ();
	}
</script>
</head>
<body>
<Acme:Three id="Tres" runat="server" />
</body>
</html>

