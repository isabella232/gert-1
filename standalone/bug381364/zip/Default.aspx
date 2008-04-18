<%@ Page language="c#" MasterPageFile="~/MasterPage.master" Inherits="Mono.Web._Default" %>
<%@ Register TagPrefix="mono" TagName="MonoSamplesHeader" src="~/controls/MonoSamplesHeader.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<mono:MonoSamplesHeader runat="server"/>
	<P>
		<asp:Label id="Label1" runat="server">Text will go here.</asp:Label></P>
	<P>
		<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></P>
	<P>
		<asp:Button id="SubmitButton" runat="server" Text="Submit"></asp:Button></P>
</asp:Content>