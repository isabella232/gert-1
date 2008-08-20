<%@ Page Language="C#" %>

<script runat="server">
	void Page_Load(object o, EventArgs e)
	 {
		// Query parameter text is not checked before saving in user cookie
		NameValueCollection request = Request.QueryString;

		// Adding cookies to the response
		Response.Cookies["userName"].Value = request["text"]; 
	}
</script>

<html>
	<head>
		<title>bug #418620</title>
	</head>
	<body>
		<p>OK</p>
	</body>
</html>
