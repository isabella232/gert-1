using System;
using System.Collections.Specialized;
using System.Configuration;

class Program
{
	static int Main ()
	{
		NameValueCollection c = (NameValueCollection)
			ConfigurationSettings.GetConfig ("Group/Section");
		string value = c ["key"] as string;
		if (value != "value")
			return 1;
		return 0;
	}
}
