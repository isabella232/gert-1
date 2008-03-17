using System;
using System.Diagnostics;
using System.Globalization;

class Program
{
	static void Main ()
	{
		Process p = new Process ();
		p.StartInfo.FileName = "explorer.exe";
		p.StartInfo.Arguments = "http://www.google.be#whatever";
		p.Start ();
		p.WaitForExit ();
	}
}
