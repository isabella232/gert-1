<%@ Page Language="C#" AutoEventWireup="true"  %>
<%@ Import Namespace="Mono.Web.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
	void Page_Load (object sender, EventArgs e)
	{
		CompanyV1.Text = HelperV1.Company;
		CompanyV2.Text = HelperV2.Company;
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>bug #388425</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:Label ID="CompanyV1" runat="server" />
		<asp:Label ID="CompanyV2" runat="server" />
	</form>
</body>
</html>
