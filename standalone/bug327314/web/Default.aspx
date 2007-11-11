<%@ Page Language="C#"%>
<html xmlns="http://www.w3.org/1999/xhtml">
	<script runat="server">
		protected override void OnLoad (EventArgs e)
		{
			Response.Redirect ("https://localhost:4443/New.aspx?name=er&address=ERE", false);
		}
	</script>
</html>
