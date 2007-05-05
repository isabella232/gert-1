using System;
using Microsoft.Win32;

public class RegistryTest
{
	static void Main ()
	{
		using (RegistryKey softwareKey = Registry.CurrentUser.OpenSubKey ("software", true)) {
			RegistryKey monoKey = softwareKey.CreateSubKey ("monotest1");
			monoKey.SetValue ("test", "whatever");
			monoKey.Close ();
			softwareKey.DeleteSubKeyTree ("monotest1");
		}
	}
}
