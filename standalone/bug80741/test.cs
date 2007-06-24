using System;
using System.Drawing.Printing;

public class Test
{
	[STAThread]
	static int Main ()
	{
		PrinterSettings settings = new PrinterSettings ();
		if (settings == null) {
		}
		return 0;
	}
}
