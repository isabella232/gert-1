using System;
using System.Collections.Generic;

class Program
{
	static int Main ()
	{
		IEnumerable<IEnumerable<string>> table = new string [] [] {
			new string[] { "1a", "1b" },
			new string[] { "2a", "2b" }
		};

		List<string> cells = new List<string> ();

		foreach (IEnumerable<string> row in table) {
			foreach (string cell in row)
				cells.Add (cell);
		}

		if (cells.Count != 4)
			return 1;
		if (cells [0] != "1a")
			return 2;
		if (cells [1] != "1b")
			return 2;
		if (cells [2] != "2a")
			return 2;
		if (cells [3] != "2b")
			return 2;
		return 0;
	}
}
