using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomDefaultPage : Page
{
	protected void Page_Load (object sender, EventArgs e)
	{
		Label label = FindControl ("lblHello") as Label;
		if (label != null)
			label.Text = "CustomDefault";
	}
}
