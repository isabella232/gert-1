using System.Collections.Generic;

class Program
{
	static int Main (string [] args)
	{
		IList<int> str = new int [] { 1, 2, 3, 4, 5, 6 };
		if (str == null)
			return 1;
		if (str.Count != 6)
			return 2;
		return 0;
	}
}
