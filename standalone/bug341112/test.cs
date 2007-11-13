using System;
using System.Collections.Generic;

class Program
{
	static void Main ()
	{
		List<string> in1 = new List<string> ();
		in1.Add ("A");
		List<string> in2 = new List<string> ();
		in2.Add ("B");
		in2.Add (null);
		in2.Add ("C");
		SetRequiredInputTypes (new List<string> [] { in1, in2 });
	}

	static void SetRequiredInputTypes (IEnumerable<IEnumerable<string>> enum_enum_strings)
	{
		foreach (IEnumerable<string> enum_strings in enum_enum_strings) {
			foreach (string s in enum_strings) {
				if (s == "D")
					throw new Exception ();
			}
		}
	}
}
