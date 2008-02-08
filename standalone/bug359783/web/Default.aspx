<%@ Page language="c#" Inherits="Mono.Web._Default" %>
<%@ Register TagPrefix="mono" TagName="MonoSamplesHeader" src="~/controls/MonoSamplesHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>bug #359783</title>
		<link rel="stylesheet" type="text/css" href="/mono-xsp.css">
	</HEAD>
	<body><mono:MonoSamplesHeader runat="server"/>
		<form id="Test" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server">Text will go here.</asp:Label></P>
			<P>
				<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></P>
			<P>
				<asp:Button id="SubmitButton" runat="server" Text="Submit"></asp:Button></P>
		</form>
	</body>
</HTML>
