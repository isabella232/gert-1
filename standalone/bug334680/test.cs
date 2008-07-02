using System;
using System.Configuration;
using System.Windows.Forms;

class Program
{
	static void Main ()
	{
#if NET_2_0
		WindowsFormsSection section = (WindowsFormsSection)
			ConfigurationManager.GetSection ("system.windows.forms");
		Assert.IsTrue (section.JitDebugging, "#1");
#else
		Assert.IsNotNull (ConfigurationSettings.GetConfig ("system.windows.forms"), "#1");
#endif
	}
}
