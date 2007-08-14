using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ServerTransfer
{
	public class WebForm2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;

		private void Page_Load (object sender, System.EventArgs e)
		{
			string whatever = Context.Request.QueryString ["whatever"];
			if (whatever != null) {
				Label2.Text = "QueryString available (value of whatever is: " + whatever + ")";
			} else {
				Label2.Text = "QueryString not available !!!";
			}

			StringBuilder sb = new StringBuilder ();
			sb.Append ("FilePath=" + Context.Request.FilePath + "\r\n");
			sb.Append ("Path=" + Context.Request.Path + "\r\n");
			sb.Append ("PathInfo=" + Context.Request.PathInfo + "\r\n");
			sb.Append ("PhysAppPath=" + Context.Request.PhysicalApplicationPath + "\r\n");
			sb.Append ("PhysPath=" + Context.Request.PhysicalPath + "\r\n");
			sb.Append ("RawUrl=" + Context.Request.RawUrl + "\r\n");
			if (Context.Request.UrlReferrer != null) {
				sb.Append ("UrlReferrer=" + Context.Request.UrlReferrer + "\r\n");
			}
			Label3.Text = sb.ToString ();
		}

		override protected void OnInit (EventArgs e)
		{
			InitializeComponent ();
			base.OnInit (e);
		}

		private void InitializeComponent ()
		{
			this.Load += new EventHandler (this.Page_Load);
		}
	}
}
