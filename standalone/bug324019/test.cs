using System;
using System.Globalization;

class Program
{
	static int Main ()
	{
		CultureInfo culture = new CultureInfo ("nl-BE");
		int y = int.Parse (culture.NumberFormat.CurrencySymbol + "3,00", NumberStyles.Currency, culture);
		if (y != 3)
			return 1;
		int x = int.Parse (3.ToString ("c", culture), NumberStyles.Currency, culture);
		if (x != 3)
			return 2;
		return 0;
	}
}
