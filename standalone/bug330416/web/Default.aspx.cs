using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Mono.Util;

public class _Default : Page
{
	protected Label ItemCountLabel;

	void Page_Load (object sender, System.EventArgs e)
	{
		ItemCountLabel.Text = Bag.ItemCount.ToString (
			CultureInfo.InvariantCulture);
	}

	override protected void OnInit (EventArgs e)
	{
		InitializeComponent ();
		base.OnInit (e);
	}

	private void InitializeComponent ()
	{
		Load += new EventHandler (Page_Load);
	}
}
