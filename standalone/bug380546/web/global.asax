<%@ Application Language="C#" %>
<script runat='server'>
	void Application_Start(object o, EventArgs e)
	{
		DataStore.Open ();
	}

	void Application_End(object o, EventArgs e)
	{
		DataStore.Close ();
	}
</script>
