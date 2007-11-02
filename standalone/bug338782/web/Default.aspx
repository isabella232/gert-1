<html>
	<head>
		<style type='text/css'>
			.green { color: green; }
			.red { color: red; }
		</style>
	</head>
	<script runat='server'>
		Sub Page_Load (Byval o as Object, Byval e as EventArgs)
			Btn.CssClass = "red"
		End Sub
	</script>
	<body>
		<form runat='server'>
			<asp:LinkButton id='Btn' class='green' runat='server'>Button</asp:LinkButton>
		</form>
	</body>
</html>
