<%@ Application Language="C#" %>
<%@ Import Namespace="AspNet.StarterKits.Classifieds.Web" %>
<%@ Import Namespace="System.Security.Principal" %>

<script RunAt="server">
	void Application_Start (Object sender, EventArgs e)
	{
		ClassifiedsHttpApplication cha = new ClassifiedsHttpApplication ();
		cha.Application_Start (sender, e);
	}

	void Application_AuthenticateRequest (Object sender, EventArgs e)
	{
		if (HttpContext.Current.User != null) {
			if (HttpContext.Current.User.Identity.IsAuthenticated) {
				if (HttpContext.Current.User.Identity is FormsIdentity) {
					FormsIdentity fi = (FormsIdentity) HttpContext.Current.User.Identity;
					FormsAuthenticationTicket fat = fi.Ticket;

					String [] roles = fat.UserData.Split ('|');
					HttpContext.Current.User = new GenericPrincipal (fi, roles);
				}
			}
		}
	}
</script>
