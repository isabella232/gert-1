<%@ Page Language="C#" %>
<%@ OutputCache Duration="5" VaryByParam="*" %>
<%@ Import Namespace="System.Globalization" %>
<script runat="server">
	static int counter = 0;
	
	void Page_Load (object o, EventArgs e)
	{
		Msg.Text = (counter++).ToString (CultureInfo.InvariantCulture);
	}
</script>
<html>
	<body>
		<p>V2=<asp:Literal id="Msg" runat="server" /></p>
	</body>
</html> 
