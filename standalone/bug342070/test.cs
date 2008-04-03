using System;
using System.Globalization;
using System.Net;

class Program
{
	static int Main ()
	{
		MyTestService svc = new MyTestService ();
		DateTime date = svc.SayHello ("Mono");
		if (date != DateTime.MinValue) {
			Console.WriteLine (date.ToLongDateString ());
			return 1;
		}

		return 0;
	}
}
