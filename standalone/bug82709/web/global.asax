<% @Application Language="C#" %>
<object id="Test" scope="session" class="System.Collections.ArrayList" runat="server" />
<script runat="server">
	void Session_Start(object o, EventArgs e)
	{
		Session ["Counter"] = 0;
	}
</script>