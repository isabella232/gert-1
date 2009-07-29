using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public class Logon : System.Web.UI.Page
{
	protected void Page_Load (object sender, EventArgs e)
	{
		FormsAuthentication.RedirectFromLoginPage ("user", true);
	}
}
