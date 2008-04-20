using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using MonoTest;

public class ConfigPage : System.Web.UI.Page
{
	void Page_Load(object sender, System.EventArgs e)
	{
		TestConfiguration config1 = (TestConfiguration) ConfigurationSettings.GetConfig ("system.web/MonoTest1");
		Config1Value.Text = config1.Name;

		TestConfiguration config2 = (TestConfiguration) ConfigurationSettings.GetConfig ("system.web/MonoTest2");
		Config2Value.Text = config2.Name;
	}

	override protected void OnInit(EventArgs e)
	{
		InitializeComponent();
		base.OnInit(e);
	}

	void InitializeComponent()
	{
		Load += new EventHandler(Page_Load);
	}

	protected Literal Config1Value;
	protected Literal Config2Value;
}
