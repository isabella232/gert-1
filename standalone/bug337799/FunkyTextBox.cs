using System;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: WebResource ("Mono.Web.Security.UI.MyResources.Test.css", "text/css", PerformSubstitution=true)]
[assembly: WebResource ("Mono.Web.Security.UI.MyResources.Test.js", "text/javascript")]

namespace Mono.Web.Security.UI
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
			this.Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Test", Page.ClientScript.GetWebResourceUrl(this.GetType(), "Mono.Web.Security.UI.MyResources.Test.js"));

			// create the style sheet control and put it in the document header
			string csslink = "<link rel='stylesheet' type='text/css' href='" + Page.ClientScript.GetWebResourceUrl (this.GetType (), "Mono.Web.Security.UI.MyResources.Test.css") + "' />";
			LiteralControl include = new LiteralControl(csslink);
			this.Page.Header.Controls.Add(include);
		}
	}
}
