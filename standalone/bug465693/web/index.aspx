<%@ Page Language="C#" %>
<script runat="server">
	void Page_Load(object o, EventArgs e)
	{
		Response.Write (SiteMap.CurrentNode.Title);
	}
</script>
