<%@ Page Language="C#" Culture="fr-FR" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Threading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<script runat="server">
	public void Page_Load (object sender, EventArgs e)
	{
		Thread.CurrentThread.CurrentCulture = new CultureInfo ("de-DE");
	}
</script>
<html>
	<head>
		<title>bug #404083</title>
	</head>
	<body>
	</body>
</html>
