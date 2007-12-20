using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test
{
	public class IndexPage : Page
	{
		protected Label Label1;

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);
			Label1.Text = "FINE";
		}
	}
}
