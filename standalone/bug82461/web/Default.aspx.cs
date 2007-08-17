using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ConfigurationSectionTestCase
{
	public class _Default : Page
	{
		protected HtmlForm form1;
		protected Label Label1;

		protected void Page_Load (object sender, EventArgs e)
		{
#if NET_2_0
			if (ConfigurationManager.GetSection ("testSection") == null)
#else
			if (ConfigurationSettings.GetConfig ("testSection") == null)
#endif
				Label1.Text = "testSection == NULL";
			else
				Label1.Text = "testSection != NULL";
		}
	}
}
