<%@ Page Language="C#" %>
<%@ Register TagName="Logo" TagPrefix="Mono" Src="~/Logo.ascX" %>
<%@ Import Namespace="Mono.WebTest.UI" %>

<html>
<body>
	<%
		MembersDataComponent comp = new MembersDataComponent ();
		Response.Write ("<p>" + comp.GetType ().FullName + "</p>");

		Banner b = new Banner ();
		Response.Write ("<p>" + b.GetType ().FullName + "</p>");
	%>
	<form runat="server">
		<Mono:Logo Text="We rock!" runat="server" />
		<vv:Footer Text="We rule!" runat="server" />
	</form>
</body>
</html>
