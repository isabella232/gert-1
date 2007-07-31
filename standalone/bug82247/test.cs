using System;

class Program
{
	static int Main ()
	{
		double [,] [] foo = new double [1, 1] [];
		foo [0, 0] = new double [2];

		double [,] [] bar;

		bar = (double [,] []) foo.Clone ();
		bar = (double [,] []) ReturnArray ();
		bar = ReturnArray ();

		if (bar [0, 0] [0] != 1)
			return 1;
		if (bar [0, 0] [1] != 2)
			return 2;
		return 0;
	}

	static double [,] [] ReturnArray ()
	{
		double [,] [] zoo = new double [1, 1] [];
		zoo [0, 0] = new double [2];
		zoo [0, 0] [0] = 1;
		zoo [0, 0] [1] = 2;
		return zoo;
	}
}
