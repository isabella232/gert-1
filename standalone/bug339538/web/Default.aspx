<%@ Page Language="C#" %>

<%@ Import Namespace="System.Data.SqlClient" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	protected override void OnLoad (EventArgs e)
	{
		Response.Redirect (Request.RawUrl);
	}

	protected void Button1_Click (object sender, EventArgs e) {
		throw new Exception ("my exception");
	}

	protected void Button2_Click (object sender, EventArgs e) {
		Response.Redirect (Request.RawUrl);
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
</head>
<body>
	<form id="Form1" runat="server">
		<div>
			<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Throw" />
			<asp:Button ID="Button2" runat="server" Text="Redirect" OnClick="Button2_Click" /></div>
	</form>
</body>
</html>
