using System;
using System.Collections.Generic;

class Program
{
	static int Main ()
	{
		List<string> ll = new List<string> ();
		ll.Add ("hello");
		ll.Add (",");
		ll.Add (" ");
		ll.Add ("world");
		ll.Add ("!");

		foreach (string s in ll)
			if (s == null)
				return 1;
		return 0;
	}
}
