<%@ Page Language="C#" AutoEventWireup="true" Inherits="_Default" %>
<html>
<head runat="server" />
<body>
	<p>
	This is a test to see if mono can handle a control embedded in a script tag; which MS is able to deal with.
	</p>
	<script <asp:Literal ID="languageLiteral" runat="server" EnableViewState="false" /> <asp:Literal ID="srcLiteral" runat="server" EnableViewState="false" /> <asp:Literal ID="typeLiteral" runat="server" EnableViewState="false" />></script>
</body>
</html>
