using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class DropDownList : System.Web.UI.Page
{
	protected Label Label1;

	protected void Page_Load (object sender, EventArgs e)
	{
		Label1.Text = "OK";
	}
}
