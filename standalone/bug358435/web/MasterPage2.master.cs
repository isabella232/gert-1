using System;
using System.Web.UI;

public partial class MasterPage2 : MasterPage
{
	protected void Page_Load (object sender, EventArgs e)
	{
	}

	public string MYLabel1 {
		set {
			Label1.Text = value;
		}
	}
}
