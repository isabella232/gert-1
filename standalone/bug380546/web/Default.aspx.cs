using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class _Default : System.Web.UI.Page
{
	void Page_Load(object sender, EventArgs e)
	{
		Label1.Text = DataStore.Find ("Label1");
	}

	override protected void OnInit (EventArgs e)
	{
		InitializeComponent ();
		base.OnInit (e);
	}

	void InitializeComponent()
	{
		Load += new EventHandler(Page_Load);
	}

	protected Label Label1;
}
