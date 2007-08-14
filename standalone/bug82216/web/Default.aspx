<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagName="Label" TagPrefix="asp" Src="controls/Banner.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<asp:SecuredPanel runat="server">
				<asp:TextBox ID="TextBox1" Text="Normal TextBox" runat="server" />
			</asp:SecuredPanel>
			<asp:Label ID="MyLabel" text="FINE" runat="server" />
			<asp:SomeBanner ID="MyBanner" text="OK" runat="server" />
			<asp:PasswordBox ID="MyPassword" runat="server" />
			<asp:TextBox ID="TextBox2" Text="Another TextBox" runat="server" />
		</div>
	</form>
</body>
</html>
