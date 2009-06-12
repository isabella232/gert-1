<%@ Page language="c#" %>
<%@ OutputCache Location="None" VaryByParam="None" Duration="1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN">
<html>
	<head>
		<title>bug #512037</title>
	</head>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:label id="Label3" runat="server"  ForeColor="Red" EnableViewState="False">Test</asp:label>
		</form>
	</body>
</html>
