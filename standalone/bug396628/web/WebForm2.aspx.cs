using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class WebForm2 : Page
{
	public void Page_Load (object sender, EventArgs e)
	{
		Session ["V"] = 20;
		Response.Redirect ("WebForm3.aspx");
	}
}
