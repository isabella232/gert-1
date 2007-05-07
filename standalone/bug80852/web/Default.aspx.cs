using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load (object sender, EventArgs e)
	{
		if (MultiView1.ActiveViewIndex != 0)
			MultiView1.ActiveViewIndex = 0;
	}

	protected void MultiView1_ActiveViewChanged (object sender, EventArgs e)
	{
		Label1.Text = "Changed";
	}
}
