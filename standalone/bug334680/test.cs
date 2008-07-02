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
		object config = ConfigurationSettings.GetConfig ("system.windows.forms");
#if MONO
		Assert.IsNull (config, "#1");
#else
		Assert.IsNotNull (config, "#1");
#endif
#endif
	}
}
