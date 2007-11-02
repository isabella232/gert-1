<%@ Page Language="C#" %>
<html>
	<head>
		<style type='text/css'>
			.green { color: green; }
			.red { color: red; }
		</style>
	</head>
	<script runat='server'>
		void Page_Load (Object o, EventArgs e)
		{
			Btn.CssClass = "red";
		}
	</script>
	<body>
		<form runat='server'>
			<asp:LinkButton id='Btn' class='green' runat='server'>Button</asp:LinkButton>
		</form>
	</body>
</html>
