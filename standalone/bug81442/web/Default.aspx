<%@ Page Language="C#" Inherits="MasterTest.Default" MasterPageFile="~/MasterPage.master" CodeFile="Default.aspx.cs" %>
<%@ MasterType  VirtualPath="~/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolder" Runat="Server">
<body>
<asp:Button id="button1" runat="server" OnClick="onButtonClick" Text="Commit!"/> 
</asp:Content>