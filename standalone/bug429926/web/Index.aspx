<%@ Page Language="C#" %>
<%@ OutputCache Duration="1800" VaryByParam="*" %>
<%@ Register tagPrefix="test" tagName="Counter" src="counter.ascx" %>
<html>
	<body>
		<test:Counter runat="server" />
	</body>
</html>
