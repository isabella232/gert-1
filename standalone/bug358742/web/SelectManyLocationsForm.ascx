<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectManyLocationsForm.ascx.cs" Inherits="SelectManyLocationsForm" %>
<%@ Register TagPrefix="VM" TagName="SelectLocationForm" Src="SelectLocationForm.ascx" %>
<asp:Panel runat="server">
<VM:SelectLocationForm ID="A" runat="server" />
<VM:SelectLocationForm ID="B" runat="server" />
</asp:Panel>
