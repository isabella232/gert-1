using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public class WebForm3 : Page
{
	protected Label Label1;

	public void Page_Load (object sender, EventArgs e)
	{
		Label1.Text = ((int) Session ["V"]).ToString (CultureInfo.InvariantCulture);
	}
}
