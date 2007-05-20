using System;
using System.Text.RegularExpressions;

class Program
{
	static int Main ()
	{
		string result = Regex.Replace (@"a", "a", @"\\");
		if (result == @"\\") {
			return 0;
		}
		return 1;
	}
}
