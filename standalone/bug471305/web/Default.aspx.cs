using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class _Default : Page
{
	protected HtmlForm form1;

	public class CustomControl : Control
	{
		protected override void OnInit (EventArgs e)
		{
			Label label = new Label ();
			label.Text = "label";
			Controls.Add (label);
			base.OnInit (e);
		}
	}

	protected void Page_Load (object sender, EventArgs e)
	{
		CustomControl ctrl = new CustomControl ();
		form1.Controls.Add (ctrl);
		form1.Controls.Remove (ctrl);
		form1.Controls.Add (ctrl);
	}
}
