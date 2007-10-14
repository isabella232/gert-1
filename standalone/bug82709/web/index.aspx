<%@ Page Language="C#"%>
<%@ Import Namespace="System.Globalization"%>
<html>
<script runat="server">
	void Page_Load(object o, EventArgs e)
	{
		object counter = Session["Counter"];
		int count = 0;
		if (counter != null) {
			count = (int) counter;
		}
		Session ["Counter"] = ++count;
		CounterLabel.Text = count.ToString (CultureInfo.InvariantCulture);
	}
</script>
<body>
<form runat="server">
	<asp:Label id="CounterLabel" runat="server" />
</form>
</body>
</html>