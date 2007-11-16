using System;
using System.Collections.Generic;

class Program
{
	static int Main ()
	{
		LinkedList<string> ll = new LinkedList<string> ();
		ll.AddLast ("hello");
		ll.AddLast (",");
		ll.AddLast (" ");
		ll.AddLast ("world");
		ll.AddLast ("!");

		foreach (string s in ll)
			if (s == null)
				return 1;
		return 0;
	}
}
