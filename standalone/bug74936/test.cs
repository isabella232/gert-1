using System;

class Program
{
	static int Main()
	{
		try {
			DateTime.Parse("1");
			Console.WriteLine("#1");
			return 1;
		} catch (FormatException) {
		}

		DateTime now = DateTime.Now;
		DateTime datetime =  DateTime.Parse("8.5");
		if (datetime.Day != 8)
			return 2;
		if (datetime.Hour != 0)
			return 3;
		if (datetime.Millisecond != 0)
			return 4;
		if (datetime.Minute != 0)
			return 5;
		if (datetime.Month != 5)
			return 6;
		if (datetime.Second != 0)
			return 7;
		if (datetime.Year != now.Year)
			return 8;
		return 0;
	}
}
