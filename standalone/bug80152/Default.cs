using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace TestExecute
{
	public class Default : Page
	{
		protected override void OnLoad (System.EventArgs e)
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;
			File.Create (Path.Combine (baseDir, "Default.executed")).Close ();
			Server.Execute ("./Other.aspx");
		}
	}
}
