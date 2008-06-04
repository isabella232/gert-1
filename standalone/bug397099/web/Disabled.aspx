<%@ Page EnableEventValidation="false" %>
<script runat="server">
	void Page_Load (object o, EventArgs e)
	{
		EvVal.Text = EnableEventValidation.ToString();
	}
</script>

<html>
	<body>
		<p>Page.EnableEventValidation:<asp:Literal ID="EvVal" runat="server" /></p>
	</body>
</html>
