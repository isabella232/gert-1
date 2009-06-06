using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Web.Configuration;

class Program
{
	static string config_xml_template = 
		@"<?xml version='1.0' ?>
		<configuration>
			<location path='/{0}' />
		</configuration>";

	static int Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Please specify the locationPath to use.");
			return 1;
		}

		return RunTest (args [0]);
	}

	static int RunTest (string locationPath)
	{
		string basedir = AppDomain.CurrentDomain.BaseDirectory;
		File.WriteAllText (AppDomain.CurrentDomain.SetupInformation.ConfigurationFile,
			string.Format (config_xml_template, locationPath));

		try {
			WebConfigurationManager.GetSection ("location");
			return 1;
		} catch (ConfigurationErrorsException) {
		}

		return 0;
	}
}
