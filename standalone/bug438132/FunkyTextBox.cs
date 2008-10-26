using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mono.Web.UI.Controls
{
	public class FunkyTextBox : TextBox
	{
		protected override void RenderContents(HtmlTextWriter output)
		{
			output.Write(Text);
		}

		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			LiteralControl header = new LiteralControl ("<h1>ok</h1>");
			this.Page.Header.Controls.Add (header);
		}

		public static string Funky = "Groove";
	}
}
