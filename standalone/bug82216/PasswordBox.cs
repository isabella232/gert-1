using System;
using System.Web;
using System.Web.UI;

namespace Mono.Web.Security.UI
{
	public class PasswordBox : Control
	{
		protected override void Render (HtmlTextWriter output)
		{
			output.Write ("<input type=\"password\" value=\"Mono is great\">");
		}
	}
}
