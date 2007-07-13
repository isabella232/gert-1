using System;
using System.Collections.Generic;

class Program
{
	static int x = 5;

	static int Main (string [] args)
	{
		foreach (bool b in test ()) {
			if (b == true) {
			}
		}
		if (x != 2)
			return 2;
		return 0;
	}

	static IEnumerable<bool> setX ()
	{
		x = 0;
		try {
			yield return true;
		} finally {
			x = 1;
		}
	}

	static IEnumerable<bool> test ()
	{
		foreach (bool b in setX ()) {
			yield return b;
			goto label;
		}
	label:
		x++;
	}
}
