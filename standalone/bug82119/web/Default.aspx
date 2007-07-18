<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:Label ID="label1" runat="server" Enabled="<%# true %>">hello</asp:Label>
	<asp:Label ID="label2" runat="server" Enabled="<%# false %>">world</asp:Label>
</asp:Content>
