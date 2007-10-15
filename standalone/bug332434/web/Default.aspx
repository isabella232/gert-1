<%@ Page Language="C#" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>bug #332434</title>
	<script runat="server">
		void Page_Load (object o, EventArgs e)
		{
			Providers.Text = "Hello";
		}
	</script>
</head>
<body>
	<form action="Default.aspx" runat="server">
		<asp:Label ID="Providers" runat="server" />
	</form>
</body>
</html>
