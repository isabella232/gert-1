using System;
using System.Web;
using System.Web.UI;

namespace TestExecute
{
	public class Other : Page
	{
		protected override void OnLoad (System.EventArgs e)
		{
			Console.WriteLine ("Hello from other");
		}
	}
}
