using System;
using System.Configuration;

public class Test
{
	static int Main ()
	{
		string value = ConfigurationSettings.AppSettings ["yourkey"];
		if (value == null)
			return 1;
		if (value != "your value")
			return 2;

		object o = ConfigurationSettings.GetConfig ("connectionStrings");
		if (o == null)
			return 3;

		ConnectionStringsSection csSection = o as ConnectionStringsSection;
		if (csSection == null)
			return 4;

		ConnectionStringSettings css = csSection.ConnectionStrings ["Publications"];
		if (css == null)
			return 5;

		if (css.ProviderName != "System.Data.SqlClient")
			return 6;

		return 0;
	}
}
