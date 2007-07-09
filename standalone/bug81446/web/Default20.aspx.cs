using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

using MonoTest;
using ConfigurationSection = MonoTest.ConfigurationSection;

namespace Mono.Test
{
	public partial class _Default : Page
	{
		protected override void OnInit (EventArgs e)
		{
			base.OnInit (e);

			ConfigurationSection config1 = (ConfigurationSection) ConfigurationManager.GetSection ("system.web/MonoTest1");
			Config1Value.Text = config1.Name;

			object config2 = ConfigurationManager.GetSection ("system.web/MonoTest2");
			Config2Value.Text = config2.GetType ().FullName;

			object config3 = ConfigurationManager.GetSection ("system.web/MonoTest3");
			Config3Value.Text = config3.GetType ().FullName;
		}
	}
}
