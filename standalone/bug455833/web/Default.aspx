<%@ Page Language="C#" AutoEventWireup="true" Title="Untitled Page" %>
<html>
	<head>
		<title>bug #455833</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<asp:TreeView ID="NavigationTree" runat="Server" DataSourceID="SiteMapDataSource">
				<Nodes>
				</Nodes>
			</asp:TreeView>
			<asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" ShowStartingNode="False" />
		</form>
	</body>
</html>
