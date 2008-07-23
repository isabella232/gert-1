<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
	<head>
		<title>bug #411213</title>
	</head>
	<body>
			<form id="form1" runat="server">
				<p>BeginRequest:<asp:Label runat="server" ID="BeginRequestCountLabel" /></p>
				<p>EndRequest:<asp:Label runat="server" ID="EndRequestCountLabel" /></p>
			</form>
	</body>
</html>
