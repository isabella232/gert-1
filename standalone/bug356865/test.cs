using System;
using Testy;

class Program
{
	static int Main ()
	{
		Object o = new Object ();
		if (o.MyFormat ("hello:{0}:{1}:", "there", "yak") != "hello:there:yak:")
			return 1;
		return 0;
	}
}
