using System;
using System.Globalization;

delegate object ParseFun (string text, IFormatProvider provider);

class Program
{
	static void Main ()
	{
		ParseFun runner = new ParseFun (ParseA);
		runner ("a", CultureInfo.InvariantCulture);

		runner = new ParseFun (ParseB);
		runner ("b", CultureInfo.InvariantCulture);
	}

	static bool ParseA (string text, IFormatProvider provider)
	{
		return false;
	}

	static void ParseB (string text, IFormatProvider provider)
	{
	}
}
