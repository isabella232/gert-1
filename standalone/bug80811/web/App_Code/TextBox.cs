using System;
using System.Web;
using System.Web.UI;

namespace Mono.Web.UI
{
	public class TextBox : System.Web.UI.WebControls.TextBox
	{
		protected override void Render (HtmlTextWriter output)
		{
			output.Write ("<input type=\"text\" value=\"Mono is great\">");
		}
	}
}
