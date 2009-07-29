<%@ Application Language="C#" %>
<script RunAt="server">
	public void FormsAuthentication_OnAuthenticate (object sender, FormsAuthenticationEventArgs args)
	{
		args.User = new System.Security.Principal.GenericPrincipal (
			new System.Security.Principal.GenericIdentity ("UnknownUser", "Custom"),
			new string [] { "MyRole" });
	}
</script>
