using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using MonoTest;

namespace Mono.Test
{
	public partial class _Default : Page
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit (e);

			TestConfigurationSection config1 = (TestConfigurationSection) ConfigurationManager.GetSection ("system.web/MonoTest1");
			Config1Value.Text = config1.Name;

			TestConfiguration config2 = (TestConfiguration) ConfigurationManager.GetSection ("system.web/MonoTest2");
			Config2Value.Text = config2.Name;
		}
	}
}
