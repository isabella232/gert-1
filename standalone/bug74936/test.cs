using System;

public class EntryPoint {
	public static int Main() {
		string msg = "Should've resulted in FormatException";		

		try {
			DateTime.Parse("1");
			Console.WriteLine("#1: " + msg);
			return 1;
		} catch (FormatException) {
		}

		try {
			DateTime.Parse("8.5");
			Console.WriteLine("#2: " + msg);
			return 1;
		} catch (FormatException) {
		}

		return 0;
	}
}

