<%@ Page Language="C#" %>
<html>
	<body>
		<form id="Form1" runat='server'>
			<p>PrivateBinPath=<%= AppDomain.CurrentDomain.SetupInformation.PrivateBinPath %></p>
			<p>BinDirectory=<%= HttpRuntime.BinDirectory %></p>
		</form>
	</body>
</html>
