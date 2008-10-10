using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebSite;

namespace RefAssembly
{
	public class TestControl : System.Web.UI.UserControl, IMyBase
	{
		public string MyName
		{
			get { return System.Reflection.Assembly.GetExecutingAssembly ().FullName; }
		}

		protected System.Web.UI.WebControls.Label MyLabel;

		protected override void OnInit (EventArgs e)
		{
			MyLabel.Text = MyName;
			base.OnInit (e);
		}
	}
}
