using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ServerTransfer
{
	public class _default : System.Web.UI.Page
	{
		private void Page_Load (object sender, System.EventArgs e)
		{
			Server.Transfer ("WebForm2.aspx?whatever=abc");
		}

		override protected void OnInit (EventArgs e)
		{
			InitializeComponent ();
			base.OnInit (e);
		}

		private void InitializeComponent ()
		{
			this.Load += new System.EventHandler (this.Page_Load);
		}
	}
}
