using System;
using System.Globalization;
using System.Web;
using System.Web.UI;

public class Default : System.Web.UI.Page
{
	protected System.Web.UI.WebControls.Label AppStart;
	protected System.Web.UI.WebControls.Label SessionStart;

	void Page_Load (object sender, EventArgs args)
	{
		AppStart.Text = Counters.AppStart.ToString (
			CultureInfo.InvariantCulture);
		SessionStart.Text = Counters.SessionStart.ToString (
			CultureInfo.InvariantCulture);
	}
}
