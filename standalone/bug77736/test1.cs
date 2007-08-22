using System;
using System.Diagnostics;

class Foo
{
	public static int Main ()
	{
		for (int i = 0; i < 10000; i++) {
			Console.WriteLine (i.ToString ());
			Process p = new Process ();
			p.StartInfo.FileName = "true";

			p.Start ();

			bool ret = p.WaitForExit (60000);

			if (!ret && p.HasExited) {
				return 1;
			}
		}
		return 0;
	}
}
