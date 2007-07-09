using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public class ConfigPage : System.Web.UI.Page
{
	private void Page_Load(object sender, System.EventArgs e)
	{
		object config1 = ConfigurationSettings.GetConfig ("system.web/MonoTest1");
		Config1Value.Text = config1.GetType ().FullName;

		object config2 = ConfigurationSettings.GetConfig ("system.web/MonoTest2");
		Config2Value.Text = config2.GetType ().FullName;
	}

	override protected void OnInit(EventArgs e)
	{
		InitializeComponent();
		base.OnInit(e);
	}
		
	private void InitializeComponent()
	{
		this.Load += new System.EventHandler(this.Page_Load);
	}

	protected Literal Config1Value;
	protected Literal Config2Value;
}
