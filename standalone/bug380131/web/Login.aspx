<%@ Page Language="C#" Title="Welcome" %>

<script runat="server">
	protected override void OnLoad (EventArgs e)
	{
		string roles = "Administrators";
		string user = "gert";

		FormsAuthentication.Initialize ();
		FormsAuthenticationTicket fat = new FormsAuthenticationTicket (1,
			user, DateTime.Now, DateTime.Now.AddMinutes (30), false, roles,
			FormsAuthentication.FormsCookiePath);
		Response.Cookies.Add (new HttpCookie (FormsAuthentication.FormsCookieName,
		FormsAuthentication.Encrypt (fat)));
		Response.Redirect (FormsAuthentication.GetRedirectUrl (user, false));
	}
</script>
<html>
	<body>
	</body>
</html>
