<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<script runat="server">
	public void Page_Load (object sender, EventArgs e)
	{
		ConfigPath.Text = Mono.Web.UI.Action.GetConfigPath ();
	}
</script>
<html>
	<head>
		<title>bug #405574</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<asp:Label id="ConfigPath" runat="server" />
		</form>
	</body>
</html>
