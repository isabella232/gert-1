using System;
using System.IO;
using System.Reflection;

class Test
{
	static int Main (string[] args)
	{
		Stream s = File.Create ("ref.dll");
		s.Close ();
		
		try {
			Assembly.LoadFrom ("ref.dll");
		} catch (BadImageFormatException) {
		} catch (Exception ex) {
			Console.WriteLine ("#1: " + ex.ToString ());
			return 1;
		}

		using (StreamWriter sw = File.CreateText ("ref.dll")) {
			sw.WriteLine ("whatever");
			sw.Close ();
		}

		try {
			Assembly.LoadFrom ("ref.dll");
		} catch (BadImageFormatException) {
		} catch (Exception ex) {
			Console.WriteLine ("#2: " + ex.ToString ());
			return 1;
		}

		return 0;
	}
}
