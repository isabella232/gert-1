using System;
using System.Configuration;

class Program
{
	[STAThread]
	static int Main (string [] args)
	{
		if (!VerifyAppSetting ())
			return 1;
		WeatherForcecastService wfs = new WeatherForcecastService ();
		if (!VerifyAppSetting ())
			return 2;
		wfs.Credentials = System.Net.CredentialCache.DefaultCredentials;
		if (!VerifyAppSetting ())
			return 3;
		return 0;
	}

	static bool VerifyAppSetting ()
	{
#if NET_2_0
		if (ConfigurationManager.AppSettings.Get ("myConfig") != "poke")
			return false;
#endif
		return (ConfigurationSettings.AppSettings ["myConfig"] == "poke");
	}
}
