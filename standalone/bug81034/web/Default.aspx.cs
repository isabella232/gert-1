using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public class _Default : Page
{
	protected Literal languageLiteral;
	protected Literal srcLiteral;
	protected Literal typeLiteral;

	protected void Page_Load (object sender, EventArgs e)
	{
		languageLiteral.Text = "language=\"javascript\"";
		typeLiteral.Text = "type=\"text/javascript\"";
		srcLiteral.Text = "src=\"/js/test.js\"";
	}
}
