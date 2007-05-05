using Microsoft.Win32;

public class EntryPoint {
	static void Main () {
		using (RegistryKey key1 = Registry.LocalMachine.OpenSubKey ("software", true)) {
			RegistryKey key2 = key1.OpenSubKey ("test");
			if (key2 != null)
				key1.DeleteSubKey ("test");

			key2 = key1.CreateSubKey ("test");
			using (RegistryKey key4 = Registry.LocalMachine.OpenSubKey ("software")) {
			}

			key2.Close ();
			key1.DeleteSubKeyTree ("test");
		}
	}
}

