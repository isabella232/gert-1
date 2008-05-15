using System;
using System.Linq;

class Program
{
	static void Main ()
	{
		IQueryable<int> iq = null;
		iq.Select (i => i);
	}
}
