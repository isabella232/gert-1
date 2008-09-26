<%@ Control Language="C#" %>
<%@ Import Namespace="System.Globalization" %>
<script runat="server">
	static int counter = 0;

	void Page_Load (object o, EventArgs e)
	{
		Msg.Text = (counter++).ToString (CultureInfo.InvariantCulture);
	}
</script>
<p>V1=<asp:Literal id="Msg" runat="server" /></p>
