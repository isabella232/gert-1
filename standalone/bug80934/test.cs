using System;
using System.Configuration;
using System.Globalization;
using System.Reflection;

public class Test
{
	static int Main ()
	{
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationBase = "sub";
		setup.ConfigurationFile = "application.config";
		AppDomain domain = AppDomain.CreateDomain("ConfigurationFileDomain", null, setup);
		CrossDomainTester cdt = CreateCrossDomainTester (domain);
		return cdt.Run ();
	}

	static CrossDomainTester CreateCrossDomainTester (AppDomain domain)
	{
		Type testerType = typeof (CrossDomainTester);

		return (CrossDomainTester) domain.CreateInstanceAndUnwrap (
			testerType.Assembly.FullName, testerType.FullName, false,
			BindingFlags.Public | BindingFlags.Instance, null, new object [0],
			CultureInfo.InvariantCulture, new object [0], domain.Evidence);
	}

	class CrossDomainTester : MarshalByRefObject
	{
		public int Run ()
		{
#if NET_2_0
			string mono = ConfigurationManager.AppSettings ["mono"];
#else
			string mono = ConfigurationSettings.AppSettings ["mono"];
#endif
			if (mono != "great")
				return 1;
			return 0;
		}
	}
}
