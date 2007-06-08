using System;
using System.Runtime.InteropServices;

class Program
{
	[DllImport ("Dingus")]
	extern static void Do<T> ();

	static void Main ()
	{
		Do<int> ();
	}
}
