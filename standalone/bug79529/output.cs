using System;
using System.Globalization;

class Program
{
	static void Main (string [] args)
	{
		if (args.Length != 1) {
			Console.WriteLine ("Usage: output.exe <lines>");
		}

		int lines = int.Parse (args [0]);

		for (int i = 1; i < lines; i++) {
			if (i == 5) {
				Console.Out.WriteLine (" ");
				Console.Error.WriteLine (" ");
			} else {
				Console.Out.WriteLine ("STDOUT => " + i.ToString (
					CultureInfo.InvariantCulture));
				Console.Error.WriteLine ("STDERR => " + i.ToString (
					CultureInfo.InvariantCulture));
			}
		}
	}
}
