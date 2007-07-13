using System;
using System.Collections.Generic;

class Program
{
	static int x = 2;

	static int Main (string [] args)
	{
		foreach (bool b in test ()) {
			if (b == true) {
			}
		}
		if (x != 0)
			return 1;
		return 0;
	}

	static IEnumerable<bool> setX ()
	{
		x = 1;
		try {
			yield return true;
		} finally {
			x = 0;
		}
	}

	static IEnumerable<bool> test ()
	{
		foreach (bool b in setX ()) {
			yield return b;
			goto label;
		}
	label:
		yield break;
	}
}
