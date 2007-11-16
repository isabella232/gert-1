using System;
using System.Globalization;
using System.Net;

class Program
{
	static int Main ()
	{
		MyTestService svc = new MyTestService ();
		if (svc.SayHello ("Mono") != DateTime.MinValue)
			return 1;

		return 0;
	}
}
