<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
	<head>
		<title>bug #4000807</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<%Mono.Web.UI.Action r = new Mono.Web.UI.Action(Mono.Web.UI.Exec.Run);%>
			<p><%= Mono.Web.UI.Exec.Render () %><%Response.Write("A");%><%r();%><%= Mono.Web.UI.Exec.Render () %><%Response.Write("B");%></p>
	</form>
</body>
</html>
