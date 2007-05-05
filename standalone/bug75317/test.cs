using System;

class Program
{
	static int Main ()
	{
		DateTime currentDate = DateTime.Now;

		if (currentDate.Year > 2000) {
			goto check_year;
		}

		return 1;

	check_year:
		return 0;
	}
}
