using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
	protected void Page_Load (object sender, EventArgs e)
	{
		Properties.Settings s = new Properties.Settings ();
		lblDefault.Text = Properties.Settings.Default.WebConfigTestSetting;
		lblConfigValue.Text = s.WebConfigTestSetting;
	}
}
