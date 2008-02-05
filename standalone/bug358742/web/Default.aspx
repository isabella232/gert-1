<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>
<%@ Register TagPrefix="Loc" TagName="SelectLocation" Src="~/SelectLocationForm.ascx" %>
<%@ Register TagPrefix="MN" TagName="SelectManyLocations" Src="~/SelectManyLocationsForm.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div align="center">
		<img alt="Doctor" src="Img/doctor1.jpg" border="0" />
		<Loc:SelectLocation runat="server" />
		<MN:SelectManyLocations ID="Many" runat="server" />
	</div>
</asp:Content>
