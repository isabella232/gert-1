using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace TestExecute
{
	public class Other : Page
	{
		protected override void OnLoad (System.EventArgs e)
		{
			string baseDir = AppDomain.CurrentDomain.BaseDirectory;
			File.Create (Path.Combine (baseDir, "Other.executed")).Close ();
		}
	}
}
