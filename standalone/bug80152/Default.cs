using System;
using System.Web;
using System.Web.UI;

namespace TestExecute
{
	public class Default : Page
	{
		protected override void OnLoad (System.EventArgs e)
		{
			Console.WriteLine ("Hello from page... Default.aspx");
			Server.Execute ("./Other.aspx");
		}
	}
}
