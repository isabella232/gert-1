using System;

using Microsoft.Win32;

class Program
{
	static void Main ()
	{
		string subkey = @"Software\nunit.org\Nunit\2.4";
		using (RegistryKey key = Registry.LocalMachine.CreateSubKey (subkey))
		using (RegistryKey fooKey = key.CreateSubKey ("foo")) {
			key.SetValue ("X", 5);
			fooKey.SetValue ("Y", 6);
			foreach (string name in key.GetValueNames ())
				key.DeleteValue (name);
			foreach (string name in key.GetSubKeyNames ()) {
				key.DeleteSubKeyTree (name);
			}
		}
	}
}
