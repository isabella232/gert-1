<%@ Page Language="C#"%>
<html>
<script runat="server">
	void Page_Load(object o, EventArgs e)
	{
		Session.Abandon ();
	}
</script>
<body>
</body>
</html>