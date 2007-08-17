
using System;
using System.Web;
using System.Web.UI;

namespace MasterTest
{
	public partial class Default : Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{
			Master.Init ();
		}

		public virtual void onButtonClick(object sender, EventArgs e)
		{
			Master.testingMethod();
		}
	}
}
