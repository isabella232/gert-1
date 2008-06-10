using System;
using System.Collections;
using System.Reflection;
using System.Threading;

class Program
{
	static ArrayList ar = new ArrayList ();

	static void Main ()
	{
		for (int i = 0; i < 10; i++)
			ar.Add (new Program ());
		Environment.Exit (0);
	}

	static void LaLa ()
	{
		while (true)
			typeof (Program).GetFields ();
	}

	~Program ()
	{
		new Thread (new ThreadStart (LaLa)).Start ();
	}
}
