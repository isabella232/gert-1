using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class WebForm1 : Page
{
	public void Page_Load (object sender, EventArgs e)
	{
		Session ["V"] = 10;
		Server.Transfer ("WebForm3.aspx");
	}
}
