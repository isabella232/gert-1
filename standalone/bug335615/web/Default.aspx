<%@ Page Language="C#"%>
<html>
	<body>
		<form runat="server">
			<p>ARG1=<%= Request.QueryString ["arg1"]%></p>
			<p>ARG2=<%= Request.QueryString ["arg2"]%></p>
		</form>
	</body>
</html>