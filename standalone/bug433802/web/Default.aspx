<script runat="server">
	void Page_Load (object sender, EventArgs e)
	{
		#if MONO_ASP
			Label1.Text = "The Good";
		#else
			Label1.Text = "The Bad";
		#endif
	}
</script>
<asp:Label id="Label1" runat="server" />