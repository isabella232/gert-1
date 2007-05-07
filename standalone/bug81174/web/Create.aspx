<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="CreatePage" %>

<html>
<head id="head1" runat="server">
</head>
<body>
	<form id="form1" runat="server">
		<asp:Localize ID="TitleLocalize" runat="server" Text="<%$resources:Title %>"></asp:Localize>
		<asp:Localize ID="HeadingLocalize" runat="server" Text="<%$resources:,Heading %>"></asp:Localize> 
	</form>
</body>
</html>
